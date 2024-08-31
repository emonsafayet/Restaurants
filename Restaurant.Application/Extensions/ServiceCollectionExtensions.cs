using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Users;

namespace Restaurants.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        var appilcationAssembly = typeof(ServiceCollectionExtensions).Assembly;
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(appilcationAssembly));

        services.AddAutoMapper(appilcationAssembly);

        services.AddValidatorsFromAssembly(appilcationAssembly)
            .AddFluentValidationAutoValidation(); 
    
        services.AddScoped<IUserContext, UserContext>();
        services.AddHttpContextAccessor();
    }
}
