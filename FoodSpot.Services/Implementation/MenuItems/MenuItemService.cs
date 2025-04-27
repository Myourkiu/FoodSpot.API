using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FoodSpot.Domain.Models.Restaurants;
using FoodSpot.DTOs.Request.MenuItems;
using FoodSpot.DTOs.Response.MenuItems;
using FoodSpot.Infrastructure.Repositories.Interfaces.MenuItems;
using FoodSpot.Infrastructure.Repositories.Interfaces.Restaurants;
using FoodSpot.Services.Interfaces.MenuItems;

namespace FoodSpot.Services.Implementation.MenuItems
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;
        public MenuItemService(IMenuItemRepository menuItemRepository, IRestaurantRepository restaurantRepository, IMapper mapper)
        {
            _menuItemRepository = menuItemRepository;
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
        }
        public async Task<MenuItemResponse> Create(CreateMenuItemRequest request)
        {
            Restaurant restaurant = await _restaurantRepository.GetById(request.RestaurantId) ?? throw new Exception("Restaurant not found");

            MenuItem menuItem = _mapper.Map<MenuItem>(request);

            menuItem = await _menuItemRepository.Create(menuItem);

            return _mapper.Map<MenuItemResponse>(menuItem);
        }
    }
}
