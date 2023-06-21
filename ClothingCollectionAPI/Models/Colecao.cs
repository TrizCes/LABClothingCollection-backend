using ClothingCollectionAPI.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingCollectionAPI.Models
{
    public class Colecao
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é de preenchimento obrigatório")]
        [MaxLength(200, ErrorMessage = "O campo nome não pode exceder 200 caracteres")]
        public String NomeColecao { get; set; }

        [ForeignKey("Usuario")]
        [Required(ErrorMessage = "O Id do responsável é de preenchimento obrigatório")]
        public int IdResponsavel { get; set; }
        private Usuario Usuario { get; set; }

        [Required(ErrorMessage = "O campo Marca é de preenchimento obrigatório")]
        [MaxLength(100, ErrorMessage = "O campo marca não pode exceder 100 caracteres")]
        public String Marca { get; set; }

        [Required(ErrorMessage = "O campo Orçamento é de preenchimento obrigatório")]
        [DataType(DataType.Currency)]
        public double Orcamento { get; set; }

        [Required(ErrorMessage = "O campo Ano de lançamento é de preenchimento obrigatório")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        public DateTime AnoLancamento { get; set; }

        [Required(ErrorMessage = "O campo Estação é de preenchimento obrigatório")]
        public EnumEstacao Estacao { get; set; }

        [Required(ErrorMessage = "O campo Estado no Sistema é de preenchimento obrigatório")]
        public EnumStatus EstadoSistema { get; set; }
    }
}
