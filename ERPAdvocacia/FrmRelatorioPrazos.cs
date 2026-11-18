using ERPAdvocacia.Data;
using ERPAdvocacia.UI;
using System;
using System.Data;
using System.Windows.Forms;

namespace ERPAdvocacia
{
                                       
                                                                       
    public partial class FrmRelatorioPrazos : Form
    {
        public FrmRelatorioPrazos()
        {
            InitializeComponent();
        }

        private void FrmRelatorioPrazos_Load(object sender, EventArgs e)
        {
                                                                         
            dtpInicial.Checked = false;
            dtpFinal.Checked = false;

            cmbStatus.Items.Add("(Todos)");
            cmbStatus.Items.Add("pendente");
            cmbStatus.Items.Add("cumprido");
            cmbStatus.Items.Add("cancelado");
            cmbStatus.SelectedIndex = 0;

            try
            {
                ConexaoBD db = new ConexaoBD();
                DataTable responsaveis = db.ExecutarSelect("SELECT id_usuario, nome FROM USUARIO ORDER BY nome");
                Controles.PreencherComboComTodos(cmbResponsavel, responsaveis, "nome", "id_usuario", "(Todos)");
            }
            catch (Exception ex)
            {
                Mensagens.Erro("carregar os responsáveis", ex);
            }

            GridHelper.PintarPrazos(dgvPrazos);

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

                                                                                 
                string sql = @"SELECT P.numero_cnj AS processo, C.nome_razao_social AS cliente,
                       PR.titulo, U.nome AS responsavel,
                       PR.data_vencimento, PR.status, PR.data_cumprimento
                       FROM PRAZO_PROCESSUAL PR
                       INNER JOIN PROCESSO P ON PR.processo_id = P.id_processo
                       INNER JOIN CLIENTE C ON P.cliente_id = C.id_cliente
                       INNER JOIN USUARIO U ON PR.responsavel_id = U.id_usuario
                       WHERE (@inicio IS NULL OR PR.data_vencimento >= @inicio)
                       AND (@fim IS NULL OR PR.data_vencimento < @fim)
                       AND (@status = '' OR PR.status = @status)
                       AND (@responsavel = 0 OR PR.responsavel_id = @responsavel)
                       ORDER BY PR.data_vencimento";

                                                                           
                object inicio = dtpInicial.Checked ? dtpInicial.Value.Date : null;
                object fim = dtpFinal.Checked ? dtpFinal.Value.Date.AddDays(1) : null;
                string status = cmbStatus.SelectedIndex <= 0 ? "" : cmbStatus.Text;

                DataTable dados = db.ExecutarSelect(sql,
                    ConexaoBD.P("@inicio", inicio),
                    ConexaoBD.P("@fim", fim),
                    ConexaoBD.P("@status", status),
                    ConexaoBD.P("@responsavel", Controles.IdSelecionado(cmbResponsavel)));

                dgvPrazos.DataSource = dados;

                GridHelper.Titulo(dgvPrazos, "processo", "Processo");
                GridHelper.Titulo(dgvPrazos, "cliente", "Cliente");
                GridHelper.Titulo(dgvPrazos, "titulo", "Título");
                GridHelper.Titulo(dgvPrazos, "responsavel", "Responsável");
                GridHelper.Titulo(dgvPrazos, "data_vencimento", "Vencimento");
                GridHelper.Titulo(dgvPrazos, "status", "Status");
                GridHelper.Titulo(dgvPrazos, "data_cumprimento", "Cumprimento");
                GridHelper.FormatarColuna(dgvPrazos, "data_vencimento", "dd/MM/yyyy HH:mm");
                GridHelper.FormatarColuna(dgvPrazos, "data_cumprimento", "dd/MM/yyyy HH:mm");

                dgvPrazos.ClearSelection();

                MostrarResumo(dados);
            }
            catch (Exception ex)
            {
                Mensagens.Erro("gerar o relatório", ex);
            }
        }

        private void MostrarResumo(DataTable dados)
        {
            int pendentes = 0;
            int cumpridos = 0;
            int vencidos = 0;

            foreach (DataRow linha in dados.Rows)
            {
                string status = linha["status"].ToString();

                if (status == "pendente")
                {
                    pendentes++;

                    if (Convert.ToDateTime(linha["data_vencimento"]) < DateTime.Now)
                    {
                        vencidos++;
                    }
                }
                else if (status == "cumprido")
                {
                    cumpridos++;
                }
            }

            lblResumo.Text = dados.Rows.Count + " prazo(s) encontrado(s): "
                + pendentes + " pendente(s) (" + vencidos + " vencido(s)), "
                + cumpridos + " cumprido(s).";
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            GerarRelatorio();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            dtpInicial.Checked = false;
            dtpFinal.Checked = false;
            cmbStatus.SelectedIndex = 0;
            cmbResponsavel.SelectedIndex = 0;

            GerarRelatorio();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Exportador.ParaCsv(dgvPrazos, "relatorio_prazos", "Relatório de prazos");
        }
    }
}
