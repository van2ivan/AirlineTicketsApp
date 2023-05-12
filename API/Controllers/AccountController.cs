using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.DTOs;
using API.Errors;
using API.Extensions;
using AutoMapper;
using Core.Entities.Identity;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userMananger;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        public AccountController(UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager, ITokenService tokenService,
        IMapper mapper)
        {
            _mapper = mapper;
            _signInManager = signInManager;
            _userMananger = userManager;
            _tokenService = tokenService;
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDTO>> GetCurrentUser()
        {
            var user = await _userMananger.FindByEmailFromClaimsPrincipleAsync(HttpContext.User);

            return new UserDTO
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                DisplayName = user.DisplayName
            };
        }

        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
        {
            return await _userMananger.FindByEmailAsync(email) != null;
        }

        [Authorize]
        [HttpGet("details")]
        public async Task<ActionResult<DetailsDTO>> GetUserDetails()
        {
            var user = await _userMananger.FindByUserByClaimsPrincipleWithDetailsAsync(HttpContext.User);

            return _mapper.Map<Details, DetailsDTO>(user.Details);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            var user = await _userMananger.FindByEmailAsync(loginDTO.Email);
            if (user == null) return Unauthorized(new ApiResponse(401));

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);
            if (!result.Succeeded) return Unauthorized(new ApiResponse(401));

            return new UserDTO
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                DisplayName = user.DisplayName
            };
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
        {
            if(CheckEmailExistsAsync(registerDTO.Email).Result.Value)
            {
                return new BadRequestObjectResult(new ApiValidationError{Errors = new []
                {"Email address is already used by someone else"}});
            }
            var user = new AppUser
            {
                DisplayName = registerDTO.DisplayName,
                Email = registerDTO.Email,
                UserName = registerDTO.Email
            };

            var result = await _userMananger.CreateAsync(user, registerDTO.Password);
            if (!result.Succeeded) return BadRequest(new ApiResponse(400));

            return new UserDTO
            {
                DisplayName = user.DisplayName,
                Token = _tokenService.CreateToken(user),
                Email = user.Email
            };
        }

        [Authorize]
        [HttpPut("details")]
        public async Task<ActionResult<DetailsDTO>> UpdateUserDetails(DetailsDTO details)
        {
            var user = await _userMananger.FindByEmailFromClaimsPrincipleAsync(HttpContext.User);
            user.Details = _mapper.Map<DetailsDTO, Details>(details);
            var result = await _userMananger.UpdateAsync(user);

            if (result.Succeeded) return Ok(_mapper.Map<Details, DetailsDTO>(user.Details));
            return BadRequest("Error during update of user");
        }


    }
}