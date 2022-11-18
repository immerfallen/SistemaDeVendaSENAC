﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaDeVenda.Server.Infra;

namespace SistemaDeVenda.Server.Migrations
{
    [DbContext(typeof(SistemaDeVendaContext))]
    partial class SistemaDeVendaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SistemaDeVenda.Server.Domain.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF_CNPJ")
                        .HasMaxLength(14);

                    b.Property<string>("Email")
                        .HasMaxLength(45);

                    b.Property<string>("Nome")
                        .HasMaxLength(255);

                    b.Property<string>("Senha")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .IsUnique()
                        .HasFilter("[Nome] IS NOT NULL");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("SistemaDeVenda.Server.Domain.ItensVenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProdutoId");

                    b.Property<int>("VendaId");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("VendaId");

                    b.ToTable("ItensVenda");
                });

            modelBuilder.Entity("SistemaDeVenda.Server.Domain.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasMaxLength(45);

                    b.Property<string>("LinkFoto");

                    b.Property<string>("Nome")
                        .HasMaxLength(45);

                    b.Property<decimal>("PrecoUnitario");

                    b.Property<decimal>("QuantidadeEstoque");

                    b.Property<string>("UnidadeMedida");

                    b.HasKey("Id");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("SistemaDeVenda.Server.Domain.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasMaxLength(45);

                    b.Property<string>("NomeCompleto")
                        .HasMaxLength(255);

                    b.Property<int>("Papel");

                    b.Property<string>("Senha")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("SistemaDeVenda.Server.Domain.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId");

                    b.Property<DateTime>("Data")
                        .HasColumnType("Date");

                    b.Property<int>("VendedorId");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("VendedorId");

                    b.ToTable("Venda");
                });

            modelBuilder.Entity("SistemaDeVenda.Server.Domain.Vendedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasMaxLength(45);

                    b.Property<string>("Nome")
                        .HasMaxLength(255);

                    b.Property<string>("Senha")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Vendedor");
                });

            modelBuilder.Entity("SistemaDeVenda.Server.Domain.ItensVenda", b =>
                {
                    b.HasOne("SistemaDeVenda.Server.Domain.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SistemaDeVenda.Server.Domain.Venda", "Venda")
                        .WithMany()
                        .HasForeignKey("VendaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SistemaDeVenda.Server.Domain.Venda", b =>
                {
                    b.HasOne("SistemaDeVenda.Server.Domain.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SistemaDeVenda.Server.Domain.Vendedor", "Vendedor")
                        .WithMany()
                        .HasForeignKey("VendedorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
