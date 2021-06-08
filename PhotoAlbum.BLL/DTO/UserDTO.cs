using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAlbum.BLL.DTO
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public bool isDeleted { get; set; } = false;
    }
}
