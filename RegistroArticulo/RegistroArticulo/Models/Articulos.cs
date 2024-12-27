using System.ComponentModel.DataAnnotations;

namespace RegistroArticulo.Models
{
    public class Articulos
    {
        [Key]
        public int ArticuloId { get; set; }

        [Required(ErrorMessage = "El Campo Descripcion es Obligatorio")]
        [StringLength(100, ErrorMessage = "La Descripcion no puede exceder los 100 caracteres")]
        
         public string? Descripcion { get; set; } = string.Empty;

        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Solo se permiten numeros")]
        [Required(ErrorMessage = "El Campo Cantidad Es Obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "La Cantidad debe ser Mayor a 0")]
        public int Cantidad { get; set; }

        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Solo se permiten numeros")]
        [Required(ErrorMessage = "El Campo Precio es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El Precio debe ser mayor a 0")]
        public decimal Precio { get; set; }






    }
}
