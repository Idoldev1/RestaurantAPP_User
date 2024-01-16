using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Domain.Models;

namespace RestaurantAPI.Data.Data;


public class ApplicationDb : IdentityDbContext<User, UserRole, int>
{
    public ApplicationDb(DbContextOptions<ApplicationDb> options) : base(options)
    {
        
    }


    //public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Add any additional configurations or constraints here
    }
}