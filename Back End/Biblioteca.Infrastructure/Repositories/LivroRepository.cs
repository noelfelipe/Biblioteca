using Biblioteca.Domain;
using Biblioteca.Domain.Intefaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Livro> ObterPorIdAsync(Guid id)
        {
            return await _dbContext.Livros.FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<Guid> AdicionarAsync(Livro livro)
        {
            await _dbContext.Livros.AddAsync(livro);
            await _dbContext.SaveChangesAsync();
            return livro.Id;
        }

        public async Task<bool> AtualizarAsync(Livro livro)
        {
            {
                var livroExistente = await _dbContext.Livros.FindAsync(livro.Id);
                if (livroExistente == null)
                {
                    return false;
                }

                _dbContext.Entry(livroExistente).CurrentValues.SetValues(livro);
                try
                {
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public async Task<bool> ExcluirAsync(Guid id)
        {
            var livro = await _dbContext.Livros.FindAsync(id);
            if (livro == null)
            {
                return false;
            }

            _dbContext.Livros.Remove(livro);
            await _dbContext.SaveChangesAsync();
            return true;
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
