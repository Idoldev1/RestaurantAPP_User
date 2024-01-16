using MediatR;
using RestaurantAPI.Domain.Models;
using RestaurantAPI.Service.Queries;
using RestaurantAPI.Service.Repositories.Interfaces;

namespace RestaurantAPI.Service.Handlers;


public class ViewOrderItemsHandler : IRequestHandler<ViewOrderItemsQuery, IEnumerable<Order>>
{
    private readonly IOrderRepository _orderRepository;

        public ViewOrderItemsHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
    public Task<IEnumerable<Order>> Handle(ViewOrderItemsQuery request, CancellationToken cancellationToken)
    {
        return _orderRepository.GetOrders(request.UserId);
    }
}