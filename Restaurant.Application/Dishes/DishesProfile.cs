using AutoMapper;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Entities;
namespace Restaurants.Application.Dishes;

public class DishesProfile :Profile
{
    public DishesProfile()
    {
            CreateMap<Dish, DishDto>();
    }
}
