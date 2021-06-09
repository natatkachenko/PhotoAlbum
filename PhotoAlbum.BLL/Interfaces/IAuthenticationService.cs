using Microsoft.AspNetCore.Identity;
using PhotoAlbum.BLL.DTO;
using PhotoAlbum.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAlbum.BLL.Interfaces
{
    /// <summary>
    /// Contains methods for providing users authentication and authorization.
    /// </summary>
    public interface IAuthenticationService
    {
        IdentityResult RegisterUser(UserToRegisterDTO userToRegisterDTO);
        User FindUser(UserToLoginDTO userToLoginDTO);
        bool CheckPassword(User entity, string password);
        IdentityRole FindRole(string role);
    }
}
