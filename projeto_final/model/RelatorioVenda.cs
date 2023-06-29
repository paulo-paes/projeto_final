using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_final.model
{
    public class RelatorioVenda
    {
        public int Codigo { get; set; }
        public DateTime DataVenda { get; set; }
        public string NomeCliente { get; set; }
        public int TotalItens { get; set; }
        public double SubTotal { get; set; }
        public double Desconto { get; set; }
        public double ValorTotal { get; set; }
        public string Situacao { get; set; }

        public RelatorioVenda() { }
    }
}
