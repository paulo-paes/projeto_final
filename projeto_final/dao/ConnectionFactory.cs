using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_final.dao
{
    public static class ConnectionFactory
    {
        private static string strConnection = "server=localhost;User Id=root;database=projeto_final;password=root";

        public static MySqlConnection Connect()
        {
            MySqlConnection conexao = new MySqlConnection(strConnection);
            try
            {
                conexao.Open();
            }
            catch
            {
                throw new Exception("Não foi possível conectar no banco de dados");
            }
            
            return conexao;
        }

        public static void CloseConnection(MySqlConnection conexao)
        {
            conexao.Close();
        }        
    }
}
