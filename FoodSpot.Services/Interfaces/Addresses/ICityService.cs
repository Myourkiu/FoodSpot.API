using FoodSpot.Domain.Models.Addresses;
using FoodSpot.DTOs.Response.Addresses.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSpot.Services.Interfaces.Addresses
{
    public interface ICityService
    {
        Task<CityResponse> SelectById(int id);
        Task<IEnumerable<City>> SelectByStateId(int stateId);
    }
}
