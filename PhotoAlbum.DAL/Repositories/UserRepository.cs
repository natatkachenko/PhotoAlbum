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
    public class UserRepository : IRepository<User>
    {
        readonly PhotoContext db;

        public UserRepository(PhotoContext context)
        {
            db = context;
        }

        public Task AddAsync(User entity)
        {
            return Task.Run(() => db.Users.Add(entity));
        }

        public void DeleteById(int id)
        {
            var user = db.Users.Find(id);
            if (user != null)
                user.isDeleted = true;
        }

        public IQueryable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
