using FoodSpot.Domain.Models.Addresses;
using FoodSpot.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSpot.DTOs.Request.Addresses
{
    public class CreateAddressRequest
    {
        public string CEP { get; set; }
        public string Street { get; set; }
        public string? Complement { get; set; }
        public string Neighborhood { get; set; }
        public int Number { get; set; }

        public long StateId { get; set; }
        public long CityId { get; set; }
    }
}
