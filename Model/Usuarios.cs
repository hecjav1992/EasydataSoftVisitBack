using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SistemaDeVisitaCampeon.Server.Model
{
    [Table("user", Schema = "public")]
    public class Usuarios
    {
        [Key]
        public int id { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public string rol { get; set; }
    }
}