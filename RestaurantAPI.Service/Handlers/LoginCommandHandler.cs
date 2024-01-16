using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using RestaurantAPI.Domain.Models;
using RestaurantAPI.Service.Commands;

namespace RestaurantAPI.Service.Handlers;


public class LoginCommandHandler : IRequestHandler<LoginUserCommand, Unit>
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly HttpContextAccessor _contextAccessor;

    public LoginCommandHandler (UserManager<User> userManager, SignInManager<User> signInManager, HttpContextAccessor contextAccessor)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _contextAccessor = contextAccessor;
    }
    public async Task<Unit> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        //This is a function to check if the email exists or is valid
        var user = await _userManager.FindByEmailAsync(request.Email);

        //If user is not found, throw an error message
        if(user == null)
        {
            throw new Exception("Email not found. Please check the email again or create an account");
        }

        var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);

        if(result.Succeeded)
        {
            var returnUrl = _contextAccessor.HttpContext.Request.Query["returnUrl"].FirstOrDefault();
            _contextAccessor.HttpContext.Response.Redirect(returnUrl ?? "/");

            return Unit.Value;
        }
        else
        {
            throw new Exception("Invalid Password. Please check and try again");
        }

    }

}
