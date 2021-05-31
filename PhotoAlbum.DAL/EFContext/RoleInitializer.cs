using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using PhotoAlbum.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.DAL.EFContext
{
    public class RoleInitializer
    {
        public static void Initialize(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            var userName = configuration["Admin:UserName"];
            var password = configuration["Admin:Password"];

            if (roleManager.FindByNameAsync("Administrator") is null)
            {
                roleManager.CreateAsync(new IdentityRole("Administrator"));
                
            }
            if(roleManager.FindByNameAsync("RegisteredUser") is null)
            {
                roleManager.CreateAsync(new IdentityRole("RegisteredUser"));
            }
            if(userManager.FindByNameAsync(userName) is null)
            {
                User admin = new User { UserName = userName };
                IdentityResult result = userManager.CreateAsync(admin, password).Result;
                if (result.Succeeded)
                    userManager.AddToRoleAsync(admin, "Administrator");
            }
        }
    }
}
