using System;
using System.Windows.Forms;
using ERPAdvocacia.Data;

namespace ERPAdvocacia.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                ConexaoBD db = new ConexaoBD();
                gridClientes.DataSource = db.ExecutarSelect("SELECT * FROM CLIENTE");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }
    }   
}