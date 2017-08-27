using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilFood.Migrations
{
    public partial class SeedFornecedores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT into Fornecedores (Nome) VALUES ('Popedi')");
            migrationBuilder.Sql("INSERT into Fornecedores (Nome) VALUES ('Chapao')");
            migrationBuilder.Sql("INSERT into Fornecedores (Nome) VALUES ('Kiburgao')");

            migrationBuilder.Sql("INSERT into Servicos (Nome, Preco, FornecedorId) VALUES ('Entrega', 5.00,(SELECT FornecedorId FROM Fornecedores WHERE Nome= 'Popedi'))");

            migrationBuilder.Sql("INSERT into Cardapios (Nome, FornecedorId) VALUES ('Bebidas', (SELECT FornecedorId FROM Fornecedores WHERE Nome= 'Popedi'))");
            migrationBuilder.Sql("INSERT into Cardapios (Nome, FornecedorId) VALUES ('Marmitas', (SELECT FornecedorId FROM Fornecedores WHERE Nome= 'Popedi'))");

            migrationBuilder.Sql("INSERT into Itens (Nome, Preco, Descricao, CardapioId) VALUES ('Marmita Media', 15.00, 'Tamanho Medio',(SELECT CardapioId FROM Cardapios WHERE Nome= 'Marmitas'))");
            migrationBuilder.Sql("INSERT into Itens (Nome, Preco, Descricao, CardapioId) VALUES ('Marmita Grande', 20.00, 'Tamanho Grande',(SELECT CardapioId FROM Cardapios WHERE Nome= 'Marmitas'))");
            migrationBuilder.Sql("INSERT into Itens (Nome, Preco, Descricao, CardapioId) VALUES ('Coca Lata', 4.00, 'Lata',(SELECT CardapioId FROM Cardapios WHERE Nome= 'Bebidas'))");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Fornecedores WHERE Nome IN('Popedi', 'Chapao', 'Kiburgao')");
        }
    }
}
