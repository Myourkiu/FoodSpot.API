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
    public class StateRepository : IStateRepository
    {
        private readonly ApplicationDbContext _context;
        public StateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task BulkInsertStates(IEnumerable<State> states)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _context.States.ExecuteDeleteAsync();
                    await _context.Cities.ExecuteDeleteAsync();

                    await _context.States.AddRangeAsync(states);
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


        public async Task<IEnumerable<State>> Select()
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    IEnumerable<State> states = await _context.States.ToListAsync();
                    return states;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task<State> SelectById(long id)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    State? state = await _context.States.FirstOrDefaultAsync(s => s.Id == id);
                    return state;
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
