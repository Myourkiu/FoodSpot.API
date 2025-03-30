using FoodSpot.Domain.Models.Addresses;
using FoodSpot.DTOs.Response.Addresses.States;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSpot.Services.Interfaces.Addresses
{
    public interface IStateService
    {
        Task<StateResponse> SelectById(int id);
        Task<IEnumerable<State>> Select();
        Task ProcessStatesAndCitiesFile(IFormFile file);
    }
}
