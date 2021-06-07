using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhotoAlbum.BLL.DTO
{
    public class UserToRegisterDTO
    {
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords don't match!")]
        public string PasswordConfirm { get; set; }
        public bool isDeleted { get; set; } = false;
    }
}
