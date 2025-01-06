using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EstoqueOnline.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EstoqueOnline.Application.Services
{
    public class TokenService : ITokenService
    {
        private IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateToken(Usuario user)
        {
            var handler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("SecretToken").Value));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(2),
                Subject = GenerateClaims(user)
            };

            var token = handler.CreateToken(tokenDescriptor);
            var jwt = handler.WriteToken(token);
            return jwt;
        }

        private static ClaimsIdentity GenerateClaims(Usuario user)
        {
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.Name, user.Email));
            claims.AddClaim(new Claim("UserId", user.Id));
            claims.AddClaim(new Claim(ClaimTypes.Role, user.Role));
            return claims;
        }
    }
}
