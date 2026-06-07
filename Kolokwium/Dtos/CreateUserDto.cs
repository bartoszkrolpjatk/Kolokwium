using System.ComponentModel.DataAnnotations;

namespace Kolokwium.Dtos;

public class CreateUserDto
{
    [Required]
    public string FirstName { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;

    [Required]
    public string Email { get; set; } = null!;
    
    [Required]
    public int RoleId { get; set; }
}