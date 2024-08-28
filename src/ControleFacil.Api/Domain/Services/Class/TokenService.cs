using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ControleFacil.Api.Damain.Models;
using Microsoft.IdentityModel.Tokens;

namespace ControleFacil.Api.Domain.Services.Class
{
    public class TokenService
    {
        private readonly IConfiguration _configuretion;

        public TokenService(IConfiguration configuration)
        {
            _configuretion = configuration;
        }

        public string Token(Usuario obj)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuretion["KeySecret"] ?? throw new ArgumentNullException("Algo deu errado!"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{

                    new Claim(ClaimTypes.NameIdentifier, obj.ID.ToString()),
                    new Claim(ClaimTypes.Email, obj.Email),
                }),

                Expires = DateTime.UtcNow.AddHours(Convert.ToInt32( _configuretion["HorasValidadeToken"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}