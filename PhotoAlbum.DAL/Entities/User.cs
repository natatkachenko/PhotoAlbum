using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAlbum.DAL.Entities
{
    public class User : IdentityUser
    {
        public DateTime DateOfBirth { get; set; }
    }
}
