using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClothingCollectionAPI.Models;
using ClothingCollectionAPI.Context;
using ClothingCollectionAPI.Models.Enums;
using AutoMapper;
using ClothingCollectionAPI.DTO.Response;

namespace ClothingCollectionAPI.Controllers
{
    [Route("api/colecoes")]
    [ApiController]
    public class ColecoesController : ControllerBase
    {
        private readonly LabClothingCollectionContext _context;

        public ColecoesController(LabClothingCollectionContext context)
        {
            _context = context;
        }

        // GET: api/Colecoes
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Colecao>>> GetColecoes([FromQuery] EnumStatus? status)
        {
            List<Colecao> colecoes = await _context.Colecoes.Where(x => status != null ? x.EstadoSistema == status : x.EstadoSistema != null).ToListAsync();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Colecao, ColecaoResponseDTO>());

            var mapper = config.CreateMapper();

            List<ColecaoResponseDTO> colecoesResponseDTO = mapper.Map<List<ColecaoResponseDTO>>(colecoes);

            return Ok(colecoesResponseDTO);
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

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Colecao, ColecaoResponseDTO>());

            var mapper = config.CreateMapper();

            ColecaoResponseDTO colecaoResponseDTO = mapper.Map<ColecaoResponseDTO>(colecao);

            return Ok(colecaoResponseDTO);
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

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Colecao, ColecaoResponseDTO>());

            var mapper = config.CreateMapper();

            ColecaoResponseDTO colecaoResponseDTO = mapper.Map<ColecaoResponseDTO>(colecao);

            return CreatedAtAction(nameof(GetColecao), new { id = colecaoResponseDTO.Id }, colecaoResponseDTO);
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
                                            u.NomeColecao == colecao.NomeColecao 
                                            && u.Id != colecao.Id);
            if (nomeConflitante)
            {
                return Conflict("Já existe uma coleção cadastrada com esse nome (É necessário informar o id no Request Body)");
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

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Colecao, ColecaoResponseDTO>());

            var mapper = config.CreateMapper();

            ColecaoResponseDTO colecaoResponseDTO = mapper.Map<ColecaoResponseDTO>(colecao);

            return Ok(colecaoResponseDTO);
        }

        // PATCH: api/Colecoes/:id/status
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPatch("{id}/status")]
        public async Task<IActionResult> PatchColecao(int id, [FromQuery] EnumStatus status)
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
                colecao.EstadoSistema = status;

                _context.Entry(colecao).State = EntityState.Modified;
                            
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Colecao, ColecaoResponseDTO>());

            var mapper = config.CreateMapper();

            ColecaoResponseDTO colecaoResponseDTO = mapper.Map<ColecaoResponseDTO>(colecao);

            return Ok(colecaoResponseDTO);
        }

        // DELETE: api/Colecoes/:id
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
