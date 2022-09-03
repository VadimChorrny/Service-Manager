using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Data
{
    public class ApplicationDbInitializer
    {
        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByEmailAsync("abc@xyz.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "1213SuperAdminPassword@#2fsSF_").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}
