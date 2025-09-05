using System.ComponentModel.DataAnnotations;

namespace Librería.Models
{
    public class Libros : IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del libro es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre del libro no puede exceder 100 carateres")]
        public string NameBook { get; set; }

        [Required(ErrorMessage = "El nombre del autor es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre del autor no puede exceder 100 carateres")]
        public string NameAuthor { get; set; }

        [Required(ErrorMessage = "El año de publicacion es obligatorio")]
        public int anioPubli { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            int añoActual = DateTime.Now.Year;
            if (anioPubli < 1900 || anioPubli > añoActual)
            {
                yield return new ValidationResult(
                    $"El año de publicación debe estar entre 1900 y {añoActual}",
                    new[] { nameof(anioPubli) });
            }
        }
    }
}
