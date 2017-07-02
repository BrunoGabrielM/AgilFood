using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace AgilFood.Controllers.Resource
{
    public class CardapioResource
    {
        public long? CardapioId { get; set; }
        public string Nome { get; set; }

        public long? FornecedorId { get; set; }
        public ICollection<ItemResource> Itens { get; set; }


        public CardapioResource()
        {
            Itens = new Collection<ItemResource>();
        }
    }
}
