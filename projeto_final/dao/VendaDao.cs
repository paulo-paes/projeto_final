using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using projeto_final.model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projeto_final.dao
{
    public class VendaDao
    {
        private const string tabela = "vendas";
        private ItemVendaDao ItemVendaDao = new ItemVendaDao();
        private ProdutoDao ProdutoDao = new ProdutoDao();
        public void Cadastrar(Venda venda)
        {
            string query = "INSERT INTO " + tabela + " (" +
                "cod_cliente," +
                /*"cod_usuario," +*/
                "total_itens," +
                "sub_total," +
                "desconto," +
                "valor_total," +
                "forma_pagamento," +
                "situacao," +
                "observacoes" +
                ")" +
                "VALUES (" +
                "@cod_cliente," +
                /*"@cod_usuario," +*/
                "@total_itens," +
                "@sub_total," +
                "@desconto," +
                "@valor_total," +
                "@forma_pagamento," +
                "@situacao," +
                "@observacoes" +
                ")";

            MySqlCommand comando = CriarComandoComParametros(query, venda);
            try
            {
                comando.ExecuteNonQuery();
                comando.CommandText = "SELECT last_insert_id() as id";
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    venda.Cod = Convert.ToInt32(reader["id"]);
                }
                ItemVendaDao.CadastrarLista(venda);
                ProdutoDao.AtualizarEstoque(venda);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw new Exception("Não foi possível inserir o registro no banco");
            }
            finally
            {
                ConnectionFactory.CloseConnection(comando.Connection);
            }
        }

        public List<Venda> Listar()
        {

            string query = "SELECT * FROM " + tabela;

            MySqlConnection conexao = ConnectionFactory.Connect();
            List<Venda> vendas = new List<Venda>();

            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexao);
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        vendas.Add(new Venda
                        {
                            Cod = reader.GetInt32("cod"),
                            DataVenda = reader.IsDBNull(1) ? DateTime.Now : reader.GetDateTime("dt_venda"),
                            CodCliente = reader.IsDBNull(2) ? -1 : reader.GetInt32("cod_cliente"),
                            CodUsuario = reader.IsDBNull(3) ? -1 : reader.GetInt32("cod_usuario"),
                            TotalItens = reader.IsDBNull(4) ? 0 : reader.GetInt32("total_itens"),
                            SubTotal = reader.IsDBNull(5) ? 0 : reader.GetDouble("sub_total"),
                            Desconto = reader.IsDBNull(6) ? 0 : reader.GetDouble("desconto"),
                            ValorTotal = reader.IsDBNull(7) ? -1 : reader.GetDouble("valor_total"),
                            FormaPagamento = reader.GetString("forma_pagamento"),
                            Situacao = reader.GetString("situacao"),
                            Observacoes = reader.GetString("observacoes")

                        });
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar os usuários no banco " + ex.Message);
            }
            finally
            {
                ConnectionFactory.CloseConnection(conexao);
            }

            return vendas;
        }

        public Venda ObterPorCod(int cod)
        {

            string query = "SELECT * FROM " + tabela +
                " WHERE cod = @cod";

            MySqlConnection conexao = ConnectionFactory.Connect();
            Venda venda = null;

            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@cod", cod);
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        venda = new Venda
                        {
                            Cod = reader.GetInt32("cod"),
                            DataVenda = reader.IsDBNull(1) ? DateTime.Now : reader.GetDateTime("dt_venda"),
                            CodCliente = reader.IsDBNull(2) ? -1 : reader.GetInt32("cod_cliente"),
                            CodUsuario = reader.IsDBNull(3) ? -1 : reader.GetInt32("cod_usuario"),
                            TotalItens = reader.IsDBNull(4) ? 0 : reader.GetInt32("total_itens"),
                            SubTotal = reader.IsDBNull(5) ? 0 : reader.GetDouble("sub_total"),
                            Desconto = reader.IsDBNull(6) ? 0 : reader.GetDouble("desconto"),
                            ValorTotal = reader.IsDBNull(7) ? -1 : reader.GetDouble("valor_total"),
                            FormaPagamento = reader.GetString("forma_pagamento"),
                            Situacao = reader.GetString("situacao"),
                            Observacoes = reader.GetString("observacoes")
                        };
                        break;
                    }
                    reader.Close();
                }
            }
            catch
            {
                throw new Exception("Não foi possível buscar o usuário no banco");
            }
            finally
            {
                ConnectionFactory.CloseConnection(conexao);
            }

            return venda;
        }

        public void Atualizar(Venda venda)
        {
            Venda vendaBanco = ObterPorCod(venda.Cod);
            if (vendaBanco == null)
            {
                throw new Exception("Venda não encontrada");
            }
            string query = "UPDATE " + tabela + " SET " +
                "observacoes = @observacoes, " +
                "situacao = @situacao " +
                "WHERE cod = @cod";

            MySqlConnection conexao = ConnectionFactory.Connect();
            MySqlCommand comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@cod", venda.Cod);
            comando.Parameters.AddWithValue("@observacoes", venda.Observacoes);
            comando.Parameters.AddWithValue("@situacao", venda.Situacao);
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar o registro no banco " + ex.Message);
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

        private MySqlCommand CriarComandoComParametros(string query, Venda venda)
        {
            MySqlConnection conexao = ConnectionFactory.Connect();

            MySqlCommand comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@dt_venda", venda.DataVenda);
            comando.Parameters.AddWithValue("@cod_cliente", venda.CodCliente);
            comando.Parameters.AddWithValue("@cod_usuario", venda.CodUsuario);
            comando.Parameters.AddWithValue("@total_itens", venda.TotalItens);
            comando.Parameters.AddWithValue("@sub_total", venda.SubTotal);
            comando.Parameters.AddWithValue("@desconto", venda.Desconto);
            comando.Parameters.AddWithValue("@valor_total", venda.ValorTotal);
            comando.Parameters.AddWithValue("@forma_pagamento", venda.FormaPagamento);
            comando.Parameters.AddWithValue("@situacao", venda.Situacao);
            comando.Parameters.AddWithValue("@observacoes", venda.Observacoes);

            return comando;
        }


        public List<RelatorioVenda> Listar(DateTime dataInicial, DateTime dataFinal)
        {
            dataInicial = dataInicial.Date;
            dataFinal = dataFinal.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            string query = "SELECT v.cod, v.dt_venda, c.nome, " +
                "v.total_itens, v.sub_total, v.desconto, v.valor_total, v.situacao " +
                "FROM vendas v " +
                "INNER JOIN clientes c " +
                "ON v.cod_cliente = c.cod " +
                "WHERE v.dt_venda > @dataInicial AND v.dt_venda <= @dataFinal";


            MySqlConnection conexao = ConnectionFactory.Connect();
            List<RelatorioVenda> vendas = new List<RelatorioVenda>();

            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@dataInicial", dataInicial);
                comando.Parameters.AddWithValue("@dataFinal", dataFinal);
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        vendas.Add(new RelatorioVenda
                        {
                            Codigo = reader.GetInt32("cod"),
                            DataVenda = reader.IsDBNull(1) ? DateTime.Now : reader.GetDateTime("dt_venda"),
                            NomeCliente = reader.GetString("nome"),
                            TotalItens = reader.IsDBNull(3) ? 0 : reader.GetInt32("total_itens"),
                            SubTotal = reader.IsDBNull(4) ? 0 : reader.GetDouble("sub_total"),
                            Desconto = reader.IsDBNull(5) ? 0 : reader.GetDouble("desconto"),
                            ValorTotal = reader.IsDBNull(6) ? -1 : reader.GetDouble("valor_total"),
                            Situacao = reader.IsDBNull(7) ? String.Empty : reader.GetString("situacao"),

                        });
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar as vendas no banco " + ex.Message);
            }
            finally
            {
                ConnectionFactory.CloseConnection(conexao);
            }

            return vendas;
        }

        public List<RelatorioProdutosMaisVendidos> ListarProdutos(DateTime dataInicial, DateTime dataFinal)
        {
            dataInicial = dataInicial.Date;
            dataFinal = dataFinal.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            string query = "SELECT p.cod, p.descricao, SUM(iv.quantidade) as quantidade " +
                "FROM vendas v " +
                "INNER JOIN itens_venda iv " +
                "ON iv.cod_venda = v.cod " +
                "INNER JOIN produtos p " +
                "ON p.cod = iv.cod_produto " +
                "WHERE v.dt_venda > @dataInicial AND v.dt_venda <= @dataFinal " +
                "GROUP BY p.cod " +
                "ORDER BY 3 DESC " +
                "LIMIT 10";


            MySqlConnection conexao = ConnectionFactory.Connect();
            List<RelatorioProdutosMaisVendidos> produtos = new List<RelatorioProdutosMaisVendidos>();

            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@dataInicial", dataInicial);
                comando.Parameters.AddWithValue("@dataFinal", dataFinal);
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        produtos.Add(new RelatorioProdutosMaisVendidos
                        {
                            Codigo = reader.GetInt32("cod"),
                            Descricao = reader.IsDBNull(1) ? string.Empty : reader.GetString("descricao"),
                            Quantidade = reader.IsDBNull(2) ? 0 : reader.GetDouble("quantidade")
                        });
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar os produtos no banco " + ex.Message);
            }
            finally
            {
                ConnectionFactory.CloseConnection(conexao);
            }

            return produtos;
        }
    }

}

