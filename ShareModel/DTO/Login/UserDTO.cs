using System.ComponentModel.DataAnnotations;

namespace ShareModel.DTO.Login;

public class UserDTO
{
    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

}

