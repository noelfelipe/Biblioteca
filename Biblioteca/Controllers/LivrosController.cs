using Biblioteca.Application.Intefaces;
using Biblioteca.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
        public ActionResult<IEnumerable<Livro>> ObterTodosLivros()
        {
            var livros = _libraryService.ObterTodosLivros();
            return Ok(livros);
        }

        // Endpoint para obter um livro por ID
        [HttpGet("{id}")]
        public ActionResult<Livro> ObterLivroPorId(int id)
        {
            var livro = _libraryService.ObterLivroPorId(id);
            if (livro == null)
            {
                return NotFound(); // Livro não encontrado
            }
            return Ok(livro);
        }

        // Endpoint para adicionar um novo livro
        [HttpPost]
        public ActionResult<Livro> AdicionarLivro([FromBody] Livro livro)
        {
            if (livro == null)
            {
                return BadRequest(); // Requisição inválida
            }

            _libraryService.AdicionarLivro(livro);
            return CreatedAtAction(nameof(ObterLivroPorId), new { id = livro.Id }, livro);
        }

        // Endpoint para atualizar um livro existente
        [HttpPut("{id}")]
        public IActionResult AtualizarLivro(int id, [FromBody] Livro livroAtualizado)
        {
            if (livroAtualizado == null || id != livroAtualizado.Id)
            {
                return BadRequest(); // Requisição inválida
            }

            var livroExistente = _libraryService.ObterLivroPorId(id);
            if (livroExistente == null)
            {
                return NotFound(); // Livro não encontrado
            }

            _libraryService.AtualizarLivro(livroAtualizado);
            return NoContent(); // Sucesso, sem conteúdo
        }

        // Endpoint para excluir um livro
        [HttpDelete("{id}")]
        public IActionResult ExcluirLivro(int id)
        {
            var livro = _libraryService.ObterLivroPorId(id);
            if (livro == null)
            {
                return NotFound(); // Livro não encontrado
            }

            _libraryService.ExcluirLivro(id);
            return NoContent(); // Sucesso, sem conteúdo
        }
    }
}
