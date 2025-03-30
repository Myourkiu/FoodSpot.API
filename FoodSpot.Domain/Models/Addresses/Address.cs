using FoodSpot.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSpot.Domain.Models.Addresses
{
    public class Address : EntityBase
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

        [Required]
        [ForeignKey("State")]
        public int StateId { get; set; }
        public State State { get; set; }

        [Required]
        [ForeignKey("City")]
        public int CityId { get; set; }
        public City City { get; set; }

        [Required]
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
