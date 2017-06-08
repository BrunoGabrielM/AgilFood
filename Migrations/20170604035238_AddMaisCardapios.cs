using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilFood.Migrations
{
    public partial class AddMaisCardapios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT into Cardapios (Nome, FornecedorId) VALUES ('CardapioChapao', (SELECT FornecedorId FROM Fornecedores WHERE Nome= 'Chapao'))");
            migrationBuilder.Sql("INSERT into Itens (Nome, Preco, CardapioId) VALUES ('Salgado Frito', 4.00, (SELECT CardapioId FROM Cardapios WHERE Nome= 'CardapioChapao'))");
            migrationBuilder.Sql("INSERT into Itens (Nome, Preco, CardapioId) VALUES ('Salgado Assado', 3.00, (SELECT CardapioId FROM Cardapios WHERE Nome= 'CardapioChapao'))");
            migrationBuilder.Sql("INSERT into Itens (Nome, Preco, CardapioId) VALUES ('Suco', 5.00, (SELECT CardapioId FROM Cardapios WHERE Nome= 'CardapioChapao'))");

            migrationBuilder.Sql("INSERT into Cardapios (Nome, FornecedorId) VALUES ('CardapioKiburgao', (SELECT FornecedorId FROM Fornecedores WHERE Nome= 'Kiburgao'))");
            migrationBuilder.Sql("INSERT into Itens (Nome, Preco, CardapioId) VALUES ('x-frango', 10.00, (SELECT CardapioId FROM Cardapios WHERE Nome= 'CardapioKiburgao'))");
            migrationBuilder.Sql("INSERT into Itens (Nome, Preco, CardapioId) VALUES ('x-tudo', 20.00, (SELECT CardapioId FROM Cardapios WHERE Nome= 'CardapioKiburgao'))");
            migrationBuilder.Sql("INSERT into Itens (Nome, Preco, CardapioId) VALUES ('Conquista 600ml', 5.50, (SELECT CardapioId FROM Cardapios WHERE Nome= 'CardapioKiburgao'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //Sempre uma boa pratica ter o Down da tabela
            migrationBuilder.Sql("DELETE FROM Cardapios WHERE Nome IN('CardapioPopedi', 'CardapioChapao', 'CardapioKiburgao')");
        }
    }
}
