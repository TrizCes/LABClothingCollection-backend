using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClothingCollectionAPI.Context;
using ClothingCollectionAPI.Models;
using ClothingCollectionAPI.Models.Enums;
using AutoMapper;
using ClothingCollectionAPI.DTO.Response;

namespace ClothingCollectionAPI.Controllers
{
    [Route("api/modelos")]
    [ApiController]
    public class ModelosController : ControllerBase
    {
        private readonly LabClothingCollectionContext _context;

        public ModelosController(LabClothingCollectionContext context)
        {
            _context = context;
        }


        // GET: api/Modelos
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Modelo>>> GetModelos([FromQuery] EnumLayout? layout)
        {

            List<Modelo> modelos = await _context.Modelos.Where(x => layout != null ? x.Layout == layout : x.Layout != null).ToListAsync();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Modelo, ModeloResponseDTO>());

            var mapper = config.CreateMapper();

            List<ModeloResponseDTO> modelosResponseDTO = mapper.Map<List<ModeloResponseDTO>>(modelos);
            
            return Ok(modelosResponseDTO);
        }


        // GET: api/Modelos/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Modelo>> GetModelo(int id)
        {
            var modelo = await _context.Modelos.FindAsync(id);

            if (modelo == null)
            {
                return NotFound("Modelo não encontrado");
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Modelo, ModeloResponseDTO>());

            var mapper = config.CreateMapper();

            ModeloResponseDTO modeloResponseDTO = mapper.Map<ModeloResponseDTO>(modelo);

            return Ok(modeloResponseDTO);
        }

        // POST: api/Modelos
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpPost]
        public async Task<ActionResult<Modelo>> PostModelo(Modelo modelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool nomeConflitante = await _context.Modelos
                                            .AnyAsync(u =>
                                            u.NomeModelo == modelo.NomeModelo);
            if (nomeConflitante)
            {
                return Conflict("Já existe um modelo cadastrado com esse nome");
            }

            _context.Modelos.Add(modelo);

            await _context.SaveChangesAsync();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Modelo, ModeloResponseDTO>());

            var mapper = config.CreateMapper();

            ModeloResponseDTO modeloResponseDTO = mapper.Map<ModeloResponseDTO>(modelo);

            return CreatedAtAction(nameof(GetModelo), new { id = modeloResponseDTO.Id }, modeloResponseDTO);
        }

        // PUT: api/Modelos/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModelo(int id, [FromBody] Modelo modelo)
        {
            if (id != modelo.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool nomeConflitante = await _context.Modelos
                                            .AnyAsync(u =>
                                            u.NomeModelo == modelo.NomeModelo && u.Id != modelo.Id);
            if (nomeConflitante)
            {
                return Conflict("Já existe um modelo cadastrado com esse nome");
            }

            _context.Entry(modelo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModeloExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Modelo, ModeloResponseDTO>());

            var mapper = config.CreateMapper();

            ModeloResponseDTO modeloResponseDTO = mapper.Map<ModeloResponseDTO>(modelo);

            return NoContent();
        }

        // DELETE: api/Modelos/5
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModelo(int id)
        {
            var modelo = await _context.Modelos.FindAsync(id);

            if (modelo == null)
            {
                return NotFound();
            }

            _context.Modelos.Remove(modelo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModeloExists(int id)
        {
            return _context.Modelos.Any(e => e.Id == id);
        }
    }
}
