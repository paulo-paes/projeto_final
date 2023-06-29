using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using projeto_final.model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projeto_final.dao
{
    public class ClienteDao
    {
        private const string tabela = "clientes";
        public void Cadastrar(Cliente cliente)
        {
            string query = "INSERT INTO " +
                tabela +
                " (nome, situacao, cpf, " +
                "rg, genero, dt_nascimento, estado_civil, " +
                "profissao, nacionalidade, telefone, celular, whatsapp," +
                "email, endereco, numero, bairro, cidade, complemento, uf," +
                "cep, observacoes)" +
                "VALUES (" +
                "@nome," +
                "@situacao," +
                "@cpf," +
                "@rg," +
                "@genero," +
                "@dt_nascimento," +
                "@estado_civil," +
                "@profissao," +
                "@nacionalidade," +
                "@telefone," +
                "@celular," +
                "@whatsapp," +
                "@email," +
                "@endereco," +
                "@numero," +
                "@bairro," +
                "@cidade," +
                "@complemento," +
                "@uf," +
                "@cep," +
                "@observacoes" +
                ")";

            MySqlCommand comando = CriarComandoComParametros(query, cliente);
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

        public List<Cliente> Listar()
        {

            string query = "SELECT * FROM " + tabela;

            MySqlConnection conexao = ConnectionFactory.Connect();
            List<Cliente> clientes = new List<Cliente>();

            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexao);
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        clientes.Add(new Cliente
                        {
                            Cod = reader.GetInt32("cod"),
                            Nome = reader.IsDBNull(1) ? null : reader.GetString("nome"),
                            Situacao = reader.IsDBNull(2) ? false : reader.GetInt32("situacao") == 1,
                            Cpf = reader.IsDBNull(3) ? null : reader.GetString("cpf"),
                            Rg = reader.IsDBNull(4) ? null : reader.GetString("rg"),
                            Genero = reader.IsDBNull(5) ? null : reader.GetString("genero"),
                            DataNascimento = reader.IsDBNull(6) ? DateTime.Now : reader.GetDateTime("dt_nascimento"),
                            EstadoCivil = reader.IsDBNull(7) ? null : reader.GetString("estado_civil"),
                            Profissao = reader.IsDBNull(8) ? null : reader.GetString("profissao"),
                            Nacionalidade = reader.IsDBNull(9) ? null : reader.GetString("nacionalidade"),
                            Telefone = reader.IsDBNull(10) ? null : reader.GetString("telefone"),
                            Celular = reader.IsDBNull(11) ? null : reader.GetString("celular"),
                            Whatsapp = reader.IsDBNull(12) ? false : reader.GetInt32("whatsapp") == 1,
                            Email = reader.IsDBNull(13) ? null : reader.GetString("email"),
                            Endereco = reader.IsDBNull(14) ? null : reader.GetString("endereco"),
                            Numero = reader.IsDBNull(15) ? null : reader.GetString("numero"),
                            Complemento = reader.IsDBNull(16) ? null : reader.GetString("complemento"),
                            Bairro = reader.IsDBNull(17) ? null : reader.GetString("bairro"),
                            Cidade = reader.IsDBNull(18) ? null : reader.GetString("cidade"),
                            UF = reader.IsDBNull(19) ? null : reader.GetString("uf"),
                            Cep = reader.IsDBNull(20) ? null : reader.GetString("cep"),
                            Observacoes = reader.IsDBNull(21) ? null : reader.GetString("observacoes"),
                            DataCadastro = reader.IsDBNull(22) ? DateTime.Now : reader.GetDateTime("dt_cadastro"),
                        });
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar os clientes no banco " + ex.Message);
            }
            finally
            {
                ConnectionFactory.CloseConnection(conexao);
            }

            return clientes;
        }

        public Cliente ObterPorCod(int cod)
        {

            string query = "SELECT * FROM " + tabela +
                " WHERE cod = @cod";

            MySqlConnection conexao = ConnectionFactory.Connect();
            Cliente cliente = null;

            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@cod", cod);
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cliente = new Cliente
                        {
                            Cod = reader.GetInt32("cod"),
                            Nome = reader.IsDBNull(reader.GetOrdinal("nome")) ? null : reader.GetString("nome"),
                            Situacao = reader.IsDBNull(reader.GetOrdinal("situacao")) ? false : reader.GetInt32("situacao") == 1,
                            Cpf = reader.GetString("cpf"),
                            Rg = reader.GetString("rg"),
                            Genero = reader.GetString("genero"),
                            DataNascimento = reader.IsDBNull(reader.GetOrdinal("dt_nascimento")) ? DateTime.Now : reader.GetDateTime("dt_nascimento"),
                            EstadoCivil = reader.GetString("estado_civil"),
                            Profissao = reader.GetString("profissao"),
                            Nacionalidade = reader.GetString("nacionalidade"),
                            Telefone = reader.GetString("telefone"),
                            Celular = reader.GetString("celular"),
                            Whatsapp = reader.IsDBNull(reader.GetOrdinal("whatsapp")) ? false : reader.GetInt32("whatsapp") == 1,
                            Email = reader.GetString("email"),
                            Endereco = reader.GetString("endereco"),
                            Numero = reader.GetString("numero"),
                            Complemento = reader.GetString("complemento"),
                            Bairro = reader.GetString("bairro"),
                            Cidade = reader.GetString("cidade"),
                            UF = reader.GetString("uf"),
                            Cep = reader.GetString("cep"),
                            Observacoes = reader.GetString("observacoes"),
                            DataCadastro = reader.IsDBNull(reader.GetOrdinal("dt_cadastro")) ? DateTime.Now : reader.GetDateTime("dt_cadastro"),
                        };
                        break;
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw new Exception("Não foi possível buscar o cliente no banco");
            }
            finally
            {
                ConnectionFactory.CloseConnection(conexao);
            }

            return cliente;
        }

        public void Atualizar(Cliente cliente)
        {
            Cliente clienteBanco = ObterPorCod(cliente.Cod);
            if (clienteBanco == null)
            {
                throw new Exception("Cliente não encontrado");
            }
            string query = "UPDATE " + tabela + " SET " +
                "nome = @nome, " +
                "situacao = @situacao, " +
                "cpf = @cpf, " +
                "rg = @rg, " +
                "genero = @genero, " +
                "dt_nascimento = @dt_nascimento, " +
                "estado_civil = @estado_civil, " +
                "profissao = @profissao, " +
                "nacionalidade = @nacionalidade, " +
                "telefone = @telefone, " +
                "celular = @celular, " +
                "whatsapp = @whatsapp, " +
                "email = @email ," +
                "endereco = @endereco, " +
                "numero = @numero, " +
                "bairro = @bairro, " +
                "cidade = @cidade, " +
                "complemento = @complemento, " +
                "uf = @uf, " +
                "observacoes = @observacoes, " +
                "cep = @cep " +
                "WHERE cod = @cod";

            MySqlCommand comando = CriarComandoComParametros(query, cliente);
            comando.Parameters.AddWithValue("@cod", cliente.Cod);
            MessageBox.Show(comando.CommandText);
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
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

        private MySqlCommand CriarComandoComParametros(string query, Cliente cliente)
        {
            MySqlConnection conexao = ConnectionFactory.Connect();

            MySqlCommand comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@nome", cliente.Nome);
            comando.Parameters.AddWithValue("@situacao", cliente.Situacao ? 1 : 0);
            comando.Parameters.AddWithValue("@cpf", cliente.Cpf);
            comando.Parameters.AddWithValue("@rg", cliente.Rg);
            comando.Parameters.AddWithValue("@genero", cliente.Genero);
            comando.Parameters.AddWithValue("@dt_nascimento", cliente.DataNascimento);
            comando.Parameters.AddWithValue("@estado_civil", cliente.EstadoCivil);
            comando.Parameters.AddWithValue("@profissao", cliente.Profissao);
            comando.Parameters.AddWithValue("@nacionalidade", cliente.Nacionalidade);
            comando.Parameters.AddWithValue("@telefone", cliente.Telefone);
            comando.Parameters.AddWithValue("@celular", cliente.Celular);
            comando.Parameters.AddWithValue("@whatsapp", cliente.Whatsapp ? 1 : 0);
            comando.Parameters.AddWithValue("@email", cliente.Email);
            comando.Parameters.AddWithValue("@endereco", cliente.Endereco);
            comando.Parameters.AddWithValue("@numero", cliente.Numero);
            comando.Parameters.AddWithValue("@bairro", cliente.Bairro);
            comando.Parameters.AddWithValue("@cidade", cliente.Cidade);
            comando.Parameters.AddWithValue("@complemento", cliente.Complemento);
            comando.Parameters.AddWithValue("@uf", cliente.UF);
            comando.Parameters.AddWithValue("@observacoes", cliente.Observacoes);
            comando.Parameters.AddWithValue("@cep", cliente.Cep);

            return comando;
        }
    }

}

