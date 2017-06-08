using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using AgilFood.Models;

namespace AgilFood.Persistence
{
    public class AgilFoodDbContext : DbContext
    {
        public AgilFoodDbContext(DbContextOptions<AgilFoodDbContext> options) 
             : base(options)
        {

        }

        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Cardapio> Cardapios { get; set; }
    }
}
