using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhotoAlbum.BLL.DTO
{
    public class PhotoDTO
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int Rate { get; set; }
        public string UserName { get; set; }
        [Required]
        public string ImagePath { get; set; }
        public bool isDeleted { get; set; } = false;
    }
}
