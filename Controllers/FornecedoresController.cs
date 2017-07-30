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
    [Route("/api/fornecedores")]
    public class FornecedoresController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFornecedorRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public FornecedoresController(IMapper mapper, IFornecedorRepository repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }


        [HttpPost]
        public async Task<IActionResult> CreateFornecedor([FromBody] FornecedorResource fornecedorResource)
        {

            var fornecedor = Mapper.Map<FornecedorResource, Fornecedor>(fornecedorResource);

            _repository.Add(fornecedor);
            await _unitOfWork.CompleteAsync();


            return Ok(fornecedor.FornecedorId);
        }
        
    }
}
