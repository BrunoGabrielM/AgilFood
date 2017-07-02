using System.ComponentModel.DataAnnotations.Schema;

namespace AgilFood.Core.Models
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
