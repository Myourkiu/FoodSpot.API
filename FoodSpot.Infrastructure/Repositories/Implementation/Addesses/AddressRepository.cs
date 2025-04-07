using FoodSpot.Domain.Models.Addresses;
using FoodSpot.Domain.Models.Users;
using FoodSpot.Infrastructure.Repositories.Interfaces.Addresses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSpot.Infrastructure.Repositories.Implementation.Addesses
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _context;
        public AddressRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Address> Create(Address address)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _context.Addresses.AddAsync(address);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();
                    return address;
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
