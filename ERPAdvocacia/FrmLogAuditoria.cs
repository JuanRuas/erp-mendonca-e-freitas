using ERPAdvocacia.Data;
using ERPAdvocacia.UI;
using System;
using System.Data;
using System.Windows.Forms;

namespace ERPAdvocacia
{
                                                                    
                                                             
    public partial class FrmLogAuditoria : Form
    {
        public FrmLogAuditoria()
        {
            InitializeComponent();
        }

        private void FrmLogAuditoria_Load(object sender, EventArgs e)
        {
            if (!Permissoes.Pode(Acao.ConsultarAuditoria))
            {
                Mensagens.Aviso("Você não tem permissão para consultar o log de auditoria.");
                Close();
                return;
            }

            dtpInicial.Checked = false;
            dtpFinal.Checked = false;

            cmbAcao.Items.Add("(Todas)");
            cmbAcao.Items.Add("LOGIN");
            cmbAcao.Items.Add("LOGIN_FALHA");
            cmbAcao.Items.Add("LOGOUT");
            cmbAcao.Items.Add("CADASTRAR");
            cmbAcao.Items.Add("ALTERAR");
            cmbAcao.Items.Add("DESATIVAR");
            cmbAcao.Items.Add("REATIVAR");
            cmbAcao.Items.Add("VINCULAR_ADVOGADO");
            cmbAcao.Items.Add("INICIAR_PROCESSO");
            cmbAcao.Items.Add("CUMPRIR_PRAZO");
            cmbAcao.Items.Add("REGISTRAR_MOVIMENTACAO");
            cmbAcao.Items.Add("REGISTRAR_PAGAMENTO");
            cmbAcao.Items.Add("EXPORTAR_RELATORIO");
            cmbAcao.SelectedIndex = 0;

            try
            {
                ConexaoBD db = new ConexaoBD();
                DataTable usuarios = db.ExecutarSelect("SELECT id_usuario, nome FROM USUARIO ORDER BY nome");
                Controles.PreencherComboComTodos(cmbUsuario, usuarios, "nome", "id_usuario", "(Todos)");
            }
            catch (Exception ex)
            {
                Mensagens.Erro("carregar os usuários", ex);
            }

            GerarRelatorio();
        }

        private void GerarRelatorio()
        {
            if (dtpInicial.Checked && dtpFinal.Checked && dtpInicial.Value.Date > dtpFinal.Value.Date)
            {
                Mensagens.Aviso("A data inicial não pode ser maior que a data final.");
                return;
            }

            try
            {
                ConexaoBD db = new ConexaoBD();

                string sql = @"SELECT A.data_hora, U.nome AS usuario, A.acao, A.entidade,
                       A.registro_id, A.detalhes
                       FROM AUDITORIA A
                       INNER JOIN USUARIO U ON A.usuario_id = U.id_usuario
                       WHERE (@usuario = 0 OR A.usuario_id = @usuario)
                       AND (@acao = '' OR A.acao = @acao)
                       AND (@inicio IS NULL OR A.data_hora >= @inicio)
                       AND (@fim IS NULL OR A.data_hora < @fim)
                       ORDER BY A.data_hora DESC, A.id_auditoria DESC
                       LIMIT 1000";

                object inicio = dtpInicial.Checked ? dtpInicial.Value.Date : null;
                object fim = dtpFinal.Checked ? dtpFinal.Value.Date.AddDays(1) : null;
                string acao = cmbAcao.SelectedIndex <= 0 ? "" : cmbAcao.Text;

                DataTable dados = db.ExecutarSelect(sql,
                    ConexaoBD.P("@usuario", Controles.IdSelecionado(cmbUsuario)),
                    ConexaoBD.P("@acao", acao),
                    ConexaoBD.P("@inicio", inicio),
                    ConexaoBD.P("@fim", fim));

                dgvAuditoria.DataSource = dados;

                GridHelper.Titulo(dgvAuditoria, "data_hora", "Data/Hora");
                GridHelper.Titulo(dgvAuditoria, "usuario", "Usuário");
                GridHelper.Titulo(dgvAuditoria, "acao", "Ação");
                GridHelper.Titulo(dgvAuditoria, "entidade", "Entidade");
                GridHelper.Titulo(dgvAuditoria, "registro_id", "Registro");
                GridHelper.Titulo(dgvAuditoria, "detalhes", "Detalhes");
                GridHelper.FormatarColuna(dgvAuditoria, "data_hora", "dd/MM/yyyy HH:mm:ss");
                GridHelper.Preencher(dgvAuditoria, "detalhes", 250);

                dgvAuditoria.ClearSelection();

                lblResumo.Text = dados.Rows.Count + " registro(s) encontrado(s) (mostra no máximo 1000, os mais recentes).";
            }
            catch (Exception ex)
            {
                Mensagens.Erro("gerar o log", ex);
            }
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            GerarRelatorio();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            dtpInicial.Checked = false;
            dtpFinal.Checked = false;
            cmbAcao.SelectedIndex = 0;
            cmbUsuario.SelectedIndex = 0;

            GerarRelatorio();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Exportador.ParaCsv(dgvAuditoria, "log_auditoria", "Log de auditoria");
        }
    }
}
