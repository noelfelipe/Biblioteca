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
            // Definir a configuração da tabela Livros aqui
            modelBuilder.Entity<Livro>(entity =>
            {
                entity.ToTable("Livros");
                entity.Property(e => e.Id).ValueGeneratedOnAdd().IsRequired().HasDefaultValueSql("NEWID()");
                entity.Property(e => e.Titulo).IsRequired();
                entity.Property(e => e.Autor).IsRequired();
                entity.Property(e => e.DataPublicacao).IsRequired();
                entity.Property(e => e.Isbn).IsRequired();
                entity.HasKey(e => e.Id).HasName("PK_Livros");
            });
        }
    }
}

