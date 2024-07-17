using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Domain.DTOs;

public class UpdateUserDto
{
    [Required]
    [StringLength(maximumLength: 30)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(maximumLength: 30)]
    public string LastName { get; set; }

    [Phone]
    public string PhoneNumber { get; set; }
}