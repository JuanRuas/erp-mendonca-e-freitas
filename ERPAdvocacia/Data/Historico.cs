using System;
using System.Diagnostics;
using MySqlConnector;

namespace ERPAdvocacia.Data
{
                                                                                      
                                                                         
                                                                                   
    public static class Historico
    {
                                                                                  
        public static void Registrar(MySqlConnection conn, MySqlTransaction transacao, int processoId, string descricao)
        {
            if (!SessaoUsuario.EstaLogado || processoId <= 0)
            {
                throw new InvalidOperationException("Sessão ou processo inválido para registrar o histórico.");
            }

            string sql = @"INSERT INTO MOVIMENTACAO (processo_id, usuario_id, data_hora, descricao)
                       VALUES (@processo, @usuario, NOW(), @descricao)";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn, transacao))
            {
                cmd.Parameters.AddWithValue("@processo", processoId);
                cmd.Parameters.AddWithValue("@usuario", SessaoUsuario.IdUsuario);
                cmd.Parameters.AddWithValue("@descricao", descricao);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Registrar(int processoId, string descricao)
        {
            if (!SessaoUsuario.EstaLogado || processoId <= 0)
            {
                return;
            }

            try
            {
                ConexaoBD db = new ConexaoBD();

                string sql = @"INSERT INTO MOVIMENTACAO (processo_id, usuario_id, data_hora, descricao)
                       VALUES (@processo, @usuario, NOW(), @descricao)";

                db.ExecutarComando(sql,
                    ConexaoBD.P("@processo", processoId),
                    ConexaoBD.P("@usuario", SessaoUsuario.IdUsuario),
                    ConexaoBD.P("@descricao", descricao));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Falha ao registrar movimentação: " + ex.Message);
            }
        }
    }
}
