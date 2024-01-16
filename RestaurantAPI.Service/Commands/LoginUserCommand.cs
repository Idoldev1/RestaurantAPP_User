using MediatR;

namespace RestaurantAPI.Service.Commands;


public class LoginUserCommand : IRequest<Unit>
{
    public string Email { get; set; }
    public string Password { get; set; }
}