using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoAlbum.DAL.Entities
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int Rate { get; set; }
        public string UserId { get; set; }
        [Required]
        public byte[] Data { get; set; }
        public bool isDeleted { get; set; } = false;

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
