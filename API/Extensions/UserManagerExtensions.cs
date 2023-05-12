using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<AppUser> FindByUserByClaimsPrincipleWithDetailsAsync(this UserManager<AppUser> input,
        ClaimsPrincipal user)
        {
            var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?
            .Value;

            return await input.Users.Include(x => x.Details).SingleOrDefaultAsync(x =>
            x.Email == email);
        }

        public static async Task<AppUser> FindByEmailFromClaimsPrincipleAsync(this UserManager<AppUser> input,
        ClaimsPrincipal user)
        {
            var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?
            .Value;

            return await input.Users.SingleOrDefaultAsync(x =>
            x.Email == email);
        }
    }
}