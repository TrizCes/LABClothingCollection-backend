using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ClothingCollectionAPI.Services;

namespace ClothingCollectionAPI.Models
{
    public class Usuario : Pessoa
    {
        private String _email;
        private String _tipoUsuario;
        private String _statusUsuario;

        [Required(ErrorMessage = "O campo email é de preenchimento obrigatório")]
        [MaxLength(150, ErrorMessage = "O campo email não pode exceder 150 caracteres")]
        public String Email { 
            get { return _email; } 
            set 
            {
                _email = UsuarioService.ValidarEmail(value) ? value : null ;
            } 
        }

        [Required(ErrorMessage = "O campo TipoUsuario apenas aceita as opções: Administrador, Gerente, Criador, Outro")]
        [MaxLength(150, ErrorMessage = "O campo Tipo não pode exceder 150 caracteres")]
        public String TipoUsuario {
            get { return _tipoUsuario; }
            set
            {
                _tipoUsuario = UsuarioService.ValidarTipoUsuario(value) ? value : null ;
            }
        }

        [Required(ErrorMessage = "O campo StatusUsuario apenas aceita as opções: Ativo ou Inativo")]
        [MaxLength(150, ErrorMessage = "O campo StatusUsuario não pode exceder 150 caracteres")]
        public String StatusUsuario
        {
            get { return _statusUsuario; }
            set
            {
                _statusUsuario = UsuarioService.ValidarStatusUsuario(value) ? value : null ;
            }
        }

        
    }
}
