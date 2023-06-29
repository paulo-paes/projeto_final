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

        public List<ItemVenda> ItensVenda = new List<ItemVenda>();
        public Venda() {
            Desconto = 0;
            ValorTotal = 0;
            SubTotal = 0;
        }

        public void AdicionarItemVenda(ItemVenda itemVenda)
        {
            ItemVenda itemLista = CodProdutoEstaNaVenda(itemVenda.CodProduto);
            if (itemLista != null)
            {
                itemLista.Quantidade += itemVenda.Quantidade;
                itemLista.SubTotal += itemVenda.SubTotal;
            } else
            {
                this.ItensVenda.Add(itemVenda);
            }
            RecalcularValorTotal();
        }

        private ItemVenda CodProdutoEstaNaVenda(int codProduto)
        {
            foreach (ItemVenda item in this.ItensVenda)
            {
                if (item.CodProduto == codProduto)
                {
                    return item;
                }
            }
            return null;
        }

        public void RemoverItemVenda(ItemVenda itemVenda)
        {
            this.ItensVenda.Remove(itemVenda);
            RecalcularValorTotal();
        }

        public void RecalcularValorTotal()
        {
            double valor = 0;
            foreach(ItemVenda item in this.ItensVenda)
            {
                valor += item.SubTotal;
            }

            this.SubTotal = valor;
            this.ValorTotal = this.SubTotal - this.Desconto;
        }
    }
}
