using ERPAdvocacia.Data;
using ERPAdvocacia.UI;
using System;
using System.Data;
using System.Windows.Forms;

namespace ERPAdvocacia
{
    public partial class FrmPagamentos : Form
    {
                                                                               
        private bool carregando = false;

        public FrmPagamentos()
        {
            InitializeComponent();
        }

        private void FrmPagamentos_Load(object sender, EventArgs e)
        {
            if (!Permissoes.Pode(Acao.ConsultarFinanceiro))
            {
                Mensagens.Aviso("Você não tem permissão para acessar o financeiro.");
                Close();
                return;
            }

            cmbForma.Items.Add("pix");
            cmbForma.Items.Add("dinheiro");
            cmbForma.Items.Add("cartao");
            cmbForma.Items.Add("transferencia");
            cmbForma.Items.Add("outro");

            CarregarContratos();
            LimparCampos();
            AtualizarTela();
        }

        private void CarregarContratos()
        {
            try
            {
                carregando = true;

                ConexaoBD db = new ConexaoBD();

                string sql = @"SELECT CH.id_contrato,
                       CONCAT('Contrato ', CH.id_contrato, ' - ', P.numero_cnj, ' - ',
                              C.nome_razao_social, ' (', CH.tipo, ')') AS descricao
                       FROM CONTRATO_HONORARIOS CH
                       INNER JOIN PROCESSO P ON CH.processo_id = P.id_processo
                       INNER JOIN CLIENTE C ON P.cliente_id = C.id_cliente
                       ORDER BY CH.id_contrato";

                Controles.PreencherCombo(cmbContrato, db.ExecutarSelect(sql), "descricao", "id_contrato");
            }
            catch (Exception ex)
            {
                Mensagens.Erro("carregar os contratos", ex);
            }
            finally
            {
                carregando = false;
            }
        }

                                                                                        
                                                         
        private void AtualizarTela()
        {
            int idContrato = Controles.IdSelecionado(cmbContrato);

            if (idContrato == 0)
            {
                lblTotal.Text = "-";
            }
            else
            {
                try
                {
                    ConexaoBD db = new ConexaoBD();
                    decimal? total = db.TotalRecebido(idContrato);

                    lblTotal.Text = total.HasValue ? total.Value.ToString("C2") : "-";
                }
                catch (Exception ex)
                {
                    lblTotal.Text = "-";
                    Mensagens.Erro("calcular o total recebido", ex);
                }
            }

            CarregarPagamentos(idContrato);
        }

                                                                              
        private void CarregarPagamentos(int idContrato)
        {
            try
            {
                ConexaoBD db = new ConexaoBD();

                string sql = @"SELECT PG.data_pagamento, C.nome_razao_social AS cliente, P.numero_cnj,
                       PG.valor, PG.forma_pagamento, PG.observacao
                       FROM PAGAMENTO PG
                       INNER JOIN CONTRATO_HONORARIOS CH ON PG.contrato_id = CH.id_contrato
                       INNER JOIN PROCESSO P ON CH.processo_id = P.id_processo
                       INNER JOIN CLIENTE C ON P.cliente_id = C.id_cliente
                       WHERE (@contrato = 0 OR PG.contrato_id = @contrato)
                       ORDER BY PG.data_pagamento DESC, PG.id_pagamento DESC";

                dgvPagamentos.DataSource = db.ExecutarSelect(sql, ConexaoBD.P("@contrato", idContrato));

                GridHelper.Titulo(dgvPagamentos, "data_pagamento", "Data");
                GridHelper.Titulo(dgvPagamentos, "cliente", "Cliente");
                GridHelper.Titulo(dgvPagamentos, "numero_cnj", "Processo");
                GridHelper.Titulo(dgvPagamentos, "valor", "Valor");
                GridHelper.Titulo(dgvPagamentos, "forma_pagamento", "Forma");
                GridHelper.Titulo(dgvPagamentos, "observacao", "Observação");
                GridHelper.FormatarColuna(dgvPagamentos, "data_pagamento", "dd/MM/yyyy");
                GridHelper.Dinheiro(dgvPagamentos, "valor");

                dgvPagamentos.ClearSelection();
            }
            catch (Exception ex)
            {
                Mensagens.Erro("carregar os pagamentos", ex);
            }
        }

                                                                             
        private void LimparCampos()
        {
            txtValor.Clear();
            dtpData.Value = DateTime.Today;
            cmbForma.SelectedIndex = -1;
            txtObservacao.Clear();

            btnRegistrar.Enabled = Permissoes.Pode(Acao.RegistrarPagamento);

            txtValor.Focus();
        }

        private bool ValidarCampos(out decimal valor)
        {
            valor = 0;

            if (cmbContrato.SelectedIndex == -1)
            {
                Mensagens.Aviso("Selecione o contrato.");
                cmbContrato.Focus();
                return false;
            }

            if (!decimal.TryParse(txtValor.Text, out valor) || valor <= 0)
            {
                Mensagens.Aviso("Informe um valor de pagamento maior que zero.");
                txtValor.Focus();
                return false;
            }

            if (cmbForma.SelectedIndex == -1)
            {
                Mensagens.Aviso("Selecione a forma de pagamento.");
                cmbForma.Focus();
                return false;
            }

            return true;
        }

        private void cmbContrato_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (carregando)
            {
                return;
            }

            AtualizarTela();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            carregando = true;
            cmbContrato.SelectedIndex = -1;
            carregando = false;

            LimparCampos();
            AtualizarTela();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos(out decimal valor))
            {
                return;
            }

            try
            {
                ConexaoBD db = new ConexaoBD();

                string sql = @"INSERT INTO PAGAMENTO (contrato_id, valor, data_pagamento, forma_pagamento, observacao)
                       VALUES (@contrato, @valor, @data, @forma, @obs)";

                long novoId = db.ExecutarComando(sql,
                    ConexaoBD.P("@contrato", cmbContrato.SelectedValue),
                    ConexaoBD.P("@valor", valor),
                    ConexaoBD.P("@data", dtpData.Value.Date),
                    ConexaoBD.P("@forma", cmbForma.Text),
                    ConexaoBD.P("@obs", txtObservacao.Text.Trim()));

                Auditoria.Registrar("REGISTRAR_PAGAMENTO", "PAGAMENTO", (int)novoId,
                    "Pagamento de " + valor.ToString("C2") + " (" + cmbForma.Text + ") no contrato " + Controles.IdSelecionado(cmbContrato));

                Mensagens.Sucesso("Pagamento registrado com sucesso!");

                LimparCampos();
                AtualizarTela();
            }
            catch (Exception ex)
            {
                Mensagens.Erro("registrar o pagamento", ex);
            }
        }
    }
}
