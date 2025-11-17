using Microsoft.AspNetCore.Mvc;
using Ecommerce.API.Data;
using Ecommerce.API.Models.Auth;
using Ecommerce.API.Services;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace Ecommerce.API.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly JwtService _jwt;

    public AuthController(ApplicationDbContext context, JwtService jwt)
    {
        _context = context;
        _jwt = jwt;
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponseDto>> Login(LoginDto dto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            return Unauthorized("Identifiants incorrects");

        return Ok(new LoginResponseDto
        {
            Token = _jwt.GenerateToken(user),
            User = new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                IsAdmin = user.IsAdmin
            }
        });
    }
}