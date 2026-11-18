using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ERPAdvocacia.Data;

namespace ERPAdvocacia.UI
{
                                                                                                    
                                                                                 
                                                       
    public static class Exportador
    {
        public static void ParaCsv(DataGridView grade, string nomeSugerido, string nomeRelatorio)
        {
            if (grade.Rows.Count == 0)
            {
                Mensagens.Aviso("Não há dados para exportar. Gere o relatório primeiro.");
                return;
            }

            using (SaveFileDialog dialogo = new SaveFileDialog())
            {
                dialogo.Title = "Exportar relatório";
                dialogo.Filter = "Arquivo CSV (*.csv)|*.csv";
                dialogo.FileName = nomeSugerido + "_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".csv";

                if (dialogo.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    StringBuilder sb = new StringBuilder();

                                
                    bool primeira = true;
                    foreach (DataGridViewColumn coluna in grade.Columns)
                    {
                        if (!coluna.Visible) continue;
                        if (!primeira) sb.Append(';');
                        sb.Append(Escapar(coluna.HeaderText));
                        primeira = false;
                    }
                    sb.AppendLine();

                             
                    foreach (DataGridViewRow linha in grade.Rows)
                    {
                        primeira = true;
                        foreach (DataGridViewColumn coluna in grade.Columns)
                        {
                            if (!coluna.Visible) continue;
                            if (!primeira) sb.Append(';');

                            object valor = linha.Cells[coluna.Index].FormattedValue;
                            sb.Append(Escapar(valor == null ? "" : valor.ToString()));
                            primeira = false;
                        }
                        sb.AppendLine();
                    }

                    File.WriteAllText(dialogo.FileName, sb.ToString(), new UTF8Encoding(true));

                    Auditoria.Registrar("EXPORTAR_RELATORIO", "RELATORIO", null,
                        nomeRelatorio + " exportado (" + grade.Rows.Count + " linhas)");

                    Mensagens.Sucesso("Relatório exportado com sucesso:\n" + dialogo.FileName);
                }
                catch (Exception ex)
                {
                    Mensagens.Erro("exportar o relatório (o arquivo pode estar aberto em outro programa)", ex);
                }
            }
        }

                                                                           
        private static string Escapar(string texto)
        {
            if (texto.Contains(";") || texto.Contains("\"") || texto.Contains("\n") || texto.Contains("\r"))
            {
                return "\"" + texto.Replace("\"", "\"\"") + "\"";
            }

            return texto;
        }
    }
}
