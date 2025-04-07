using FoodSpot.Domain.Models.Addresses;
using FoodSpot.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSpot.DTOs.Response.Addresses
{
    public class AddressResponse
    {
        [Required]
        public string CEP { get; set; }
        [Required]
        public string Street { get; set; }
        public string? Complement { get; set; }
        [Required]
        public string Neighborhood { get; set; }
        [Required]
        public int Number { get; set; }
        public City City { get; set; }
        public Guid UserId { get; set; }
    }
}
