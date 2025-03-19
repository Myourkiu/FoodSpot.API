using FoodSpot.Domain.Models.Users;
using FoodSpot.DTOs.Response.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSpot.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateToken(UserLoginResponse userResponse, IConfiguration configuration);
        Task<User> GetTokenUserData(HttpContext context);
    }
}
