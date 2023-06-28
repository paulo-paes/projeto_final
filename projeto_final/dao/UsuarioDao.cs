using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using projeto_final.model;
using System;
using System.Collections.Generic;

namespace projeto_final.dao
{
    public class UsuarioDao
    {
        private const string tabela = "usuarios";
        public void Cadastrar(Usuario usuario)
        {
            string query = "INSERT INTO " + tabela + " (nome, usuario, senha, situacao)" + 
                "VALUES (@nome, @usuario, @senha, @situacao)";

            MySqlCommand comando = CriarComandoComParametros(query, usuario);
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

        public List<Usuario> Listar()
        {

            string query = "SELECT * FROM " + tabela;

            MySqlConnection conexao = ConnectionFactory.Connect();
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexao);
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        usuarios.Add(new Usuario
                        {
                            Cod = reader.GetInt32("cod"),
                            Nome = reader.IsDBNull(1) ? null : reader.GetString("nome"),
                            Login = reader.IsDBNull(2) ? null : reader.GetString("usuario"),
                            Senha = reader.IsDBNull(3) ? null : reader.GetString("senha"),
                            Situacao = reader.IsDBNull(4) || reader.GetBoolean("situacao"),
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

            return usuarios;
        }

        public Usuario ObterPorCod(int cod)
        {

            string query = "SELECT * FROM " + tabela +
                " WHERE cod = @cod";

            MySqlConnection conexao = ConnectionFactory.Connect();
            Usuario usuario = null;

            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@cod", cod);
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        usuario = new Usuario
                        {
                            Cod = reader.GetInt32("cod"),
                            Nome = reader.IsDBNull(1) ? null : reader.GetString("nome"),
                            Login = reader.IsDBNull(2) ? null : reader.GetString("usuario"),
                            Senha = reader.IsDBNull(3) ? null : reader.GetString("senha"),
                            Situacao = reader.IsDBNull(4) || reader.GetBoolean("situacao"),
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

            return usuario;
        }

        public void Atualizar(Usuario usuario)
        {
            Usuario usuarioBanco = ObterPorCod(usuario.Cod);
            if (usuarioBanco == null)
            {
                throw new Exception("Cliente não encontrado");
            }
            string query = "UPDATE " + tabela + " SET " +
                "nome = @nome, " +
                "situacao = @situacao, " +
                "usuario = @usuario" +
                "senha = @senha" +
                "WHERE cod = @cod";

            MySqlCommand comando = CriarComandoComParametros(query, usuario);
            comando.Parameters.AddWithValue("@cod", usuario.Cod);
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

        private MySqlCommand CriarComandoComParametros(string query, Usuario usuario)
        {
            MySqlConnection conexao = ConnectionFactory.Connect();

            MySqlCommand comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@nome", usuario.Nome);
            comando.Parameters.AddWithValue("@situacao", usuario.Situacao);
            comando.Parameters.AddWithValue("@usuario", usuario.Login);
            comando.Parameters.AddWithValue("@senha", usuario.Senha);

            return comando;
        }
    }

}

