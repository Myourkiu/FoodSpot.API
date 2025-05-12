using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using FoodSpot.Domain.Models.Addresses;
using FoodSpot.Domain.Models.Users;

namespace FoodSpot.Domain.Models.Customers
{
    public class Customer : EntityBase
    {
        [Required]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        public Guid AddressId { get; set; }

        [ForeignKey("AddressId")]
        public Address Address { get; set; }
        public string Cpf { get; set; }
    }
}