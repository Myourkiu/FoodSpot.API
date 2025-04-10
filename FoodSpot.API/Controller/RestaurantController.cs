using FoodSpot.Domain.Models.Restaurants;
using FoodSpot.DTOs.Request.Restaurants;
using FoodSpot.DTOs.Response.Restaurants;
using FoodSpot.Services.Interfaces.Restaurants;
using Microsoft.AspNetCore.Mvc;

namespace FoodSpot.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private IRestaurantService _restaurantService;
        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }
        [HttpPost]
        public async Task<CreateRestaurantResponse> Create(CreateRestaurantRequest request)
        {
            
            return await _restaurantService.Create(request);
        }
        [HttpGet]
        public async Task<RestaurantResponse> GetById(Guid id)
        {
            return await _restaurantService.GetById(id);
        }
    }
}
