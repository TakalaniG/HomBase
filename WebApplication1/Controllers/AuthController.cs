using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HomBase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLogin request)
        {
            if (request.Username != "admin" || request.Password != "password123")
                return Unauthorized(new { message = "Invalid credentials" });

            var tokenHandler = new JwtSecurityTokenHandler();

            // Ensure this key is at least 256 bits (32 characters)
            var key = Encoding.ASCII.GetBytes("your-256-bit-long-secret-key-here-should-be-32-characters");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.Name, request.Username),
            new Claim(ClaimTypes.Role, "Admin") // Assign roles if needed
        }),
                Expires = DateTime.UtcNow.AddHours(1), // Token expires in 1 hour
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { Token = tokenString });
        }
    }

    public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
