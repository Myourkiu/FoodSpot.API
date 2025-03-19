using FoodSpot.Services.Implementation;
using FoodSpot.Services.Interfaces;

namespace FoodSpot.API.Configurations
{
    public static class ServicesConfig
    {
        public static IServiceCollection AddServicesConfig(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }
    }
}
