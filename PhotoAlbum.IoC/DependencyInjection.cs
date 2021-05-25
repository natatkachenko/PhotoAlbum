using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhotoAlbum.DAL.EFContext;
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
        }
    }
}
