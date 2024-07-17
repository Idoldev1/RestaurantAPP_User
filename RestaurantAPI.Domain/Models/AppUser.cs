using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace RestaurantAPI.Domain.Models;


public class AppUser : IdentityUser<Guid>
{
    
    [Required]
    [StringLength(15, MinimumLength = 3, ErrorMessage = "Maximum lenght for First name is 15 characters")]
    public string FirstName { get; set; }

    [Required]
    [StringLength(15, MinimumLength = 3, ErrorMessage = "Maximum lenght for name is 15 characters")]
    public string LastName { get; set; }

    public string FullName { get; set; }

    [Required]
    [MaxLength(50, ErrorMessage = "Maximum lenght for address is 50 characters")]
    public string Address { get; set; }
    
    [Required]
    public Gender Gender { get; set; }
    public string Role { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;


    /*Random rand = new();

    public User()
    {
        //This will generate a new random 7 digits number
        //CustomerId = Convert.ToString((long) Math.Floor(rand.NextDouble() *4_000_000 + 1_000_000L));

        //Also the fullname property
        FullName = $"{FirstName} {LastName}";
    }*/

    public enum UserStatus
    {
        Active,
        Pending,
        Inactive,
    }
}