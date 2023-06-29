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
        ItemVendaDao itensDao = new ItemVendaDao();
        VendaDao VendaDao = new VendaDao();

        private List<Produto> produtos;
        private List<Cliente> clientes;

        private Venda Venda = new Venda();

        private bool EditMode = false;
        private int EditCod;

        public VendaAddForm()
        {
            InitializeComponent();
        }

        public void SetVendaContext(int cod)
        {
            EditMode = true;
            Venda = VendaDao.ObterPorCod(cod);
            if (Venda != null)
            {
                Venda.ItensVenda = itensDao.ObterPorCodVenda(cod);
            }
            EditCod = cod;
        }

        private void PosSetContext()
        {
            if (Venda == null)
            {
                MessageBox.Show("Venda não encontrada");
                this.Close();
                return;
            }

            Cliente c = this.clientes.Find(x => x.Cod == Venda.CodCliente);
            MessageBox.Show((c == null).ToString()) ;
            this.cmbClientes.SelectedItem = c;

            this.cmbProdutos.Enabled = false;
            this.btnAdicionar.Enabled = false;
            this.txtDesconto.Text = Venda.Desconto.ToString();
            this.txtObservacoes.Text = Venda.Observacoes;
            this.cmbPagamento.SelectedIndex = this.cmbPagamento.Items.IndexOf(Venda.FormaPagamento);
            this.cmbSituacao.SelectedIndex = this.cmbSituacao.Items.IndexOf(Venda.Situacao);
            this.cmbPagamento.Enabled = false;
            this.gridItemVenda.Columns["Remover"].Visible = false;
            this.cmbProdutos.SelectedIndex = -1;
            this.txtDesconto.Enabled = false;
            this.txtQuantidade.Enabled = false;
            this.cmbClientes.Enabled = false;
            AtualizarLista();
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
                if (!EditMode) Limpar();
                this.gridItemVenda.AutoGenerateColumns = false;
                this.gridProduto.AutoGenerateColumns = false;
                if (EditMode) PosSetContext();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Produto produto = this.cmbProdutos.SelectedItem as Produto;

            if (produto == null)
            {
                MessageBox.Show("Selecione um produto!");
                return;
            }

            double quantidade = Convert.ToDouble(this.txtQuantidade.Text);

            if (produto.QuantidadeEstoque < quantidade)
            {
                MessageBox.Show("Estoque indisponível");
                return;
            }
            try
            {
                Venda.AdicionarItemVenda(produto, quantidade);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK);
            }
            AtualizarLista();
            Limpar();
        }

        private void Limpar()
        {
            this.cmbProdutos.SelectedIndex = -1;
            this.txtQuantidade.Text = "";
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
            gridItemVenda.DataSource = null;
            gridItemVenda.DataSource = Venda.ItensVenda;
            lblTotal.Text = Venda.ValorTotal.ToString();
            lblSubTotal.Text = Venda.SubTotal.ToString();
        }

        private void btnFecharVenda_Click(object sender, EventArgs e)
        {
            if(!ValidarVenda()) return;

            Venda.CodCliente = (this.cmbClientes.SelectedItem as Cliente).Cod;
            Venda.Observacoes = this.txtObservacoes.Text;
            Venda.FormaPagamento = this.cmbPagamento.SelectedItem as string;
            Venda.Situacao = this.cmbSituacao.SelectedItem as string;

            if (EditMode)
            {
                try
                {
                    VendaDao.Atualizar(Venda);
                    MessageBox.Show("Venda Atualizada com sucesso!");
                }
                catch
                {
                    MessageBox.Show("Não foi possível atualizar a venda");
                }
                finally
                {
                    this.Close();
                }
            } else
            {
                try
                {
                    VendaDao.Cadastrar(Venda);
                    MessageBox.Show("Venda registrada com sucesso!");
                }
                catch
                {
                    MessageBox.Show("Não foi possível realizar a venda");
                } finally
                {
                    this.Close();
                }
            }      
        }

        private bool ValidarVenda()
        {
            Cliente cliente = this.cmbClientes.SelectedItem as Cliente;
            string pag = this.cmbPagamento.SelectedItem as string;
            string sit = this.cmbSituacao.SelectedItem as string;

            if (cliente == null)
            {
                MessageBox.Show("Selecione um cliente!");
                return false;
            }

            if (pag.Trim().Length <= 0) {
                MessageBox.Show("Selecione a forma de pagamento!");
                return false;
            }

            if (sit.Trim().Length <= 0)
            {
                MessageBox.Show("Selecione a Situação!");
                return false;
            }

            return true;
        }
        private void RemoverItemVenda(int index)
        {
            this.Venda.RemoverItemVenda(index);
        }

        private void gridItemVenda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gridItemVenda.Columns["Remover"].Index)
            {
                RemoverItemVenda(e.RowIndex);
                AtualizarLista();
            }
        }

        private void cmbProdutos_SelectedValueChanged(object sender, EventArgs e)
        {
            Produto p = this.cmbProdutos.SelectedItem as Produto;
            List<Produto> lista = new List<Produto>
            {
                p
            };
            gridProduto.DataSource = lista;
        }

        private void cmbProdutos_ContextMenuStripChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbProdutos_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
