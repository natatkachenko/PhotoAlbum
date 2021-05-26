using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhotoAlbum.BLL;
using PhotoAlbum.BLL.DTO;
using PhotoAlbum.BLL.Interfaces;
using PhotoAlbum.BLL.Services;
using PhotoAlbum.DAL.EFContext;
using PhotoAlbum.DAL.Entities;
using PhotoAlbum.DAL.Interfaces;
using PhotoAlbum.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAlbum.IoC
{
    public class DependencyInjection
    {
        readonly IConfiguration conf;

        public DependencyInjection(IConfiguration configuration)
        {
            conf = configuration;
        }

        public void AddDependencies(IServiceCollection services, string rootPath)
        {
            string con = conf.GetConnectionString("Photo");
            if (con.Contains("%CONTENTROOTPATH%"))
            {
                con = con.Replace("%CONTENTROOTPATH%", rootPath);
            }

            services.AddDbContext<PhotoContext>(options => options.UseSqlServer(con));

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            var mappingConfig = new MapperConfiguration(mapConfig =>
            {
                mapConfig.AddProfile(new AutomapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient<IRepository<Photo>, PhotoRepository>();
            services.AddTransient<IRepository<Genre>, GenreRepository>();
            services.AddTransient<IService<PhotoDTO>, PhotoService>();
            services.AddTransient<IService<GenreDTO>, GenreService>();
        }
    }
}
