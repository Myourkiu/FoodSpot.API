using FoodSpot.Domain.Models.Users;
using FoodSpot.DTOs.Response.Users;
using FoodSpot.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FoodSpot.Services.Implementation
{
    public class TokenService : ITokenService
    {
        public async Task<string> GenerateToken(UserLoginResponse userResponse, IConfiguration configuration)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"] ?? throw new InvalidOperationException("Jwt:Key is not configured."));
            var issuer = configuration["Jwt:Issuer"] ?? throw new InvalidOperationException("Jwt:Issuer is not configured");
            var audience = configuration["Jwt:Audience"] ?? throw new InvalidOperationException("Jwt:Audience is not configured");

            var userData = JsonConvert.SerializeObject(new
            {
                Id = userResponse.Id,
                Email = userResponse.Email,
                Name = userResponse.Name,

            });

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userResponse.Id.ToString()),
                    new Claim(ClaimTypes.Email, userResponse.Email),
                    new Claim(ClaimTypes.UserData, userData)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                Issuer = issuer,
                Audience = audience,

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return await Task.FromResult(tokenHandler.WriteToken(token));

        }

        public async Task<User> GetTokenUserData(HttpContext context)
        {
            var userData = context.User.FindFirst(ClaimTypes.UserData);
            return await Task.FromResult((userData is not null ? JsonConvert.DeserializeObject<User>(userData.Value)! : null));
        }
    }
}
