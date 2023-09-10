using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Domain
{
    public class Livro
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string ISBN { get; set; }
    }
}

