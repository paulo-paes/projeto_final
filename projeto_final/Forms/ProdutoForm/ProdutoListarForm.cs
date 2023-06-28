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

namespace projeto_final
{
    public partial class ProdutoListarForm : Form
    {
        ProdutoDao dao = new ProdutoDao();
        public ProdutoListarForm()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProdutoListar_Load(object sender, EventArgs e)
        {
            CarregarProdutos();
        }

        private void CarregarProdutos(object sender, object e)
        {
            CarregarProdutos();
        }

        private void CarregarProdutos()
        {
            List<Produto> lista = dao.Listar();
            
            gridProdutos.DataSource = lista;
        }

        private void gridProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gridProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private int GetSelectedCod()
        {
            return (int)gridProdutos.SelectedRows[0].Cells["cod"].Value;
        }

        private void ExcluirProduto()
        {
            try
            {
                dao.Excluir(GetSelectedCod());
                MessageBox.Show("Produto Excluido com Sucesso");
                CarregarProdutos();
            } catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Houve um erro");
            }
        }

        private void gridProdutos_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gridProdutos.Columns["Excluir"].Index)
            {
                DialogResult r = MessageBox.Show("Essa ação é irreversível, você tem certeza?", "Atenção", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                    ExcluirProduto();
                }
            }
            else if (e.ColumnIndex == gridProdutos.Columns["Editar"].Index)
            {
                EditarProduto();
            }
        }

        private void EditarProduto()
        {
            ProdutoAddForm form = new ProdutoAddForm();
            form.SetProdutoContext(GetSelectedCod());

            form.FormClosing += CarregarProdutos;
            form.ShowDialog();
        }

        private void gridProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
