namespace RestaurantAPI.Domain.OptionsSetup;


public class JwtOptions
{
    public string Issuer { get; init; }
    public string Audience { get; init; }
    public string SecretKey { get; set; }
}