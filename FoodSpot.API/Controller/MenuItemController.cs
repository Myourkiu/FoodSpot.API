using FoodSpot.Domain.Models.Restaurants;
using FoodSpot.DTOs.Request.MenuItems;
using FoodSpot.DTOs.Response.MenuItems;
using FoodSpot.Services.Interfaces.MenuItems;
using Microsoft.AspNetCore.Mvc;

namespace FoodSpot.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly IMenuItemService _menuItemService;
        public MenuItemController(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }
        [HttpPost]
        public async Task<MenuItemResponse> Create(CreateMenuItemRequest request)
        {
            return await _menuItemService.Create(request);
        }
    }
}
