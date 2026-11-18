using System;
using System.Diagnostics;
using MySqlConnector;

namespace ERPAdvocacia.Data
{
                                                                         
                                                                               
    public static class Auditoria
    {
                                                                                  
        public static void Registrar(MySqlConnection conn, MySqlTransaction transacao,
            string acao, string entidade, int registroId, string detalhes)
        {
            if (!SessaoUsuario.EstaLogado)
            {
                throw new InvalidOperationException("Sessão inválida para registrar a auditoria.");
            }

            if (detalhes.Length > 255)
            {
                detalhes = detalhes.Substring(0, 255);
            }

            string sql = @"INSERT INTO AUDITORIA (usuario_id, acao, entidade, registro_id, detalhes)
                       VALUES (@usuario, @acao, @entidade, @registro, @detalhes)";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn, transacao))
            {
                cmd.Parameters.AddWithValue("@usuario", SessaoUsuario.IdUsuario);
                cmd.Parameters.AddWithValue("@acao", acao);
                cmd.Parameters.AddWithValue("@entidade", entidade);
                cmd.Parameters.AddWithValue("@registro", registroId);
                cmd.Parameters.AddWithValue("@detalhes", detalhes);
                cmd.ExecuteNonQuery();
            }
        }

                                                        
                                                                                     
        public static void Registrar(string acao, string entidade, int? registroId, string detalhes)
        {
            Registrar(SessaoUsuario.IdUsuario, acao, entidade, registroId, detalhes);
        }

                                                                                          
        public static void Registrar(int usuarioId, string acao, string entidade, int? registroId, string detalhes)
        {
            if (usuarioId <= 0)
            {
                return;
            }

            try
            {
                ConexaoBD db = new ConexaoBD();

                string sql = @"INSERT INTO AUDITORIA (usuario_id, acao, entidade, registro_id, detalhes)
                       VALUES (@usuario, @acao, @entidade, @registro, @detalhes)";

                if (detalhes != null && detalhes.Length > 255)
                {
                    detalhes = detalhes.Substring(0, 255);
                }

                db.ExecutarComando(sql,
                    ConexaoBD.P("@usuario", usuarioId),
                    ConexaoBD.P("@acao", acao),
                    ConexaoBD.P("@entidade", entidade),
                    ConexaoBD.P("@registro", registroId),
                    ConexaoBD.P("@detalhes", detalhes));
            }
            catch (Exception ex)
            {
                                                                                    
                                                                                        
                Debug.WriteLine("Falha ao registrar auditoria: " + ex.Message);
            }
        }
    }
}
