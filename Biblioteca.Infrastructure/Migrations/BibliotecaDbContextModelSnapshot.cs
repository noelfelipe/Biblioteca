using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Biblioteca.Infrastructure.Migrations
{
    [DbContext(typeof(BibliotecaDbContext))] 
    partial class BibliotecaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "6.0.21");

            modelBuilder.Entity("Biblioteca.Domain.Livro", b =>
            {
                b.Property<Guid>("Id")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("NEWID()");

                b.Property<string>("Autor")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("DataPublicacao")
                    .HasColumnType("datetime2");

                b.Property<string>("ISBN")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Titulo")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.ToTable("Livros");
            });
        }
    }
}
