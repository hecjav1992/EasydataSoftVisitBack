using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SistemaDeVisitaCampeon.Server.Model
{
    [Table("pedidos", Schema = "public")]
    public class Pedidos
    {

        [Key]
        public int id_pedido { get; set; }
        public int? id_usuario { get; set; }
        public DateTime? fecha_pedido { get; set; }
        public float? precio { get; set; }
        public String? estado { get; set; }
        public float latitud { get; set; }
        public float longitud { get; set; }
        public String? direccion { get; set; }
        public float? total { get; set; }
        public String? observaciones { get; set; }
    }
}
