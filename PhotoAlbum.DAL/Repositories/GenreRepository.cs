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
    public class GenreRepository : IRepository<Genre>
    {
        readonly PhotoContext db;

        public GenreRepository(PhotoContext context)
        {
            db = context;
        }

        public Task AddAsync(Genre entity)
        {
            return Task.Run(() => db.Genres.Add(entity));
        }

        public void DeleteById(int id)
        {
            var genre = db.Genres.Find(id);
            if (genre != null)
                db.Genres.Remove(genre);
        }

        public IQueryable<Genre> GetAll()
        {
            return db.Genres;
        }

        public Task<Genre> GetByIdAsync(int id)
        {
            return Task.Run(() => db.Genres.Find(id));
        }

        public void Update(Genre entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }
    }
}
