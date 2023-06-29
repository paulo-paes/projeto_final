using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public void AdicionarItemVenda(Produto p, double quantidade)
        {
            ValidarEstoque(p, quantidade);
            ItemVenda novoItem = new ItemVenda(p, quantidade);
            ItemVenda itemLista = CodProdutoEstaNaVenda(novoItem.CodProduto);
            if (itemLista != null)
            {
                ValidarEstoque(p, quantidade +  itemLista.Quantidade);
                itemLista.Quantidade += novoItem.Quantidade;
                itemLista.SubTotal += novoItem.SubTotal;
            } else
            {
                this.ItensVenda.Add(novoItem);
            }
            RecalcularValorTotal();
        }

        private void ValidarEstoque(Produto p, double quantidade)
        {
            if (p.QuantidadeEstoque < quantidade)
            {
                throw new Exception("Estoque indisponível");
            }
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

        public void RemoverItemVenda(int index)
        {
            this.ItensVenda.RemoveAt(index);
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
