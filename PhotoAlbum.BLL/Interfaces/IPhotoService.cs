using PhotoAlbum.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAlbum.BLL.Interfaces
{
    /// <summary>
    /// Contains methods specific for the PhotoDTO and inherits methods of the base interface.
    /// </summary>
    public interface IPhotoService : IService<PhotoDTO>
    {
        IEnumerable<PhotoDTO> GetPhotosByUserName(string userName);
    }
}
