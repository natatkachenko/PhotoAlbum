using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PhotoAlbum.BLL;
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
    /// <summary>
    /// Provides WebAPI with dependencies of the PhotoContext, repositories, services of the DAL and BLL, Automapper,
    /// ASP.Net Core Identity and JWT.
    /// </summary>
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

            services.AddScoped<IPhotoRepository, PhotoRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddTransient<IPhotoService, PhotoService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IJWTService, JWTService>();

            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<PhotoContext>();

            var jwtSettings = conf.GetSection("JwtSettings");
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
                    ValidAudience = jwtSettings.GetSection("validAudience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.GetSection("securityKey").Value))
                };
            });
        }
    }
}
