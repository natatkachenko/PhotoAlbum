using PhotoAlbum.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.DAL.Interfaces
{
    /// <summary>
    /// Contains methods specific for the User entity.
    /// </summary>
    public interface IUserRepository
    {
        IQueryable<User> GetAll();
        Task<User> GetByIdAsync(string id);
        void Update(User entity);
        void DeleteById(string id);
        User GetUserByUserName(string userName);
    }
}
