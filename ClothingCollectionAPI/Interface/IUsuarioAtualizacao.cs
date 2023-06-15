using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingCollectionAPI.Interface
{
    public interface IUsuarioAtualizacao
    {
        public String NomeCompleto { get; set; }
        public String Genero { get; set; }
        public DateTime DataNascimento { get; set; }
        public String Telefone { get; set; }
        public String TipoUsuario { get; set; }
    }
}
