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
    public class CardapiosController : Controller
    {
        private readonly AgilFoodDbContext _context;
        private readonly IMapper _mapper;

        public CardapiosController(AgilFoodDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("/api/cardapios")]
        public async Task<IEnumerable<CardapioResource>> GetCardapios()
        {
            var cardapios = await _context.Cardapios.Include(m => m.Itens).ToListAsync();

            return Mapper.Map<List<Cardapio>, List<CardapioResource>>(cardapios);
        }
    }
}
