using Biblioteca.Domain;

namespace Biblioteca.Application.Intefaces
{
    public interface ILibraryService
    {
        Task AdicionarLivroAsync(Livro livro);
        Task AtualizarLivroAsync(Livro livroAtualizado);
        Task ExcluirLivroAsync(int id);
        Task<Livro> ObterLivroPorIdAsync(int id);
        Task<IEnumerable<Livro>> ObterTodosLivrosAsync();

        Task<IEnumerable<Livro>> ObterPaginadoAsync(int pagina, int tamanhoPagina);
    }
}
