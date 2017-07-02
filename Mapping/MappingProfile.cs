using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgilFood.Controllers.Resource;
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

            //API Resource to Domain [Para fazer o CRUD]
            CreateMap<CardapioResource, Cardapio>()
                .ForMember(c => c.CardapioId, opt => opt.Ignore()) //pra nao dar erro no postman
                .ForMember(c => c.FornecedorId, opt => opt.Ignore()); 


        }
    }
}
