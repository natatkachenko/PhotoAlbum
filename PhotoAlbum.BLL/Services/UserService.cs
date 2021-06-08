using AutoMapper;
using Microsoft.AspNetCore.Http;
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

        public Task DeleteByIdAsync(string id)
        {
            var user = GetByIdAsync(id).Result;

            if (user is null)
                throw new PhotoAlbumException($"The user with {nameof(id)} wasn't found!", nameof(id));

            user.isDeleted = true;

            return UpdateAsync(user);
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return mapper.Map<IEnumerable<UserDTO>>(Database.UserRepository.GetAll().ToList()
                .Where(u => u.isDeleted == false));
        }

        public Task<UserDTO> GetByIdAsync(string id)
        {
            if (id != null)
                return Task.Run(() => mapper.Map<UserDTO>(Database.UserRepository.GetByIdAsync(id).Result));
            else
                throw new PhotoAlbumException($"{nameof(id)} cannot be null or empty!", nameof(id));
        }

        //public bool isExist(UserToRegisterDTO dto)
        //{
        //    return SignInManager.PasswordSignInAsync(dto.UserName, dto.Password, false, false).Result.Succeeded;
        //}

        public Task UpdateAsync(UserDTO dto)
        {
            CheckDTOProperties(dto);

            Database.UserRepository.Update(mapper.Map<User>(dto));
            return Database.SaveAsync();
        }

        private void CheckDTOProperties(UserDTO dto)
        {
            if (String.IsNullOrEmpty(dto.Id))
                throw new PhotoAlbumException($"{nameof(dto.Id)} cannot be null or empty!", nameof(dto.Id));
            if (String.IsNullOrEmpty(dto.UserName))
                throw new PhotoAlbumException($"{nameof(dto.UserName)} cannot be null!", nameof(dto.UserName));
        }
    }
}
