using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilFood.Migrations
{
    public partial class SeedFornecedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT into Fornecedores (Nome) VALUES ('Popedi')");
            migrationBuilder.Sql("INSERT into Fornecedores (Nome) VALUES ('Chapao')");
            migrationBuilder.Sql("INSERT into Fornecedores (Nome) VALUES ('Kiburgao')");

            migrationBuilder.Sql("INSERT into Servicos (Nome, Preco, FornecedorId) VALUES ('Entrega', 5.00,(SELECT FornecedorId FROM Fornecedores WHERE Nome= 'Popedi'))");

            migrationBuilder.Sql("INSERT into Cardapios (Nome, FornecedorId) VALUES ('CardapioPopedi', (SELECT FornecedorId FROM Fornecedores WHERE Nome= 'Popedi'))");

            migrationBuilder.Sql("INSERT into Itens (Nome, Preco, CardapioId) VALUES ('Marmita Media', 15.00, (SELECT CardapioId FROM Cardapios WHERE Nome= 'CardapioPopedi'))");
            migrationBuilder.Sql("INSERT into Itens (Nome, Preco, CardapioId) VALUES ('Marmita Grande', 20.00, (SELECT CardapioId FROM Cardapios WHERE Nome= 'CardapioPopedi'))");
            migrationBuilder.Sql("INSERT into Itens (Nome, Preco, CardapioId) VALUES ('Coca Lata', 6.00, (SELECT CardapioId FROM Cardapios WHERE Nome= 'CardapioPopedi'))");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Fornecedores WHERE Nome IN('Popedi', 'Chapao', 'Kiburgao')");
        }
    }
}
