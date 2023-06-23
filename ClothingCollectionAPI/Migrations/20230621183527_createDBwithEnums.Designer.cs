﻿// <auto-generated />
using System;
using ClothingCollectionAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClothingCollectionAPI.Migrations
{
    [DbContext(typeof(LabClothingCollectionContext))]
    [Migration("20230621183527_createDBwithEnums")]
    partial class createDBwithEnums
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClothingCollectionAPI.Models.Colecao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AnoLancamento")
                        .HasColumnType("datetime2");

                    b.Property<int>("Estacao")
                        .HasColumnType("int");

                    b.Property<int>("EstadoSistema")
                        .HasColumnType("int");

                    b.Property<int>("IdResponsavel")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NomeColecao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<double>("Orcamento")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Colecoes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnoLancamento = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Estacao = 0,
                            EstadoSistema = 0,
                            IdResponsavel = 1,
                            Marca = "Brasília Fashion",
                            NomeColecao = "Floresta Urbana",
                            Orcamento = 2000.0
                        },
                        new
                        {
                            Id = 2,
                            AnoLancamento = new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Estacao = 3,
                            EstadoSistema = 0,
                            IdResponsavel = 2,
                            Marca = "Rio Style",
                            NomeColecao = "Tropical Vibes",
                            Orcamento = 1500.0
                        },
                        new
                        {
                            Id = 3,
                            AnoLancamento = new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Estacao = 1,
                            EstadoSistema = 1,
                            IdResponsavel = 3,
                            Marca = "São Paulo Couture",
                            NomeColecao = "Retro Chic",
                            Orcamento = 3000.0
                        },
                        new
                        {
                            Id = 4,
                            AnoLancamento = new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Estacao = 0,
                            EstadoSistema = 0,
                            IdResponsavel = 4,
                            Marca = "Gothic Glam",
                            NomeColecao = "Dark Elegance",
                            Orcamento = 2500.0
                        },
                        new
                        {
                            Id = 5,
                            AnoLancamento = new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Estacao = 2,
                            EstadoSistema = 0,
                            IdResponsavel = 5,
                            Marca = "Bahia Bohemia",
                            NomeColecao = "Boho Dreams",
                            Orcamento = 1800.0
                        });
                });

            modelBuilder.Entity("ClothingCollectionAPI.Models.Modelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdColecao")
                        .HasColumnType("int");

                    b.Property<int>("Layout")
                        .HasColumnType("int");

                    b.Property<string>("NomeModelo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdColecao");

                    b.ToTable("Modelos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdColecao = 1,
                            Layout = 2,
                            NomeModelo = "Saia Transpassada",
                            Tipo = 8
                        },
                        new
                        {
                            Id = 2,
                            IdColecao = 2,
                            Layout = 0,
                            NomeModelo = "Conjunto Rio'n",
                            Tipo = 1
                        },
                        new
                        {
                            Id = 3,
                            IdColecao = 3,
                            Layout = 2,
                            NomeModelo = "Pantalona",
                            Tipo = 4
                        },
                        new
                        {
                            Id = 4,
                            IdColecao = 4,
                            Layout = 2,
                            NomeModelo = "Coturno",
                            Tipo = 5
                        },
                        new
                        {
                            Id = 5,
                            IdColecao = 5,
                            Layout = 1,
                            NomeModelo = "Delicate",
                            Tipo = 6
                        });
                });

            modelBuilder.Entity("ClothingCollectionAPI.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CpfOuCnpj")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Genero")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("StatusUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CpfOuCnpj = "123.456.789-00",
                            DataNascimento = new DateTime(1995, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "maria@mail.com",
                            Genero = "Feminino",
                            NomeCompleto = "Maria Clara Soares",
                            StatusUsuario = 0,
                            Telefone = "(47) 98895-7456",
                            TipoUsuario = 1
                        },
                        new
                        {
                            Id = 2,
                            CpfOuCnpj = "987.654.321-00",
                            DataNascimento = new DateTime(1988, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "joao@mail.com",
                            Genero = "Masculino",
                            NomeCompleto = "João da Silva",
                            StatusUsuario = 0,
                            Telefone = "(47) 97777-1234",
                            TipoUsuario = 2
                        },
                        new
                        {
                            Id = 3,
                            CpfOuCnpj = "111.222.333-44",
                            DataNascimento = new DateTime(1990, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "ana@mail.com",
                            Genero = "Feminino",
                            NomeCompleto = "Ana Oliveira",
                            StatusUsuario = 0,
                            Telefone = "(47) 94444-5678",
                            TipoUsuario = 3
                        },
                        new
                        {
                            Id = 4,
                            CpfOuCnpj = "555.666.777-88",
                            DataNascimento = new DateTime(1992, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "pedro@mail.com",
                            Genero = "Masculino",
                            NomeCompleto = "Pedro Santos",
                            StatusUsuario = 1,
                            Telefone = "(47) 93333-9876",
                            TipoUsuario = 0
                        },
                        new
                        {
                            Id = 5,
                            CpfOuCnpj = "999.888.777-66",
                            DataNascimento = new DateTime(1985, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "carolina@mail.com",
                            Genero = "Feminino",
                            NomeCompleto = "Carolina Fernandes",
                            StatusUsuario = 0,
                            Telefone = "(47) 91111-2222",
                            TipoUsuario = 0
                        });
                });

            modelBuilder.Entity("ClothingCollectionAPI.Models.Modelo", b =>
                {
                    b.HasOne("ClothingCollectionAPI.Models.Colecao", "Colecao")
                        .WithMany()
                        .HasForeignKey("IdColecao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Colecao");
                });
#pragma warning restore 612, 618
        }
    }
}