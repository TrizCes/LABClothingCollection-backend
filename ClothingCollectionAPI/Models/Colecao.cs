using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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
        public Usuario Usuario { get; set; }

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
        [RegularExpression("^(Outono|Inverno|Primavera|Verão)$", ErrorMessage = "O campo Estação deve ser 'Outono', 'Inverno', 'Primavera' ou 'Verão'")]
        [MaxLength(60, ErrorMessage = "O campo Estação não pode exceder 60 caracteres")]
        public String Estacao { get; set; }

        [Required(ErrorMessage = "O campo Estado no Sistema é de preenchimento obrigatório")]
        [RegularExpression("^(Ativa|Inativa)$", ErrorMessage = "O campo Estado no Sistema deve ser 'Ativa' ou 'Inativa'")]
        [MaxLength(60, ErrorMessage = "O campo Estação não pode exceder 60 caracteres")]
        public String EstadoSistema { get; set; }
    }
}
