using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SistemaDeVisitaCampeon.Server.Model
{
    [Table("pedidos", Schema = "public")]
    public class Pedidos
    {

        [Key]
        public int id_pedido { get; set; }  // clave primaria
        public string usuario { get; set; }
        public DateTime fecha_pedido { get; set; }
        public string estado { get; set; }
        public float latitud { get; set; }
        public float longitud { get; set; }
        public string direccion { get; set; }
        public float total { get; set; }
        public string observaciones { get; set; }
    }

    
}
