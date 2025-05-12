using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodSpot.Domain.Models.Restaurants;
using FoodSpot.Infrastructure.Repositories.Interfaces.MenuItems;
using Microsoft.EntityFrameworkCore;

namespace FoodSpot.Infrastructure.Repositories.Implementation.MenuItems
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly ApplicationDbContext _context;
        public MenuItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<MenuItem> Create(MenuItem menuItem)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _context.MenuItems.AddAsync(menuItem);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();
                    return menuItem;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task<ICollection<MenuItem>> GetByRestaurantId(Guid restaurantId)
        {
             using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try 
                {
                    ICollection<MenuItem> items = await _context.MenuItems.Where(r => r.RestaurantId == restaurantId).ToListAsync();
                    await transaction.CommitAsync();

                    return items;
                }
                catch (Exception)
                {
                    transaction.RollbackAsync();
                    throw;
                }
            }
        }
    }
}
