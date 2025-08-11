using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeVisitaCampeon.Server.Model;

namespace SistemaDeVisitaCampeon.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class PedidosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PedidosController(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/<Pedidos>
      //  [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Pedidos>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Pedidos>
        [HttpPost]
        public async Task<IActionResult>Post([FromBody] PedidosRequest request)
        {
            var nuevoPedido = new Pedidos
            {
                fecha_pedido = request.fecha_pedido,
                estado = request.estado,
                latitud = request.latitud ?? 0,
                longitud = request.longitud ?? 0,
                direccion = request.direccion,
                total = request.total ?? 0,
                observaciones = request.observaciones,

            };

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // verás el error exacto
            }


            _context.pedidos.Add(nuevoPedido);
            await _context.SaveChangesAsync();

            return Ok(new { success = true, message = "Pedido creado" });
        }

        // PUT api/<Pedidos>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Pedidos>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        public class PedidosRequest
        {
            public int? id_pedido { get; set; }
            public int? id_usuario { get; set; }
            public String usuario { get; set; }
            public int cantidad { get; set; }
            public DateTime? fecha_pedido { get; set; }
            public String? estado { get; set; }
            public float? latitud { get; set; }
            public float? longitud { get; set; }
            public String? direccion { get; set; }
            public float? total { get; set; }
            public String? observaciones { get; set; }


        }

    }
}
