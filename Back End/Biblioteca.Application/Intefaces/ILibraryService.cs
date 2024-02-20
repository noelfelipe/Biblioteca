using Biblioteca.Domain;

namespace Biblioteca.Application.Intefaces
{
    public interface ILibraryService
    {
        Task<Guid> AdicionarLivroAsync(Livro livro);
        Task<bool> AtualizarLivroAsync(Livro livroAtualizado);
        Task<bool> ExcluirLivroAsync(Guid id);
        Task<Livro> ObterLivroPorIdAsync(Guid id);
        Task<IEnumerable<Livro>> ObterTodosLivrosAsync();
        Task<IEnumerable<Livro>> ObterPaginadoAsync(int pagina, int tamanhoPagina);
    }
}
