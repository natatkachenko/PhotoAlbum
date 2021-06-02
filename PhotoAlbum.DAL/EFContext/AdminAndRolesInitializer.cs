using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhotoAlbum.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.DAL.EFContext
{
    public class AdminAndRolesInitializer
    {
        public static async Task InitializeAdminAndRoles(IServiceProvider provider, IConfiguration configuration)
        {
            var userManager = provider.GetRequiredService<UserManager<User>>();
            var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
            var userName = configuration["Admin:UserName"];
            var password = configuration["Admin:Password"];

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
                var result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(admin, "Administrator");
            }
        }
    }
}
