using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAlbum.BLL.DTO
{
    public class RegistrationResponseDTO
    {
        public bool isSuccessful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
