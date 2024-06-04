using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories; 

namespace Restaurants.Application.Restaurants;
internal class RestaurantsService(
    IRestautrantsRepository restautrantsRepository,
    ILogger<RestaurantsService> logger, IMapper mapper
    ) :  IRestaurantsService
{
    public async Task<int> Create(CreateRestaurantDto dto)
    {
        logger.LogInformation("Getting all restaurants");
        var restaurant = mapper.Map<Restaurant>(dto);
        int id = await restautrantsRepository.Create(restaurant);
        return id;
    }

    public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
    {
        logger.LogInformation("Getting all restaurants");
        IEnumerable<Restaurant> restaurants = await restautrantsRepository.GetAllAsync(); ;
        IEnumerable<RestaurantDto> restaurantDtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
         
        return restaurantDtos!;
    }
     

    public async Task<RestaurantDto?> GetById(int id)
    {
        logger.LogInformation($"Getting by id:{id}");

        Restaurant? restaurant = await restautrantsRepository.GetByIdAsync(id);
        RestaurantDto restaurantDto = mapper.Map<RestaurantDto?>(restaurant);
        return restaurantDto;
    }
}
