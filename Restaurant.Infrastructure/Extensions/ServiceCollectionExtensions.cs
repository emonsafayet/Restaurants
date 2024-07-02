using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistance;
using Restaurants.Infrastructure.Repositories;
using Restaurants.Infrastructure.Seeders;

namespace Restaurants.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration  configuration)
    {
        var connectionString = configuration.GetConnectionString("RestaurantDB");
        services.AddDbContext<RestaurantsDbContext>(option=>option.UseSqlServer(connectionString));
        services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
        
        services.AddScoped<IRestaurantsRepository, RestaurantsRepository>();
    }
}
