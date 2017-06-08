using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgilFood.Models
{
    [Table("Cardapios")]
    public class Cardapio
    {
        public long? CardapioId { get; set; }
        public string Nome { get; set; }


        public long? FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public ICollection<Item> Itens { get; set; }


        public Cardapio()
        {
            Itens = new Collection<Item>();
        }
    }
}
