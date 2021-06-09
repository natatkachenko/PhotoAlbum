using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.DAL.Interfaces
{
    /// <summary>
    /// Contains methods for providing CRUD operations.
    /// </summary>
    /// <typeparam name="T">A class of the database entity type</typeparam>
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        void Add(T entity);
        void Update(T entity);
        void DeleteById(int id);
    }
}
