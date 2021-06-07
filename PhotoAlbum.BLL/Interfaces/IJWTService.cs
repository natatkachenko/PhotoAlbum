using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PhotoAlbum.BLL.Interfaces
{
    public interface IJWTService
    {
        SigningCredentials GetSigningCredentials();
        List<Claim> GetClaims(IdentityUser user);
        JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims);
    }
}
