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

        public Task AddAsync(UserDTO dto)
        {
            var result = UserManager.CreateAsync(mapper.Map<User>(dto), dto.Password).Result;
            if (result.Succeeded)
            {
                Database.UserRepository.Add(mapper.Map<User>(dto));
                Database.SaveAsync();
                var user = Database.UserRepository.GetAll().LastOrDefault();
                return SignInManager.SignInAsync(user, false);
            }
            else
                throw new PhotoAlbumException("Adding of the new user was failed!");
        }

        public Task DeleteByIdAsync(int id)
        {
            var user = GetByIdAsync(id).Result;

            if (user is null)
                throw new PhotoAlbumException($"The user with {nameof(id)} wasn't found!", nameof(id));

            user.isDeleted = true;

            return UpdateAsync(user);
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return mapper.Map<IEnumerable<UserDTO>>(Database.UserRepository.GetAll());
        }

        public Task<UserDTO> GetByIdAsync(int id)
        {
            if (id >= 1)
                return Task.Run(() => mapper.Map<UserDTO>(Database.UserRepository.GetByIdAsync(id).Result));
            else
                throw new PhotoAlbumException($"{nameof(id)} cannot be less than or equal to 0!", nameof(id));
        }

        public bool isExist(UserDTO dto)
        {
            return SignInManager.PasswordSignInAsync(dto.UserName, dto.Password, false, false).Result.Succeeded;
        }

        public Task UpdateAsync(UserDTO dto)
        {
            Database.UserRepository.Update(mapper.Map<User>(dto));
            return Database.SaveAsync();
        }
    }
}
