namespace Biblioteca.Application.DTOs
{
    public class CreateLivroDto
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string ISBN { get; set; }
    }
}
