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
        public int StateId { get; set; }
        [ForeignKey("StateId")]
        public State State { get; set; }

        [Required]
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }

        [Required]
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
