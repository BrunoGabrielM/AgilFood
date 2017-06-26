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
    [Route("/api/cardapios")]
    public class CardapiosController : Controller
    {
        private readonly AgilFoodDbContext _context;
        private readonly IMapper _mapper;

        public CardapiosController(AgilFoodDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CardapioResource>> GetCardapios()
        {
            var cardapios = await _context.Cardapios.Include(m => m.Itens).ToListAsync();
  
            return Mapper.Map<List<Cardapio>, List<CardapioResource>>(cardapios);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCardapio([FromBody] CardapioResource cardapioResource)
        {

            //Validações (server side validations)
            if (!ModelState.IsValid) //Validar as anotations(Required, etc)
            {
                return BadRequest(ModelState);
            }

            var cardapio = Mapper.Map<CardapioResource, Cardapio>(cardapioResource);
            
            _context.Cardapios.Add(cardapio);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<Cardapio, CardapioResource>(cardapio);

            return Ok(result);
        }

        [HttpPut("{id}")] 
        public async Task<IActionResult> UpdateCardapio(int id, [FromBody] CardapioResource cardapioResource)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //primeiro vamos achar o cardapio no banco 
            var cardapio = await _context.Cardapios.SingleOrDefaultAsync(c => c.CardapioId == id);

            //Se nao existir esse objeto no banco
            if (cardapio == null)
            {
                return NotFound();
            }
            Mapper.Map<CardapioResource, Cardapio>(cardapioResource, cardapio);

            await _context.SaveChangesAsync();

            var result = _mapper.Map<Cardapio, CardapioResource>(cardapio);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            //primeiro vamos achar o cardapio no banco pelo Id
            var cardapio = await _context.Cardapios.FindAsync(id);

            //Se nao existir esse objeto no banco
            if (cardapio == null)
            {
                return NotFound();
            }

            _context.Remove(cardapio);
            await _context.SaveChangesAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var cardapio = await _context.Cardapios.SingleOrDefaultAsync(v => v.CardapioId == id);

            //Se nao existir esse objeto no banco
            if (cardapio == null)
            {
                return NotFound();
            }

            var cardapioResource = Mapper.Map<Cardapio, CardapioResource>(cardapio);

            return Ok(cardapioResource);
        }
    }
}
