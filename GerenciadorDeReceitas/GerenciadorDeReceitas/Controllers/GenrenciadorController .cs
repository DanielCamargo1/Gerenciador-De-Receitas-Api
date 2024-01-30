using GerenciadorDeReceitas.Data;
using GerenciadorDeReceitas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Diagnostics.CodeAnalysis;

namespace GerenciadorDeReceitas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenrenciadorController : ControllerBase
    {
        private readonly ReceitaDbContext _context;
        public GenrenciadorController(ReceitaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReceitaDbContext>>> GetReceita()
        {
            return Ok(await _context.Receita.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<ReceitaDbContext>> PostReceita(ReceitaModel receita)
        {
            _context.Receita.Add(receita);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetReceita", new { id = receita.Id}, receita);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ReceitaDbContext>> PutReceita(int id, ReceitaModel receita)
        {
            var ReceitaId = await _context.Receita.FindAsync(id);
            if(ReceitaId != null)
            {
                ReceitaId.Nome = receita.Nome;
                ReceitaId.Ingredientes = receita.Ingredientes;
                ReceitaId.ModoDePreparo = receita.ModoDePreparo;
                ReceitaId.DicasParaReceita = receita.DicasParaReceita;
                id++;
                await _context.SaveChangesAsync();
                return Ok(ReceitaId);
            }
            else
            { 
                return BadRequest("A receita informada nçao foi possivel localizar!");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ReceitaDbContext>> DeleteReceita(int id)
        {
            var ReceitaId = await _context.Receita.FindAsync(id);
            if(ReceitaId != null)
            {
                _context.Receita.Remove(ReceitaId);
                await _context.Receita.SingleAsync();
                return Ok(ReceitaId);
            }
            else
            {
                return BadRequest("Não possivel licalizzar a receita");
            }
        }
    }
}
