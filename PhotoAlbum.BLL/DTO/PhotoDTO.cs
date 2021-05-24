using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAlbum.BLL.DTO
{
    public class PhotoDTO
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int Rate { get; set; }
        public int GenreId { get; set; }
        public byte[] Data { get; set; }
        public bool isDeleted { get; set; }
    }
}
