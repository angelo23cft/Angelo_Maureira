using System.ComponentModel.DataAnnotations;

namespace Angelo_Maureira.Models
{
    public class TipoProducto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(200)]
        public string Descripcion { get; set; }

        [StringLength(50)]
        public string Estado { get; set; }
    }
}
