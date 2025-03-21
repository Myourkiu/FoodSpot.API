using FoodSpot.Domain.Models.Users;
using FoodSpot.DTOs.Request.Users;
using FoodSpot.DTOs.Response.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSpot.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserWithoutPasswordResponse> CreateUser(CreateUserRequest request);
        Task<UserLoginResponse> Login(UserLoginRequest request);
        Task<UserWithoutPasswordResponse> GetById(Guid id);
        Task<UserWithoutPasswordResponse> GetByEmail(string email);
        Task<UserWithoutPasswordResponse> EditUser(Guid id, EditUserRequest request);
    }
}
