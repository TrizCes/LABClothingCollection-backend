using ClothingCollectionAPI.Models;
using System;

namespace ClothingCollectionAPI.DTO.Response
{
    public class ModeloResponseDTO
    {
        public int Id { get; set; }

        public String NomeModelo { get; set; }

        public int IdColecao { get; set; }
        private Colecao Colecao { get; set; }

        public string Tipo { get; set; }

        public string Layout { get; set; }

        public static implicit operator ModeloResponseDTO(Modelo modelo)
        {
            ModeloResponseDTO modeloDTO = new ModeloResponseDTO
            {
                NomeModelo = modelo.NomeModelo,
                IdColecao = modelo.IdColecao,
                Tipo = modelo.Tipo.ToString(),
                Layout = modelo.Layout.ToString()
            };
            return modeloDTO;
        }
    }
}
