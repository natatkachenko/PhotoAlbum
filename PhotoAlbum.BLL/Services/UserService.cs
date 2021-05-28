using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PhotoAlbum.BLL.DTO;
using PhotoAlbum.BLL.Interfaces;
using PhotoAlbum.BLL.Validation;
using PhotoAlbum.DAL.Entities;
using PhotoAlbum.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var result = UserManager.CreateAsync(mapper.Map<User>(entity), entity.Password).Result;
            if (result.Succeeded)
            {
                Database.UserRepository.AddAsync(mapper.Map<User>(entity));
                Database.SaveAsync();
                var user = Database.UserRepository.GetAll().LastOrDefault();
                return SignInManager.SignInAsync(user, false);
            }
            else
                throw new PhotoAlbumException("Adding of the new user was failed!");
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
