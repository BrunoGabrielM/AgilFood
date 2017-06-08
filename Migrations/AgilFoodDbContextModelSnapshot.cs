using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AgilFood.Persistence;

namespace AgilFood.Migrations
{
    [DbContext(typeof(AgilFoodDbContext))]
    partial class AgilFoodDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AgilFood.Models.Cardapio", b =>
                {
                    b.Property<long?>("CardapioId")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("FornecedorId");

                    b.Property<string>("Nome");

                    b.HasKey("CardapioId");

                    b.HasIndex("FornecedorId")
                        .IsUnique();

                    b.ToTable("Cardapios");
                });

            modelBuilder.Entity("AgilFood.Models.Fornecedor", b =>
                {
                    b.Property<long?>("FornecedorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("FornecedorId");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("AgilFood.Models.Item", b =>
                {
                    b.Property<long?>("ItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("CardapioId");

                    b.Property<string>("Nome");

                    b.Property<double>("Preco");

                    b.HasKey("ItemId");

                    b.HasIndex("CardapioId");

                    b.ToTable("Itens");
                });

            modelBuilder.Entity("AgilFood.Models.Servico", b =>
                {
                    b.Property<long?>("ServicoId")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("FornecedorId");

                    b.Property<string>("Nome");

                    b.Property<double>("Preco");

                    b.HasKey("ServicoId");

                    b.HasIndex("FornecedorId");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("AgilFood.Models.Cardapio", b =>
                {
                    b.HasOne("AgilFood.Models.Fornecedor", "Fornecedor")
                        .WithOne("Cardapio")
                        .HasForeignKey("AgilFood.Models.Cardapio", "FornecedorId");
                });

            modelBuilder.Entity("AgilFood.Models.Item", b =>
                {
                    b.HasOne("AgilFood.Models.Cardapio", "Cardapio")
                        .WithMany("Itens")
                        .HasForeignKey("CardapioId");
                });

            modelBuilder.Entity("AgilFood.Models.Servico", b =>
                {
                    b.HasOne("AgilFood.Models.Fornecedor", "Fornecedor")
                        .WithMany("Servicos")
                        .HasForeignKey("FornecedorId");
                });
        }
    }
}
