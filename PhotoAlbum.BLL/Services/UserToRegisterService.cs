using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PhotoAlbum.BLL.DTO;
using PhotoAlbum.BLL.Interfaces;
using PhotoAlbum.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAlbum.BLL.Services
{
    public class UserToRegisterService : IUserToRegisterService
    {
        readonly UserManager<User> _userManager;
        readonly IMapper mapper;

        public UserToRegisterService(UserManager<User> userManager, IMapper map)
        {
            _userManager = userManager;
            mapper = map;
        }

        public IdentityResult RegisterUser(UserToRegisterDTO userToRegisterDTO)
        {
            var user = mapper.Map<User>(userToRegisterDTO);
            var result = _userManager.CreateAsync(user, userToRegisterDTO.Password).Result;
            return result;
        }
    }
}
