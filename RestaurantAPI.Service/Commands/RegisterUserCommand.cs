using MediatR;
using RestaurantAPI.Domain.Models;

namespace RestaurantAPI.Service.Commands;


public class RegisterUserCommand : IRequest<User>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}