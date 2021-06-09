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
    /// <inheritdoc/>
    public class UserRepository : IUserRepository
    {
        readonly PhotoContext db;

        public UserRepository(PhotoContext context)
        {
            db = context;
        }

        public void DeleteById(string id)
        {
            var user = db.Users.Find(id);
            if (user != null)
                user.isDeleted = true;
        }

        public IQueryable<User> GetAll()
        {
            return db.Users;
        }

        public Task<User> GetByIdAsync(string id)
        {
            var user = GetAll().AsNoTracking().ToList().FirstOrDefault(u => u.Id == id);
            return Task.Run(() => user);
        }

        public User GetUserByUserName(string userName)
        {
            return db.Users.AsNoTracking().ToList().FirstOrDefault(u => u.UserName == userName);
        }

        public void Update(User entity)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == entity.Id);
            user.isDeleted = entity.isDeleted;
            db.Entry(user).State = EntityState.Modified;
        }
    }
}
