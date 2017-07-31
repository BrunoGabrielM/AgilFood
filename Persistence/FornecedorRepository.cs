using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgilFood.Core;
using AgilFood.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AgilFood.Persistence
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly AgilFoodDbContext _context;

        public FornecedorRepository(AgilFoodDbContext context)
        {
            _context = context;
        }


        public async Task<Fornecedor> GetFornecedor(int id, bool includeRelated = true)
        {
            return await _context.Fornecedores
                          .SingleOrDefaultAsync(f => f.FornecedorId == id);
        }

        public void Add(Fornecedor fornecedor)
        {
            _context.Fornecedores.Add(fornecedor);
        }

        public void Remove(Fornecedor fornecedor)
        {
            _context.Fornecedores.Remove(fornecedor);
        }

        public async Task<IEnumerable<Fornecedor>> GetFornecedores()
        {
            return await _context.Fornecedores.ToListAsync();
        }
    }
}
