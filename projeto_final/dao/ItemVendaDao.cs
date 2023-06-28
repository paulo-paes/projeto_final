using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using projeto_final.model;
using System;
using System.Collections.Generic;

namespace projeto_final.dao
{
    public class ItemVendaDao
    {
        private const string tabela = "itens_venda";
        public void Cadastrar(ItemVenda item)
        {
            string query = "INSERT INTO " + tabela + " (" +
                "cod_venda," +
                "cod_produto," +
                "quantidade," +
                "descricao," +
                "vlr_unitario," +
                "sub_total" +
                ")" +
                "VALUES (" +
                "@cod_venda," +
                "@cod_produto," +
                "@quantidade," +
                "@descricao," +
                "@vlr_unitario," +
                "@sub_total" +
                ")";

            MySqlCommand comando = CriarComandoComParametros(query, item);
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

        public List<ItemVenda> Listar()
        {

            string query = "SELECT * FROM " + tabela;

            MySqlConnection conexao = ConnectionFactory.Connect();
            List<ItemVenda> itens = new List<ItemVenda>();

            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexao);
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        itens.Add(new ItemVenda
                        {
                            Cod = reader.GetInt32("cod"),
                            CodVenda = reader.GetInt32("cod_venda"),
                            CodProduto = reader.GetInt32("cod_produto"),
                            Quantidade = reader.IsDBNull(3) ? -1 : reader.GetInt32("quantidade"),
                            Descricao = reader.GetString("descricao"),
                            ValorUnitario = reader.IsDBNull(5) ? -1 : reader.GetDouble("vlr_unitario"),
                            SubTotal = reader.IsDBNull(6) ? -1 : reader.GetDouble("sub_total")
                        });
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar os itens no banco " + ex.Message);
            }
            finally
            {
                ConnectionFactory.CloseConnection(conexao);
            }

            return itens;
        }

        public ItemVenda ObterPorCod(int cod)
        {

            string query = "SELECT * FROM " + tabela +
                " WHERE cod = @cod";

            MySqlConnection conexao = ConnectionFactory.Connect();
            ItemVenda item = null;

            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@cod", cod);
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        item = new ItemVenda
                        {
                            Cod = reader.GetInt32("cod"),
                            CodVenda = reader.GetInt32("cod_venda"),
                            CodProduto = reader.GetInt32("cod_produto"),
                            Quantidade = reader.IsDBNull(3) ? -1 : reader.GetInt32("quantidade"),
                            Descricao = reader.GetString("descricao"),
                            ValorUnitario = reader.IsDBNull(5) ? -1 : reader.GetDouble("vlr_unitario"),
                            SubTotal = reader.IsDBNull(6) ? -1 : reader.GetDouble("sub_total")
                        };
                        break;
                    }
                    reader.Close();
                }
            }
            catch
            {
                throw new Exception("Não foi possível buscar o item no banco");
            }
            finally
            {
                ConnectionFactory.CloseConnection(conexao);
            }

            return item;
        }

        public void Atualizar(ItemVenda item)
        {
            ItemVenda itemBanco = ObterPorCod(item.Cod);
            if (itemBanco == null)
            {
                throw new Exception("Item não encontrado");
            }
            string query = "UPDATE " + tabela + " SET " +
                "cod_venda = @cod_venda," +
                "cod_produto = @cod_produto," +
                "quantidade = @quantidade," +
                "descricao = @descricao," +
                "vlr_unitario = @vlr_unitario" +
                "sub_total = @sub_total";

            MySqlCommand comando = CriarComandoComParametros(query, item);
            comando.Parameters.AddWithValue("@cod", item.Cod);
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

        private MySqlCommand CriarComandoComParametros(string query, ItemVenda item)
        {
            MySqlConnection conexao = ConnectionFactory.Connect();

            MySqlCommand comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@cod_venda", item.CodVenda);
            comando.Parameters.AddWithValue("@cod_produto", item.CodProduto);
            comando.Parameters.AddWithValue("@quantidade", item.Quantidade);
            comando.Parameters.AddWithValue("@descricao", item.Descricao);
            comando.Parameters.AddWithValue("@vlr_unitario", item.ValorUnitario);
            comando.Parameters.AddWithValue("@sub_total", item.SubTotal);

            return comando;
        }
    }

}

