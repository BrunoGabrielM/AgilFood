using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace AgilFood.Controllers.Resource
{
    public class FornecedorResource
    {
        public long? FornecedorId { get; set; }
        public string Nome { get; set; }


        public ICollection<ServicoResource> Servicos { get; set; }


        public FornecedorResource()
        {
            Servicos = new Collection<ServicoResource>();
        }
    }
}
