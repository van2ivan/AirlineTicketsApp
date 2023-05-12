using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Core.Entities.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var user = new AppUser
                {
                DisplayName = "Ivan",
                Email = "ivan@gmail.com",
                UserName = "ivan@gmail.com",
                Details = new Details
                    {   
                    FirstName = "Ivan",
                    LastName = "Ius",
                    Passport = "KB163843",
                    Citizenship = "Ukraine"                  
                    }
                };
            await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}