using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Angelo_Maureira.Models
{
    public class Ubicacion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public virtual ICollection<Proveedor> Proveedores { get; set; }
    }
}
