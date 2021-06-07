using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoAlbum.DAL.Entities
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int Rate { get; set; }
        public string UserName { get; set; }
        public string ImagePath { get; set; }
        public bool isDeleted { get; set; } = false;

        [ForeignKey("UserName")]
        public User User { get; set; }
    }
}
