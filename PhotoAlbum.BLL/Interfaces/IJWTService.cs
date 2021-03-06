using Microsoft.IdentityModel.Tokens;
using PhotoAlbum.DAL.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PhotoAlbum.BLL.Interfaces
{
    /// <summary>
    /// Contains methods for providing the JWT token generation.
    /// </summary>
    public interface IJWTService
    {
        SigningCredentials GetSigningCredentials();
        List<Claim> GetClaims(User user);
        JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims);
    }
}
