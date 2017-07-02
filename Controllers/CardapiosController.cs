using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgilFood.Controllers.Resource;
using AgilFood.Core;
using AgilFood.Core.Models;
using AgilFood.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgilFood.Controllers
{
    [Route("/api/cardapios")]
    public class CardapiosController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICardapioRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CardapiosController(IMapper mapper, ICardapioRepository repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<IEnumerable<CardapioResource>> GetCardapios()
        {
            var cardapios = await _repository.GetCardapios();
  
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
            
            _repository.Add(cardapio);
            await _unitOfWork.CompleteAsync();

            cardapio = await _repository.GetCardapio(cardapio.CardapioId);

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
            var cardapio = await _repository.GetCardapio(id);

            //Se nao existir esse objeto no banco
            if (cardapio == null)
            {
                return NotFound();
            }
            Mapper.Map<CardapioResource, Cardapio>(cardapioResource, cardapio);

            await _unitOfWork.CompleteAsync();

            cardapio = await _repository.GetCardapio(cardapio.CardapioId);
            var result = _mapper.Map<Cardapio, CardapioResource>(cardapio);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            //primeiro vamos achar o cardapio no banco pelo Id
            var cardapio = await _repository.GetCardapio(id, includeRelated: false);

            //Se nao existir esse objeto no banco
            if (cardapio == null)
            {
                return NotFound();
            }

            _repository.Remove(cardapio);
            await _unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var cardapio = await _repository.GetCardapio(id);

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
