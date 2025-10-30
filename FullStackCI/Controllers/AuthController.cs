using FullStackCI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FullStackCI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            // Por simplicidad, usamos credenciales fijas.
            if (model.Username == "usuario" && model.Password == "password123")
            {
                // Obtener la clave secreta desde la configuración (Program.cs para este ejemplo).
                //var key = Encoding.ASCII.GetBytes("estaesmiclavesupersecretaylargaparajwttoken1234");
                var secretKey = _configuration["Jwt:SecretKey"];
                var key = Encoding.ASCII.GetBytes(secretKey);

                // Define los "claims" (declaraciones) del usuario que se incluirán en el token.
                var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, model.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("rol", "usuario") // Ejemplo de un claim de rol.
            };

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddMinutes(30), // El token expira en 30 minutos.
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature
                    ),
                    Issuer = "TuAPI",
                    Audience = "UsuariosAPI"
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                // Devuelve el token en la respuesta.
                return Ok(new { token = tokenString });
            }

            return Unauthorized(); // Credenciales inválidas.
        }

        [HttpGet("token-info")]
        public IActionResult GetTokenInfo([FromHeader] string authorization)
        {
            if (string.IsNullOrEmpty(authorization) || !authorization.StartsWith("Bearer "))
            {
                return Unauthorized();
            }
            var token = authorization.Substring("Bearer ".Length).Trim();
            var handler = new JwtSecurityTokenHandler();
            if (!handler.CanReadToken(token))
            {
                return BadRequest("Invalid token format");
            }
            var jwtToken = handler.ReadJwtToken(token);
            return Ok(new
            {
                Issuer = jwtToken.Issuer,
                Audience = string.Join(", ", jwtToken.Audiences),
                Expiration = jwtToken.ValidTo,
                Claims = jwtToken.Claims.ToDictionary(c => c.Type, c => c.Value)
            });
        }

        [HttpGet("validate-api-key")]
        public IActionResult ValidateApiKey([FromHeader] string apiKey)
        {
            if (apiKey != "mi-api-key")
                return Unauthorized();

            return Ok(new { message = "Api key válida" });
        }
    }
}
