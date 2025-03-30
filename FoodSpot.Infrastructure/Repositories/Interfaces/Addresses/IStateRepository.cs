using FoodSpot.Domain.Models.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSpot.Infrastructure.Repositories.Interfaces.Addresses
{
    public interface IStateRepository
    {
        Task<State> SelectById(long id);
        Task<IEnumerable<State>> Select();
        Task BulkInsertStates(IEnumerable<State> states);
    }
}
