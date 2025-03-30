using FoodSpot.Domain.Models.Addresses;
using FoodSpot.Infrastructure.Repositories.Interfaces.Addresses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSpot.Infrastructure.Repositories.Implementation.Addesses
{
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationDbContext _context;
        public CityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task BulkInsertCities(IEnumerable<City> cities)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _context.Cities.ExecuteDeleteAsync();

                    await _context.Cities.AddRangeAsync(cities);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task<City> SelectById(long id)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    City city = await _context.Cities.FirstOrDefaultAsync(c => c.Id == id);
                    return city;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task<IEnumerable<City>> SelectByStateId(int stateId)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    IEnumerable<City> cities = await _context.Cities.Where(c => c.StateId == stateId).ToListAsync();
                    return cities;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }
    }
}
