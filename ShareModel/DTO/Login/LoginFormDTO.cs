using System.ComponentModel.DataAnnotations;

namespace ShareModel.DTO.Login;

public class LoginFormDTO
{
    [Required]
    public string Username { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}