using FoodSpot.Domain.Models.Addresses;
using FoodSpot.Domain.Models.Restaurants;
using FoodSpot.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodSpot.Domain;
using FoodSpot.DTOs.Response.Addresses;
using FoodSpot.DTOs.Response.Users;

namespace FoodSpot.DTOs.Response.Restaurants
{
    public class RestaurantResponse : EntityBase
    {
        public string Cnpj { get; set; }
        public AddressResponse Address { get; set; }
        public UserWithoutPasswordResponse User { get; set; }
        public ICollection<MenuItem>? MenuItems { get; set; }
    }
}
