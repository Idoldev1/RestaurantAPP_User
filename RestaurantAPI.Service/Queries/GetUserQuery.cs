using MediatR;
using RestaurantAPI.Domain.Models;

namespace RestaurantAPI.Service.Queries;


public class GetUserQuery : IRequest<User>
{
    public string Email { get; set; }
    public string Password { get; set; }
}