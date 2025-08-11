using Microsoft.AspNetCore.Mvc;
using SistemaDeVisitaCampeon.Server.Model;
using System;
using System.Threading.Tasks;

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

        // POST api/Pedidos
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PedidosRequest request)
        {
           
                var nuevoPedido = new Pedidos
                {
                    usuario = request.usuario,
                    fecha_pedido = request.fecha_pedido ?? DateTime.Now,
                    estado = request.estado ?? "pendiente",
                    latitud = request.latitud ?? 0,
                    longitud = request.longitud ?? 0,
                    direccion = request.direccion,
                    total = request.cantidad,
                    observaciones = request.observaciones
                };

                _context.pedidos.Add(nuevoPedido);
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    success = true,
                    message = nuevoPedido
                });
            
    

      
        }
        public class PedidosRequest
        {
            public int? id_pedido { get; set; }
            public string usuario { get; set; }
            public int cantidad { get; set; }
            public DateTime? fecha_pedido { get; set; }
            public string estado { get; set; }
            public float? latitud { get; set; }
            public float? longitud { get; set; }
            public string direccion { get; set; }
            public float? total { get; set; }
            public string observaciones { get; set; }
        }
    }
}
