using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace locadora.API.Services
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<string> GenerateToken(dynamic user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["token:Secret"]);

            List<Claim> listClaims = new List<Claim>();

            listClaims.Add(new Claim(ClaimTypes.Name, user.Id.ToString()));
            listClaims.Add(new Claim(ClaimTypes.Email, user.Email));

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(listClaims);

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _configuration["Token:Emissor"],
                Audience = _configuration["Token:ValidoEm"],
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(Convert.ToInt64(_configuration["Token:ExpiracaoHoras"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            return Task.FromResult(encodedToken);
        }
    }
}
