using System.ComponentModel.DataAnnotations;

namespace Tiendaonline.API.Models
{
    public class Proveedores
    {
        [Key]
        public int IdProveedor { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nombre { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? Telefono { get; set; } = string.Empty;

    }
}