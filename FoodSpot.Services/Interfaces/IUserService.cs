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
        Task<CreateUserResponse> CreateUser(CreateUserRequest request);
        Task<UserLoginResponse> Login(UserLoginRequest request);
        Task<User> GetById(Guid id);
        Task<User> GetByEmail(string email);
        Task<User> EditUser(Guid id, EditUserRequest request);
    }
}
