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

        public async Task<IEnumerable<Livro>> ObterTodos()
        {
            return await _dbContext.Livros.ToListAsync();
        }

        public async Task<Livro> ObterPorId(int id)
        {
            return await _dbContext.Livros.FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task Adicionar(Livro livro)
        {
            await _dbContext.Livros.AddAsync(livro);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Atualizar(Livro livro)
        {
            _dbContext.Entry(livro).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Excluir(int id)
        {
            var livroExistente = _dbContext.Livros.FirstOrDefault(l => l.Id == id);
            if (livroExistente != null)
            {
                _dbContext.Livros.Remove(livroExistente);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
