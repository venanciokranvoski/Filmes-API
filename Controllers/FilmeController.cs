using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Filmes_API.Models;
using Filmes_API.Data;

namespace Filmes_API.Controllers
{
    [ApiController]
    [Route("[controller]")]  // anotação Controller.

    public class FilmeController : ControllerBase
    {
        private FilmesContext _context;
        
        public FilmeController(FilmesContext context)
        {
            _context = context;
        }
        // campo da nossa classe 
        // private static List<Filme> filmes = new List<Filme>();
        // campo privado para nao se repetir nos "inserts"
        // private static int id = 1;
        
        // Implementação do Recurso
        [HttpPost]

        // Adicionar um filme     //Vem do Corpo da Requisição 
        public IActionResult AdicionarFilme([FromBody] CreateFilmeDto filmeDto)
        {    // tranformando o filmeDto em filme. 
            Filme filme = new Filme
            {
                // constructor explicito
                Titulo = filmeDto.Titulo,
                Genero = filmeDto.Genero,
                Diretor = filmeDto.Diretor,
                Duracao = filmeDto.Duracao
            };
            //filme.Id = id++;
            //filmes.Add(filme);
            // CreateAtAction qual foi a açao que criou este recurso!.
            _context.Filmes.Add(filme); // adicinando valor no banco de dados.
            _context.SaveChanges();     // Da um commit na aplicação 
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = filme.Id }, filme);
        }
              // conceito de Interface..
        [HttpGet]

        public IEnumerable<Filme> recuperarFilmes()
        {
            return _context.Filmes;
        }

        [HttpGet("{id}")]
        // Este metodo diferencia para passar o parametro diferente 

        public IActionResult RecuperaFilmesPorId(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
            {
                ReadFilmeDto filmeDto = new ReadFilmeDto
                {
                    Titulo  = filme.Titulo,
                    Diretor = filme.Diretor,
                    Duracao = filme.Duracao,
                    Id = filme.Id,
                    Genero = filme.Genero,
                    HoraDaConsulta = DateTime.Now
                };
                return Ok(filmeDto); // esses dois recursos nao sao do tipo filme
            }
            return NotFound();
        }

        // atualizando dados
        // anotação

        [HttpPut("{id}")]   // Apartir do corpo  
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme == null)
            {
                return NotFound();  
            }
            // nao é o mais recomandavel. 
            filme.Titulo  = filmeDto.Titulo;
            filme.Duracao = filmeDto.Duracao;
            filme.Diretor = filmeDto.Diretor;
            filme.Genero  = filmeDto.Genero;
            _context.SaveChanges();
            return NoContent();
        }

        // anotacao
        [HttpDelete("{id}")]

        public IActionResult DeletaFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme == null)
            {
                return NotFound();
            }
            _context.Remove(filme);
            _context.SaveChanges();
            return NotFound();
        }

    }
}


/* foreach(Filme filme in filmes)
  {
      if(filme.Id == id)
      {
          return filme;
      }
  }
  return null;
*/
// Clean Code 