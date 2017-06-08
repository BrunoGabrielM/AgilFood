using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AgilFood.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    FornecedorId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.FornecedorId);
                });

            migrationBuilder.CreateTable(
                name: "Cardapios",
                columns: table => new
                {
                    CardapioId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FornecedorId = table.Column<long>(nullable: true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cardapios", x => x.CardapioId);
                    table.ForeignKey(
                        name: "FK_Cardapios_Fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedores",
                        principalColumn: "FornecedorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    ServicoId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FornecedorId = table.Column<long>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Preco = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.ServicoId);
                    table.ForeignKey(
                        name: "FK_Servicos_Fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedores",
                        principalColumn: "FornecedorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Itens",
                columns: table => new
                {
                    ItemId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CardapioId = table.Column<long>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Preco = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itens", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Itens_Cardapios_CardapioId",
                        column: x => x.CardapioId,
                        principalTable: "Cardapios",
                        principalColumn: "CardapioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cardapios_FornecedorId",
                table: "Cardapios",
                column: "FornecedorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Itens_CardapioId",
                table: "Itens",
                column: "CardapioId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_FornecedorId",
                table: "Servicos",
                column: "FornecedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Itens");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Cardapios");

            migrationBuilder.DropTable(
                name: "Fornecedores");
        }
    }
}
