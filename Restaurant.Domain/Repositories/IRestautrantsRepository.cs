using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories;

public interface IRestautrantsRepository
{
    Task<IEnumerable<Restaurant>> GetAllAsync();
}
