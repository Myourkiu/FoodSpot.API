using FoodSpot.Domain.Models.Restaurants;
using FoodSpot.DTOs.Request.Addresses;
using FoodSpot.DTOs.Request.Restaurants;
using FoodSpot.DTOs.Response.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSpot.Services.Interfaces.Restaurants
{
    public interface IRestaurantService
    {
        Task<CreateRestaurantResponse> Create(CreateRestaurantRequest request);
        Task<RestaurantResponse> GetById(Guid id);
    }
}
