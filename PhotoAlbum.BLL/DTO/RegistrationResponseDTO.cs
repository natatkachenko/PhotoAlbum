using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAlbum.BLL.DTO
{
    /// <summary>
    /// Contains properties for storing response of the user registration action.
    /// </summary>
    public class RegistrationResponseDTO
    {
        public bool isSuccessful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
