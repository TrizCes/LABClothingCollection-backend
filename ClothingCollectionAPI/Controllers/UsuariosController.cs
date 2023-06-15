﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClothingCollectionAPI.Context;
using ClothingCollectionAPI.Models;
using ClothingCollectionAPI.Interface;

namespace ClothingCollectionAPI.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuariosContext _context;

        public UsuariosController(UsuariosContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // POST: api/Usuarios
        [HttpPost]
        public async Task<ActionResult<Usuario>> Post([FromBody] Usuario usuario)
        {
            if (string.IsNullOrEmpty(usuario.NomeCompleto) ||
                string.IsNullOrEmpty(usuario.CpfOuCnpj) || 
                string.IsNullOrEmpty(usuario.Email) ||
                string.IsNullOrEmpty(usuario.TipoUsuario) ||
                string.IsNullOrEmpty(usuario.StatusUsuario)
                )
            {
                return BadRequest("Os campos obrigatórios devem ser preenchidos.");
            }

            bool docConflitante = await _context.Usuarios.AnyAsync(u => u.CpfOuCnpj == usuario.CpfOuCnpj);
            if (docConflitante)
            {
                return Conflict("O CPF ou CNPJ informado já foi cadastrado.");
            }

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction( 
                "Novo usuario adicionado", 
                new { 
                    identificador = usuario.Id, 
                    tipo = usuario.TipoUsuario },
                usuario
                );
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] IUsuarioAtualizacao usuario)
        {
            bool existeUsuario = await _context.Usuarios
                                .AnyAsync(x => x.Id == id) 
                                .ConfigureAwait(true);
            if (!existeUsuario)
            {
                return BadRequest("Identificador não consta nos nossos arquivos");
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound("Erro ao buscar o registro");
                }
                else
                {
                    throw;
                }
            }

            return Ok(usuario);
        }



        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
