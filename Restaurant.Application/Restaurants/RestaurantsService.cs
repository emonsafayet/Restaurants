﻿using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories; 

namespace Restaurants.Application.Restaurants;
internal class RestaurantsService(
    IRestautrantsRepository restautrantsRepository,
    ILogger<RestaurantsService> logger
    ) :  IRestaurantsService
{
    public async Task<IEnumerable<Restaurant>> GetAllRestaurants()
    {
        logger.LogInformation("Getting all restaurants");
        var restaurants = await restautrantsRepository.GetAllAsync(); ;
        return restaurants;
    }
}
