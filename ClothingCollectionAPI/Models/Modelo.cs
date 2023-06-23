using ClothingCollectionAPI.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


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
        private Colecao Colecao { get; set; }

        [Required(ErrorMessage = "O campo Tipo é de preenchimento obrigatório")]
        public EnumTipoModelo Tipo { get; set; }

        [Required(ErrorMessage = "O campo Layout é de preenchimento obrigatório")]
        public EnumLayout Layout { get; set; }

    }
}
