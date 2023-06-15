using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClothingCollectionAPI.Context;
using ClothingCollectionAPI.Models;
using ClothingCollectionAPI.DTO;

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
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios([FromQuery] string status)
        {
            var usuariosLista = await _context.Usuarios.ToListAsync().ConfigureAwait(true);

            if(status != null )
            {
                string maiusculaStatus = status.ToUpper();

                if (maiusculaStatus == "ATIVO")
                {
                    //verificar usuarios com status igual ativo
                    var usuariosAtivos = usuariosLista.Where(u =>
                                                        u.StatusUsuario
                                                        .ToUpper() == "ATIVO")
                                                       .ToList();
                    return Ok(usuariosAtivos);
                }
                else if (maiusculaStatus == "INATIVO")
                {
                    var usuariosInativos = usuariosLista.Where(u =>
                                                        u.StatusUsuario
                                                        .ToUpper() == "INATIVO")
                                                       .ToList();
                    return Ok(usuariosInativos);
                }
            }
            
            return Ok(usuariosLista);
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
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UsuariosDto usuarioAtualizacao)
        {
            bool existeUsuario = await _context.Usuarios
                                .AnyAsync(x => x.Id == id) 
                                .ConfigureAwait(true);
            if (!existeUsuario)
            {
                return NotFound("Identificador não consta nos nossos arquivos");
            }

            var usuario = await _context.Usuarios.FindAsync(id);

            usuario.NomeCompleto = usuarioAtualizacao.NomeCompleto;
            usuario.Genero = usuarioAtualizacao.Genero;
            usuario.DataNascimento = usuarioAtualizacao.DataNascimento;
            usuario.Telefone = usuarioAtualizacao.Telefone;
            usuario.TipoUsuario = usuarioAtualizacao.TipoUsuario;

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                bool usuarioConsta = await _context.Usuarios
                                .AnyAsync(x => x.Id == id)
                                .ConfigureAwait(true);
                if (!usuarioConsta)
                {
                    return BadRequest("Solicitação inválida");
                }
                else
                {
                    throw;
                }
            }

            return Ok(usuario);
        }

        // PUT: api/Usuarios/5/status
        [HttpPut("{id}/status")]
        public async Task<IActionResult> PutStatus(int id, [FromBody] string status)
        {
            bool existeUsuario = await _context.Usuarios
                                .AnyAsync(x => x.Id == id)
                                .ConfigureAwait(true);
            if (!existeUsuario)
            {
                return NotFound("Identificador não consta nos nossos arquivos");
            }


            var usuario = await _context.Usuarios.FindAsync(id);

            try
            {
         
                usuario.StatusUsuario = status;

                _context.Entry(usuario).State = EntityState.Modified;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                bool usuarioConsta = await _context.Usuarios
                                .AnyAsync(x => x.Id == id)
                                .ConfigureAwait(true);
                if (!usuarioConsta)
                {
                    return BadRequest("Solicitação inválida");
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

    }
}
