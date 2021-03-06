using PhotoAlbum.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.BLL.Interfaces
{
    /// <summary>
    /// Contains methods specific for the UserDTO.
    /// </summary>
    public interface IUserService
    {
        IEnumerable<UserDTO> GetAll();
        Task<UserDTO> GetByIdAsync(string id);
        Task UpdateAsync(UserDTO dto);
        Task DeleteByIdAsync(string id);
    }
}
