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
        public UsuariosContext (DbContextOptions<UsuariosContext> options)
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
    }
}
