namespace Biblioteca.Domain.Intefaces
{
    public interface ILivroRepository
    {
        Task<IEnumerable<Livro>> ObterTodosAsync();
        Task<Livro> ObterPorIdAsync(Guid id);
        Task<Guid> AdicionarAsync(Livro livro);
        Task<bool> AtualizarAsync(Livro livro);
        Task<bool> ExcluirAsync(Guid id);
        Task<IEnumerable<Livro>> ObterPaginadoAsync(int pagina = 1, int tamanhoPagina = 50);
    }
}
