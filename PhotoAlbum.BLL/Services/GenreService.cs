using AutoMapper;
using PhotoAlbum.BLL.DTO;
using PhotoAlbum.BLL.Interfaces;
using PhotoAlbum.BLL.Validation;
using PhotoAlbum.DAL.Entities;
using PhotoAlbum.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.BLL.Services
{
    public class GenreService : IService<GenreDTO>
    {
        IUnitOfWork Database { get; set; }
        readonly IMapper mapper;

        public GenreService(IUnitOfWork unitOfWork, IMapper map)
        {
            Database = unitOfWork;
            mapper = map;
        }

        public Task AddAsync(GenreDTO entity)
        {
            ThrowPhotoAlbumException(entity);

            Database.GenreRepository.AddAsync(mapper.Map<Genre>(entity));
            return Database.SaveAsync();
        }

        public Task DeleteByIdAsync(int id)
        {
            var genre = GetByIdAsync(id).Result;

            if (genre is null)
                throw new PhotoAlbumException($"The genre with {nameof(id)} wasn't found!", nameof(id));

            genre.isDeleted = true;

            return UpdateAsync(genre);
        }

        public IEnumerable<GenreDTO> GetAll()
        {
            return mapper.Map<IEnumerable<GenreDTO>>(Database.GenreRepository.GetAll());
        }

        public Task<GenreDTO> GetByIdAsync(int id)
        {
            if (id >= 1)
                return Task.Run(() => mapper.Map<GenreDTO>(Database.GenreRepository.GetByIdAsync(id).Result));
            else
                throw new PhotoAlbumException($"{nameof(id)} cannot be less than or equal to 0!", nameof(id));
        }

        public Task UpdateAsync(GenreDTO entity)
        {
            ThrowPhotoAlbumException(entity);

            Database.GenreRepository.Update(mapper.Map<Genre>(entity));
            return Database.SaveAsync();
        }

        private void ThrowPhotoAlbumException(GenreDTO dto)
        {
            if (String.IsNullOrEmpty(dto.Name))
                throw new PhotoAlbumException($"{nameof(dto.Name)} cannot be null or empty!", nameof(dto.Name));
        }
    }
}
