using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSpot.Domain.Models.Restaurants
{
    public class MenuItem : EntityBase
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        [Required]
        public Guid RestaurantId { get; set; }


        [ForeignKey("RestaurantId")]
        public Restaurant Restaurant { get; set; }
    }
}
