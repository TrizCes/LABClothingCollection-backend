using System;
using System.ComponentModel.DataAnnotations;
using ClothingCollectionAPI.Models.Enums;
using ClothingCollectionAPI.Services;

namespace ClothingCollectionAPI.Models
{
    public class Usuario : Pessoa
    {
        private String _email;

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
        public EnumTipoUsuario TipoUsuario {get; set;}

        [Required(ErrorMessage = "O campo StatusUsuario apenas aceita as opções: Ativo ou Inativo")]
        public EnumStatus StatusUsuario {get; set;}
   
    }
}
