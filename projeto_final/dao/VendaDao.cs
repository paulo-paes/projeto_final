using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using projeto_final.model;
using System;
using System.Collections.Generic;

namespace projeto_final.dao
{
    public class VendaDao
    {
        private const string tabela = "vendas";
        public void Cadastrar(Venda venda)
        {
            string query = "INSERT INTO " + tabela + " (" +
                "dt_venda," +
                "cod_cliente," +
                "cod_usuario," +
                "total_itens," +
                "sub_total," +
                "desconto," +
                "valor_total," +
                "forma_pagamento," +
                "situacao," +
                "observacoes" +
                ")" +
                "VALUES (" +
                "@dt_venda" +
                "@cod_cliente" +
                "@cod_usuario" +
                "@total_itens" +
                "@sub_total" +
                "@desconto" +
                "@valor_total" +
                "@forma_pagamento" +
                "@situacao" +
                "@observacoes" +
                ")";

            MySqlCommand comando = CriarComandoComParametros(query, venda);
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
                throw new Exception("Cliente não encontrado");
            }
            string query = "UPDATE " + tabela + " SET " +
                "nome = @nome, " +
                "situacao = @situacao, " +
                "usuario = @usuario" +
                "senha = @senha" +
                "WHERE cod = @cod";

            MySqlCommand comando = CriarComandoComParametros(query, venda);
            comando.Parameters.AddWithValue("@cod", venda.Cod);
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
    }

}

