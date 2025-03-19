using FoodSpot.Infrastructure.Repositories.Implementation.Users;
using FoodSpot.Infrastructure.Repositories.Interfaces.Users;

namespace FoodSpot.API.Configurations
{
    public static class RepositoryConfig
    {
        public static IServiceCollection AddRepositoryConfig(this IServiceCollection repositories)
        {
            repositories.AddScoped<IUserRepository, UserRepository>();

            return repositories;
        }
    }
}
