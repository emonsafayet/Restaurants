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
        var restaurants =await restautrantsService.GetAllRestaurants();
       return Ok(restaurants);
    }
}
