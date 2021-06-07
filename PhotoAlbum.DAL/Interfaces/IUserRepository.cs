using PhotoAlbum.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAlbum.DAL.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByUserName(string userName);
    }
}
