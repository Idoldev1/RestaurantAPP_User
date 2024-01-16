using RestaurantAPI.Domain.Models;

namespace RestaurantAPI.Service.Repositories.Interfaces;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetOrders(int userId);
}