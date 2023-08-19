using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTKontrolu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login()
        {
            // Kullanıcı kimlik doğrulama işlemi gerçekleştirilir
            // Kullanıcı adı ve şifre kontrol edilir

            var token = GenerateToken("kullaniciadi"); // Kullanıcının adını token üretimi için kullanabilirsiniz
            return Ok(new { token });
        }

        private string GenerateToken(string username)
        {
            var appSettings = _configuration.GetSection("AppSettings");
            var secret = appSettings.GetValue<string>("Secret");
            var issuer = appSettings.GetValue<string>("Issuer");
            var audience = appSettings.GetValue<string>("Audience");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username)
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
