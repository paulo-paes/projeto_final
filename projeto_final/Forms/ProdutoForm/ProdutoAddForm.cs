using projeto_final.dao;
using projeto_final.model;
using projeto_final.util;
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
    public partial class ProdutoAddForm : Form
    {
        readonly ProdutoDao dao = new ProdutoDao();
        private int CodigoSelecionado;
        private bool EditMode = false;
        public ProdutoAddForm()
        {
            InitializeComponent();
        }

        private void ProdutoForm_Load(object sender, EventArgs e)
        {
            if (EditMode)
            {
                Produto p = dao.ObterPorCod(CodigoSelecionado);
                if (p == null)
                {
                    MessageBox.Show("Produto Não encontrado");
                    this.Close();
                    return;
                }

                txtCodigo.Text = p.Cod.ToString();
                txtCodigoBarras.Text = p.CodigoBarras;
                txtDescricao.Text = p.Descricao;
                txtAltura.Text = p.Altura.ToString();
                txtLargura.Text = p.Largura.ToString();
                txtMarca.Text = p.Marca;
                txtPeso.Text = p.Peso.ToString();
                txtPrecoVenda.Text = p.PrecoVenda.ToString();
                txtProfundidade.Text = p.Profundidade.ToString();
                txtQuantidadeEstoque.Text = p.QuantidadeEstoque.ToString();
                chkCondicao.Checked = p.Condicao;
                chkSituacao.Checked = p.Situacao;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidarProduto()) return;
            Produto p = ObterProduto();
            try
            {
                if (EditMode)
                {
                    p.Cod = this.CodigoSelecionado;
                    dao.Atualizar(p);
                    MessageBox.Show("Produto atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK);
                } else
                {
                    dao.Cadastrar(p);

                    MessageBox.Show("Produto cadastrado com sucesso!", "Produto Cadastrado", MessageBoxButtons.OK);
                }
                this.Close();
            } catch (Exception ex)
            {
                MessageBox.Show("Houve um erro", ex.Message, MessageBoxButtons.OK);
            }            
        }

        private bool ValidarProduto()
        {
            bool valid = true;
            if (txtDescricao.Text.Trim().Count() == 0)
            {
                MessageBox.Show("Preencha a Descrição", "Erro");
                valid = false;
            } else if (txtPrecoVenda.Text.Trim().Count() == 0)
            {
                MessageBox.Show("Preencha o Preço do produto", "Erro");
                valid = false;
            } else if (txtQuantidadeEstoque.Text.Trim().Count() == 0)
            {
                MessageBox.Show("Preencha a quantidade em estoque", "Erro");
                valid = false;
            } else if (!Util.ValidarDouble(txtQuantidadeEstoque.Text))
            {
                MessageBox.Show("Preencha um valor válido para o estoque", "Erro");
                valid = false;
            } else if (!Util.ValidarDouble(txtPrecoVenda.Text))
            {
                MessageBox.Show("Preencha um valor válido para o preço de venda", "Erro");
                valid = false;
            } else if (txtPeso.Text.Trim().Count() > 0 && !Util.ValidarDouble(txtPeso.Text))
            {
                MessageBox.Show("Preencha um valor válido para o peso", "Erro");
                valid = false;
            } else if (txtAltura.Text.Trim().Count() > 0 && !Util.ValidarDouble(txtAltura.Text))
            {
                MessageBox.Show("Preencha um valor válido para a Altura", "Erro");
                valid = false;
            } else if (txtLargura.Text.Trim().Count() > 0 && !Util.ValidarDouble(txtLargura.Text))
            {
                MessageBox.Show("Preencha um valor válido para a Largura", "Erro");
                valid = false;
            } else if (txtProfundidade.Text.Trim().Count() > 0 && !Util.ValidarDouble(txtProfundidade.Text))
            {
                MessageBox.Show("Preencha um valor válido para a Profundidade", "Erro");
                valid = false;
            }

            return valid;
        }

        private Produto ObterProduto()
        {
            Produto produto = new Produto
            {
                Descricao = txtDescricao.Text,
                Largura = txtLargura.Text.Length > 0 ? Convert.ToDouble(txtLargura.Text) : 0,
                Altura = txtAltura.Text.Length > 0 ? Convert.ToDouble(txtAltura.Text) : 0,
                CodigoBarras = txtCodigoBarras.Text,
                Profundidade = txtProfundidade.Text.Length > 0 ? Convert.ToDouble(txtProfundidade.Text) : 0,
                Condicao = chkCondicao.Checked,
                Situacao = chkSituacao.Checked,
                Marca = txtMarca.Text,
                Peso = txtPeso.Text.Length > 0 ? Convert.ToDouble(txtPeso.Text) : 0,
                PrecoVenda = Convert.ToDouble(txtPrecoVenda.Text),
                QuantidadeEstoque = Convert.ToDouble(txtQuantidadeEstoque.Text)

            };
            return produto;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetProdutoContext(int cod)
        {
            this.CodigoSelecionado = cod;
            EditMode = true;
        }
    }
}
