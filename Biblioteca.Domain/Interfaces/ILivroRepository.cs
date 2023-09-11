namespace Biblioteca.Domain.Intefaces
{
    public interface ILivroRepository
    {
        Task<IEnumerable<Livro>> ObterTodosAsync();
        Task<Livro> ObterPorIdAsync(int id);
        Task AdicionarAsync(Livro livro);
        Task AtualizarAsync(Livro livro);
        Task ExcluirAsync(int id);
    }
}
