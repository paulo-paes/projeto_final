using projeto_final.dao;
using projeto_final;
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
using projeto_final.Forms.ClienteForm;
using projeto_final.Forms.VendaForm;
using projeto_final.Forms.RelatorioForm;

namespace projeto_final
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            ProdutoAddForm form = new ProdutoAddForm
            {
                ShowInTaskbar = false,
                MinimizeBox = false,
                MaximizeBox = false,
                TopMost = true,
            };
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnListarPordutos_Click(object sender, EventArgs e)
        {
            ProdutoListarForm produtoListar = new ProdutoListarForm();
            produtoListar.ShowDialog();

        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            ClienteListarForm form = new ClienteListarForm();
            form.ShowDialog();
        }

        private void btnNovoCliente_Click(object sender, EventArgs e)
        {
            ClienteAddForm form = new ClienteAddForm();
            form.ShowDialog();
        }

        private void btnVendas_Click(object sender, EventArgs e)
        {
            VendaAddForm form = new VendaAddForm();
            form.ShowDialog();
        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            RelatorioForm form = new RelatorioForm();
            form.ShowDialog();
        }
    }
}
