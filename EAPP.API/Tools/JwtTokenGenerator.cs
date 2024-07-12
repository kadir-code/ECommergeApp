using EAPP.API.Models.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EAPP.API.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenDTO GenerateToken(CheckUserDTO dto)
        {

            var claims = new List<Claim>();
            if (!string.IsNullOrEmpty(dto.Role))
                claims.Add(new Claim(ClaimTypes.Role,dto.Role));

            claims.Add(new Claim(ClaimTypes.NameIdentifier, dto.Id.ToString()));

            if (!string.IsNullOrEmpty(dto.FirstName))
                claims.Add(new Claim("FirstName", dto.FirstName));

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var expireDate = DateTime.UtcNow.AddMinutes(JwtTokenDefaults.Expire);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: JwtTokenDefaults.ValidIssuer,
                audience: JwtTokenDefaults.ValidAudience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expireDate,
                signingCredentials: credentials
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return new TokenDTO(handler.WriteToken(jwtSecurityToken), expireDate);

        }
    }
}
