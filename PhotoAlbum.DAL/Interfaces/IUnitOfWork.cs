using PhotoAlbum.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Photo> PhotoRepository { get; }
        IRepository<Genre> GenreRepository { get; }

        Task<int> SaveAsync();
    }
}
