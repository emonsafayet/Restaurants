using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Restaurants; 

namespace Restaurants.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        var appilcationAssembly = typeof(ServiceCollectionExtensions).Assembly;

        services.AddScoped<IRestaurantsService, RestaurantsService>();
        services.AddAutoMapper(appilcationAssembly);
        services.AddValidatorsFromAssembly(appilcationAssembly)
            .AddFluentValidationAutoValidation(); 
    }
}
