using FoodSpot.Domain.Models.Addresses;
using FoodSpot.Domain.Models.Restaurants;
using FoodSpot.DTOs.Response.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSpot.DTOs.Response.Restaurants
{
    public class CreateRestaurantResponse
    {
        public Restaurant Restaurant { get; set; }
        public Address Address { get; set; }
        public UserWithoutPasswordResponse User {  get; set; }
    }
}
