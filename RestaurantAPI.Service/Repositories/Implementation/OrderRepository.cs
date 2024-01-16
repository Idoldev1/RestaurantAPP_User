using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Data.Data;
using RestaurantAPI.Domain.Models;
using RestaurantAPI.Service.Repositories.Interfaces;

namespace RestaurantAPI.Service.Repositories.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDb _context;

        public OrderRepository(ApplicationDb context)
        {
            _context = context;
        }



        public async Task<IEnumerable<Order>> GetOrders(int userId)
        {
            return await _context.Orders.Where(item => item.UserId == userId).ToListAsync();
        }
    }
}