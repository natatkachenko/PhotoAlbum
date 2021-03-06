using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
        readonly IAuthenticationService authenticationService;
        readonly IJWTService JWT;

        public AccountsController(IAuthenticationService service, IJWTService JWTService)
        {
            authenticationService = service;
            JWT = JWTService;
        }

        [HttpPost("Registration")]
        public ActionResult RegisterUser([FromBody] UserToRegisterDTO userToRegisterDTO)
        {
            if (userToRegisterDTO == null || !ModelState.IsValid)
                return BadRequest();

            var result = authenticationService.RegisterUser(userToRegisterDTO);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                return BadRequest(new RegistrationResponseDTO { Errors = errors });
            }

            return StatusCode(201);
        }

        [HttpPost("Login")]
        public ActionResult Login([FromBody] UserToLoginDTO userToLoginDTO)
        {
            var user = authenticationService.FindUser(userToLoginDTO);

            if (user is null || !authenticationService.CheckPassword(user, userToLoginDTO.Password))
                return Unauthorized(new LoginResponseDTO { ErrorMessage = "Invalid Authentication" });

            var signingCredentials = JWT.GetSigningCredentials();
            var claims = JWT.GetClaims(user);
            var tokenOptions = JWT.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return Ok(new LoginResponseDTO { IsAuthSuccessful = true, Token = token });
        }
    }
}
