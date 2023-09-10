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

        public async Task<IEnumerable<Livro>> ObterTodosLivros()
        {
            return await _livroRepository.ObterTodos();
        }

        public async Task<Livro> ObterLivroPorId(int id)
        {
            return await _livroRepository.ObterPorId(id);
        }

        public async Task AdicionarLivro(Livro livro)
        {
            await _livroRepository.Adicionar(livro);
        }

        public async Task AtualizarLivro(Livro livro)
        {
            await _livroRepository.Atualizar(livro);
        }

        public async Task ExcluirLivro(int id)
        {
            await _livroRepository.Excluir(id);
        }
    }
}
