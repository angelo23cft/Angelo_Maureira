using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Angelo_Maureira.Data;

namespace Angelo_Maureira.Models
{
    public class Ubicacion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        //public virtual ICollection<Proveedor> Proveedores { get; set; }//

        // Método para contar los proveedores relacionados con esta ubicación
        public async Task<int> ContarProveedoresAsync(ComercialSantaClaraContext context)
        {
            return await context.Proveedores.CountAsync(p => p.UbicacionId == this.Id);
        }
    }
}
