using PhotoAlbum.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAlbum.DAL.Interfaces
{
    public interface IPhotoRepository : IRepository<Photo>
    {
        void SetUserToEntity(Photo entity);
    }
}
