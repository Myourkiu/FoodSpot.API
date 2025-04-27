using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodSpot.Domain.Models.Restaurants;
using FoodSpot.DTOs.Request.MenuItems;
using FoodSpot.DTOs.Response.MenuItems;

namespace FoodSpot.Services.Interfaces.MenuItems
{
    public interface IMenuItemService
    {
        Task<MenuItemResponse> Create(CreateMenuItemRequest request);
    }
}
