using Microsoft.AspNetCore.Identity;
using PhotoAlbum.BLL.DTO;
using PhotoAlbum.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAlbum.BLL.Interfaces
{
    public interface IAuthenticationService
    {
        IdentityResult RegisterUser(UserToRegisterDTO userToRegisterDTO);
        User FindUser(UserToLoginDTO userToLoginDTO);
        bool CheckPassword(User entity, string password);
        IdentityRole FindRole(string role);
    }
}
