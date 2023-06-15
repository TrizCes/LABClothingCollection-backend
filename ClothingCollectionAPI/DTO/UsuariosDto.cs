using ClothingCollectionAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingCollectionAPI.DTO
{
    public class UsuariosDto
    {
        private String _tipoUsuario;
        public string NomeCompleto { get; set; }
        public string Genero { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string TipoUsuario {
            get { return _tipoUsuario; }
            set
            {
                _tipoUsuario = UsuarioService.ValidarTipoUsuario(value) ? value : null ;
            }
        }
    }
}
