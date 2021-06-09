using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAlbum.BLL.DTO
{
    /// <summary>
    /// Contains properties for storing response of the user login action.
    /// </summary>
    public class LoginResponseDTO
    {
        public bool IsAuthSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        /// <summary>
        /// Stores JWT token.
        /// </summary>
        public string Token { get; set; }
    }
}
