using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClothingCollectionAPI.Models;
using ClothingCollectionAPI.DTO;


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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Colecao>>> GetColecoes([FromQuery] StatusDto status)
        {
            var colecoesLista = await _context.Colecoes.ToListAsync().ConfigureAwait(true);

            if (status.Status != null)
            {
                string maiusculaStatus = status.Status.ToUpper();

                if (maiusculaStatus == "ATIVA")
                {
                    //verificar usuarios com status igual ativo
                    var colecoesAtivas = colecoesLista.Where(u =>
                                                        u.EstadoSistema
                                                        .ToUpper() == "ATIVA")
                                                       .ToList();
                    return Ok(colecoesAtivas);
                }
                else if (maiusculaStatus == "INATIVA")
                {
                    var colecoesAtivas = colecoesLista.Where(u =>
                                                    u.EstadoSistema
                                                    .ToUpper() == "INATIVA")
                                                   .ToList();
                    return Ok(colecoesAtivas);

                }
            }
                return Ok(colecoesLista);
        }

        // GET: api/Colecoes/:id
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Colecao>> GetColecao(int id)
        {
            var colecao = await _context.Colecoes.FindAsync(id);

            if (colecao == null)
            {
                return NotFound();
            }

            return Ok(colecao);
        }

        // POST: api/Colecoes
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpPost]
        public async Task<ActionResult<Colecao>> PostColecao([FromBody] Colecao colecao)
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

        // PUT: api/Colecoes/:id
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColecao(int id, [FromBody] Colecao colecao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool existeColecao = await _context.Colecoes
                                .AnyAsync(x => x.Id == id)
                                .ConfigureAwait(true);
            if (!existeColecao)
            {
                return NotFound("Identificador não consta nos nossos arquivos");
            }

            bool nomeConflitante = await _context.Colecoes
                                            .AnyAsync(u =>
                                            u.NomeColecao == colecao.NomeColecao);
            if (nomeConflitante)
            {
                return Conflict("Já existe uma coleção cadastrada com esse nome");
            }

            _context.Entry(colecao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();    
            }

            return Ok(colecao);
        }

        // PUT: api/Colecoes/:id/status
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}/status")]
        public async Task<IActionResult> PutColecao(int id, [FromBody] StatusDto status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool existeColecao = await _context.Colecoes
                                .AnyAsync(x => x.Id == id)
                                .ConfigureAwait(true);
            if (!existeColecao)
            {
                return NotFound("Identificador não consta nos nossos arquivos");
            }

            var colecao = await _context.Colecoes.FindAsync(id);

            try
            {
                colecao.EstadoSistema = status.Status;

                _context.Entry(colecao).State = EntityState.Modified;
                            
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }
            return Ok(colecao);
        }

        // DELETE: api/Colecoes/:id
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

    }
}
