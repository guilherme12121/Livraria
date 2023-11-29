using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LivrariaController : ControllerBase
    {
        private readonly LivrariaContext _context;

        public LivrariaController(LivrariaContext context)
        {
            _context = context;
           
        }
        [HttpGet("ObterTodosLivros")]
        public async Task<ActionResult<IEnumerable<Livros>>> ObterTodosLivros()
        {
            try
            {
                if (_context.Livros.Count() == 0)
                {
                    return NotFound("Não existem livros na lista");
                }

                var livro = await _context.Livros.ToListAsync();

                return Ok(livro);
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro na solicitação...");
            }
        }
        [HttpGet("ObterLivrosPor/{id:int}")]
        public async Task<ActionResult<IEnumerable<Livros>>> ObterLivrosPorId(int id)
        {
            try
            {
                if (_context.Livros.Count() == 0)
                {
                    return NotFound("Não existem livros na lista");
                }

                var Livro = await _context.Livros.FindAsync(id);

                if (Livro == null)
                {
                    return NotFound("O livro não foi encontrado");
                }

                return Ok(Livro);
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro na solicitação...");
            }
        }
        [HttpPost("AdicionarLivros")]
        public async Task<ActionResult<IEnumerable<Livros>>> AdicionarLivros(Livros livros)
        {
            try
            {
                var id = livros.LivroId;
                
                var livroExistente = _context.Livros.Find(id);
               
                if (livroExistente != null)
                {
                    return BadRequest("Ja existe um livros com esse id");
                }

               

                await _context.Livros.AddAsync(livros);
                await _context.SaveChangesAsync();
                return Ok(livros);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro na solicitação: {ex.InnerException?.Message}");
            }
        }
        [HttpDelete("DeletarLivros")]
        public async Task<ActionResult<IEnumerable<Livros>>> DeletarLivros(int Id)
        {
            try
            {
                if (_context.Livros.Count() == 0)
                {
                    return NotFound("Não existem livros na lista");
                }

                var livros = await _context.Livros.FindAsync(Id);

                if (livros == null)
                {
                    return NotFound("O livros não foi encontrado");
                }

                var deleteLivros = _context.Livros.Remove(livros);
                await _context.SaveChangesAsync();

                return Ok(new { Mensagem = "Livros excluído com sucesso", LivrosExcluido = deleteLivros.Entity });
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro na solicitação");
            }
        }
        [HttpPut("AtualizarLivros")]
        public async Task<ActionResult<IEnumerable<Livros>>> AtualizarLivros(int Id, Livros livros)
        {
            try
            {
                if (_context.Livros.Count() == 0)
                {
                    return NotFound("A lista está vazia");
                }

                var procurarLivros = await _context.Livros.FindAsync(Id);

                procurarLivros.LivroId = livros.LivroId;
                procurarLivros.LivroNome = livros.LivroNome;
                procurarLivros.Anodaedição = livros.Anodaedição;
                procurarLivros.Autor = livros.Autor;
                procurarLivros.Editora = livros.Editora;
                procurarLivros.Idioma = livros.Idioma;
                procurarLivros.Numerodepagina = livros.Numerodepagina;



                _context.Livros.Update(procurarLivros);
                await _context.SaveChangesAsync();

                return Ok(livros);
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro na solicitação");
            }
        }
    }
}
