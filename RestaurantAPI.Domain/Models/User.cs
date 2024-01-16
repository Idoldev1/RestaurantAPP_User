using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace RestaurantAPI.Domain.Models;


public class User : IdentityUser<int>
{
    [Required(ErrorMessage = "First name is a required field.")]
    [MaxLength(15, ErrorMessage = "Maximum lenght for name is 15 characters")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is a required field.")]
    [MaxLength(15, ErrorMessage = "Maximum lenght for name is 15 characters")]
    public string LastName { get; set; }

    public string FullName { get; set; }

    [Required(ErrorMessage = "Address is a required field.")]
    [MaxLength(50, ErrorMessage = "Maximum lenght for address is 50 characters")]
    public string? Address { get; set; }

    [Required]
    public string Password { get; set; }
    public string CustomerId { get; set; }


    Random rand = new();

    public User()
    {
        //This will generate a new random 7 digits number
        //CustomerId = Convert.ToString((long) Math.Floor(rand.NextDouble() *4_000_000 + 1_000_000L));

        //Also the fullname property
        FullName = $"{FirstName} {LastName}";
    }
}