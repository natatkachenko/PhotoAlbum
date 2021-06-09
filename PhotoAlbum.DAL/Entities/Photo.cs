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
        public string UserId { get; set; }
        /// <summary>
        /// Stores the path to the image.
        /// </summary>
        public string ImagePath { get; set; }
        /// <summary>
        /// Stores the state of the entity instance (deleted or not).
        /// </summary>
        public bool isDeleted { get; set; } = false;

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
