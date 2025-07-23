using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SistemaDeVisitaCampeon.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogingController : ControllerBase
    {
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

        public class LoginRequest
        {
            public string? username { get; set; }
            public string? password { get; set; }
        }

    }
}
