using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClothingCollectionAPI.Context;
using ClothingCollectionAPI.Models;

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
        public async Task<ActionResult<IEnumerable<Modelo>>> GetModelos([FromQuery] String layout)
        {
            var modelosLista = await _context.Modelo.ToListAsync();

            if (layout != null)
            {
                string maiusculaStatus = layout.ToUpper();

                if (maiusculaStatus == "BORDADO")
                {
                    //verificar usuarios com status igual ativo
                    var layoutBordado = modelosLista.Where(u =>
                                                        u.Layout
                                                        .ToUpper() == "BORDADO")
                                                       .ToList();
                    return Ok(layoutBordado);
                }
                else if (maiusculaStatus == "ESTAMPA")
                {
                    var layoutEstampa = modelosLista.Where(u =>
                                                    u.Layout
                                                    .ToUpper() == "ESTAMPA")
                                                   .ToList();
                    return Ok(layoutEstampa);

                }
                else if (maiusculaStatus == "LISO")
                {
                    var layoutLiso = modelosLista.Where(u =>
                                                    u.Layout
                                                    .ToUpper() == "LISO")
                                                   .ToList();
                    return Ok(layoutLiso);

                }
            }

            return Ok(modelosLista);
        }


        // GET: api/Modelos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Modelo>> GetModelo(int id)
        {
            var modelo = await _context.Modelo.FindAsync(id);

            if (modelo == null)
            {
                return NotFound();
            }

            return modelo;
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

            bool nomeConflitante = await _context.Modelo
                                            .AnyAsync(u =>
                                            u.NomeModelo == modelo.NomeModelo);
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

            return NoContent();
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

            bool nomeConflitante = await _context.Modelo
                                            .AnyAsync(u =>
                                            u.NomeModelo == modelo.NomeModelo);
            if (nomeConflitante)
            {
                return Conflict("Já existe um modelo cadastrado com esse nome");
            }

            _context.Modelo.Add(modelo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetModelo), new { id = modelo.Id }, modelo);
        }

        // DELETE: api/Modelos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModelo(int id)
        {
            var modelo = await _context.Modelo.FindAsync(id);
            if (modelo == null)
            {
                return NotFound();
            }

            _context.Modelo.Remove(modelo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModeloExists(int id)
        {
            return _context.Modelo.Any(e => e.Id == id);
        }
    }
}
