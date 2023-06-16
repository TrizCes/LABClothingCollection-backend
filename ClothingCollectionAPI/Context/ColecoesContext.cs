using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClothingCollectionAPI.Models;

    public class ColecoesContext : DbContext
    {
        public ColecoesContext (DbContextOptions<ColecoesContext> options)
            : base(options)
        {
        }

        public DbSet<ClothingCollectionAPI.Models.Colecao> Colecoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("ServerConnection");
            }
        }
    }
