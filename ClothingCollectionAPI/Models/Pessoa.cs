using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingCollectionAPI.Models
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é de preenchimento obrigatório")]
        [MaxLength(200, ErrorMessage = "O campo nome não pode exceder 200 caracteres")]
        public String NomeCompleto { get; set; }

        [MaxLength(50, ErrorMessage = "O campo gênero não pode exceder 50 caracteres")]
        public String Genero { get; set; }

        [Required(ErrorMessage = "O campo Data de Nascimento é de preenchimento obrigatório")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo é de preenchimento obrigatório")]
        [MaxLength(50, ErrorMessage = "O campo deve ser preenchido corretamente")]

        public String CpfOuCnpj { get; set; }

        [Required(ErrorMessage = "O campo Telefone é de preenchimento obrigatório")]
        [MaxLength(25, ErrorMessage = "O campo Telefone deve ser preenchido corretamente")]

        public String Telefone { get; set; }
    }
}
