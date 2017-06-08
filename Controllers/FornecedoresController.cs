using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgilFood.Controllers.Resource;
using AgilFood.Models;
using AgilFood.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgilFood.Controllers
{
    public class FornecedoresController
    {
        private readonly AgilFoodDbContext _context;
        private readonly IMapper _mapper;

        public FornecedoresController(AgilFoodDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("/api/fornecedores")]
        public async Task<IEnumerable<FornecedorResource>> GetFornecedores()
        {
            var fornecedores = await _context.Fornecedores.Include(m => m.Servicos).ToListAsync();

            return Mapper.Map<List<Fornecedor>, List<FornecedorResource>>(fornecedores);
        }
    }
}
