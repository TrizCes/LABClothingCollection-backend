using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClothingCollectionAPI.Models;

namespace ClothingCollectionAPI.Context
{
    public class UsuariosContext : DbContext
    {
        public UsuariosContext(DbContextOptions<UsuariosContext> options)
            : base(options)
        {
        }

        public UsuariosContext() { }

        public virtual DbSet<ClothingCollectionAPI.Models.Usuario> Usuarios { get; set; }

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
                                TipoUsuario = "Gerente",
                                StatusUsuario = "Ativo",
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
                                TipoUsuario = "Criador",
                                StatusUsuario = "Ativo"
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
                                TipoUsuario = "Administrador",
                                StatusUsuario = "Ativo"
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
                                TipoUsuario = "Outro",
                                StatusUsuario = "Inativo"
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
                                TipoUsuario = "Outro",
                                StatusUsuario = "Ativo"
                            }
               );

        }
    }
}
