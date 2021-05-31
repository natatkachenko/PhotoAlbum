using Microsoft.AspNetCore.Identity;
using PhotoAlbum.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.DAL.EFContext
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string userName = "admin";
            string password = "1234";

            if (await roleManager.FindByNameAsync("Administrator") is null)
            {
                await roleManager.CreateAsync(new IdentityRole("Administrator"));
                
            }
            if(await roleManager.FindByNameAsync("RegisteredUser") is null)
            {
                await roleManager.CreateAsync(new IdentityRole("RegisteredUser"));
            }
            if(await userManager.FindByNameAsync(userName) is null)
            {
                User admin = new User { UserName = userName, DateOfBirth = new DateTime(1992, 05, 10) };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(admin, "Administrator");
            }
        }
    }
}
