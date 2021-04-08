﻿// <auto-generated />
using System;
using ControleVeicular;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ControleVeicular.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ControleVeicular.Models.Anuncio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ano")
                        .IsRequired();

                    b.Property<string>("Cor")
                        .IsRequired();

                    b.Property<DateTime>("DataVenda");

                    b.Property<int?>("MarcaId");

                    b.Property<int?>("ModeloId");

                    b.Property<string>("TipoCombustivel")
                        .IsRequired();

                    b.Property<decimal>("ValorCompra");

                    b.Property<decimal>("ValorVenda");

                    b.HasKey("Id");

                    b.HasIndex("MarcaId");

                    b.HasIndex("ModeloId");

                    b.ToTable("Anuncio");
                });

            modelBuilder.Entity("ControleVeicular.Models.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Marca");
                });

            modelBuilder.Entity("ControleVeicular.Models.Modelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<int>("MarcaId");

                    b.HasKey("Id");

                    b.HasIndex("MarcaId");

                    b.ToTable("Modelo");
                });

            modelBuilder.Entity("ControleVeicular.Models.Anuncio", b =>
                {
                    b.HasOne("ControleVeicular.Models.Marca", "Marca")
                        .WithMany("Anuncios")
                        .HasForeignKey("MarcaId");

                    b.HasOne("ControleVeicular.Models.Modelo", "Modelo")
                        .WithMany("Anuncios")
                        .HasForeignKey("ModeloId");
                });

            modelBuilder.Entity("ControleVeicular.Models.Modelo", b =>
                {
                    b.HasOne("ControleVeicular.Models.Marca", "Marca")
                        .WithMany("Modelos")
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
