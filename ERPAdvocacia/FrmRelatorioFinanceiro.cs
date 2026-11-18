using ERPAdvocacia.Data;
using ERPAdvocacia.UI;
using System;
using System.Data;
using System.Windows.Forms;

namespace ERPAdvocacia
{
                                                      
                                                                                          
                                                                                       
    public partial class FrmRelatorioFinanceiro : Form
    {
                                                                                   
        private bool carregando = false;

        public FrmRelatorioFinanceiro()
        {
            InitializeComponent();
        }

        private void FrmRelatorioFinanceiro_Load(object sender, EventArgs e)
        {
            if (!Permissoes.Pode(Acao.ConsultarFinanceiro))
            {
                Mensagens.Aviso("Você não tem permissão para acessar o financeiro.");
                Close();
                return;
            }

            dtpInicial.Checked = false;
            dtpFinal.Checked = false;

            cmbStatus.Items.Add("(Todos)");
            cmbStatus.Items.Add("ativo");
            cmbStatus.Items.Add("encerrado");
            cmbStatus.Items.Add("cancelado");
            cmbStatus.SelectedIndex = 0;

            try
            {
                carregando = true;

                ConexaoBD db = new ConexaoBD();

                DataTable clientes = db.ExecutarSelect("SELECT id_cliente, nome_razao_social FROM CLIENTE ORDER BY nome_razao_social");
                Controles.PreencherComboComTodos(cmbCliente, clientes, "nome_razao_social", "id_cliente", "(Todos)");

                CarregarProcessos();
            }
            catch (Exception ex)
            {
                Mensagens.Erro("carregar os filtros", ex);
            }
            finally
            {
                carregando = false;
            }

            GerarRelatorio();
        }

                                                              
        private void CarregarProcessos()
        {
            ConexaoBD db = new ConexaoBD();

            string sql = @"SELECT id_processo, numero_cnj
                   FROM PROCESSO
                   WHERE (@cliente = 0 OR cliente_id = @cliente)
                   ORDER BY numero_cnj";

            DataTable processos = db.ExecutarSelect(sql,
                ConexaoBD.P("@cliente", Controles.IdSelecionado(cmbCliente)));

            Controles.PreencherComboComTodos(cmbProcesso, processos, "numero_cnj", "id_processo", "(Todos)");
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (carregando)
            {
                return;
            }

            try
            {
                CarregarProcessos();
            }
            catch (Exception ex)
            {
                Mensagens.Erro("carregar os processos do cliente", ex);
            }
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

                string sql = @"SELECT CH.id_contrato, C.nome_razao_social AS cliente, P.numero_cnj AS processo,
                       CH.tipo, CH.valor_referencia, CH.percentual_exito,
                       CH.data_assinatura, CH.status
                       FROM CONTRATO_HONORARIOS CH
                       INNER JOIN PROCESSO P ON CH.processo_id = P.id_processo
                       INNER JOIN CLIENTE C ON P.cliente_id = C.id_cliente
                       WHERE (@cliente = 0 OR C.id_cliente = @cliente)
                       AND (@processo = 0 OR P.id_processo = @processo)
                       AND (@inicio IS NULL OR CH.data_assinatura >= @inicio)
                       AND (@fim IS NULL OR CH.data_assinatura <= @fim)
                       AND (@status = '' OR CH.status = @status)
                       ORDER BY C.nome_razao_social, P.numero_cnj";

                object inicio = dtpInicial.Checked ? dtpInicial.Value.Date : null;
                object fim = dtpFinal.Checked ? dtpFinal.Value.Date : null;
                string status = cmbStatus.SelectedIndex <= 0 ? "" : cmbStatus.Text;

                DataTable dados = db.ExecutarSelect(sql,
                    ConexaoBD.P("@cliente", Controles.IdSelecionado(cmbCliente)),
                    ConexaoBD.P("@processo", Controles.IdSelecionado(cmbProcesso)),
                    ConexaoBD.P("@inicio", inicio),
                    ConexaoBD.P("@fim", fim),
                    ConexaoBD.P("@status", status));

                                                                                    
                dados.Columns.Add("total_recebido", typeof(decimal));

                decimal somaReferencia = 0;
                decimal somaRecebido = 0;

                foreach (DataRow linha in dados.Rows)
                {
                    decimal? total = db.TotalRecebido(Convert.ToInt32(linha["id_contrato"]));
                    linha["total_recebido"] = total ?? 0;
                    somaRecebido += total ?? 0;

                    if (linha["valor_referencia"] != DBNull.Value)
                    {
                        somaReferencia += Convert.ToDecimal(linha["valor_referencia"]);
                    }
                }

                dgvFinanceiro.DataSource = dados;

                GridHelper.Ocultar(dgvFinanceiro, "id_contrato");
                GridHelper.Titulo(dgvFinanceiro, "cliente", "Cliente");
                GridHelper.Titulo(dgvFinanceiro, "processo", "Processo");
                GridHelper.Titulo(dgvFinanceiro, "tipo", "Tipo do Contrato");
                GridHelper.Titulo(dgvFinanceiro, "valor_referencia", "Valor de Referência");
                GridHelper.Titulo(dgvFinanceiro, "percentual_exito", "% Êxito");
                GridHelper.Titulo(dgvFinanceiro, "data_assinatura", "Assinatura");
                GridHelper.Titulo(dgvFinanceiro, "status", "Status");
                GridHelper.Titulo(dgvFinanceiro, "total_recebido", "Total Recebido");
                GridHelper.FormatarColuna(dgvFinanceiro, "data_assinatura", "dd/MM/yyyy");
                GridHelper.Dinheiro(dgvFinanceiro, "valor_referencia");
                GridHelper.Dinheiro(dgvFinanceiro, "total_recebido");

                dgvFinanceiro.ClearSelection();

                lblResumo.Text = dados.Rows.Count + " contrato(s) encontrado(s).";
                lblTotais.Text = "Soma dos valores de referência: " + somaReferencia.ToString("C2")
                    + "     |     Total recebido: " + somaRecebido.ToString("C2");
            }
            catch (Exception ex)
            {
                Mensagens.Erro("gerar o relatório", ex);
            }
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            GerarRelatorio();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            carregando = true;
            dtpInicial.Checked = false;
            dtpFinal.Checked = false;
            cmbStatus.SelectedIndex = 0;
            cmbCliente.SelectedIndex = 0;
            carregando = false;

            try
            {
                CarregarProcessos();
            }
            catch (Exception ex)
            {
                Mensagens.Erro("carregar os processos", ex);
            }

            GerarRelatorio();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Exportador.ParaCsv(dgvFinanceiro, "relatorio_financeiro", "Relatório financeiro");
        }
    }
}
