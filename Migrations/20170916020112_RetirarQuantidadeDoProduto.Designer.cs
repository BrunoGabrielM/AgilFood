﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AgilFood.Persistence;

namespace AgilFood.Migrations
{
    [DbContext(typeof(AgilFoodDbContext))]
    [Migration("20170916020112_RetirarQuantidadeDoProduto")]
    partial class RetirarQuantidadeDoProduto
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AgilFood.Core.Models.Cardapio", b =>
                {
                    b.Property<int>("CardapioId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FornecedorId");

                    b.Property<string>("Nome");

                    b.HasKey("CardapioId");

                    b.HasIndex("FornecedorId");

                    b.ToTable("Cardapios");
                });

            modelBuilder.Entity("AgilFood.Core.Models.Fornecedor", b =>
                {
                    b.Property<int>("FornecedorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Celular");

                    b.Property<string>("Email");

                    b.Property<string>("EnderecoBairro");

                    b.Property<string>("EnderecoCEP");

                    b.Property<string>("EnderecoCidade");

                    b.Property<int>("EnderecoNumero");

                    b.Property<string>("EnderecoRua");

                    b.Property<string>("Nome");

                    b.Property<string>("Telefone");

                    b.HasKey("FornecedorId");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("AgilFood.Core.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CardapioId");

                    b.Property<string>("Descricao");

                    b.Property<string>("Nome");

                    b.Property<double>("Preco");

                    b.HasKey("ItemId");

                    b.HasIndex("CardapioId");

                    b.ToTable("Itens");
                });

            modelBuilder.Entity("AgilFood.Core.Models.Pedido", b =>
                {
                    b.Property<int>("PedidoId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataPedido");

                    b.Property<string>("EmailUsuario");

                    b.Property<string>("NomeUsuario");

                    b.HasKey("PedidoId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("AgilFood.Core.Models.PedidoItem", b =>
                {
                    b.Property<int>("ItemId");

                    b.Property<int>("PedidoId");

                    b.HasKey("ItemId", "PedidoId");

                    b.HasIndex("PedidoId");

                    b.ToTable("PedidoItens");
                });

            modelBuilder.Entity("AgilFood.Core.models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("FornecedorId");

                    b.HasKey("Id");

                    b.HasIndex("FornecedorId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("AgilFood.Core.Models.Servico", b =>
                {
                    b.Property<int>("ServicoId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FornecedorId");

                    b.Property<string>("Nome");

                    b.Property<double>("Preco");

                    b.HasKey("ServicoId");

                    b.HasIndex("FornecedorId");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("AgilFood.Core.Models.Cardapio", b =>
                {
                    b.HasOne("AgilFood.Core.Models.Fornecedor", "Fornecedor")
                        .WithMany("Cardapios")
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AgilFood.Core.Models.Item", b =>
                {
                    b.HasOne("AgilFood.Core.Models.Cardapio", "Cardapio")
                        .WithMany("Itens")
                        .HasForeignKey("CardapioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AgilFood.Core.Models.PedidoItem", b =>
                {
                    b.HasOne("AgilFood.Core.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AgilFood.Core.Models.Pedido", "Pedido")
                        .WithMany("Itens")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AgilFood.Core.models.Photo", b =>
                {
                    b.HasOne("AgilFood.Core.Models.Fornecedor")
                        .WithMany("Photos")
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AgilFood.Core.Models.Servico", b =>
                {
                    b.HasOne("AgilFood.Core.Models.Fornecedor", "Fornecedor")
                        .WithMany("Servicos")
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
