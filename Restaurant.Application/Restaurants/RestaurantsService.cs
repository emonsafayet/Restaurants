using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories; 

namespace Restaurants.Application.Restaurants;
internal class RestaurantsService(
    IRestautrantsRepository restautrantsRepository,
    ILogger<RestaurantsService> logger
    ) :  IRestaurantsService
{
    public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
    {
        logger.LogInformation("Getting all restaurants");
        var restaurants = await restautrantsRepository.GetAllAsync(); ;
        var restaurantDto = restaurants.Select(RestaurantDto.FromEntity);
         
        return restaurantDto!;
    }

    public async Task<RestaurantDto?> GetById(int id)
    {
        logger.LogInformation($"Getting by id:{id}");

        var result = await restautrantsRepository.GetByIdAsync(id);
        var restaurantDto = RestaurantDto.FromEntity(result);
        return restaurantDto;
    }
}
