using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSpot.DTOs.Response.Addresses.Cities
{
    public class CityResponse
    {
        public int Id { get; init; }
        public int StateId { get; init; }
        public string Name { get; init; }
    }
}
