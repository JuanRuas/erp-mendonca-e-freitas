using System;
using System.Data;
using System.Windows.Forms;

namespace ERPAdvocacia.UI
{
                                                            
    public static class Controles
    {
                                                                   
        public static void PreencherCombo(ComboBox combo, DataTable dados, string campoTexto, string campoValor)
        {
            combo.DataSource = dados;
            combo.DisplayMember = campoTexto;
            combo.ValueMember = campoValor;
            combo.SelectedIndex = -1;
        }

                                                                                  
                                                                                  
        public static void PreencherComboComTodos(ComboBox combo, DataTable dados, string campoTexto, string campoValor, string textoTodos)
        {
            DataRow todos = dados.NewRow();
            todos[campoValor] = 0;
            todos[campoTexto] = textoTodos;
            dados.Rows.InsertAt(todos, 0);

            combo.DataSource = dados;
            combo.DisplayMember = campoTexto;
            combo.ValueMember = campoValor;
            combo.SelectedIndex = 0;
        }

                                                                                        
        public static int IdSelecionado(ComboBox combo)
        {
            if (combo.SelectedValue == null)
            {
                return 0;
            }

            return Convert.ToInt32(combo.SelectedValue);
        }
    }
}
