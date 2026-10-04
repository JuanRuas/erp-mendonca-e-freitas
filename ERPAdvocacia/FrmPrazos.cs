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
    public partial class FrmPrazos : Form
    {
        private int idPrazoSelecionado = 0;
        public FrmPrazos()
        {
            InitializeComponent();
        }
        private void CarregarProcessos()
        {
            try
            {
                ConexaoBD db = new ConexaoBD();

                string sql = @"SELECT id_processo, numero_cnj
                       FROM PROCESSO
                       ORDER BY numero_cnj";

                DataTable dt = db.ExecutarSelect(sql);

                cmbProcesso.DataSource = dt;
                cmbProcesso.DisplayMember = "numero_cnj";
                cmbProcesso.ValueMember = "id_processo";
                cmbProcesso.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar processos: " + ex.Message);
            }
        }
        private void CarregarResponsaveis()
        {
            try
            {
                ConexaoBD db = new ConexaoBD();

                string sql = @"SELECT id_usuario, nome
                       FROM USUARIO
                       WHERE ativo = TRUE
                       ORDER BY nome";

                DataTable dt = db.ExecutarSelect(sql);

                cmbResponsavel.DataSource = dt;
                cmbResponsavel.DisplayMember = "nome";
                cmbResponsavel.ValueMember = "id_usuario";
                cmbResponsavel.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar responsáveis: " + ex.Message);
            }
        }
        private void CarregarDados()
        {
            try
            {
                ConexaoBD db = new ConexaoBD();

                string sql = @"SELECT PR.id_prazo, PR.processo_id, PR.responsavel_id,
                       P.numero_cnj, U.nome AS responsavel,
                       PR.titulo, PR.descricao, PR.data_vencimento,
                       PR.status, PR.data_cumprimento
                       FROM PRAZO_PROCESSUAL PR
                       INNER JOIN PROCESSO P ON PR.processo_id = P.id_processo
                       INNER JOIN USUARIO U ON PR.responsavel_id = U.id_usuario
                       ORDER BY PR.data_vencimento";

                dgvPrazos.DataSource = db.ExecutarSelect(sql);

                dgvPrazos.Columns["id_prazo"].Visible = false;
                dgvPrazos.Columns["processo_id"].Visible = false;
                dgvPrazos.Columns["responsavel_id"].Visible = false;

                dgvPrazos.Columns["numero_cnj"].HeaderText = "Processo";
                dgvPrazos.Columns["responsavel"].HeaderText = "Responsável";
                dgvPrazos.Columns["titulo"].HeaderText = "Título";
                dgvPrazos.Columns["descricao"].HeaderText = "Descrição";
                dgvPrazos.Columns["data_vencimento"].HeaderText = "Vencimento";
                dgvPrazos.Columns["status"].HeaderText = "Status";
                dgvPrazos.Columns["data_cumprimento"].HeaderText = "Cumprimento";

                dgvPrazos.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar prazos: " + ex.Message);
            }
        }
        private void LimparCampos()
        {
            idPrazoSelecionado = 0;

            cmbProcesso.SelectedIndex = -1;
            cmbResponsavel.SelectedIndex = -1;
            txtTitulo.Clear();
            txtDescricao.Clear();
            dtpVencimento.Value = DateTime.Now;
            txtStatus.Text = "pendente";

            dgvPrazos.ClearSelection();

            btnSalvar.Enabled = true;
            btnAlterar.Enabled = false;
            btnCumprir.Enabled = false;

            cmbProcesso.Focus();
        }
        private bool ValidarCampos()
        {
            if (cmbProcesso.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um processo.");
                cmbProcesso.Focus();
                return false;
            }

            if (cmbResponsavel.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um responsável.");
                cmbResponsavel.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("Informe o título do prazo.");
                txtTitulo.Focus();
                return false;
            }

            return true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void FrmPrazos_Load(object sender, EventArgs e)
        {
            CarregarProcessos();
            CarregarResponsaveis();
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

                    string sql = @"INSERT INTO PRAZO_PROCESSUAL
                           (processo_id, responsavel_id, titulo, descricao, data_vencimento, status)
                           VALUES
                           (@processo, @responsavel, @titulo, @descricao, @vencimento, @status)";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@processo", cmbProcesso.SelectedValue);
                    cmd.Parameters.AddWithValue("@responsavel", cmbResponsavel.SelectedValue);
                    cmd.Parameters.AddWithValue("@titulo", txtTitulo.Text.Trim());
                    cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text.Trim());
                    cmd.Parameters.AddWithValue("@vencimento", dtpVencimento.Value);
                    cmd.Parameters.AddWithValue("@status", "pendente");

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Prazo cadastrado com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CarregarDados();
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar prazo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPrazos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow linha = dgvPrazos.Rows[e.RowIndex];

            idPrazoSelecionado = Convert.ToInt32(linha.Cells["id_prazo"].Value);

            cmbProcesso.SelectedValue = Convert.ToInt32(linha.Cells["processo_id"].Value);
            cmbResponsavel.SelectedValue = Convert.ToInt32(linha.Cells["responsavel_id"].Value);

            txtTitulo.Text = linha.Cells["titulo"].Value.ToString();
            txtDescricao.Text = linha.Cells["descricao"].Value.ToString();
            dtpVencimento.Value = Convert.ToDateTime(linha.Cells["data_vencimento"].Value);
            txtStatus.Text = linha.Cells["status"].Value.ToString();

            btnSalvar.Enabled = false;
            btnAlterar.Enabled = txtStatus.Text == "pendente";
            btnCumprir.Enabled = txtStatus.Text == "pendente";
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (idPrazoSelecionado == 0 || !ValidarCampos())
            {
                return;
            }

            try
            {
                ConexaoBD db = new ConexaoBD();

                using (MySqlConnection conn = db.CriarConexao())
                {
                    conn.Open();

                    string sql = @"UPDATE PRAZO_PROCESSUAL SET
                           processo_id = @processo,
                           responsavel_id = @responsavel,
                           titulo = @titulo,
                           descricao = @descricao,
                           data_vencimento = @vencimento
                           WHERE id_prazo = @id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@processo", cmbProcesso.SelectedValue);
                    cmd.Parameters.AddWithValue("@responsavel", cmbResponsavel.SelectedValue);
                    cmd.Parameters.AddWithValue("@titulo", txtTitulo.Text.Trim());
                    cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text.Trim());
                    cmd.Parameters.AddWithValue("@vencimento", dtpVencimento.Value);
                    cmd.Parameters.AddWithValue("@id", idPrazoSelecionado);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Prazo alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CarregarDados();
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao alterar prazo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCumprir_Click(object sender, EventArgs e)
        {
            if (idPrazoSelecionado == 0)
            {
                MessageBox.Show("Selecione um prazo.");
                return;
            }

            DialogResult resposta = MessageBox.Show(
                "Deseja realmente marcar este prazo como cumprido?",
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

                    string sql = "CALL sp_cumprir_prazo(@id)";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", idPrazoSelecionado);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Prazo cumprido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CarregarDados();
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cumprir prazo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
