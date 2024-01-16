using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantAPI.Data.Data;
using RestaurantAPI.Domain.Models;

namespace RestaurantAPI.Data;


public static class ServiceRegistration
{
    public static IServiceCollection AddDataDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDb>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("RestaurantAPI.API"));
        });


        services.AddIdentityCore<User>()
                .AddEntityFrameworkStores<ApplicationDb>();
        
        return services;
    }
}