using System.ComponentModel.DataAnnotations;

namespace ShareModel.DTO.Login;

public class RegisterFormDTO
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Username { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Address { get; set; } = string.Empty;
}