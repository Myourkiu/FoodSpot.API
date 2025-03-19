using FoodSpot.Domain.Models.Users;
using FoodSpot.Infrastructure.Repositories.Interfaces.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSpot.Infrastructure.Repositories.Implementation.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(User user)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _context.Users.AddAsync(user);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();
                    return user;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    User? user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

                    return user;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task<User?> GetUserById(Guid id)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    User? user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

                    return user;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task<bool> VerifyUserExists(string email)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    bool verify = await _context.Users.AnyAsync(u => u.Email == email);

                    return verify;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        #region Auxiliaries

        #endregion
    }
}
