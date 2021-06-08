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
        readonly IAuthenticationService authenticationService;

        public UsersController(IAuthenticationService service)
        {
            authenticationService = service;
        }

        [HttpPost("CreateUser")]
        public ActionResult CreateUser([FromBody] UserToRegisterDTO userToRegisterDTO)
        {
            return RedirectToActionPreserveMethod("RegisterUser", "Accounts", new { userToRegisterDTO });
        }
    }
}
