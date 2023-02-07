using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AppAgendaAPI.Models;
using Microsoft.IdentityModel.Tokens;

namespace API.Services;

    public static class TokenService
    {
        public static string GenereteToken(User user, string type)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("AbacateComBanana29/11/2003");
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName.ToString()),
                    new Claim(ClaimTypes.Email, user.UserEmail.ToString()),
                    new Claim(ClaimTypes.Role, type)
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);

        }
    }