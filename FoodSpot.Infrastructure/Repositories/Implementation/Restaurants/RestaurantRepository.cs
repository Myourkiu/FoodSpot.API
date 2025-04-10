using FoodSpot.Domain.Models.Restaurants;
using FoodSpot.Domain.Models.Users;
using FoodSpot.Infrastructure.Repositories.Interfaces.Restaurants;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSpot.Infrastructure.Repositories.Implementation.Restaurants
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly ApplicationDbContext _context;
        public RestaurantRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Restaurant> Create(Restaurant restaurant)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _context.Restaurants.AddAsync(restaurant);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();
                    return restaurant;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task<Restaurant> GetById(Guid id)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    Restaurant? restaurant = await _context.Restaurants.FirstOrDefaultAsync(r => r.Id == id);
                    return restaurant;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
