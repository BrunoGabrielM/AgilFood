using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace AgilFood.Controllers.Resource
{
    public class PedidoResource
    {
        public int PedidoId { get; set; }
        public string NomeUsuario { get; set; }
        public string EmailUsuario { get; set; }//como o Auth0 pego de la e mando pra ca
        public DateTime DataPedido { get; set; }
        public ICollection<ItemResource> Itens { get; set; }

            
        public PedidoResource()
        {
            Itens = new Collection<ItemResource>();
        }
    }
}
