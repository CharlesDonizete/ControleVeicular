using ControleVeicular.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleVeicular
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Anuncio> Anuncio { get; set; }
        public DbSet<Modelo> Modelo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Marca>().HasKey(t => t.Id);
           
            modelBuilder.Entity<Modelo>().HasKey(t => t.Id);            
         
            modelBuilder.Entity<Anuncio>().HasKey(t => t.Id);
        }

      
    }
}
