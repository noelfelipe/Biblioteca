using Microsoft.EntityFrameworkCore;
using Biblioteca.Domain;

namespace Biblioteca.Infrastructure
{
    public class BibliotecaDbContext : DbContext
    {
        public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options) : base(options)
        {
        }

        public DbSet<Livro> Livros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações de mapeamento e outras configurações de entidade podem ser definidas aqui.
        }
    }
}

