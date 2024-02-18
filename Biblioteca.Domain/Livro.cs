using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Domain
{
    public class Livro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required] 
        public string Titulo { get; set; }

        [Required] 
        public string Autor { get; set; }

        [Required] 
        public DateTime DataPublicacao { get; set; }

        [Required]
        [Validation.ISBN(ErrorMessage = "ISBN inválido")]
        public string Isbn { get; set; }
    }
}
