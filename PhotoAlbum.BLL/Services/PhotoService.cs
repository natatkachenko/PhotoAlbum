using AutoMapper;
using PhotoAlbum.BLL.DTO;
using PhotoAlbum.BLL.Interfaces;
using PhotoAlbum.DAL.Entities;
using PhotoAlbum.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.BLL.Services
{
    public class PhotoService : IService<PhotoDTO>
    {
        IUnitOfWork Database { get; set; }
        readonly IMapper mapper;

        public PhotoService(IUnitOfWork unitOfWork, IMapper map)
        {
            Database = unitOfWork;
            mapper = map;
        }

        public IEnumerable<PhotoDTO> GetAll()
        {
            return mapper.Map<IEnumerable<PhotoDTO>>(Database.PhotoRepository.GetAll());
        }

        public Task<PhotoDTO> GetByIdAsync(int id)
        {
            return Task.Run(() => mapper.Map<PhotoDTO>(Database.PhotoRepository.GetByIdAsync(id).Result));
        }

        public Task AddAsync(PhotoDTO entity)
        {
            Database.PhotoRepository.AddAsync(mapper.Map<Photo>(entity));
            return Database.SaveAsync();
        }

        public Task UpdateAsync(PhotoDTO entity)
        {
            Database.PhotoRepository.Update(mapper.Map<Photo>(entity));
            return Database.SaveAsync();
        }

        public Task DeleteByIdAsync(int id)
        {
            var photo = GetByIdAsync(id).Result;
            photo.isDeleted = true;

            return UpdateAsync(photo);
        }
    }
}
