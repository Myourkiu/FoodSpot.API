using FoodSpot.Services.Implementation.Addresses;
using FoodSpot.Services.Implementation.Token;
using FoodSpot.Services.Implementation.Users;
using FoodSpot.Services.Interfaces;
using FoodSpot.Services.Interfaces.Addresses;

namespace FoodSpot.API.Configurations
{
    public static class ServicesConfig
    {
        public static IServiceCollection AddServicesConfig(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IStateService, StateService>();
            return services;
        }
    }
}
