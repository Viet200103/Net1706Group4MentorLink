using System.ComponentModel.DataAnnotations;

namespace MentorLink.Business.Dtos;

public class LoginRequestDTO
{

    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public required string Email { get; set; }
    
    public required string Password { get; set; }
}