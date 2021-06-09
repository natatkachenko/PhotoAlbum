using PhotoAlbum.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAlbum.DAL.Interfaces
{
    /// <summary>
    /// Contains methods specific for the Photo entity and inherits methods of the base interface.
    /// </summary>
    public interface IPhotoRepository : IRepository<Photo>
    {
        void SetUserToEntity(Photo entity);
    }
}
