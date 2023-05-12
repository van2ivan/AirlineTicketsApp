using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Errors;
using API.Extensions;
using AutoMapper;
using Core.Entities.CompletedBookingAggregate;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class CompletedBookingController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly ICompletedBookingService _completedBookingService;
        public CompletedBookingController(ICompletedBookingService completedBookingService,
        IMapper mapper)
        {
            _completedBookingService = completedBookingService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<CompletedBooking>> CreateCompletedBooking(
            CompletedBookingDTO completedBookingDTO
        )
        {
            var email = HttpContext.User.RetreiveEmailFromPrincipal();
            var details = _mapper.Map<DetailsDTO, Details>(completedBookingDTO.BookingDetails);
            var completedBooking = await _completedBookingService.CreateCompletedBookingAsync(email, completedBookingDTO.LuggageOptionId, completedBookingDTO.BookingId, details);

            if (completedBooking == null) return BadRequest(new ApiResponse(400, "Error creating completed booking"));
            return Ok(completedBooking);
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CompletedBookingDTO>>> GetCompletedBookingsForUser()
        {
            var email = HttpContext.User.RetreiveEmailFromPrincipal();
            var completedBookings = await _completedBookingService.GetCompletedBookingForUserAsync(email);
            return Ok(_mapper.Map<IReadOnlyList<CompletedBooking>, IReadOnlyList<CompletedBookingToReturnDTO>>(completedBookings));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CompletedBookingToReturnDTO>> GetCompletedBookingByIdForUser(int id)
        {
            var email = HttpContext.User.RetreiveEmailFromPrincipal();
            var completedBooking = await _completedBookingService.GetCompletedBookingByIdAsync(id, email);
            if (completedBooking == null) return NotFound(new ApiResponse(404));
            return _mapper.Map<CompletedBooking, CompletedBookingToReturnDTO>(completedBooking);
        }
        [HttpGet("luggageOptions")]
        public async Task<ActionResult<IReadOnlyList<LuggageOption>>> GetLuggageOptions()
        {
            return Ok(await _completedBookingService.GetLuggageOptionsAsync());
        }
    }

}