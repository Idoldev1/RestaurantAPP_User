using MediatR;
using RestaurantAPI.Domain.Models;

namespace RestaurantAPI.Service.Queries;


public class ViewOrderItemsQuery : IRequest<IEnumerable<Order>>
{
    public int UserId { get; set; }
}