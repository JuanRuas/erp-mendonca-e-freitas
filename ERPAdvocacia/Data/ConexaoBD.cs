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

            using (MySqlConnection conn = CriarConexao())
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
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








        public static MySqlParameter P(string nome, object valor)
        {
            MySqlParameter p = new MySqlParameter();
            p.ParameterName = nome;
            p.Value = valor ?? DBNull.Value;
            return p;
        }


        public DataTable ExecutarSelect(string sql, params MySqlParameter[] parametros)
        {
            using (MySqlConnection conn = CriarConexao())
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddRange(parametros);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }


        public long ExecutarComando(string sql, params MySqlParameter[] parametros)
        {
            using (MySqlConnection conn = CriarConexao())
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddRange(parametros);

                cmd.ExecuteNonQuery();

                return cmd.LastInsertedId;
            }
        }




        public decimal? TotalRecebido(int idContrato)
        {
            using (MySqlConnection conn = CriarConexao())
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("sp_total_recebido_contrato", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_id_contrato", idContrato);

                MySqlParameter saida = new MySqlParameter("p_total", MySqlDbType.Decimal);
                saida.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(saida);

                cmd.ExecuteNonQuery();

                if (saida.Value == null || saida.Value == DBNull.Value)
                {
                    return null;
                }

                return Convert.ToDecimal(saida.Value);
            }
        }
    }
}
