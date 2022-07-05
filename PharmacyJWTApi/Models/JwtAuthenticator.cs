using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;

namespace PharmacyJWTApi.Models
{
    public class JwtAuthenticator : IJwtAuthenticator
    {
        private readonly string Key;

        public JwtAuthenticator(string Key)
        {
            this.Key = Key;
        }



        public string TokenGenerator(int id, string role, string username, string password)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Role, role),
                    new Claim(ClaimTypes.Name,username),
                    new Claim(ClaimTypes.NameIdentifier,id.ToString())
                }
                ),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
