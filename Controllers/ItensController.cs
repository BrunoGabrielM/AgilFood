using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgilFood.Controllers.Resource;
using AgilFood.Core;
using AgilFood.Core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AgilFood.Controllers
{
    [Route("/api/itens")]
    public class ItensController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IItemRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ItensController(IMapper mapper, IItemRepository repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] ItemResource itemResource)
        {

            var item = Mapper.Map<ItemResource, Item>(itemResource);

            _repository.Add(item);
            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<Item, ItemResource>(item);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<List<ItemResource>> Getitens(int id)
        {
            var itens = await _repository.GetItens(id);

            return Mapper.Map<List<Item>, List<ItemResource>>(itens);
        }


    }
}
