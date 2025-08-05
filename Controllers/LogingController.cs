using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SistemaDeVisitaCampeon.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogingController : ControllerBase
    {

        private readonly AppDbContext _context;

        public LogingController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var lista = new List<object>
    {
        new { id = 1, nombre = "Juan" },
        new { id = 2, nombre = "Ana" },
        new { id = 3, nombre = "Luis" }
    };

            return Ok(lista);
        }

        /*
                [HttpPost("login")]
                public IActionResult Login([FromBody] LoginRequest request)
                {
                    string User=request.username!;
                    string Password=request.password!;

                    switch ((User,Password)) {
                        case ("admin", "1234"):
                            {
                                return Ok(new { success = true, token = "123abc" });
                            }
                        case ("admin2", "1234"):
                            {
                                return Ok(new { success = true, token = "123abd" });
                            }
                    }

                    return Unauthorized(new { success = false, message = "Credenciales inválidas" });
                }
        */
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _context.user
                .FirstOrDefaultAsync(u => u.usuario == request.usuario && u.contrasena == request.contrasena);

            if (user != null)
            {
               
                return Ok(new { success = true, token = "token_generado_123" });
            }

            return Unauthorized(new { success = false, message = "Credenciales inválidas" });
        }


        public class LoginRequest
        {
            public string? usuario { get; set; }
            public string? contrasena { get; set; }
        }

    }
}
