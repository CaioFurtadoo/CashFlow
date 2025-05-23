﻿using CashFlow.Domain.Entities;
using CashFlow.Domain.Security.Tokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CashFlow.Infrastructure.Security.Tokens
{
    internal class JwtTokenGenerator : IAcessTokenGenerator
    {
        private readonly uint _expirationTimeInMinutes;
        private readonly string _singingKey;

        public JwtTokenGenerator(uint expirationTimeInMinutes, string singingKey)
        {
            _expirationTimeInMinutes = expirationTimeInMinutes;
            _singingKey = singingKey;
        }
        public string Generate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Sid, user.UserIdentifier.ToString()),

            };

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Expires = DateTime.UtcNow.AddMinutes(_expirationTimeInMinutes),
                SigningCredentials = new SigningCredentials(GetSymmetricSecurityKey(),SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(claims),
            };
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(securityToken);
        }

        private SecurityKey GetSymmetricSecurityKey()
        {
            var key = Encoding.UTF8.GetBytes(_singingKey);
            return new SymmetricSecurityKey(key);
        }
    }
}
