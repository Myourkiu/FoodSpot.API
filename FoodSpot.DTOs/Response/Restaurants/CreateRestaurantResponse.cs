using FoodSpot.Domain;
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
using FoodSpot.DTOs.Response.Users;
using FoodSpot.DTOs.Response.Addresses;

namespace FoodSpot.DTOs.Response.Restaurants
{
    public class CreateRestaurantResponse : EntityBase
    {
        [Required]
        public string Cnpj { get; set; }
        public UserWithoutPasswordResponse User { get; set; }
        public AddressResponse Address { get; set; }
        public ICollection<MenuItem>? MenuItems { get; set; }
    }
}
