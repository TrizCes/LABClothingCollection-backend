using ClothingCollectionAPI.Models;
using System;

namespace ClothingCollectionAPI.DTO.Response
{
    public class ColecaoResponseDTO
    {
        public int Id { get; set; }
        public String NomeColecao { get; set; }
        public int IdResponsavel { get; set; }
        private Usuario Usuario { get; set; }
        public String Marca { get; set; }
        public double Orcamento { get; set; }
        public DateTime AnoLancamento { get; set; }
        public string Estacao { get; set; }
        public string EstadoSistema { get; set; }

        public static implicit operator ColecaoResponseDTO(Colecao colecao)
        {
            ColecaoResponseDTO colecaoDTO = new ColecaoResponseDTO
            {
                NomeColecao = colecao.NomeColecao,
                IdResponsavel = colecao.IdResponsavel,
                Marca = colecao.Marca,
                Orcamento = colecao.Orcamento,
                AnoLancamento = colecao.AnoLancamento,
                Estacao = colecao.Estacao.ToString(),
                EstadoSistema = colecao.EstadoSistema.ToString()
            };
            return colecaoDTO;
        }
    }
}
