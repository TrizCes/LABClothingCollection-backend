using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClothingCollectionAPI.Context;
using ClothingCollectionAPI.Models;
using ClothingCollectionAPI.DTO;
using ClothingCollectionAPI.Models.Enums;
using ClothingCollectionAPI.DTO.Response;
using AutoMapper;

namespace ClothingCollectionAPI.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly LabClothingCollectionContext _context;

        public UsuariosController(LabClothingCollectionContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios([FromQuery] EnumStatus? status)
        {
            List<Usuario> usuarios = await _context.Usuarios.Where(x => status != null ? x.StatusUsuario == status : x.StatusUsuario != null).ToListAsync();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Usuario, UsuarioResponseDTO>());

            var mapper = config.CreateMapper();

            List<UsuarioResponseDTO> usuarioResponseDTO = mapper.Map<List<UsuarioResponseDTO>>(usuarios);

            return Ok(usuarioResponseDTO);
        }

        // GET: api/Usuarios/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {

            var usuario = await _context.Usuarios.FindAsync(id);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Usuario, UsuarioResponseDTO>());

            var mapper = config.CreateMapper();

            UsuarioResponseDTO usuarioResponseDTO = mapper.Map<UsuarioResponseDTO>(usuario);

            if (usuario == null)
            {
                return NotFound("Id do usuario não encontrado");
            }

            return Ok(usuarioResponseDTO);
        }

        // POST: api/Usuarios
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpPost]
        public async Task<ActionResult<Usuario>> Post([FromBody] Usuario usuario)
        {

            bool docConflitante = await _context.Usuarios.AnyAsync(u => u.CpfOuCnpj == usuario.CpfOuCnpj);
            if (docConflitante)
            {
                return Conflict("O CPF ou CNPJ informado já foi cadastrado.");
            }

            try
            {
                _context.Usuarios.Add(usuario);

                await _context.SaveChangesAsync();
            }
            catch
            {
                return BadRequest();
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Usuario, UsuarioResponseDTO>());

            var mapper = config.CreateMapper();

            UsuarioResponseDTO usuarioResponseDTO = mapper.Map<UsuarioResponseDTO>(usuario);

            return CreatedAtAction(
                nameof(GetUsuario), 
                new { Id = usuarioResponseDTO.Id }, usuarioResponseDTO
                );
        }

        // PUT: api/Usuarios/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
                    return BadRequest();
                }
                else
                {
                    throw;
                }
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Usuario, UsuarioResponseDTO>());

            var mapper = config.CreateMapper();

            UsuarioResponseDTO usuarioResponseDTO = mapper.Map<UsuarioResponseDTO>(usuario);

            return Ok(usuarioResponseDTO);
        }

        // Patch: api/Usuarios/5/status 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchStatus(int id, [FromQuery] EnumStatus status)
        {
            var existeUsuario = await _context.Usuarios
                                .FirstOrDefaultAsync(x => x.Id == id)
                                .ConfigureAwait(true);
            if (existeUsuario is null)
            {
                return NotFound("Identificador não consta nos nossos arquivos");
            }

            try
            {
                existeUsuario.StatusUsuario = status;

                await _context.SaveChangesAsync();
            }
            catch
            {
                return BadRequest();
            }

            return Ok(existeUsuario);
        }

    }
}
