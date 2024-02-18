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

        public async Task<Livro> ObterLivroPorIdAsync(Guid id)
        {
            return await _livroRepository.ObterPorIdAsync(id);
        }

        public async Task<Guid> AdicionarLivroAsync(Livro livro)
        {
            return await _livroRepository.AdicionarAsync(livro);
        }

        public async Task<bool> AtualizarLivroAsync(Livro livro)
        {
            return await _livroRepository.AtualizarAsync(livro);
        }

        public async Task<bool> ExcluirLivroAsync(Guid id)
        {
            return await _livroRepository.ExcluirAsync(id);
        }

        public async Task<IEnumerable<Livro>> ObterPaginadoAsync(int pagina, int tamanhoPagina)
        {
            return await _livroRepository.ObterPaginadoAsync(pagina, tamanhoPagina);
        }
    }
}
