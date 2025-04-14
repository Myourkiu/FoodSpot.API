using FoodSpot.Domain.Models.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSpot.Infrastructure.Repositories.Interfaces.Addresses
{
    public interface IAddressRepository
    {
        Task<Address> Create(Address address);
        Task<Address> GetById(Guid id);
    }
}
