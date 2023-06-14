using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
                if (ValidarEmail(value))
                    _email = value;
                else
                    throw new ArgumentException("Email inválido.");
            } 
        }

        [Required(ErrorMessage = "O campo Tipo é de preenchimento obrigatório")]
        [MaxLength(150, ErrorMessage = "O campo Tipo não pode exceder 150 caracteres")]
        public String TipoUsuario {
            get { return _tipoUsuario; }
            set
            {
                if (ValidarTipoUsuario(value))
                    _tipoUsuario = value;
                else
                    throw new ArgumentException("Tipo de usuário inválido.");
            }
        }

        [Required(ErrorMessage = "O campo Status é de preenchimento obrigatório")]
        [MaxLength(150, ErrorMessage = "O campo Status não pode exceder 150 caracteres")]
        public String StatusUsuario
        {
            get { return _statusUsuario; }
            set
            {
                if (ValidarStatusUsuario(value))
                    _statusUsuario = value;
                else
                    throw new ArgumentException("Status do usuário inválido.");
            }
        }

        private bool ValidarEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }

        private bool ValidarTipoUsuario(string tipoUsuario)
        {
            return tipoUsuario == "Administrador" ||
                   tipoUsuario == "Gerente" ||
                   tipoUsuario == "Criador" ||
                   tipoUsuario == "Outro";
        }

        private bool ValidarStatusUsuario(string statusUsuario)
        {
            return statusUsuario == "Ativo" ||
                   statusUsuario == "Inativo";
        }
    }
}
