using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pruebaIntap2.Infrastructure;
using System.Security.Cryptography;
using System.Text;

namespace pruebaIntap2.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Username == dto.Username);
            if (user == null || user.PasswordHash != Hash(dto.PasswordHash))
                return Unauthorized("Credenciales inválidas");

            return Ok(new { user.Id, user.Username });
        }

        private string Hash(string password) => Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(password)));
    }
}
