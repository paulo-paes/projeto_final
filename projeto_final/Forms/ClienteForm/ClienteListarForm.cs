using projeto_final.dao;
using projeto_final.Forms.ClienteForm;
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
    public partial class ClienteListarForm : Form
    {
        ClienteDao dao = new ClienteDao();
        public ClienteListarForm()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClienteListarForm_Load(object sender, EventArgs e)
        {
            CarregarClientes();
        }

        private void CarregarClientes(object sender, EventArgs e)
        {
            CarregarClientes();
        }

        private void CarregarClientes()
        {
            try
            {
                List<Cliente> clientes = dao.Listar();
                gridClientes.DataSource = clientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }
        }

        private void gridClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gridClientes.Columns["Excluir"].Index)
            {
                DialogResult r = MessageBox.Show("Essa ação é irreversível, você tem certeza?", "Atenção", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                    ExcluirCliente(e.RowIndex);
                }
            }
            else if (e.ColumnIndex == gridClientes.Columns["Editar"].Index)
            {
                EditarCliente(e.RowIndex);
            }
        }

        private void ExcluirCliente(int rowIndex)
        {
            try
            {
                int clienteId = (int)gridClientes.Rows[rowIndex].Cells["Id"].Value;
                dao.Excluir(clienteId);
                MessageBox.Show("Cliente excluído com sucesso");
                CarregarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao excluir cliente");
            }
        }

        private void EditarCliente(int rowIndex)
        {
            int clienteId = (int)gridClientes.Rows[rowIndex].Cells["Cod"].Value;
            MessageBox.Show(clienteId.ToString());
            ClienteAddForm form = new ClienteAddForm();
            form.SetProdutoContext(clienteId);

            form.FormClosing += CarregarClientes;
            form.ShowDialog();
        }
    }
}
