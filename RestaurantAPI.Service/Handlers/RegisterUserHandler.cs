using MediatR;
using Microsoft.AspNetCore.Identity;
using RestaurantAPI.Domain.Models;
using RestaurantAPI.Service.Commands;
using RestaurantAPI.Service.Repositories.Interfaces;

namespace RestaurantAPI.Service.Handlers;


public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, User>
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    //private readonly IAuthToken _authToken;

    public RegisterUserHandler(UserManager<User> userManager, IAuthToken authToken, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        //_authToken = authToken;
    }
    public async Task<User> Handle(RegisterUserCommand register, CancellationToken cancellationToken)
    {
        var user = new User { UserName = register.Email, Email = register.Email };

        var result = await _userManager.CreateAsync(user, register.Password);

        if (result.Succeeded)
        {
            //You might generate a new token here or otherwise comment it out
            //var authToken = _authToken.GenerateToken(user);

            await _signInManager.SignInAsync(user, isPersistent: false);

            return user;
        }
        else
        {
            throw new ArgumentException("Registration failed, please try again");
        }
    }
}
