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
        private UserRepository userRepository;

        public UnitOfWork(PhotoContext context)
        {
            db = context;
        }

        public IPhotoRepository PhotoRepository => photoRepository = photoRepository ?? new PhotoRepository(db);

        public IRepository<User> UserRepository => userRepository = userRepository ?? new UserRepository(db);

        public Task<int> SaveAsync()
        {
            return db.SaveChangesAsync();
        }
    }
}
