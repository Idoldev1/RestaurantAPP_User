using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static RestaurantAPI.Domain.Models.AppUser;

namespace RestaurantAPI.Domain.DTOs;


public class AppUserDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }

    [Required(ErrorMessage = "First name is required")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Phone number is required")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Role is required")]
    public string Role { get; set; }

    [JsonIgnore]
    public UserStatus Status { get; set; }
    public string status { get { return Status.ToString(); } }
    public string FullName { get { return $"{FirstName ?? ""} {LastName ?? ""}"; } }
}