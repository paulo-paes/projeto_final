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

namespace projeto_final.Forms.ClienteForm
{
    public partial class ClienteAddForm : Form
    {

        ClienteDao dao = new ClienteDao();
        private int CodigoSelecionado;
        private bool EditMode = false;

        public ClienteAddForm()
        {
            InitializeComponent();
        }

        private void ClienteAddFom_Load(object sender, EventArgs e)
        {
            if (EditMode)
            {
                Cliente c = dao.ObterPorCod(CodigoSelecionado);
                if (c == null)
                {
                    MessageBox.Show("Cliente Não encontrado");
                    this.Close();
                    return;
                }
                txtCodigo.Text = c.Cod.ToString();
                txtNome.Text = c.Nome;
                txtUf.Text = c.UF;
                txtCep.Text = c.Cep;
                dtpNascimento.Value = c.DataNascimento;
                txtEmail.Text = c.Email;
                txtEndereco.Text = c.Endereco;
                txtBairro.Text = c.Bairro;
                txtCelular.Text = c.Celular;
                txtCidade.Text = c.Cidade;
                txtComplemento.Text = c.Complemento;
                txtCpf.Text = c.Cpf;
                txtRg.Text = c.Rg;
                txtGenero.Text = c.Genero;
                txtEstadoCivil.Text = c.EstadoCivil;
                txtNumero.Text = c.Numero;
                txtNacionalidade.Text = c.Nacionalidade;
                txtProfissao.Text = c.Profissao;
                txtObservacoes.Text = c.Observacoes;
                chkSituacao.Checked = c.Situacao;
                txtTelefone.Text = c.Telefone;
                chkWhatsapp.Checked = c.Whatsapp;
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarCliente()) return;
            Cliente c = ObterCliente();
            try
            {
                if (EditMode)
                {
                    c.Cod = this.CodigoSelecionado;
                    dao.Atualizar(c);
                    MessageBox.Show("Cliente atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK);
                }
                else
                {
                    dao.Cadastrar(c);

                    MessageBox.Show("Cliente cadastrado com sucesso!", "Cliente Cadastrado", MessageBoxButtons.OK);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Houve um erro", ex.Message, MessageBoxButtons.OK);
            }
        }

        private Cliente ObterCliente()
        {
            Cliente c = new Cliente();
            c.Nome = txtNome.Text;
            c.UF = txtUf.Text;
            c.Cep = txtCep.Text;
            c.DataNascimento = dtpNascimento.Value;
            c.Email = txtEmail.Text;
            c.Endereco = txtEndereco.Text;
            c.Bairro = txtBairro.Text;
            c.Celular = txtCelular.Text;
            c.Cidade = txtCidade.Text;
            c.Complemento = txtComplemento.Text;
            c.Cpf = txtCpf.Text;
            c.Rg = txtRg.Text;
            c.Genero = txtGenero.Text;
            c.EstadoCivil = txtEstadoCivil.Text;
            c.Numero = txtNumero.Text;
            c.Nacionalidade = txtNacionalidade.Text;
            c.Profissao = txtProfissao.Text;
            c.Observacoes = txtObservacoes.Text;
            c.Situacao = chkSituacao.Checked;
            c.Telefone = txtTelefone.Text;
            c.Whatsapp = chkWhatsapp.Checked;
            return c;
        }

        private bool ValidarCliente()
        {
            if (txtNome.Text.Trim().Length == 0)
            {
                MessageBox.Show("Preencha o nome");
                return false;
            }
            return true;
        }

        public void SetProdutoContext(int cod)
        {
            this.CodigoSelecionado = cod;
            EditMode = true;
        }
    }
}
