using Biblioteca.Application.Intefaces;
using Biblioteca.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks; // Adicione esta linha

namespace MinhaApi.Controllers
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

        // Endpoint para obter todos os livros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livro>>> ObterTodosLivros()
        {
            var livros = await _libraryService.ObterTodosLivrosAsync();
            return Ok(livros);
        }

        // Endpoint para obter um livro por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> ObterLivroPorId(int id)
        {
            var livro = await _libraryService.ObterLivroPorIdAsync(id);
            if (livro == null)
            {
                return NotFound(); // Livro não encontrado
            }
            return Ok(livro);
        }

        // Endpoint para adicionar um novo livro
        [HttpPost]
        public async Task<ActionResult<Livro>> AdicionarLivro([FromBody] Livro livro)
        {
            if (livro == null)
            {
                return BadRequest(); // Requisição inválida
            }

            await _libraryService.AdicionarLivroAsync(livro);
            return CreatedAtAction(nameof(ObterLivroPorId), new { id = livro.Id }, livro);
        }

        // Endpoint para atualizar um livro existente
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarLivro(int id, [FromBody] Livro livroAtualizado)
        {
            if (livroAtualizado == null || id != livroAtualizado.Id)
            {
                return BadRequest(); // Requisição inválida
            }

            var livroExistente = await _libraryService.ObterLivroPorIdAsync(id);
            if (livroExistente == null)
            {
                return NotFound(); // Livro não encontrado
            }

            await _libraryService.AtualizarLivroAsync(livroAtualizado);
            return NoContent(); // Sucesso, sem conteúdo
        }

        // Endpoint para excluir um livro
        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirLivro(int id)
        {
            var livro = await _libraryService.ObterLivroPorIdAsync(id);
            if (livro == null)
            {
                return NotFound(); // Livro não encontrado
            }

            await _libraryService.ExcluirLivroAsync(id);
            return NoContent(); // Sucesso, sem conteúdo
        }
    }
}
