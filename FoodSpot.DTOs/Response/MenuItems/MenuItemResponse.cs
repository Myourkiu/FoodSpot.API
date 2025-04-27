using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodSpot.Domain;

namespace FoodSpot.DTOs.Response.MenuItems
{
    public class MenuItemResponse : EntityBase
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool isAvailable { get; set; }
        public Guid RestaurantId { get; set; }
    }
}
