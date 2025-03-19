using FoodSpot.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSpot.Infrastructure.Repositories.Interfaces.Users
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user);
        Task<User?> GetUserByEmail(string email);
        Task<User?> GetUserById (Guid id);
        Task<bool> VerifyUserExists (string email);
    }
}
