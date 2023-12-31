﻿using System;
using Microsoft.EntityFrameworkCore;
using ClothingCollectionAPI.Models;

namespace ClothingCollectionAPI.Context
{
    public class LabClothingCollectionContext : DbContext
    {
        public LabClothingCollectionContext(DbContextOptions<LabClothingCollectionContext> options)
            : base(options)
        {
        }

        public LabClothingCollectionContext() { }

        public DbSet<ClothingCollectionAPI.Models.Usuario> Usuarios { get; set; }
        public DbSet<ClothingCollectionAPI.Models.Colecao> Colecoes { get; set; }
        public DbSet<ClothingCollectionAPI.Models.Modelo> Modelos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("ServerConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(
                            new Usuario
                            {
                                Id = 1,
                                NomeCompleto = "Maria Clara Soares",
                                Genero = "Feminino",
                                DataNascimento = new DateTime(1995, 07, 03),
                                CpfOuCnpj = "123.456.789-00",
                                Telefone = "(47) 98895-7456",
                                Email = "maria@mail.com",
                                TipoUsuario = Models.Enums.EnumTipoUsuario.Gerente,
                                StatusUsuario = 0,
                            },
                            new Usuario
                            {
                                Id = 2,
                                NomeCompleto = "João da Silva",
                                Genero = "Masculino",
                                DataNascimento = new DateTime(1988, 05, 15),
                                CpfOuCnpj = "987.654.321-00",
                                Telefone = "(47) 97777-1234",
                                Email = "joao@mail.com",
                                TipoUsuario = Models.Enums.EnumTipoUsuario.Criador,
                                StatusUsuario = 0
                            },
                            new Usuario
                            {
                                Id = 3,
                                NomeCompleto = "Ana Oliveira",
                                Genero = "Feminino",
                                DataNascimento = new DateTime(1990, 12, 22),
                                CpfOuCnpj = "111.222.333-44",
                                Telefone = "(47) 94444-5678",
                                Email = "ana@mail.com",
                                TipoUsuario = Models.Enums.EnumTipoUsuario.Outro,
                                StatusUsuario = 0
                            },
                            new Usuario
                            {
                                Id = 4,
                                NomeCompleto = "Pedro Santos",
                                Genero = "Masculino",
                                DataNascimento = new DateTime(1992, 03, 10),
                                CpfOuCnpj = "555.666.777-88",
                                Telefone = "(47) 93333-9876",
                                Email = "pedro@mail.com",
                                TipoUsuario = 0,
                                StatusUsuario = Models.Enums.EnumStatus.Inativo
                            },
                            new Usuario
                            {
                                Id = 5,
                                NomeCompleto = "Carolina Fernandes",
                                Genero = "Feminino",
                                DataNascimento = new DateTime(1985, 08, 18),
                                CpfOuCnpj = "999.888.777-66",
                                Telefone = "(47) 91111-2222",
                                Email = "carolina@mail.com",
                                TipoUsuario = 0,
                                StatusUsuario = 0
                            });

            modelBuilder.Entity<Colecao>().HasData(
                            new Colecao
                            {
                                Id = 1,
                                NomeColecao = "Floresta Urbana",
                                IdResponsavel = 1,
                                Marca = "Brasília Fashion",
                                Orcamento = 2000.00,
                                AnoLancamento = new DateTime(2023, 1, 1),
                                Estacao = 0,
                                EstadoSistema = 0
                            },
                            new Colecao
                            {
                                Id = 2,
                                NomeColecao = "Tropical Vibes",
                                IdResponsavel = 2,
                                Marca = "Rio Style",
                                Orcamento = 1500.00,
                                AnoLancamento = new DateTime(2023, 4, 15),
                                Estacao = Models.Enums.EnumEstacao.Verao,
                                EstadoSistema = 0
                             },
                            new Colecao
                            {
                                Id = 3,
                                NomeColecao = "Retro Chic",
                                IdResponsavel = 3,
                                Marca = "São Paulo Couture",
                                Orcamento = 3000.00,
                                AnoLancamento = new DateTime(2023, 9, 1),
                                Estacao = Models.Enums.EnumEstacao.Inverno,
                                EstadoSistema = Models.Enums.EnumStatus.Inativo
                            },
                            new Colecao
                            {
                                Id = 4,
                                NomeColecao = "Dark Elegance",
                                IdResponsavel = 4,
                                Marca = "Gothic Glam",
                                Orcamento = 2500.00,
                                AnoLancamento = new DateTime(2023, 6, 30),
                                Estacao = 0,
                                EstadoSistema = 0
                            },
                            new Colecao
                            {
                                Id = 5,
                                NomeColecao = "Boho Dreams",
                                IdResponsavel = 5,
                                Marca = "Bahia Bohemia",
                                Orcamento = 1800.00,
                                AnoLancamento = new DateTime(2023, 2, 10),
                                Estacao = Models.Enums.EnumEstacao.Primavera,
                                EstadoSistema = 0
                            });

            modelBuilder.Entity<Modelo>().HasData(
                            new Modelo
                            {
                                Id = 1,
                                NomeModelo = "Saia Transpassada",
                                IdColecao = 1,
                                Tipo = Models.Enums.EnumTipoModelo.Saia, 
                                Layout = Models.Enums.EnumLayout.Liso
                            },
                            new Modelo
                            {
                                Id = 2,
                                NomeModelo = "Conjunto Rio'n",
                                IdColecao = 2,
                                Tipo = Models.Enums.EnumTipoModelo.Biquini,
                                Layout = Models.Enums.EnumLayout.Bordado
                            },
                            new Modelo
                            {
                                Id = 3,
                                NomeModelo = "Pantalona",
                                IdColecao = 3,
                                Tipo = Models.Enums.EnumTipoModelo.Calca,
                                Layout = Models.Enums.EnumLayout.Liso
                            },
                            new Modelo
                            {
                                Id = 4,
                                NomeModelo = "Coturno",
                                IdColecao = 4,
                                Tipo = Models.Enums.EnumTipoModelo.Calcados,
                                Layout = Models.Enums.EnumLayout.Liso
                            },
                            new Modelo
                            {
                                Id = 5,
                                NomeModelo = "Delicate",
                                IdColecao = 5,
                                Tipo = Models.Enums.EnumTipoModelo.Camisa,
                                Layout = Models.Enums.EnumLayout.Estampa
                            });
        }
    }
}
