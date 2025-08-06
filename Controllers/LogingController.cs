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


        [HttpGet("productos")]
        public async Task<IActionResult> productos()
        {
            var productos = await _context.productos.Select(u => new {
            u.id,
            u.nombre,
            u.descripcion,
            u.precio,
            u.stock
             }).ToListAsync(); ;

            return Ok(productos);
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
    .Where(u => u.usuario == request.usuario && u.contrasena == request.contrasena)
    .Select(u => new {
        u.id,
        u.usuario,
        u.contrasena,
        u.rol
    })
    .FirstOrDefaultAsync();

            if (user != null)
            {

                return Ok(new { success = true, token = "token_generado_123", message = user.rol });
            }

            return Unauthorized(new { success = false, message = "Credenciales inválidas" });
        }


        public class LoginRequest
        {
            public string? usuario { get; set; }
            public string? contrasena { get; set; }
            public string? rol {  get; set; }
        }

    }
}
