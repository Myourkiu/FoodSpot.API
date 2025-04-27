using FoodSpot.Infrastructure.Repositories.Implementation.Addesses;
using FoodSpot.Infrastructure.Repositories.Implementation.MenuItems;
using FoodSpot.Infrastructure.Repositories.Implementation.Restaurants;
using FoodSpot.Infrastructure.Repositories.Implementation.Users;
using FoodSpot.Infrastructure.Repositories.Interfaces.Addresses;
using FoodSpot.Infrastructure.Repositories.Interfaces.MenuItems;
using FoodSpot.Infrastructure.Repositories.Interfaces.Restaurants;
using FoodSpot.Infrastructure.Repositories.Interfaces.Users;

namespace FoodSpot.API.Configurations
{
    public static class RepositoryConfig
    {
        public static IServiceCollection AddRepositoryConfig(this IServiceCollection repositories)
        {
            repositories.AddScoped<IUserRepository, UserRepository>();
            repositories.AddScoped<IStateRepository, StateRepository>();
            repositories.AddScoped<ICityRepository, CityRepository>();
            repositories.AddScoped<IAddressRepository, AddressRepository>();
            repositories.AddScoped<IRestaurantRepository, RestaurantRepository>();
            repositories.AddScoped<IMenuItemRepository, MenuItemRepository>();

            return repositories;
        }
    }
}
