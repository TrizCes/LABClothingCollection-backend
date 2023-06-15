using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClothingCollectionAPI.Models;
using ClothingCollectionAPI.Services;

namespace ClothingCollectionAPI.Controllers
{
    [Route("api/colecoes")]
    [ApiController]
    public class ColecoesController : ControllerBase
    {
        private readonly ColecoesContext _context;

        public ColecoesController(ColecoesContext context)
        {
            _context = context;
        }

        // GET: api/Colecoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Colecao>>> GetColecoes()
        {
            return await _context.Colecoes.ToListAsync();
        }

        // GET: api/Colecoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Colecao>> GetColecao(int id)
        {
            var colecao = await _context.Colecoes.FindAsync(id);

            if (colecao == null)
            {
                return NotFound();
            }

            return colecao;
        }

        // PUT: api/Colecoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColecao(int id, Colecao colecao)
        {
            if (id != colecao.Id)
            {
                return BadRequest();
            }

            _context.Entry(colecao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColecaoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Colecoes
        [HttpPost]
        public async Task<ActionResult<Colecao>> PostColecao(Colecao colecao)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool nomeConflitante = await _context.Colecoes
                                            .AnyAsync(u =>
                                            u.NomeColecao == colecao.NomeColecao);
            if (nomeConflitante)
            {
                return Conflict("Já existe uma coleção cadastrada com esse nome");
            }

            _context.Colecoes.Add(colecao);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetColecao), new { id = colecao.Id }, colecao);
        }

        // DELETE: api/Colecoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColecao(int id)
        {
            var colecao = await _context.Colecoes.FindAsync(id);
            if (colecao == null)
            {
                return NotFound();
            }

            _context.Colecoes.Remove(colecao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ColecaoExists(int id)
        {
            return _context.Colecoes.Any(e => e.Id == id);
        }
    }
}
