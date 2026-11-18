using ERPAdvocacia.Data;
using ERPAdvocacia.UI;
using System;
using System.Data;
using System.Windows.Forms;

namespace ERPAdvocacia
{
    public partial class FrmHonorarios : Form
    {
        private int idContratoSelecionado = 0;

        public FrmHonorarios()
        {
            InitializeComponent();
        }

        private void FrmHonorarios_Load(object sender, EventArgs e)
        {
            if (!Permissoes.Pode(Acao.ConsultarFinanceiro))
            {
                Mensagens.Aviso("Você não tem permissão para acessar o financeiro.");
                Close();
                return;
            }

            cmbTipo.Items.Add("fixo");
            cmbTipo.Items.Add("mensal");
            cmbTipo.Items.Add("exito");

            cmbStatus.Items.Add("ativo");
            cmbStatus.Items.Add("encerrado");
            cmbStatus.Items.Add("cancelado");

            CarregarDados();
            LimparCampos();
        }

                                                                                 
                                                                            
                                                                
        private void CarregarProcessos(bool apenasSemContrato)
        {
            try
            {
                ConexaoBD db = new ConexaoBD();

                string sql = @"SELECT P.id_processo,
                       CONCAT(P.numero_cnj, ' - ', C.nome_razao_social) AS descricao
                       FROM PROCESSO P
                       INNER JOIN CLIENTE C ON P.cliente_id = C.id_cliente";

                if (apenasSemContrato)
                {
                    sql += @" WHERE NOT EXISTS (SELECT 1 FROM CONTRATO_HONORARIOS CH
                              WHERE CH.processo_id = P.id_processo)";
                }

                sql += " ORDER BY P.numero_cnj";

                Controles.PreencherCombo(cmbProcesso, db.ExecutarSelect(sql), "descricao", "id_processo");
            }
            catch (Exception ex)
            {
                Mensagens.Erro("carregar os processos", ex);
            }
        }

        private void CarregarDados()
        {
            try
            {
                ConexaoBD db = new ConexaoBD();

                string sql = @"SELECT CH.id_contrato, CH.processo_id,
                       C.nome_razao_social AS cliente, P.numero_cnj,
                       CH.tipo, CH.valor_referencia, CH.percentual_exito,
                       CH.data_assinatura, CH.status
                       FROM CONTRATO_HONORARIOS CH
                       INNER JOIN PROCESSO P ON CH.processo_id = P.id_processo
                       INNER JOIN CLIENTE C ON P.cliente_id = C.id_cliente
                       WHERE C.nome_razao_social LIKE @pesquisa
                       OR P.numero_cnj LIKE @pesquisa
                       OR CH.tipo LIKE @pesquisa
                       OR CH.status LIKE @pesquisa
                       ORDER BY CH.id_contrato DESC";

                dgvContratos.DataSource = db.ExecutarSelect(sql, txtPesquisar.Text.Trim());

                GridHelper.Ocultar(dgvContratos, "id_contrato", "processo_id");
                GridHelper.Titulo(dgvContratos, "cliente", "Cliente");
                GridHelper.Titulo(dgvContratos, "numero_cnj", "Processo");
                GridHelper.Titulo(dgvContratos, "tipo", "Tipo");
                GridHelper.Titulo(dgvContratos, "valor_referencia", "Valor de Referência");
                GridHelper.Titulo(dgvContratos, "percentual_exito", "% Êxito");
                GridHelper.Titulo(dgvContratos, "data_assinatura", "Assinatura");
                GridHelper.Titulo(dgvContratos, "status", "Status");
                GridHelper.Dinheiro(dgvContratos, "valor_referencia");
                GridHelper.FormatarColuna(dgvContratos, "data_assinatura", "dd/MM/yyyy");

                dgvContratos.ClearSelection();
            }
            catch (Exception ex)
            {
                Mensagens.Erro("carregar os contratos", ex);
            }
        }

        private void LimparCampos()
        {
            idContratoSelecionado = 0;

            CarregarProcessos(true);
            cmbProcesso.Enabled = true;

            cmbTipo.SelectedIndex = -1;
            txtValor.Clear();
            txtPercentual.Clear();
            txtPercentual.Enabled = false;
            dtpAssinatura.Value = DateTime.Today;

                                                                                             
            cmbStatus.SelectedItem = "ativo";
            cmbStatus.Enabled = false;

            dgvContratos.ClearSelection();

            btnSalvar.Enabled = Permissoes.Pode(Acao.GerenciarHonorarios);
            btnAlterar.Enabled = false;

            cmbProcesso.Focus();
        }

                                                                          
        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool exito = cmbTipo.Text == "exito";

            txtPercentual.Enabled = exito;

            if (!exito)
            {
                txtPercentual.Clear();
            }
        }

        private bool ValidarCampos(out decimal? valor, out decimal? percentual)
        {
            valor = null;
            percentual = null;

            if (idContratoSelecionado == 0 && cmbProcesso.SelectedIndex == -1)
            {
                Mensagens.Aviso("Selecione o processo do contrato.");
                cmbProcesso.Focus();
                return false;
            }

            if (cmbTipo.SelectedIndex == -1)
            {
                Mensagens.Aviso("Selecione o tipo do contrato.");
                cmbTipo.Focus();
                return false;
            }

            bool exito = cmbTipo.Text == "exito";

                                                                                 
            if (txtValor.Text.Trim() == "")
            {
                if (!exito)
                {
                    Mensagens.Aviso("Informe o valor de referência do contrato.");
                    txtValor.Focus();
                    return false;
                }
            }
            else
            {
                if (!decimal.TryParse(txtValor.Text, out decimal v) || v < 0 || (!exito && v == 0))
                {
                    Mensagens.Aviso("Informe um valor de referência válido.");
                    txtValor.Focus();
                    return false;
                }

                valor = v;
            }

            if (exito)
            {
                                                                 
                if (!decimal.TryParse(txtPercentual.Text, out decimal p) || p < 20 || p > 30)
                {
                    Mensagens.Aviso("O percentual de êxito deve estar entre 20 e 30.");
                    txtPercentual.Focus();
                    return false;
                }

                percentual = p;
            }

            if (cmbStatus.SelectedIndex == -1)
            {
                Mensagens.Aviso("Selecione o status do contrato.");
                cmbStatus.Focus();
                return false;
            }

            return true;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos(out decimal? valor, out decimal? percentual))
            {
                return;
            }

            try
            {
                ConexaoBD db = new ConexaoBD();

                string sql = @"INSERT INTO CONTRATO_HONORARIOS
                       (processo_id, tipo, valor_referencia, percentual_exito, data_assinatura, status)
                       VALUES
                       (@processo, @tipo, @valor, @percentual, @data, @status)";

                long novoId = db.ExecutarComando(sql,
                    ConexaoBD.P("@processo", cmbProcesso.SelectedValue),
                    ConexaoBD.P("@tipo", cmbTipo.Text),
                    ConexaoBD.P("@valor", valor),
                    ConexaoBD.P("@percentual", percentual),
                    ConexaoBD.P("@data", dtpAssinatura.Value.Date),
                    ConexaoBD.P("@status", "ativo"));

                Auditoria.Registrar("CADASTRAR", "CONTRATO_HONORARIOS", (int)novoId,
                    "Contrato " + cmbTipo.Text + " cadastrado para o processo " + cmbProcesso.Text);

                Mensagens.Sucesso("Contrato cadastrado com sucesso!");

                CarregarDados();
                LimparCampos();
            }
            catch (Exception ex)
            {
                Mensagens.Erro("cadastrar o contrato", ex);
            }
        }

        private void dgvContratos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow linha = dgvContratos.Rows[e.RowIndex];

            idContratoSelecionado = Convert.ToInt32(linha.Cells["id_contrato"].Value);

                                                                                      
            CarregarProcessos(false);
            cmbProcesso.SelectedValue = Convert.ToInt32(linha.Cells["processo_id"].Value);
            cmbProcesso.Enabled = false;

            cmbTipo.SelectedItem = linha.Cells["tipo"].Value.ToString();

            if (linha.Cells["valor_referencia"].Value == DBNull.Value)
            {
                txtValor.Clear();
            }
            else
            {
                txtValor.Text = Convert.ToDecimal(linha.Cells["valor_referencia"].Value).ToString("0.00");
            }

            if (linha.Cells["percentual_exito"].Value == DBNull.Value)
            {
                txtPercentual.Clear();
            }
            else
            {
                txtPercentual.Text = Convert.ToDecimal(linha.Cells["percentual_exito"].Value).ToString("0.##");
            }

            dtpAssinatura.Value = Convert.ToDateTime(linha.Cells["data_assinatura"].Value);

            cmbStatus.Enabled = true;
            cmbStatus.SelectedItem = linha.Cells["status"].Value.ToString();

            btnSalvar.Enabled = false;
            btnAlterar.Enabled = Permissoes.Pode(Acao.GerenciarHonorarios);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (idContratoSelecionado == 0 || !ValidarCampos(out decimal? valor, out decimal? percentual))
            {
                return;
            }

            try
            {
                ConexaoBD db = new ConexaoBD();

                string sql = @"UPDATE CONTRATO_HONORARIOS SET
                       tipo = @tipo,
                       valor_referencia = @valor,
                       percentual_exito = @percentual,
                       data_assinatura = @data,
                       status = @status
                       WHERE id_contrato = @id";

                db.ExecutarComando(sql,
                    ConexaoBD.P("@tipo", cmbTipo.Text),
                    ConexaoBD.P("@valor", valor),
                    ConexaoBD.P("@percentual", percentual),
                    ConexaoBD.P("@data", dtpAssinatura.Value.Date),
                    ConexaoBD.P("@status", cmbStatus.Text),
                    ConexaoBD.P("@id", idContratoSelecionado));

                Auditoria.Registrar("ALTERAR", "CONTRATO_HONORARIOS", idContratoSelecionado,
                    "Contrato alterado (tipo " + cmbTipo.Text + ", status " + cmbStatus.Text + ")");

                Mensagens.Sucesso("Contrato alterado com sucesso!");

                CarregarDados();
                LimparCampos();
            }
            catch (Exception ex)
            {
                Mensagens.Erro("alterar o contrato", ex);
            }
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            LimparCampos();
            txtPesquisar.Focus();
            CarregarDados();
        }
    }
}
