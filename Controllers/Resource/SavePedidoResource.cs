using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgilFood.Controllers.Resource
{
    public class SavePedidoResource
    {
        public int PedidoId { get; set; }
        public string NomeUsuario { get; set; }
        public string EmailUsuario { get; set; }

        public ICollection<int> Itens { get; set; }

        public SavePedidoResource()
        {
            Itens = new Collection<int>();
        }
    }
}
