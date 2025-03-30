using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSpot.Domain.Models.Addresses
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        [ForeignKey("State")]
        public int StateId { get; set; }
        public State State { get; set; }
    }
}
