using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgilFood.Models
{
    [Table("Itens")]
    public class Item
    {
        public long? ItemId { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }

        public long? CardapioId { get; set; }
        public Cardapio Cardapio { get; set; }
    }
}
