using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Infrastructure.Extensions;
using Restaurants.Infrastructure.Seeders;
using Restaurants.Application.Extensions;
using Serilog;
using Microsoft.Extensions.Hosting;
using Restaurants.API.Middlewares;
using Microsoft.AspNetCore.Routing;
using Restaurants.Domain.Entities;
using Restaurants.API.Extensions;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. 
builder.AddPresentation();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantsSeeder>();
 
await seeder.Seed();

// Configure the HTTP request pipeline.
app.UseMiddleware<RequestTimeLoggingMiddleware>();
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseSerilogRequestLogging();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapGroup("api/identity")
    .WithTags("Identity")
   .MapIdentityApi<User>();

app.UseAuthorization();
app.MapControllers();
app.Run();
