using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_final.model
{
    public class ItemVenda
    {
        public int Cod { get; set; }
        public int CodVenda { get; set; }
        public int CodProduto { get; set; }
        public double Quantidade { get; set; }
        public string Descricao { get; set; }
        public double ValorUnitario { get; set; }
        public double SubTotal { get; set; }

        public ItemVenda() { }

        public ItemVenda(Produto p, double quantidade)
        {
            Descricao = p.Descricao;
            ValorUnitario = p.PrecoVenda;
            CodProduto = p.Cod;
            Quantidade = quantidade;
            SubTotal = Quantidade * ValorUnitario;
        }
    }
}
