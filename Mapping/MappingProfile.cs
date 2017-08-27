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
            CreateMap<Photo, PhotoResource>();
            CreateMap<Pedido, PedidoResource>()
                .ForMember(pr => pr.Itens, opt => opt.MapFrom(pedido => pedido.Itens.Select(pi => new ItemResource { ItemId = pi.Item.ItemId, Nome = pi.Item.Nome, Preco = pi.Item.Preco, Descricao = pi.Item.Descricao})));                
            CreateMap<Pedido, SavePedidoResource>()
                .ForMember(pr => pr.Itens, opt => opt.MapFrom(p => p.Itens.Select(pi => pi.ItemId)));

            //API Resource to Domain [Para fazer o CRUD]
            CreateMap<FornecedorQueryResource, FornecedorQuery>();
            CreateMap<CardapioResource, Cardapio>();
            CreateMap<FornecedorResource, Fornecedor>();
            CreateMap<ItemResource, Item>();
            CreateMap<SavePedidoResource, Pedido>()
                .ForMember(p => p.PedidoId, opt => opt.Ignore())
                .ForMember(p => p.Itens, opt => opt.MapFrom(pr => pr.Itens.Select(id => new PedidoItem { ItemId = id })));

        }
    }
}
