using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_final.model
{
    public class Venda
    {
        public int Cod { get; set; }
        public DateTime DataVenda { get; set; }
        public int CodCliente { get; set; }
        public int CodUsuario { get; set; }
        public int TotalItens { get; set; }
        public double SubTotal { get; set; }
        public double Desconto { get; set; }
        public double ValorTotal { get; set; }
        public string FormaPagamento { get; set; }
        public string Situacao { get; set; }
        public string Observacoes { get; set; }

        public Venda() { }
    }
}
