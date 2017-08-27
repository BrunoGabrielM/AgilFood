using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilFood.Migrations
{
    public partial class SeedPedidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT into pedidos (DataPedido, EmailUsuario, NomeUsuario) VALUES ('22/08/2017 00:00:00', 'carlos@gmail.com', 'Carlos')");
            migrationBuilder.Sql("INSERT into pedidos (DataPedido, EmailUsuario, NomeUsuario) VALUES ('05/05/2017 00:00:00', 'paulo@gmail.com', 'Paulo')");
            migrationBuilder.Sql("INSERT into pedidos (DataPedido, EmailUsuario, NomeUsuario) VALUES ('10/08/2017 00:00:00', 'pedro@gmail.com', 'Pedro')");
            migrationBuilder.Sql("INSERT into pedidos (DataPedido, EmailUsuario, NomeUsuario) VALUES ('05/07/2017 00:00:00', 'alvaro@gmail.com', 'Alvaro')");
            migrationBuilder.Sql("INSERT into pedidos (DataPedido, EmailUsuario, NomeUsuario) VALUES ('15/07/2017 00:00:00', 'sandro@gmail.com', 'Sandro')");


            migrationBuilder.Sql("INSERT into PedidoItens (ItemId, PedidoId) VALUES ((SELECT ItemId FROM Itens WHERE Nome= 'Marmita Media'), (SELECT PedidoId FROM pedidos WHERE EmailUsuario= 'carlos@gmail.com'))");
            migrationBuilder.Sql("INSERT into PedidoItens (ItemId, PedidoId) VALUES ((SELECT ItemId FROM Itens WHERE Nome= 'Marmita Grande'), (SELECT PedidoId FROM pedidos WHERE EmailUsuario= 'carlos@gmail.com'))");
            migrationBuilder.Sql("INSERT into PedidoItens (ItemId, PedidoId) VALUES ((SELECT ItemId FROM Itens WHERE Nome= 'Coca Lata'), (SELECT PedidoId FROM pedidos WHERE EmailUsuario= 'carlos@gmail.com'))");
            migrationBuilder.Sql("INSERT into PedidoItens (ItemId, PedidoId) VALUES ((SELECT ItemId FROM Itens WHERE Nome= 'Marmita Media'), (SELECT PedidoId FROM pedidos WHERE EmailUsuario= 'paulo@gmail.com'))");
            migrationBuilder.Sql("INSERT into PedidoItens (ItemId, PedidoId) VALUES ((SELECT ItemId FROM Itens WHERE Nome= 'Marmita Grande'), (SELECT PedidoId FROM pedidos WHERE EmailUsuario= 'pedro@gmail.com'))");
            migrationBuilder.Sql("INSERT into PedidoItens (ItemId, PedidoId) VALUES ((SELECT ItemId FROM Itens WHERE Nome= 'Coca Lata'), (SELECT PedidoId FROM pedidos WHERE EmailUsuario= 'alvaro@gmail.com'))");
            migrationBuilder.Sql("INSERT into PedidoItens (ItemId, PedidoId) VALUES ((SELECT ItemId FROM Itens WHERE Nome= 'Coca Lata'), (SELECT PedidoId FROM pedidos WHERE EmailUsuario= 'sandro@gmail.com'))");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM pedidos WHERE EmailUsuario IN('carlos@gmail.com', 'paulo@gmail.com', 'pedro@gmail.com', 'alvaro@gmail.com', 'sandro@gmail.com')");
        }


    }
}
