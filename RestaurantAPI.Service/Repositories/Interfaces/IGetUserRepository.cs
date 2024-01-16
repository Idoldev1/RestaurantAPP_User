using RestaurantAPI.Domain.Models;

namespace RestaurantAPI.Service.Repositories.Interfaces;


public interface IGetUserRepository
{
    Task<User> GetUserAsync(string email, string password);
    Task<User> GetUserByEmailAsync(string email);
}