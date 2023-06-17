using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingCollectionAPI.Models
{
    public class Modelo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é de preenchimento obrigatório")]
        [MaxLength(200, ErrorMessage = "O campo nome não pode exceder 200 caracteres")]
        public String NomeModelo { get; set; }

        [ForeignKey("Colecao")]
        [Required(ErrorMessage = "O Id da coleção é de preenchimento obrigatório")]
        public int IdColecao { get; set; }
        public Colecao Colecao { get; set; }

        [Required(ErrorMessage = "O campo Tipo é de preenchimento obrigatório")]
        [RegularExpression("^(Bermuda|Biquini|Bolsa|Boné|Calça|Calçados|Camisa|Chapéu|Saia)$", 
            ErrorMessage = "O campo Tipo deve ser 'Bermuda', 'Biquini', 'Bolsa', 'Boné', 'Calça', 'Calçados', 'Camisa', 'Chapéu' ou 'Saia'")]
        [MaxLength(60, ErrorMessage = "O campo Tipo não pode exceder 60 caracteres")]
        public String Tipo { get; set; }

        [Required(ErrorMessage = "O campo Layout é de preenchimento obrigatório")]
        [RegularExpression("^(Bordado|Estampa|Liso)$", ErrorMessage = "O campo Layout deve ser 'Bordado', 'Estampa' ou 'Liso'")]
        [MaxLength(60, ErrorMessage = "O campo Layout não pode exceder 60 caracteres")]
        public String Layout { get; set; }

    }
}
