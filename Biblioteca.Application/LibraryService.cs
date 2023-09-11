using Biblioteca.Application.Intefaces;
using Biblioteca.Domain;
using Biblioteca.Domain.Intefaces;

namespace Biblioteca.Application
{
    public class LibraryService : ILibraryService
    {
  
            private readonly ILivroRepository _livroRepository;

            public LibraryService(ILivroRepository livroRepository)
            {
                _livroRepository = livroRepository;
            }

            public async Task<IEnumerable<Livro>> ObterTodosLivrosAsync()
            {
                return await _livroRepository.ObterTodosAsync();
            }

            public async Task<Livro> ObterLivroPorIdAsync(int id)
            {
                return await _livroRepository.ObterPorIdAsync(id);
            }

            public async Task AdicionarLivroAsync(Livro livro)
            {
                await _livroRepository.AdicionarAsync(livro);
            }

            public async Task AtualizarLivroAsync(Livro livro)
            {
                await _livroRepository.AtualizarAsync(livro);
            }

            public async Task ExcluirLivroAsync(int id)
            {
                await _livroRepository.ExcluirAsync(id);
            }
    }
}
