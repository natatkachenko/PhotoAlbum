using PhotoAlbum.BLL.DTO;
using PhotoAlbum.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAlbum.BLL.Interfaces
{
    public interface IUserService : IService<UserToRegisterDTO>
    {
        bool isExist(UserToRegisterDTO dto);
        User GetUserByUserName(string userName);
    }
}
