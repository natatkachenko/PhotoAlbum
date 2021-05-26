﻿using AutoMapper;
using PhotoAlbum.BLL.DTO;
using PhotoAlbum.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAlbum.BLL
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Photo, PhotoDTO>().ReverseMap();
            CreateMap<Genre, GenreDTO>().ReverseMap();
        }
    }
}