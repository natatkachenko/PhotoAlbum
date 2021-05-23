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
    public class PhotoRepository : IRepository<Photo>
    {
        readonly PhotoContext db;

        public PhotoRepository(PhotoContext context)
        {
            db = context;
        }

        public Task AddAsync(Photo entity)
        {
            return Task.Run(() => db.Photos.Add(entity));
        }

        public void DeleteById(int id)
        {
            var photo = db.Photos.Find(id);
            if (photo != null)
                db.Photos.Remove(photo);
        }

        public IQueryable<Photo> GetAll()
        {
            return db.Photos;
        }

        public Task<Photo> GetByIdAsync(int id)
        {
            return Task.Run(() => db.Photos.Find(id));
        }

        public void Update(Photo entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }
    }
}
