using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RestaurantAPI.Domain.Models;
using RestaurantAPI.Domain.OptionsSetup;
using RestaurantAPI.Service.Repositories.Interfaces;

namespace RestaurantAPI.Service.Repositories.Implementation;

internal sealed class AuthToken : IAuthToken
{
    private readonly JwtOptions _options;

    public AuthToken(IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }
    
    public string GenerateToken(User user)
    {
        
        // Create claims based on user information
        var claims = new[]
        {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
        };

        // Create the token
        var token = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1), // Token expiration time
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)), SecurityAlgorithms.HmacSha256)
        );

        // Serialize the token to a string
        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return tokenString;
    }
}