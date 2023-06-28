using MySql.Data.MySqlClient;
using projeto_final.model;
using System;
using System.Collections.Generic;

namespace projeto_final.dao
{
    public class ProdutoDao
    {
        private const string tabela = "produtos";
        public void Cadastrar(Produto produto)
        {
            string query = "INSERT INTO " +
                tabela +
                " (descricao, cod_barras, marca, " +
                "peso, largura, altura, profundidade, " +
                "situacao, condicao, preco_venda, quantidade_estoque)" +
                "VALUES (" +
                "@descricao," +
                "@cod_barras," +
                "@marca," +
                "@peso," +
                "@largura," +
                "@altura," +
                "@profundidade," +
                "@situacao," +
                "@condicao," +
                "@preco_venda," +
                "@quantidade_estoque" +
                ")";

            MySqlCommand comando = CriarComandoComParametros(query, produto);
            try
            {
                comando.ExecuteNonQuery();
            }
            catch
            {
                throw new Exception("Não foi possível inserir o registro no banco");
            }
            finally
            {
                ConnectionFactory.CloseConnection(comando.Connection);
            }
        }

        public List<Produto> Listar()
        {

            string query = "SELECT * FROM " + tabela;

            MySqlConnection conexao = ConnectionFactory.Connect();
            List<Produto> produtos = new List<Produto>();

            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexao);
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        produtos.Add(new Produto
                        {
                            Cod = reader.GetInt32("cod"),
                            Descricao = reader.GetString("descricao"),
                            CodigoBarras = reader.GetString("cod_barras"),
                            Marca = reader.GetString("marca"),
                            Peso = reader.GetDouble("peso"),
                            Largura = reader.GetDouble("largura"),
                            Altura = reader.GetDouble("altura"),
                            Profundidade = reader.GetDouble("profundidade"),
                            Situacao = reader.GetInt32("situacao") == 1,
                            Condicao = reader.GetInt32("condicao") == 1,
                            PrecoVenda = reader.GetDouble("preco_venda"),
                            QuantidadeEstoque = reader.GetDouble("quantidade_estoque"),
                            DataCadastro = reader.GetDateTime("dt_cadastro"),
                        });
                    }
                    reader.Close();
                }
            }
            catch
            {
                throw new Exception("Não foi possível buscar os produtos no banco");
            }
            finally
            {
                ConnectionFactory.CloseConnection(conexao);
            }

            return produtos;
        }

        public Produto ObterPorCod(int cod)
        {

            string query = "SELECT * FROM " + tabela +
                " WHERE cod = @cod";

            MySqlConnection conexao = ConnectionFactory.Connect();
            Produto produto = null;

            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@cod", cod);
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        produto = new Produto
                        {
                            Cod = reader.GetInt32("cod"),
                            Descricao = reader.GetString("descricao"),
                            CodigoBarras = reader.GetString("cod_barras"),
                            Marca = reader.GetString("marca"),
                            Peso = reader.GetDouble("peso"),
                            Largura = reader.GetDouble("largura"),
                            Altura = reader.GetDouble("altura"),
                            Profundidade = reader.GetDouble("profundidade"),
                            Situacao = reader.GetInt32("situacao") == 1,
                            Condicao = reader.GetInt32("condicao") == 1,
                            PrecoVenda = reader.GetDouble("preco_venda"),
                            QuantidadeEstoque = reader.GetDouble("quantidade_estoque"),
                            DataCadastro = reader.GetDateTime("dt_cadastro"),
                        };
                        break;
                    }
                    reader.Close();
                }
            }
            catch
            {
                throw new Exception("Não foi possível buscar os produtos no banco");
            }
            finally
            {
                ConnectionFactory.CloseConnection(conexao);
            }

            return produto;
        }

        public void Atualizar(Produto produto)
        {
            Produto produtoBanco = ObterPorCod(produto.Cod);
            if (produtoBanco == null)
            {
                throw new Exception("Produto não encontrado");
            }
            string query = "UPDATE " + tabela + " SET " +
                "descricao = @descricao, " +
                "cod_barras = @cod_barras, " +
                "marca = @marca, " +
                "peso = @peso, " +
                "largura = @largura, " +
                "altura = @altura, " +
                "profundidade = @profundidade, " +
                "situacao = @situacao, " +
                "condicao = @condicao, " +
                "preco_venda = @preco_venda, " +
                "quantidade_estoque = @quantidade_estoque " +
                "WHERE cod = @cod";

            MySqlCommand comando = CriarComandoComParametros(query, produto);
            comando.Parameters.AddWithValue("@cod", produto.Cod);
            try
            {
                comando.ExecuteNonQuery();
            }
            catch
            {
                throw new Exception("Não foi possível atualizar o registro no banco");
            }
            finally
            {
                ConnectionFactory.CloseConnection(comando.Connection);
            }
        }

        public void Excluir(int cod)
        {
            string query = "DELETE FROM " + tabela + " WHERE cod = @cod";

            MySqlConnection conexao = ConnectionFactory.Connect();

            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@cod", cod);

                comando.ExecuteNonQuery();
            }
            catch
            {
                throw new Exception("Não foi possível excluir o registro do banco");
            }
            finally
            {
                ConnectionFactory.CloseConnection(conexao);
            }
        }

        private MySqlCommand CriarComandoComParametros(string query, Produto produto)
        {
            MySqlConnection conexao = ConnectionFactory.Connect();

            MySqlCommand comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@descricao", produto.Descricao);
            comando.Parameters.AddWithValue("@cod_barras", produto.CodigoBarras);
            comando.Parameters.AddWithValue("@marca", produto.Marca);
            comando.Parameters.AddWithValue("@peso", produto.Peso);
            comando.Parameters.AddWithValue("@largura", produto.Largura);
            comando.Parameters.AddWithValue("@altura", produto.Altura);
            comando.Parameters.AddWithValue("@profundidade", produto.Profundidade);
            comando.Parameters.AddWithValue("@situacao", produto.Situacao ? 1 : 0);
            comando.Parameters.AddWithValue("@condicao", produto.Condicao ? 1 : 0);
            comando.Parameters.AddWithValue("@preco_venda", produto.PrecoVenda);
            comando.Parameters.AddWithValue("@quantidade_estoque", produto.QuantidadeEstoque);

            return comando;
        }
    }

}

