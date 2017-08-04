using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgilFood.Controllers.Resource;
using AgilFood.Core.models;
using AgilFood.Core.Models;
using AutoMapper;

namespace AgilFood.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to API Resource
            CreateMap<Fornecedor, FornecedorResource>();
            CreateMap<Cardapio, CardapioResource>();
            CreateMap<Item, ItemResource>();
            CreateMap<Servico, ServicoResource>();
            CreateMap(typeof(QueryResult<>), typeof(QueryResultResource<>));

            //API Resource to Domain [Para fazer o CRUD]
            CreateMap<FornecedorQueryResource, FornecedorQuery>();
            CreateMap<CardapioResource, Cardapio>();
            CreateMap<FornecedorResource, Fornecedor>();
            CreateMap<ItemResource, Item>();
            
        }
    }
}
