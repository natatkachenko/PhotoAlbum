using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoAlbum.BLL.DTO;
using PhotoAlbum.BLL.Interfaces;

namespace PhotoAlbum.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        readonly IAuthenticationService authenticatiionService;
        readonly IJWTService JWT;

        public AccountsController(IAuthenticationService service, IJWTService JWTService)
        {
            authenticatiionService = service;
            JWT = JWTService;
        }

        [HttpPost("Registration")]
        public ActionResult RegisterUser([FromBody] UserToRegisterDTO userToRegisterDTO)
        {
            if (userToRegisterDTO == null || !ModelState.IsValid)
                return BadRequest();

            var result = authenticatiionService.RegisterUser(userToRegisterDTO);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                return BadRequest(new RegistrationResponseDTO { Errors = errors });
            }

            return StatusCode(201);
        }
    }
}
