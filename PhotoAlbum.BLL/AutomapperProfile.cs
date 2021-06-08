using AutoMapper;
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
            CreateMap<Photo, PhotoDTO>()
                .ForMember(pdto => pdto.UserName, p => p.MapFrom(photo => photo.User.UserName))
                .ReverseMap();
            CreateMap<User, UserToRegisterDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
