using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Biblioteca.Application.DTOs
{
    public class UpdateLivroDto
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Autor { get; set; }
        [Required]
        public DateTime DataPublicacao { get; set; }

        [Validation.ISBN(ErrorMessage = "ISBN inválido")]
        [Required]
        public string ISBN { get; set; }
    }
}
