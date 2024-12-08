using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Angelo_Maureira.Models
{
    public class Proveedor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Rut { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [ForeignKey("Ubicacion")]
        public int UbicacionId { get; set; }

        public virtual Ubicacion Ubicacion { get; set; }
    }
}
