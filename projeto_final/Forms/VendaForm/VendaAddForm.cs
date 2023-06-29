using projeto_final.dao;
using projeto_final.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_final.Forms.VendaForm
{
    public partial class VendaAddForm : Form
    {

        ProdutoDao ProdutoDao = new ProdutoDao();
        ClienteDao ClienteDao = new ClienteDao();
        VendaDao VendaDao = new VendaDao();

        private List<Produto> produtos;
        private List<Cliente> clientes;

        private Venda Venda = new Venda();

        public VendaAddForm()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VendaAddForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.produtos = this.ProdutoDao.Listar();
                this.clientes = this.ClienteDao.Listar();

                this.cmbClientes.DataSource = this.clientes;
                this.cmbProdutos.DataSource = this.produtos;
                this.gridProdutosVenda.AutoGenerateColumns = false;
                this.gridProdutosVenda.DataSource = this.Venda.ItensVenda;
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Produto produto = this.cmbProdutos.SelectedItem as Produto;

            double quantidade = Convert.ToDouble(this.txtQuantidade.Text);
            ItemVenda itemVenda = new ItemVenda(produto, quantidade);

            Venda.AdicionarItemVenda(itemVenda);
            AtualizarLista();
        }

        private void AtualizarLista()
        {
            if (txtDesconto.Text.Trim().Length > 0)
            {
                try
                {
                    Venda.Desconto = Convert.ToDouble(txtDesconto.Text);
                    Venda.RecalcularValorTotal();
                }
                catch
                {
                    MessageBox.Show("Insira um desconto válido");
                }
            }
            gridProdutosVenda.DataSource = null;
            gridProdutosVenda.DataSource = Venda.ItensVenda;
            lblTotal.Text = Venda.ValorTotal.ToString();
            lblSubTotal.Text = Venda.SubTotal.ToString();
        }

        private void btnFecharVenda_Click(object sender, EventArgs e)
        {
            Venda.CodCliente = (this.cmbClientes.SelectedItem as Cliente).Cod;
            VendaDao.Cadastrar(Venda);
        }
    }
}
