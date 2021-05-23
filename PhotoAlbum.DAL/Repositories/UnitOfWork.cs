using PhotoAlbum.DAL.EFContext;
using PhotoAlbum.DAL.Entities;
using PhotoAlbum.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly PhotoContext db;
        private PhotoRepository photoRepository;
        private GenreRepository genreRepository;

        public UnitOfWork(PhotoContext context)
        {
            db = context;
        }

        public IRepository<Photo> PhotoRepository => photoRepository = photoRepository ?? new PhotoRepository(db);

        public IRepository<Genre> GenreRepository => genreRepository = genreRepository ?? new GenreRepository(db);

        public Task<int> SaveAsync()
        {
            return db.SaveChangesAsync();
        }
    }
}
