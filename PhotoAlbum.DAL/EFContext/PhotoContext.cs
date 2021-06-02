using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhotoAlbum.DAL.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PhotoAlbum.DAL.EFContext
{
    public class PhotoContext : IdentityDbContext<User>
    {
        public PhotoContext(DbContextOptions<PhotoContext> options) : base(options) { }

        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 1,
                FileName = "Forest.jpg",
                Description = "Forest",
                Date = new DateTime(2020, 05, 10),
                Rate = 0,
                Data = File.ReadAllBytes("App_Data/Forest.jpg")
            });
        }
    }
}
