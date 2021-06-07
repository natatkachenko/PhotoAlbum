using PhotoAlbum.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAlbum.BLL.Interfaces
{
    public interface IPhotoService : IService<PhotoDTO>
    {
        IEnumerable<PhotoDTO> GetPhotosByUserName(string userName);
    }
}
