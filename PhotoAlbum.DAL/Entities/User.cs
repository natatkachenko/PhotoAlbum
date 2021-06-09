using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAlbum.DAL.Entities
{
    public class User : IdentityUser
    {
        /// <summary>
        /// Stores the state of the entity instance (deleted or not).
        /// </summary>
        public bool isDeleted { get; set; } = false;

        public ICollection<Photo> Photos { get; set; }
    }
}
