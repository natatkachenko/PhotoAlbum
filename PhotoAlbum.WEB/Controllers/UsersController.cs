using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoAlbum.BLL.DTO;
using PhotoAlbum.BLL.Interfaces;

namespace PhotoAlbum.WEB.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("CreateUser")]
        public ActionResult CreateUser([FromBody] UserToRegisterDTO userToRegisterDTO)
        {
            return RedirectToActionPreserveMethod("RegisterUser", "Accounts", new { userToRegisterDTO });
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDTO>> Delete(string id)
        {
            try
            {
                await _userService.DeleteByIdAsync(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
