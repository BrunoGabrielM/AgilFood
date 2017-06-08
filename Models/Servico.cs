using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgilFood.Models
{
    [Table("Servicos")]
    public class Servico
    {
        public long? ServicoId { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }


        public long? FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}
