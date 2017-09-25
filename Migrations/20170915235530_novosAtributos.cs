using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilFood.Migrations
{
    public partial class novosAtributos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Itens",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Fornecedores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Fornecedores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnderecoBairro",
                table: "Fornecedores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnderecoCEP",
                table: "Fornecedores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnderecoCidade",
                table: "Fornecedores",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnderecoNumero",
                table: "Fornecedores",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EnderecoRua",
                table: "Fornecedores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Fornecedores",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Itens");

            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "EnderecoBairro",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "EnderecoCEP",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "EnderecoCidade",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "EnderecoNumero",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "EnderecoRua",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Fornecedores");
        }
    }
}
