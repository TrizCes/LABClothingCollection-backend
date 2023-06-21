using ClothingCollectionAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ClothingCollectionAPI.DTO.Response
{
    public class UsuarioResponseDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string NomeCompleto { get; set; }
        public string Genero { get; set; }
        public string CpfOuCnpj { get; set; }
        public string Telefone { get; set; }

        public string TipoUsuario { get; set; }
        public string StatusUsuario { get; set; }

        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime DataNascimento { get; set; }

        public static implicit operator UsuarioResponseDTO(Usuario usuario)
        {
            UsuarioResponseDTO usuarioDTO = new UsuarioResponseDTO
            {
                Email = usuario.Email,
                NomeCompleto = usuario.NomeCompleto,
                Genero = usuario.Genero,
                CpfOuCnpj = usuario.CpfOuCnpj,
                Telefone = usuario.Telefone,
                DataNascimento = usuario.DataNascimento,
                StatusUsuario = usuario.StatusUsuario.ToString(),
                TipoUsuario = usuario.TipoUsuario.ToString(),
            };
            return usuarioDTO;
        }
    }
}
