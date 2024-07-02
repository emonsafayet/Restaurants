using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories;
using Restaurants.Domain.Entities;

public interface IRestaurantsRepository
{
    Task<IEnumerable<Restaurant>> GetAllAsync();
    Task<Restaurant?> GetByIdAsync(int id);
    Task<int> Create(Restaurant entity);
    Task Delete(Restaurant entity);
    Task SaveChanges();
}
