using ERPAdvocacia.Data;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPAdvocacia
{
    public partial class FrmClientes : Form
    {
        private void LimparCampos()
        {
            idClienteSelecionado = 0;
            txtNomeRazaoSocial.Clear();
            txtCpfCnpj.Clear();
            txtTelefone.Clear();
            txtEmail.Clear();
            txtEndereco.Clear();
            dgvClientes.ClearSelection();
            btnSalvar.Enabled = true;
            btnAlterar.Enabled = false;
            btnDesativar.Enabled = false;
            txtNomeRazaoSocial.Focus();
        }
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNomeRazaoSocial.Text))
            {
                MessageBox.Show(
                    "Informe o nome ou razão social do cliente.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtNomeRazaoSocial.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCpfCnpj.Text))
            {
                MessageBox.Show(
                    "Informe o CPF ou CNPJ do cliente.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtCpfCnpj.Focus();
                return false;
            }

            return true;
        }
        private int idClienteSelecionado = 0;
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            CarregarDados();
            LimparCampos();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }

            try
            {
                ConexaoBD db = new ConexaoBD();

                using (MySqlConnection conn = db.CriarConexao())
                {
                    conn.Open();

                    string sql = @"INSERT INTO CLIENTE (nome_razao_social, cpf_cnpj, telefone, email, endereco)
                           VALUES (@nome, @cpf, @telefone, @email, @endereco)";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@nome", txtNomeRazaoSocial.Text.Trim());
                    cmd.Parameters.AddWithValue("@cpf", txtCpfCnpj.Text.Trim());
                    cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text.Trim());

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Cliente cadastrado com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimparCampos();
                CarregarDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar cliente: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CarregarDados()
        {
            try
            {
                ConexaoBD db = new ConexaoBD();

                string sql = @"SELECT * FROM CLIENTE
                       WHERE nome_razao_social LIKE @pesquisa
                       OR cpf_cnpj LIKE @pesquisa
                       ORDER BY nome_razao_social";

                dgvClientes.DataSource = db.ExecutarSelect(sql, txtPesquisar.Text.Trim());
                dgvClientes.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar clientes: " + ex.Message);
            }
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow linha = dgvClientes.Rows[e.RowIndex];

            idClienteSelecionado = Convert.ToInt32(linha.Cells["id_cliente"].Value);

            txtNomeRazaoSocial.Text = linha.Cells["nome_razao_social"].Value.ToString();
            txtCpfCnpj.Text = linha.Cells["cpf_cnpj"].Value.ToString();
            txtTelefone.Text = linha.Cells["telefone"].Value.ToString();
            txtEmail.Text = linha.Cells["email"].Value.ToString();
            txtEndereco.Text = linha.Cells["endereco"].Value.ToString();

            bool ativo = Convert.ToBoolean(linha.Cells["ativo"].Value);

            btnSalvar.Enabled = false;
            btnAlterar.Enabled = ativo;
            btnDesativar.Enabled = ativo;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (idClienteSelecionado == 0 || !ValidarCampos())
            {
                return;
            }

            try
            {
                ConexaoBD db = new ConexaoBD();

                using (MySqlConnection conn = db.CriarConexao())
                {
                    conn.Open();

                    string sql = @"UPDATE CLIENTE SET
                           nome_razao_social = @nome,
                           cpf_cnpj = @cpf,
                           telefone = @telefone,
                           email = @email,
                           endereco = @endereco
                           WHERE id_cliente = @id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@nome", txtNomeRazaoSocial.Text.Trim());
                    cmd.Parameters.AddWithValue("@cpf", txtCpfCnpj.Text.Trim());
                    cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", idClienteSelecionado);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Cliente alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CarregarDados();
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao alterar cliente: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDesativar_Click(object sender, EventArgs e)
        {
            if (idClienteSelecionado == 0)
            {
                MessageBox.Show("Selecione um cliente.");
                return;
            }

            DialogResult resposta = MessageBox.Show(
                "Deseja realmente desativar este cliente?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resposta == DialogResult.No)
            {
                return;
            }

            try
            {
                ConexaoBD db = new ConexaoBD();

                using (MySqlConnection conn = db.CriarConexao())
                {
                    conn.Open();

                    string sql = "UPDATE CLIENTE SET ativo = FALSE WHERE id_cliente = @id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", idClienteSelecionado);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Cliente desativado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CarregarDados();
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao desativar cliente: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            LimparCampos();
            txtPesquisar.Focus();
            CarregarDados();
        }

        private void txtNomeRazaoSocial_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
