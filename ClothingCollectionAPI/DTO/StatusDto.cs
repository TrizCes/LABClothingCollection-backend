using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingCollectionAPI.DTO
{
    public class StatusDto
    {
        [RegularExpression("^(Ativa|Inativa)$", ErrorMessage = "O campo deve ser 'Ativa' ou 'Inativa'")]
        public String? Status { get; set; }
    }
}
