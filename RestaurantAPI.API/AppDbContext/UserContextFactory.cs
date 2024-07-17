using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RestaurantAPI.Data.Database;

namespace RestaurantAPI.API.AppDbContext;


public class UserContextFactory : IDesignTimeDbContextFactory<ApplicationDb>
{
    public ApplicationDb CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();


        var builder = new DbContextOptionsBuilder<ApplicationDb>()

        .UseSqlite(configuration.GetConnectionString("OrderDbConnection"),
            b => b.MigrationsAssembly("RestaurantApp.Order.API"));



        return new ApplicationDb(builder.Options);
    }
}