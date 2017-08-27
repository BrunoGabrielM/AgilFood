using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using AgilFood.Core.models;
using AgilFood.Core.Models;

namespace AgilFood.Persistence
{
    public class AgilFoodDbContext : DbContext
    {
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Cardapio> Cardapios { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }


        public AgilFoodDbContext(DbContextOptions<AgilFoodDbContext> options) 
             : base(options)
        {

        }

        //Para poder usar many-to-many relationShip
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PedidoItem>().HasKey(pi =>
                new { pi.ItemId, pi.PedidoId });
        }
    }
}
