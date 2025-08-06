using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeVisitaCampeon.Server.Model
{
    [Table("producto", Schema = "public")]
    public class Productos
    {
        [Key]
        public int id { get; set; }
        public string? nombre { get; set; }
        public string? descripcion { get; set; }
        public float? precio { get; set; }
        public int? stock { get; set; }
    }
}
