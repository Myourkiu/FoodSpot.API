using FoodSpot.Domain.Models.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSpot.Infrastructure.Repositories.Interfaces.Addresses
{
    public interface ICityRepository
    {
        Task<City> SelectById(long id);
        Task<IEnumerable<City>> SelectByStateId(int stateId);
        Task BulkInsertCities(IEnumerable<City> cities);
    }
}
