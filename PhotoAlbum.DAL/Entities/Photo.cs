using System;

namespace PhotoAlbum.DAL.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int Rate { get; set; }
        public int GenreId { get; set; }
        public byte[] Data { get; set; }
    }
}
