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
        readonly IConfiguration conf;

        public RoleInitializer(IConfiguration configuration)
        {
            conf = configuration;
        }

        public async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var userName = conf["Admin:UserName"];
            var password = conf["Admin:Password"];

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
                User admin = new User { UserName = userName };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(admin, "Administrator");
            }
        }
    }
}
