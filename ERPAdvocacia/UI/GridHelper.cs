using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ERPAdvocacia.UI
{
                                                                        
                                                                              
    public static class GridHelper
    {
        public static void Titulo(DataGridView grid, string coluna, string titulo)
        {
            if (grid.Columns.Contains(coluna))
            {
                grid.Columns[coluna].HeaderText = titulo;
            }
        }

        public static void Ocultar(DataGridView grid, params string[] colunas)
        {
            foreach (string coluna in colunas)
            {
                if (grid.Columns.Contains(coluna))
                {
                    grid.Columns[coluna].Visible = false;
                }
            }
        }

                                                                                 
        public static void FormatarColuna(DataGridView grid, string coluna, string formato)
        {
            if (grid.Columns.Contains(coluna))
            {
                grid.Columns[coluna].DefaultCellStyle.Format = formato;
            }
        }

                                                            
        public static void Dinheiro(DataGridView grid, string coluna)
        {
            if (grid.Columns.Contains(coluna))
            {
                grid.Columns[coluna].DefaultCellStyle.Format = "N2";
                grid.Columns[coluna].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

                                                                                                  
        public static void Preencher(DataGridView grid, string coluna, int larguraMinima)
        {
            if (grid.Columns.Contains(coluna))
            {
                grid.Columns[coluna].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                grid.Columns[coluna].MinimumWidth = larguraMinima;
            }
        }

                                                                                              
        public static void FormatarCpfCnpj(DataGridView grid, string coluna)
        {
            grid.CellFormatting += (sender, e) =>
            {
                if (e.RowIndex >= 0
                    && e.Value != null
                    && grid.Columns.Contains(coluna)
                    && e.ColumnIndex == grid.Columns[coluna].Index)
                {
                    e.Value = Formato.CpfCnpj(e.Value.ToString());
                    e.FormattingApplied = true;
                }
            };
        }

                                              
                                                   
                                      
                                       
                                                                                              
        public static void PintarPrazos(DataGridView grid)
        {
            grid.DataBindingComplete += (sender, e) =>
            {
                if (!grid.Columns.Contains("status") || !grid.Columns.Contains("data_vencimento"))
                {
                    return;
                }

                foreach (DataGridViewRow linha in grid.Rows)
                {
                    string status = Convert.ToString(linha.Cells["status"].Value) ?? "";
                    object vencimento = linha.Cells["data_vencimento"].Value;

                    if (status == "cumprido")
                    {
                        linha.DefaultCellStyle.BackColor = Color.FromArgb(226, 242, 226);
                    }
                    else if (status == "cancelado")
                    {
                        linha.DefaultCellStyle.BackColor = Color.FromArgb(235, 235, 235);
                    }
                    else if (status == "pendente" && vencimento != null && vencimento != DBNull.Value
                             && Convert.ToDateTime(vencimento) < DateTime.Now)
                    {
                        linha.DefaultCellStyle.BackColor = Color.FromArgb(252, 226, 226);
                    }
                }
            };
        }
    }
}
