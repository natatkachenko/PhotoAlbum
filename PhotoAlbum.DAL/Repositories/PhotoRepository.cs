using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PhotoAlbum.DAL.EFContext;
using PhotoAlbum.DAL.Entities;
using PhotoAlbum.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.DAL.Repositories
{
    public class PhotoRepository : IPhotoRepository
    {
        readonly PhotoContext db;

        public PhotoRepository(PhotoContext context)
        {
            db = context;
        }

        public void Add(Photo entity)
        {
            var user = db.Users.FirstOrDefault(u => u.UserName == entity.User.UserName);
            entity.User = user;
            db.Photos.Add(entity);
        }

        public void DeleteById(int id)
        {
            var photo = db.Photos.Find(id);
            if (photo != null)
                photo.isDeleted = true;
        }

        public IQueryable<Photo> GetAll()
        {
            return db.Photos.Include(p => p.User);
        }

        public Task<Photo> GetByIdAsync(int id)
        {
            var photo = GetAll().AsNoTracking().ToList().FirstOrDefault(p => p.Id == id);
            return Task.Run(() => photo);
        }

        public void Update(Photo entity)
        {
            SetUserToEntity(entity);

            db.Entry(entity).State = EntityState.Modified;
        }

        public void SetUserToEntity(Photo entity)
        {
            var user = db.Users.FirstOrDefault(u => u.UserName == entity.User.UserName);
            entity.User = user;
        }
    }
}
