using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace AlimentoMascotas.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<EAlimento> Alimento { get; set; } // Crea una tabla en la base de datos con la estructura de la entidad establecida
        public DbSet<EEspecie> Especie { get; set; }
        public DbSet<EEtapa> Etapa { get; set; }
        public DbSet<EMarca> Marca { get; set; }
        public DbSet<ESize> Size { get; set; }
        public DbSet<EIngrediente> Ingrediente { get; set; }
        public DbSet<EAditivo> Aditivo { get; set; }
        public DbSet<EAnalitico> Analitico { get; set; }
        public DbSet<ESizeEnAlimento> SizeEnAlimento { get; set; }
        public DbSet<EIngredienteEnAlimento> IngredienteEnAlimento { get; set; }
        public DbSet<EAditivoEnAlimento> AditivoEnAlimento { get; set; }
        public DbSet<EAnaliticoEnAlimento> AnaliticoEnAlimento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-9LP34N0;Initial Catalog=AlimentoMascotasDB;Persist Security Info=True;User ID=sa;Password=aDEdE9EM");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EAlimento>()
                .HasIndex(e => e.MarcaId)
                .IsUnique(false);
            modelBuilder.Entity<EAlimento>()
                .HasIndex(e => e.EspecieId)
                .IsUnique(false);
            modelBuilder.Entity<EAlimento>()
                .HasIndex(e => e.EtapaId)
                .IsUnique(false);

            modelBuilder.Entity<ESizeEnAlimento>()
                .HasKey(e => new { e.SizeId, e.AlimentoId });
            modelBuilder.Entity<EIngredienteEnAlimento>()
                .HasKey(e => new { e.IngredienteId, e.AlimentoId });
            modelBuilder.Entity<EAditivoEnAlimento>()
                .HasKey(e => new { e.AditivoId, e.AlimentoId });
            modelBuilder.Entity<EAnaliticoEnAlimento>()
                .HasKey(e => new { e.AnaliticoId, e.AlimentoId });

            SeedData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            List<EMarca> marcas = new()
            {
                new EMarca { Id = 1, Name = "Raza" }
            };

            List<EEspecie> especies = new()
            {
                new EEspecie { Id = 1, Name = "Gato" },
                new EEspecie { Id = 2, Name = "Perro" }
            };

            List<EEtapa> etapas = new()
            {
                new EEtapa { Id = 1, Name = "Adulto" },
                new EEtapa { Id = 2, Name = "Cachorro" },
                new EEtapa { Id = 3, Name = "Senior"},
            };

            List<EAlimento> alimentos = new()
            {
                new EAlimento
                {
                    Id = 1,
                    Name = "Alimento Raza para perros adultos sabor Pollo, Carne, Cereales y Arroz",
                    MarcaId = 1,
                    EspecieId = 2,
                    EtapaId = 1,
                    LastUpdate = DateTime.UtcNow,
                }
            };

            List<ESize> sizes = new()
            {
                new ESize { Id = 1, Size = 1.5M },
                new ESize { Id = 2, Size = 3M },
                new ESize { Id = 3, Size = 8M },
                new ESize { Id = 4, Size = 15M },
                new ESize { Id = 5, Size = 21M },
            };

            List<EIngrediente> ingredientes = new()
            {
                new EIngrediente { Id = 1, Name = "Res" },
                new EIngrediente { Id = 2, Name = "Pollo" },
                new EIngrediente { Id = 3, Name = "Salmón" },
                new EIngrediente { Id = 4, Name = "Cerdo" },
                new EIngrediente { Id = 5, Name = "Harina de res" },
                new EIngrediente { Id = 6, Name = "Harina de pollo" },
                new EIngrediente { Id = 7, Name = "Harina de salmón" },
                new EIngrediente { Id = 8, Name = "Harina de cerdo" },
                new EIngrediente { Id = 9, Name = "Subproducto de res" },
                new EIngrediente { Id = 10, Name = "Subproducto de pollo" },
                new EIngrediente { Id = 11, Name = "Subproducto de salmón" },
                new EIngrediente { Id = 12, Name = "Subproducto de cerdo" },
                new EIngrediente { Id = 13, Name = "Maíz" },
                new EIngrediente { Id = 14, Name = "Proteina de ave deshidratada" },
                new EIngrediente { Id = 15, Name = "Harina de maíz" },
                new EIngrediente { Id = 16, Name = "Grasas animales" },
                new EIngrediente { Id = 17, Name = "Proteina de cerdi deshidratada" },
                new EIngrediente { Id = 18, Name = "Hidrolizado de proteinas animales" },
                new EIngrediente { Id = 19, Name = "Pulpa de remolacha" },
                new EIngrediente { Id = 20, Name = "Gluten de maíz" },
                new EIngrediente { Id = 21, Name = "Minerales" },
                new EIngrediente { Id = 22, Name = "Aceite de pescado" },
                new EIngrediente { Id = 23, Name = "Aceite de soja" },
                new EIngrediente { Id = 24, Name = "Levaduras" },
                new EIngrediente { Id = 25, Name = "Hidrolizado de crustáceo", Description = "Fuente de glucosamina" },
                new EIngrediente { Id = 26, Name = "Hidrolizado de cartílago", Description = "Fuente de codroitina" },
            };

            List<EAditivo> aditivos = new()
            {
                new EAditivo { Id = 1, Name = "Vitamina A" },
                new EAditivo { Id = 2, Name = "Vitamina D3" },
                new EAditivo { Id = 3, Name = "E1 (Hierro)" },
                new EAditivo { Id = 4, Name = "E2 (Yodo)" },
                new EAditivo { Id = 5, Name = "E4 (Cobre)" },
                new EAditivo { Id = 6, Name = "E5 (Manganeso)" },
                new EAditivo { Id = 7, Name = "E6 (Zinc)" },
                new EAditivo { Id = 8, Name = "E8 (Selenio)" },
                new EAditivo { Id = 9, Name = "Conservantes" },
                new EAditivo { Id = 10, Name = "Antioxidantes" },
            };

            List<EAnalitico> analiticos = new()
            {
                new EAnalitico { Id = 1, Name = "Proteina" },
                new EAnalitico { Id = 2, Name = "Grasa" },
                new EAnalitico { Id = 3, Name = "Ceniza" },
                new EAnalitico { Id = 4, Name = "Fibras" },
                new EAnalitico { Id = 5, Name = "Ácidos grasos omega" },
                new EAnalitico { Id = 6, Name = "EPA/DHA" },
                new EAnalitico { Id = 7, Name = "Humedad" },
                new EAnalitico { Id = 8, Name = "Calcio" },
                new EAnalitico { Id = 9, Name = "Fósforo" },
                new EAnalitico { Id = 10, Name = "Energía" },
            };

            List<ESizeEnAlimento> sizesEnAlimentos = new()
            {
                new ESizeEnAlimento { AlimentoId = 1, SizeId = 1 },
                new ESizeEnAlimento { AlimentoId = 1, SizeId = 2 },
                new ESizeEnAlimento { AlimentoId = 1, SizeId = 3 },
                new ESizeEnAlimento { AlimentoId = 1, SizeId = 4 },
                new ESizeEnAlimento { AlimentoId = 1, SizeId = 5 },
            };

            List<EIngredienteEnAlimento> ingredientesEnAlimentos = new()
            {
                //new EIngredienteEnAlimento { AlimentoId = 1, IngredienteId = 1, QuantityPer = 1M },
            };

            List<EAditivoEnAlimento> aditivosEnAlimentos = new()
            {
                //new EAditivoEnAlimento { AlimentoId = 1, AditivoId = 1, QuantityPer = 1M },
            };

            List<EAnaliticoEnAlimento> analiticosEnAlimentos = new()
            {
                new EAnaliticoEnAlimento { AlimentoId = 1, AnaliticoId = 1, QuantityPer = 21M },
                new EAnaliticoEnAlimento { AlimentoId = 1, AnaliticoId = 2, QuantityPer = 9M },
                new EAnaliticoEnAlimento { AlimentoId = 1, AnaliticoId = 4, QuantityPer = 3.5M },
                new EAnaliticoEnAlimento { AlimentoId = 1, AnaliticoId = 3, QuantityPer = 10M },
                new EAnaliticoEnAlimento { AlimentoId = 1, AnaliticoId = 7, QuantityPer = 12M },
                new EAnaliticoEnAlimento { AlimentoId = 1, AnaliticoId = 8, QuantityPer = 2M },
                new EAnaliticoEnAlimento { AlimentoId = 1, AnaliticoId = 9, QuantityPer = 1.3M },
                new EAnaliticoEnAlimento { AlimentoId = 1, AnaliticoId = 10, QuantityGra = 3200M },
            };

            modelBuilder.Entity<EMarca>().HasData(marcas);
            modelBuilder.Entity<EEspecie>().HasData(especies);
            modelBuilder.Entity<EEtapa>().HasData(etapas);
            modelBuilder.Entity<EAlimento>().HasData(alimentos);
            modelBuilder.Entity<ESize>().HasData(sizes);
            modelBuilder.Entity<EIngrediente>().HasData(ingredientes);
            modelBuilder.Entity<EAditivo>().HasData(aditivos);
            modelBuilder.Entity<EAnalitico>().HasData(analiticos);
            modelBuilder.Entity<ESizeEnAlimento>().HasData(sizesEnAlimentos);
            modelBuilder.Entity<EIngredienteEnAlimento>().HasData(ingredientesEnAlimentos);
            modelBuilder.Entity<EAditivoEnAlimento>().HasData(aditivosEnAlimentos);
            modelBuilder.Entity<EAnaliticoEnAlimento>().HasData(analiticosEnAlimentos);
        }
    }
}
