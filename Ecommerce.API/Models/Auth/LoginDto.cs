namespace Ecommerce.API.Models.Auth;

public class LoginDto
{
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
}

public class LoginResponseDto
{
    public string Token { get; set; } = "";
    public UserDto User { get; set; } = null!;
}

public class UserDto
{
    public int Id { get; set; }
    public string Username { get; set; } = "";
    public string Email { get; set; } = "";
    public bool IsAdmin { get; set; }
}