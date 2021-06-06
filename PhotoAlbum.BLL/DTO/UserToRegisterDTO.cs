using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhotoAlbum.BLL.DTO
{
    public class UserToRegisterDTO
    {
        [Required]
        [Display(Name = "Login")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords don't match!")]
        [Display(Name = "Confirm password")]
        public string PasswordConfirm { get; set; }
        public bool isDeleted { get; set; } = false;
    }
}
