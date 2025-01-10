using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options): base(options) { }

        public DbSet<Series> Series { get; set; }
       public DbSet<Generos> Generos { get; set; }
        public DbSet<Productora> Productoras { get; set; }
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                base.OnModelCreating(modelBuilder); 

            #region "Tablas"
            modelBuilder.Entity<Series>().ToTable("Series");
            modelBuilder.Entity<Generos>().ToTable("Generos");
            modelBuilder.Entity<Productora>().ToTable("Productoras");
            #endregion

            #region "Llaves Primarias"
           modelBuilder.Entity<Series>().HasKey(s => s.Id);
            modelBuilder.Entity<Generos>().HasKey(g => g.Id);
            modelBuilder.Entity<Productora>().HasKey(p => p.Id);
            #endregion

            #region "Relaciones"

            #region "Generos y Series"
            modelBuilder.Entity<Generos>()
                .HasMany<Series>(g => g.Series)
                .WithMany(s => s.Generos);
           
            #endregion

            #region "Series y Productoras"

            modelBuilder.Entity<Productora>().HasOne(p => p.Series).WithOne(s => s.Productora)
                 .HasForeignKey<Series>(s => s.ProductoraId);

            modelBuilder.Entity<Series>()
         .HasIndex(s => s.ProductoraId)
         .IsUnique(false);

            #endregion

            #endregion

            #region "Configuracion de Propiedades"

            #region "Series"
            modelBuilder.Entity<Series>().Property(s => s.NombreSerie).IsRequired();
           modelBuilder.Entity<Series>().Property(s => s.ProductoraId).IsRequired();
            modelBuilder.Entity<Series>().Property(s => s.ImagenPortada).IsRequired();  
            modelBuilder.Entity<Series>().Property(s => s.EnlaceVideo).IsRequired();
            modelBuilder.Entity<Series>().Property(s => s.GeneroId).IsRequired();
            modelBuilder.Entity<Series>().Property(s => s.GeneroSecundarioId).IsRequired(false); 
            #endregion

            #region "Generos"
            modelBuilder.Entity<Generos>().Property(g => g.NombreGenero).IsRequired();
            #endregion

            #region "Productora"
            modelBuilder.Entity<Productora>().Property(p => p.NombreProductora).IsRequired();
            #endregion

            #endregion
         
            
        }
    }
}
