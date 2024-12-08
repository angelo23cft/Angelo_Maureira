using Angelo_Maureira.Models;
using Microsoft.EntityFrameworkCore;

namespace Angelo_Maureira.Data
{
    public class ComercialSantaClaraContext : DbContext
    {
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Ubicacion> Ubicaciones { get; set; }
        public DbSet<TipoProducto> TiposProducto { get; set; }

        public ComercialSantaClaraContext(DbContextOptions<ComercialSantaClaraContext> options)
            : base(options)
        {
        }
    }
}
