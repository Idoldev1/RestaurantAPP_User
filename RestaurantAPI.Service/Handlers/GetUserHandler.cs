using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Http;
using RestaurantAPI.Domain.Models;
using RestaurantAPI.Service.Queries;
using RestaurantAPI.Service.Repositories.Interfaces;

namespace RestaurantAPI.Service;


public class GetAccountHandler : IRequestHandler<GetUserQuery, User>
{
    private readonly IGetUserRepository _userRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public GetAccountHandler(IGetUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
    {
        _userRepository = userRepository;
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
        {
            var userEmail = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!string.IsNullOrEmpty(userEmail))
            {
                return await _userRepository.GetUserByEmailAsync(userEmail);
            }
            else
            {
                throw new Exception ("Please enter a valid email address");
            }
        }
        return await _userRepository.GetUserAsync(request.Email, request.Password);
    }
}
