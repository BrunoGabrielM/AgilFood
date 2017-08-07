using System.Collections.Generic;
using System.Collections.ObjectModel;
using AgilFood.Core.models;

namespace AgilFood.Core.Models
{
    public class Fornecedor
    {
        public int FornecedorId { get; set; }
        public string Nome { get; set; }    
          
        
        public ICollection<Servico> Servicos { get; set; }
        public ICollection<Cardapio> Cardapios { get; set; }
        public ICollection<Photo> Photos { get; set; }


        public Fornecedor()
        {
            Servicos = new Collection<Servico>();
            Cardapios = new Collection<Cardapio>();
            Photos = new Collection<Photo>();
        }
    }
}
