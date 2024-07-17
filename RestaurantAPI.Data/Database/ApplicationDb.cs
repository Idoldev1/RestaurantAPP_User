using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Domain.Models;

namespace RestaurantAPI.Data.Database;


public class ApplicationDb : IdentityDbContext<AppUser, UserRole, Guid>
{
    public ApplicationDb(DbContextOptions<ApplicationDb> options) : base(options)
    {
        
    }

    public DbSet<Order> Orders { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Add any additional configurations or constraints here
    }
}