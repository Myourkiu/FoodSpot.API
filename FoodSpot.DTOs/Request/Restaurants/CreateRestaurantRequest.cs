using FoodSpot.Domain.Models.Addresses;
using FoodSpot.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodSpot.DTOs.Request.Users;
using FoodSpot.DTOs.Request.Addresses;

namespace FoodSpot.DTOs.Request.Restaurants
{
    public class CreateRestaurantRequest
    {
        public string Cnpj { get; set; }
        public CreateUserOnObjectRequest UserRequest { get; set; }
        public CreateAddressRequest AddressRequest { get; set; }
    }
}
