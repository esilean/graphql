using GraphQLChocolate.API.Infra.Interfaces;
using GraphQLChocolate.API.Models;
using GraphQLChocolate.API.Settings;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GraphQLChocolate.API.Infra
{
    public class GenerateToken : IGenerateToken
    {
        private readonly AppSettingsToken _appSettingsToken;
        public GenerateToken(AppSettings appSettings)
        {
            _appSettingsToken = appSettings.TokenSettings;
        }

        public string Generate(User user)
        {
            var claims = new Claim[]
             {
                 new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                 new Claim(ClaimTypes.Role, "user")
             };

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettingsToken.Key));
            var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Audience = _appSettingsToken.Audience,
                Issuer = _appSettingsToken.Audience,
                Expires = DateTime.UtcNow.AddMinutes(120),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
