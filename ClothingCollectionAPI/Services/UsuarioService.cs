using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClothingCollectionAPI.Services
{
    public class UsuarioService
    {
        public static bool ValidarEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }

        public static bool ValidarTipoUsuario(string tipoUsuario)
        {
            return tipoUsuario == "Administrador" ||
                   tipoUsuario == "Gerente" ||
                   tipoUsuario == "Criador" ||
                   tipoUsuario == "Outro";
        }

        public static bool ValidarStatusUsuario(string statusUsuario)
        {
            return statusUsuario == "Ativo" ||
                   statusUsuario == "Inativo";
        }
    }
}
