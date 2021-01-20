﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Service
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey key;
        private readonly UserManager<AppUser> userManager;
        public TokenService(IConfiguration config, UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
            this.key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(config["TokenKey"])
            );
        }

        public async Task<string> CreateToken(AppUser user)
        {
            var claims = new List<Claim> {
                new Claim (JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new Claim (JwtRegisteredClaimNames.UniqueName, user.UserName),
        };
            
            var creds = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha512Signature
            );

            var tokenDescriptor = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(28),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);


        }
    
    }
}
