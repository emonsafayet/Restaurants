using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories;
using Restaurants.Domain.Entities;

public interface IRestautrantsRepository
{
    Task<IEnumerable<Restaurant>> GetAllAsync();
    Task<Restaurant?> GetByIdAsync(int id);
    Task<int>  Create(Restaurant entity);
}
