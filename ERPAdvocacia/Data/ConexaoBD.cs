using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySqlConnector;

namespace ERPAdvocacia.Data
{
    public class ConexaoBD
    {
        private string conexao = "Server=localhost;Database=erp_advocacia;Uid=root;Pwd=;";

        public MySqlConnection CriarConexao()
        {
            return new MySqlConnection(conexao);
        }
        public DataTable ExecutarSelect(string sql)
        {
            MySqlConnection conn = new MySqlConnection(conexao);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            conn.Close();
            return dt;
        }
        public DataTable ExecutarSelect(string sql, string pesquisa)
        {
            using (MySqlConnection conn = CriarConexao())
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@pesquisa", "%" + pesquisa + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }
        public DataTable ExecutarSelectPorId(string sql, int id)
        {
            using (MySqlConnection conn = CriarConexao())
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }
    }
}