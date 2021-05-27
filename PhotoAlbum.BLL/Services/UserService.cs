using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PhotoAlbum.BLL.DTO;
using PhotoAlbum.BLL.Interfaces;
using PhotoAlbum.DAL.Entities;
using PhotoAlbum.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }
        readonly IMapper mapper;
        UserManager<User> UserManager { get; set; }
        SignInManager<User> SignInManager { get; set; }

        public UserService(IUnitOfWork unitOfWork, IMapper map, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            Database = unitOfWork;
            mapper = map;
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public Task AddAsync(UserDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExist(UserDTO dto)
        {
            return SignInManager.PasswordSignInAsync(dto.UserName, dto.Password, false, false).Result.Succeeded;
        }

        public Task UpdateAsync(UserDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
