using PhotoAlbum.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAlbum.BLL.Interfaces
{
    public interface IUserService : IService<RegisterUserDTO>
    {
        bool isExist(RegisterUserDTO dto);
    }
}
