﻿using AutoMapper;
using PhotoAlbum.BLL.DTO;
using PhotoAlbum.BLL.Interfaces;
using PhotoAlbum.BLL.Validation;
using PhotoAlbum.DAL.Entities;
using PhotoAlbum.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
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
            if (id >= 1)
                return Task.Run(() => mapper.Map<PhotoDTO>(Database.PhotoRepository.GetByIdAsync(id).Result));
            else
                throw new PhotoAlbumException($"{nameof(id)} cannot be less than or equal to 0!", nameof(id));
        }

        public Task AddAsync(PhotoDTO entity)
        {
            ThrowPhotoAlbumException(entity);

            (Database.PhotoRepository as DAL.Repositories.PhotoRepository).Add(mapper.Map<Photo>(entity));
            return Database.SaveAsync();
        }

        public Task UpdateAsync(PhotoDTO entity)
        {
            ThrowPhotoAlbumException(entity);

            Database.PhotoRepository.Update(mapper.Map<Photo>(entity));
            return Database.SaveAsync();
        }

        public Task DeleteByIdAsync(int id)
        {
            var photo = GetByIdAsync(id).Result;

            if(photo is null)
                throw new PhotoAlbumException($"The photo with {nameof(id)} wasn't found!", nameof(id));

            photo.isDeleted = true;

            return UpdateAsync(photo);
        }

        private void ThrowPhotoAlbumException(PhotoDTO dto)
        {
            if (String.IsNullOrEmpty(dto.Title))
                throw new PhotoAlbumException($"{nameof(dto.Title)} cannot be null or empty!", nameof(dto.Title));
            else if(dto.ImagePath is null)
                throw new PhotoAlbumException($"{nameof(dto.ImagePath)} cannot be null!", nameof(dto.ImagePath));
        }
    }
}
