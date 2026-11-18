using ERPAdvocacia.Data;
using ERPAdvocacia.UI;
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
                Mensagens.Erro("carregar processos", ex);
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
                Mensagens.Erro("carregar responsáveis", ex);
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
                       WHERE PR.titulo LIKE @pesquisa
                       OR P.numero_cnj LIKE @pesquisa
                       OR U.nome LIKE @pesquisa
                       ORDER BY PR.data_vencimento";

                dgvPrazos.DataSource = db.ExecutarSelect(sql, txtPesquisar.Text.Trim());

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

                GridHelper.FormatarColuna(dgvPrazos, "data_vencimento", "dd/MM/yyyy HH:mm");
                GridHelper.FormatarColuna(dgvPrazos, "data_cumprimento", "dd/MM/yyyy HH:mm");

                dgvPrazos.ClearSelection();
            }
            catch (Exception ex)
            {
                Mensagens.Erro("carregar prazos", ex);
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

            btnSalvar.Enabled = Permissoes.Pode(Acao.CadastrarPrazo);
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

            GridHelper.PintarPrazos(dgvPrazos);

            txtTitulo.PlaceholderText = "Ex.: Contestação, Recurso, Audiência";
            txtDescricao.PlaceholderText = "Detalhes do prazo (opcional)";

            CarregarProcessos();
            CarregarResponsaveis();
            CarregarDados();
            LimparCampos();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            LimparCampos();
            txtPesquisar.Focus();
            dgvPrazos.DataSource = null;
            CarregarDados();
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

                    Auditoria.Registrar("CADASTRAR", "PRAZO_PROCESSUAL", (int)cmd.LastInsertedId,
                        "Prazo cadastrado: " + txtTitulo.Text.Trim());
                }

                MessageBox.Show("Prazo cadastrado com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CarregarDados();
                LimparCampos();
            }
            catch (Exception ex)
            {
                Mensagens.Erro("cadastrar prazo", ex);
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
            btnAlterar.Enabled = txtStatus.Text == "pendente" && Permissoes.Pode(Acao.AlterarPrazo);
            btnCumprir.Enabled = txtStatus.Text == "pendente" && Permissoes.Pode(Acao.CumprirPrazo);
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
                           WHERE id_prazo = @id AND status = 'pendente'";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@processo", cmbProcesso.SelectedValue);
                    cmd.Parameters.AddWithValue("@responsavel", cmbResponsavel.SelectedValue);
                    cmd.Parameters.AddWithValue("@titulo", txtTitulo.Text.Trim());
                    cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text.Trim());
                    cmd.Parameters.AddWithValue("@vencimento", dtpVencimento.Value);
                    cmd.Parameters.AddWithValue("@id", idPrazoSelecionado);

                    int alterados = cmd.ExecuteNonQuery();

                    if (alterados == 0)
                    {
                        Mensagens.Aviso("O prazo não foi alterado. Ele pode ter sido finalizado ou removido. Atualize a seleção.");
                        LimparCampos();
                        CarregarDados();
                        return;
                    }

                    Auditoria.Registrar("ALTERAR", "PRAZO_PROCESSUAL", idPrazoSelecionado,
                        "Prazo alterado: " + txtTitulo.Text.Trim());
                }

                MessageBox.Show("Prazo alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CarregarDados();
                LimparCampos();
            }
            catch (Exception ex)
            {
                Mensagens.Erro("alterar prazo", ex);
            }
        }

        private void btnCumprir_Click(object sender, EventArgs e)
        {
            if (idPrazoSelecionado == 0)
            {
                MessageBox.Show("Selecione um prazo.");
                return;
            }

            if (!Mensagens.Confirmar("Deseja realmente marcar este prazo como cumprido?"))
            {
                return;
            }

            try
            {
                ConexaoBD db = new ConexaoBD();
                using (MySqlConnection conn = db.CriarConexao())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("CALL sp_cumprir_prazo(@id, @usuario)", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idPrazoSelecionado);
                        cmd.Parameters.AddWithValue("@usuario", SessaoUsuario.IdUsuario);
                        object? resultado = cmd.ExecuteScalar();

                        if (resultado == null || resultado == DBNull.Value)
                        {
                            throw new InvalidOperationException("A procedure não confirmou o cumprimento.");
                        }

                        if (Convert.ToInt32(resultado) != 1)
                        {
                            Mensagens.Aviso("O prazo não existe mais ou não está pendente. Atualize a seleção.");
                            LimparCampos();
                            CarregarDados();
                            return;
                        }
                    }
                }

                Mensagens.Sucesso("Prazo cumprido com sucesso!");
                CarregarDados();
                LimparCampos();
            }
            catch (Exception ex)
            {
                Mensagens.Erro("cumprir prazo", ex);
            }
        }

    }
}
