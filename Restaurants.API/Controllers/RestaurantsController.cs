using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using System.Threading.Tasks;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/restaurants")]
public class RestaurantsController(IRestaurantsService restautrantsService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var restaurants = await restautrantsService.GetAllRestaurants();
        return Ok(restaurants);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var restaurant = await restautrantsService.GetById(id);
        if (restaurant == null)
            return NotFound();
        return Ok(restaurant);
    }
}
