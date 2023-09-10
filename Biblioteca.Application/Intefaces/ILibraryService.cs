using Biblioteca.Domain;

namespace Biblioteca.Application.Intefaces
{
    public interface ILibraryService
    {
        Task AdicionarLivro(Livro livro);
        Task AtualizarLivro(Livro livroAtualizado);
        Task ExcluirLivro(int id);
        Task<Livro> ObterLivroPorId(int id);
        Task<IEnumerable<Livro>> ObterTodosLivros();
    }
}
