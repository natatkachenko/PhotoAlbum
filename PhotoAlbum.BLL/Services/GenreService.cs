using PhotoAlbum.BLL.DTO;
using PhotoAlbum.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.BLL.Services
{
    public class GenreService : IService<GenreDTO>
    {
        public Task AddAsync(GenreDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GenreDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<GenreDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(GenreDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
