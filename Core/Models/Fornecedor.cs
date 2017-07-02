using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AgilFood.Core.Models
{
    public class Fornecedor
    {
        public long? FornecedorId { get; set; }
        public string Nome { get; set; } 

        public Cardapio Cardapio { get; set; }
        public ICollection<Servico> Servicos { get; set; }



        public Fornecedor()
        {
            Servicos = new Collection<Servico>();
        }
    }
}
