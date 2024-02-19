using Biblioteca.Domain;
using Microsoft.AspNetCore.Mvc;
using Biblioteca.Application.DTOs;
using Biblioteca.Application.Intefaces;

namespace Biblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public LivrosController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        // GET: api/Livros
        [HttpGet]
        public async Task<IActionResult> GetLivros()
        {
            var livros = await _libraryService.ObterTodosLivrosAsync();
            return Ok(livros);
        }

        // GET: api/Livros/5
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetLivro(Guid id)
        {
            var livro = await _libraryService.ObterLivroPorIdAsync(id);
            if (livro == null)
            {
                return NotFound();
            }
            return Ok(livro);
        }

        // POST: api/Livros
        [HttpPost]
        public async Task<IActionResult> PostLivro(CreateLivroDto createLivroDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //é possivel tbm utilizar automapper mas como a solução seria simples optei por não utilizar

            var livro = new Livro
            {
                Titulo = createLivroDto.Titulo,
                Autor = createLivroDto.Autor,
                DataPublicacao = createLivroDto.DataPublicacao,
                Isbn = createLivroDto.ISBN
            };

            await _libraryService.AdicionarLivroAsync(livro);

            return Ok(CreatedAtAction(nameof(GetLivro), new { id = livro.Id }, livro));
        }

        // PUT: api/Livros/5
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> PutLivro(Guid id, UpdateLivroDto updateLivroDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var livro = new Livro
            {
                Id = id,
                Titulo = updateLivroDto.Titulo,
                Autor = updateLivroDto.Autor,
                DataPublicacao = updateLivroDto.DataPublicacao,
                Isbn = updateLivroDto.ISBN
            };

            var resultado = await _libraryService.AtualizarLivroAsync(livro);

            if (!resultado)
            {
                return NotFound("Livro não encontrado");
            }

            return Ok("Livro Atualizado");
        }

        // DELETE: api/Livros/5
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteLivro(Guid id)
        {
            var resultado = await _libraryService.ExcluirLivroAsync(id);

            if (!resultado)
            {
                return NotFound("Livro não encontrado");
            }

            return Ok("Livro Deletado");
        }
    }
}
