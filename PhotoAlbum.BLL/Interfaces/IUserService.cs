using PhotoAlbum.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAlbum.BLL.Interfaces
{
    public interface IUserService : IService<UserDTO>
    {
        bool isExist(UserDTO dto);
    }
}
