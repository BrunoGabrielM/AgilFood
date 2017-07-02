using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using AgilFood.Core.Models;

namespace AgilFood.Persistence
{
    public class AgilFoodDbContext : DbContext
    {
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Cardapio> Cardapios { get; set; }


        public AgilFoodDbContext(DbContextOptions<AgilFoodDbContext> options) 
             : base(options)
        {

        }
    }
}
