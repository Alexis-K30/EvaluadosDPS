using System.ComponentModel.DataAnnotations;

namespace Librería.Models
{
    public class Libros
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 carateres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, 10000, ErrorMessage = "El precio debe estar entre 0.01 y 10000")]
        public decimal Price { get; set; }
    }
}
