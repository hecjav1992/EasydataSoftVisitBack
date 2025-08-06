using Microsoft.EntityFrameworkCore;
using SistemaDeVisitaCampeon.Server.Model;
namespace SistemaDeVisitaCampeon.Server
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuarios> user { get; set; }
        public DbSet<Productos> productos { get; set; }
    }
}
