using Microsoft.AspNetCore.Identity;
using PhotoAlbum.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAlbum.BLL.Interfaces
{
    public interface IUserToRegisterService
    {
        IdentityResult RegisterUser(UserToRegisterDTO userToRegisterDTO);
    }
}
