namespace RestaurantAPI.Domain.DTOs;


public class AuthToken
{
    public string AccessToken { get; set;}
    public string RefreshToken { get; set;}
}