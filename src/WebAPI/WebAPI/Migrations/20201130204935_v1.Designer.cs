﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI;

namespace WebAPI.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20201130204935_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAPI.Entities.endereco", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("bairro");

                    b.Property<string>("cep");

                    b.Property<string>("complemento");

                    b.Property<string>("localidade");

                    b.Property<string>("logradouro");

                    b.Property<string>("uf");

                    b.HasKey("id");

                    b.ToTable("endereco");
                });

            modelBuilder.Entity("WebAPI.Entities.pedido", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("enderecoId");

                    b.Property<decimal>("total");

                    b.HasKey("id");

                    b.HasIndex("enderecoId");

                    b.ToTable("pedido");
                });

            modelBuilder.Entity("WebAPI.Entities.prato", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nome");

                    b.Property<int?>("pedidoid");

                    b.Property<decimal>("preco");

                    b.Property<int>("quantidade");

                    b.Property<int>("restauranteId");

                    b.HasKey("id");

                    b.HasIndex("pedidoid");

                    b.HasIndex("restauranteId");

                    b.ToTable("prato");
                });

            modelBuilder.Entity("WebAPI.Entities.prato_pedido", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("id_pedido");

                    b.Property<int>("id_prato");

                    b.Property<int>("quantidade");

                    b.HasKey("id");

                    b.HasIndex("id_pedido");

                    b.HasIndex("id_prato");

                    b.ToTable("prato_pedido");
                });

            modelBuilder.Entity("WebAPI.Entities.restaurante", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nome");

                    b.HasKey("id");

                    b.ToTable("restaurante");
                });

            modelBuilder.Entity("WebAPI.Entities.pedido", b =>
                {
                    b.HasOne("WebAPI.Entities.endereco", "endereco")
                        .WithMany()
                        .HasForeignKey("enderecoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebAPI.Entities.prato", b =>
                {
                    b.HasOne("WebAPI.Entities.pedido")
                        .WithMany("pratos")
                        .HasForeignKey("pedidoid");

                    b.HasOne("WebAPI.Entities.restaurante", "restaurante")
                        .WithMany()
                        .HasForeignKey("restauranteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebAPI.Entities.prato_pedido", b =>
                {
                    b.HasOne("WebAPI.Entities.pedido", "pedido")
                        .WithMany("prato_pedido")
                        .HasForeignKey("id_pedido")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebAPI.Entities.prato", "prato")
                        .WithMany()
                        .HasForeignKey("id_prato")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}