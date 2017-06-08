using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgilFood.Controllers.Resource;
using AgilFood.Models;
using AutoMapper;

namespace AgilFood.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Fornecedor, FornecedorResource>();
            CreateMap<Cardapio, CardapioResource>();
            CreateMap<Item, ItemResource>();
            CreateMap<Servico, ServicoResource>();
        }
    }
}
