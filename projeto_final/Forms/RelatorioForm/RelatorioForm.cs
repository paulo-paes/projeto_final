using projeto_final.dao;
using projeto_final.Forms.ClienteForm;
using projeto_final.Forms.VendaForm;
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

namespace projeto_final.Forms.RelatorioForm
{
    public partial class RelatorioForm : Form
    {

        VendaDao dao = new VendaDao();
        public RelatorioForm()
        {
            InitializeComponent();
        }

        private void Pesquisar_Click(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void CarregarDados(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void CarregarDados()
        {
            DateTime dataInicial = dtpInicial.Value;
            DateTime dataFinal = dtpFinal.Value;

            List<RelatorioVenda> vendas = dao.Listar(dataInicial, dataFinal);
            List<RelatorioProdutosMaisVendidos> produtos = dao.ListarProdutos(dataInicial, dataFinal);
            gridProdutosVendidos.AutoGenerateColumns = false;
            gridProdutosVendidos.DataSource = produtos;
            gridVendas.AutoGenerateColumns = false;
            gridVendas.DataSource = vendas;
            double valorTotal = 0;
            foreach (RelatorioVenda v in vendas)
            {
                valorTotal += v.ValorTotal;
            }
            lblQuantidadeVendas.Text = vendas.Count.ToString();
            lblTotal.Text = valorTotal.ToString();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QuantidadeVendas_Click(object sender, EventArgs e)
        {

        }

        private void RelatorioMenu_Load(object sender, EventArgs e)
        {

        }

        private void gridVendas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gridVendas.Columns["Editar"].Index)
            {
                EditarVenda((int)gridVendas.SelectedRows[0].Cells["Codigo"].Value);
            }
        }

        private void EditarVenda(int cod)
        {
            VendaAddForm form = new VendaAddForm();
            

            form.FormClosing += CarregarDados;

            form.SetVendaContext(cod);
            form.ShowDialog();
        }
    }
}
