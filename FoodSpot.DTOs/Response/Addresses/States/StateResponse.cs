using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSpot.DTOs.Response.Addresses.States
{
    public class StateResponse
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string UF { get; init; }
    }
}
