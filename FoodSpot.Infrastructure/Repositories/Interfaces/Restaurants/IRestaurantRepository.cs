using FoodSpot.Domain.Models.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSpot.Infrastructure.Repositories.Interfaces.Restaurants
{
    public interface IRestaurantRepository
    {
        Task<Restaurant> Create(Restaurant restaurant);
    }
}
