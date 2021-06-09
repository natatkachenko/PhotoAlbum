using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PhotoAlbum.BLL.DTO;
using PhotoAlbum.BLL.Interfaces;
using PhotoAlbum.BLL.Validation;
using PhotoAlbum.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAlbum.BLL.Services
{
    /// <inheritdoc/>
    public class AuthenticationService : IAuthenticationService
    {
        readonly UserManager<User> _userManager;
        readonly RoleManager<IdentityRole> _roleManager;
        readonly IMapper mapper;

        public AuthenticationService(UserManager<User> userManager, IMapper map, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            mapper = map;
            _roleManager = roleManager;
        }

        public IdentityRole FindRole(string role)
        {
            if (role == "RegisteredUser")
            {
                return _roleManager.FindByNameAsync(role).Result;
            }
            return null;
        }

        public bool CheckPassword(User entity, string password)
        {
            return _userManager.CheckPasswordAsync(entity, password).Result;
        }

        public User FindUser(UserToLoginDTO userToLoginDTO)
        {
            var user = _userManager.FindByNameAsync(userToLoginDTO.UserName).Result;
            if (user is null || user.isDeleted == true)
                return null;

            return user;
        }

        public IdentityResult RegisterUser(UserToRegisterDTO userToRegisterDTO)
        {
            var user = mapper.Map<User>(userToRegisterDTO);
            var result = _userManager.CreateAsync(user, userToRegisterDTO.Password).Result;

            if (result.Succeeded)
            {
                var role = FindRole("RegisteredUser");
                if (role != null)
                    _userManager.AddToRoleAsync(user, role.Name).Wait();
                else
                    throw new PhotoAlbumException($"{nameof(role)} cannot be null or empty!", nameof(role));
            }  

            return result;
        }
    }
}
