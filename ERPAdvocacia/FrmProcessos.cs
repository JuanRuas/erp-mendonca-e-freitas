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
    public partial class FrmProcessos : Form
    {
        private void CarregarClientes()
        {
            try
            {
                ConexaoBD db = new ConexaoBD();

                string sql = "SELECT id_cliente, nome_razao_social FROM CLIENTE WHERE ativo = TRUE ORDER BY nome_razao_social";
                DataTable dt = db.ExecutarSelect(sql);

                cmbCliente.DataSource = dt;
                cmbCliente.DisplayMember = "nome_razao_social";
                cmbCliente.ValueMember = "id_cliente";
                cmbCliente.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                Mensagens.Erro("carregar clientes", ex);
            }
        }
        private int idProcessoSelecionado = 0;
        private void LimparCampos()
        {
            idProcessoSelecionado = 0;

            cmbCliente.SelectedIndex = -1;
            txtNumeroCnj.Clear();
            txtVara.Clear();
            txtComarca.Clear();
            txtValorCausa.Clear();
            txtStatus.Text = "rascunho";
            dtpDataAbertura.Value = DateTime.Today;
            btnVincularAdvogados.Enabled = false;

            dgvProcessos.ClearSelection();

            btnSalvar.Enabled = Permissoes.Pode(Acao.CadastrarProcesso);
            btnAlterar.Enabled = false;
            btnIniciar.Enabled = false;

            cmbCliente.Focus();
        }
        private bool ValidarCampos()
        {
            if (cmbCliente.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um cliente.");
                cmbCliente.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNumeroCnj.Text))
            {
                MessageBox.Show("Informe o número CNJ.");
                txtNumeroCnj.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtValorCausa.Text))
            {
                if (!decimal.TryParse(txtValorCausa.Text, out decimal valor) || valor < 0)
                {
                    MessageBox.Show("Informe um valor da causa válido.");
                    txtValorCausa.Focus();
                    return false;
                }
            }

            return true;
        }
        private void CarregarDados()
        {
            try
            {
                ConexaoBD db = new ConexaoBD();

                string sql = @"SELECT P.id_processo, P.numero_cnj, C.nome_razao_social,
                       P.vara, P.comarca, P.status, P.data_abertura,
                       P.valor_causa, P.cliente_id
                       FROM PROCESSO P
                       INNER JOIN CLIENTE C ON P.cliente_id = C.id_cliente
                       WHERE P.numero_cnj LIKE @pesquisa
                       OR C.nome_razao_social LIKE @pesquisa
                       OR P.vara LIKE @pesquisa
                       OR P.comarca LIKE @pesquisa
                       OR P.status LIKE @pesquisa
                       ORDER BY P.id_processo DESC";
                dgvProcessos.DataSource = db.ExecutarSelect(sql, txtPesquisar.Text.Trim());

                dgvProcessos.Columns["id_processo"].HeaderText = "ID";
                dgvProcessos.Columns["numero_cnj"].HeaderText = "Número CNJ";
                dgvProcessos.Columns["nome_razao_social"].HeaderText = "Cliente";
                dgvProcessos.Columns["data_abertura"].HeaderText = "Abertura";
                dgvProcessos.Columns["valor_causa"].HeaderText = "Valor da Causa";

                dgvProcessos.Columns["cliente_id"].Visible = false;

                GridHelper.Titulo(dgvProcessos, "vara", "Vara");
                GridHelper.Titulo(dgvProcessos, "comarca", "Comarca");
                GridHelper.Titulo(dgvProcessos, "status", "Status");
                GridHelper.FormatarColuna(dgvProcessos, "data_abertura", "dd/MM/yyyy");
                GridHelper.Dinheiro(dgvProcessos, "valor_causa");
                GridHelper.Ocultar(dgvProcessos, "id_processo");

                dgvProcessos.ClearSelection();
            }
            catch (Exception ex)
            {
                Mensagens.Erro("carregar processos", ex);
            }
        }
        public FrmProcessos()
        {
            InitializeComponent();
        }

        private void FrmProcessos_Load(object sender, EventArgs e)
        {
            txtNumeroCnj.PlaceholderText = "0000000-00.0000.8.13.0000";
            txtVara.PlaceholderText = "Ex.: 1ª Vara Cível";
            txtComarca.PlaceholderText = "Ex.: Frutal";
            txtValorCausa.PlaceholderText = "0,00";
            txtPesquisar.PlaceholderText = "CNJ, cliente, vara, comarca ou status";

            CarregarClientes();
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

                    string sql = @"INSERT INTO PROCESSO
                           (cliente_id, numero_cnj, vara, comarca, status, data_abertura, valor_causa)
                           VALUES
                           (@cliente, @cnj, @vara, @comarca, @status, @data, @valor)";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@cliente", cmbCliente.SelectedValue);
                    cmd.Parameters.AddWithValue("@cnj", txtNumeroCnj.Text.Trim());
                    cmd.Parameters.AddWithValue("@vara", txtVara.Text.Trim());
                    cmd.Parameters.AddWithValue("@comarca", txtComarca.Text.Trim());
                    cmd.Parameters.AddWithValue("@status", "rascunho");
                    cmd.Parameters.AddWithValue("@data", dtpDataAbertura.Value.Date);

                    if (string.IsNullOrWhiteSpace(txtValorCausa.Text))
                    {
                        cmd.Parameters.AddWithValue("@valor", DBNull.Value);
                    }
                    else
                    {
                        decimal valor = decimal.Parse(txtValorCausa.Text);
                        cmd.Parameters.AddWithValue("@valor", valor);
                    }

                    cmd.ExecuteNonQuery();

                    Auditoria.Registrar("CADASTRAR", "PROCESSO", (int)cmd.LastInsertedId,
                        "Processo cadastrado: " + txtNumeroCnj.Text.Trim());
                }

                MessageBox.Show("Processo cadastrado com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CarregarDados();
                LimparCampos();
            }
            catch (Exception ex)
            {
                Mensagens.Erro("cadastrar processo", ex);
            }
        }

        private void dgvProcessos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow linha = dgvProcessos.Rows[e.RowIndex];

            idProcessoSelecionado = Convert.ToInt32(linha.Cells["id_processo"].Value);

            cmbCliente.SelectedValue = Convert.ToInt32(linha.Cells["cliente_id"].Value);
            txtNumeroCnj.Text = linha.Cells["numero_cnj"].Value.ToString();
            txtVara.Text = linha.Cells["vara"].Value.ToString();
            txtComarca.Text = linha.Cells["comarca"].Value.ToString();
            txtStatus.Text = linha.Cells["status"].Value.ToString();

            if (linha.Cells["data_abertura"].Value != DBNull.Value)
            {
                dtpDataAbertura.Value = Convert.ToDateTime(linha.Cells["data_abertura"].Value);
            }

            if (linha.Cells["valor_causa"].Value == DBNull.Value)
            {
                txtValorCausa.Clear();
            }
            else
            {
                txtValorCausa.Text = linha.Cells["valor_causa"].Value.ToString();
            }

            btnSalvar.Enabled = false;
            btnAlterar.Enabled = Permissoes.Pode(Acao.AlterarProcesso);


            btnVincularAdvogados.Enabled = true;

            btnIniciar.Enabled = txtStatus.Text == "rascunho" && Permissoes.Pode(Acao.IniciarProcesso);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (idProcessoSelecionado == 0 || !ValidarCampos())
            {
                return;
            }

            try
            {
                ConexaoBD db = new ConexaoBD();

                using (MySqlConnection conn = db.CriarConexao())
                {
                    conn.Open();

                    string sql = @"UPDATE PROCESSO SET
                           cliente_id = @cliente,
                           numero_cnj = @cnj,
                           vara = @vara,
                           comarca = @comarca,
                           data_abertura = @data,
                           valor_causa = @valor
                           WHERE id_processo = @id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@cliente", cmbCliente.SelectedValue);
                    cmd.Parameters.AddWithValue("@cnj", txtNumeroCnj.Text.Trim());
                    cmd.Parameters.AddWithValue("@vara", txtVara.Text.Trim());
                    cmd.Parameters.AddWithValue("@comarca", txtComarca.Text.Trim());
                    cmd.Parameters.AddWithValue("@data", dtpDataAbertura.Value.Date);
                    cmd.Parameters.AddWithValue("@id", idProcessoSelecionado);

                    if (string.IsNullOrWhiteSpace(txtValorCausa.Text))
                    {
                        cmd.Parameters.AddWithValue("@valor", DBNull.Value);
                    }
                    else
                    {
                        decimal valor = decimal.Parse(txtValorCausa.Text);
                        cmd.Parameters.AddWithValue("@valor", valor);
                    }

                    cmd.ExecuteNonQuery();

                    Auditoria.Registrar("ALTERAR", "PROCESSO", idProcessoSelecionado,
                        "Processo alterado: " + txtNumeroCnj.Text.Trim());
                }

                MessageBox.Show("Processo alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CarregarDados();
                LimparCampos();
            }
            catch (Exception ex)
            {
                Mensagens.Erro("alterar processo", ex);
            }
        }

        private void btnVincularAdvogados_Click(object sender, EventArgs e)
        {
            if (idProcessoSelecionado == 0)
            {
                MessageBox.Show("Selecione um processo.");
                return;
            }

            FrmVincularAdvogado form = new FrmVincularAdvogado(idProcessoSelecionado, txtNumeroCnj.Text);
            form.ShowDialog();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (idProcessoSelecionado == 0)
            {
                MessageBox.Show("Selecione um processo.");
                return;
            }

            if (!Mensagens.Confirmar("Deseja realmente iniciar este processo?"))
            {
                return;
            }

            try
            {
                ConexaoBD db = new ConexaoBD();
                using (MySqlConnection conn = db.CriarConexao())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("CALL sp_iniciar_processo(@id, @usuario)", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idProcessoSelecionado);
                        cmd.Parameters.AddWithValue("@usuario", SessaoUsuario.IdUsuario);
                        using (MySqlDataReader resultado = cmd.ExecuteReader())
                        {
                            if (!resultado.Read() || resultado.IsDBNull(resultado.GetOrdinal("processos_iniciados")))
                            {
                                throw new InvalidOperationException("A procedure não confirmou o resultado.");
                            }

                            int iniciados = Convert.ToInt32(resultado["processos_iniciados"]);
                            string mensagem = Convert.ToString(resultado["mensagem"]) ?? "O processo não foi iniciado.";

                            if (iniciados != 1)
                            {
                                Mensagens.Aviso(mensagem);
                                LimparCampos();
                                CarregarDados();
                                return;
                            }
                        }
                    }
                }

                Mensagens.Sucesso("Processo iniciado com sucesso.");
                CarregarDados();
                LimparCampos();
            }
            catch (Exception ex)
            {
                Mensagens.Erro("iniciar processo", ex);
            }
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            idProcessoSelecionado = 0;
            btnAlterar.Enabled = false;
            btnIniciar.Enabled = false;
            btnVincularAdvogados.Enabled = false;
            CarregarDados();
        }
    }
}
