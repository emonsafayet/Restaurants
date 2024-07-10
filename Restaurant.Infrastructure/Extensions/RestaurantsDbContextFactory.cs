using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Restaurants.Infrastructure.Persistance;
using System.IO;

public class RestaurantsDbContextFactory : IDesignTimeDbContextFactory<RestaurantsDbContext>
{
    public RestaurantsDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<RestaurantsDbContext>();
        var connectionString = configuration.GetConnectionString("RestaurantsDb");

        optionsBuilder.UseSqlServer(connectionString);

        return new RestaurantsDbContext(optionsBuilder.Options);
    }
}