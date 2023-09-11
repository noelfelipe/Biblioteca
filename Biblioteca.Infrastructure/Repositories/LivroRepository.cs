using Biblioteca.Domain;
using Biblioteca.Domain.Intefaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Infrastructure.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly BibliotecaDbContext _dbContext;

        public LivroRepository(BibliotecaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Livro>> ObterTodosAsync()
        {
            return await _dbContext.Livros.ToListAsync();
        }

        public async Task<Livro> ObterPorIdAsync(int id)
        {
            return await _dbContext.Livros.FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task AdicionarAsync(Livro livro)
        {
            await _dbContext.Livros.AddAsync(livro);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Livro livro)
        {
            _dbContext.Entry(livro).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task ExcluirAsync(int id)
        {
            var livroExistente = await _dbContext.Livros.FirstOrDefaultAsync(l => l.Id == id);
            if (livroExistente != null)
            {
                _dbContext.Livros.Remove(livroExistente);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Livro>> ObterPaginadoAsync(int pagina = 1, int tamanhoPagina = 50)
        {
            return await _dbContext.Livros
                .Skip((pagina - 1) * tamanhoPagina)
                .Take(tamanhoPagina)
                .ToListAsync();
        }
    }
}
