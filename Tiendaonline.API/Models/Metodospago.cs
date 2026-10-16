using System.ComponentModel.DataAnnotations;

namespace Tiendaonline.API.Models
{
    public class Metodospago
    {
        [Key]
        public int IdMetodospago { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nombre { get; set; } = string.Empty;
    }
}