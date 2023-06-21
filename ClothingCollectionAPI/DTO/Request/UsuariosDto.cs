using ClothingCollectionAPI.Models.Enums;
using System;

namespace ClothingCollectionAPI.DTO
{
    public class UsuariosDto
    {
        public string NomeCompleto { get; set; }
        public string Genero { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public EnumTipoUsuario TipoUsuario { get; set; }
    }
}
