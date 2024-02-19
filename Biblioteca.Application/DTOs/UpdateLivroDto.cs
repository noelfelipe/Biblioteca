using System.Text.Json.Serialization;

namespace Biblioteca.Application.DTOs
{
    public class UpdateLivroDto
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string ISBN { get; set; }
    }
}
