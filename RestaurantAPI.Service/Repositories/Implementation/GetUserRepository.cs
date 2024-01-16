using Microsoft.AspNetCore.Identity;
using RestaurantAPI.Domain.Models;
using RestaurantAPI.Service.Repositories.Interfaces;

namespace RestaurantAPI.Service.Repositories.Implementation
{
    public class GetUserRepository : IGetUserRepository
    {
        private readonly UserManager<User> _userManager;

        public GetUserRepository(UserManager<User> context)
        {
            _userManager = context;
        }



        public async Task<User> GetUserAsync(string email, string password)
        {
            // Validate credentials and retrieve the user
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                return user;
            }

            return null; // Return null if user is not found or password is incorrect
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (!string.IsNullOrEmpty(email))
            {
                return user;
            }
            return null;
        }
    }
}