using RestaurantAPI.Domain.Models;

namespace RestaurantAPI.Service.Repositories.Interfaces;


public interface IAuthToken
{
    string GenerateToken(User user);
}