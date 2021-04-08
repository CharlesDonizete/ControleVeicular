using ControleVeicular.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleVeicular
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Marca>().HasKey(t => t.Id);
            modelBuilder.Entity<Marca>().HasMany(t => t.Modelos).WithOne(t => t.Marca);
            modelBuilder.Entity<Marca>().HasMany(t => t.Anuncios).WithOne(t => t.Marca);

            modelBuilder.Entity<Modelo>().HasKey(t => t.Id);
            //modelBuilder.Entity<Modelo>().HasMany(t => t.Anuncios).WithOne(t => t.Modelo);

            modelBuilder.Entity<Anuncio>().HasKey(t => t.Id);
            modelBuilder.Entity<Anuncio>().HasOne(t => t.Modelo).WithOne(t => t.Anuncio);
            //modelBuilder.Entity<Anuncio>().HasOne(t => t.Marca).WithOne(t => t.Anuncio);
        }
    }
}
