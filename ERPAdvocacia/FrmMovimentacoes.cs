using ERPAdvocacia.Data;
using ERPAdvocacia.UI;
using System;
using System.Data;
using System.Windows.Forms;

namespace ERPAdvocacia
{
    public partial class FrmMovimentacoes : Form
    {

        private bool carregando = false;

        public FrmMovimentacoes()
        {
            InitializeComponent();
        }

        private void FrmMovimentacoes_Load(object sender, EventArgs e)
        {
            txtUsuario.Text = SessaoUsuario.Nome;

            CarregarProcessos();
            CarregarHistorico();
            LimparCampos();
        }

        private void CarregarProcessos()
        {
            try
            {
                carregando = true;

                ConexaoBD db = new ConexaoBD();

                string sql = @"SELECT P.id_processo,
                       CONCAT(P.numero_cnj, ' - ', C.nome_razao_social) AS descricao
                       FROM PROCESSO P
                       INNER JOIN CLIENTE C ON P.cliente_id = C.id_cliente
                       ORDER BY P.numero_cnj";

                Controles.PreencherCombo(cmbProcesso, db.ExecutarSelect(sql), "descricao", "id_processo");
            }
            catch (Exception ex)
            {
                Mensagens.Erro("carregar os processos", ex);
            }
            finally
            {
                carregando = false;
            }
        }



        private void CarregarHistorico()
        {
            try
            {
                ConexaoBD db = new ConexaoBD();

                string sql = @"SELECT M.data_hora, P.numero_cnj, U.nome AS usuario, M.descricao
                       FROM MOVIMENTACAO M
                       INNER JOIN PROCESSO P ON M.processo_id = P.id_processo
                       INNER JOIN USUARIO U ON M.usuario_id = U.id_usuario
                       WHERE (@processo = 0 OR M.processo_id = @processo)
                       ORDER BY M.data_hora DESC, M.id_movimentacao DESC
                       LIMIT 300";

                dgvMovimentacoes.DataSource = db.ExecutarSelect(sql,
                    ConexaoBD.P("@processo", Controles.IdSelecionado(cmbProcesso)));

                GridHelper.Titulo(dgvMovimentacoes, "data_hora", "Data/Hora");
                GridHelper.Titulo(dgvMovimentacoes, "numero_cnj", "Processo");
                GridHelper.Titulo(dgvMovimentacoes, "usuario", "Registrado por");
                GridHelper.Titulo(dgvMovimentacoes, "descricao", "Descrição");
                GridHelper.FormatarColuna(dgvMovimentacoes, "data_hora", "dd/MM/yyyy HH:mm");
                GridHelper.Preencher(dgvMovimentacoes, "descricao", 250);

                dgvMovimentacoes.ClearSelection();
            }
            catch (Exception ex)
            {
                Mensagens.Erro("carregar o histórico", ex);
            }
        }



        private void LimparCampos()
        {
            txtDescricao.Clear();
            txtDataHora.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            btnRegistrar.Enabled = Permissoes.Pode(Acao.RegistrarMovimentacao);

            txtDescricao.Focus();
        }

        private bool ValidarCampos()
        {
            if (cmbProcesso.SelectedIndex == -1)
            {
                Mensagens.Aviso("Selecione o processo.");
                cmbProcesso.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                Mensagens.Aviso("Informe a descrição da movimentação.");
                txtDescricao.Focus();
                return false;
            }

            return true;
        }

        private void cmbProcesso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (carregando)
            {
                return;
            }

            CarregarHistorico();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            carregando = true;
            cmbProcesso.SelectedIndex = -1;
            carregando = false;

            LimparCampos();
            CarregarHistorico();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }

            try
            {
                ConexaoBD db = new ConexaoBD();



                string sql = @"INSERT INTO MOVIMENTACAO (processo_id, usuario_id, data_hora, descricao)
                       VALUES (@processo, @usuario, NOW(), @descricao)";

                long novoId = db.ExecutarComando(sql,
                    ConexaoBD.P("@processo", cmbProcesso.SelectedValue),
                    ConexaoBD.P("@usuario", SessaoUsuario.IdUsuario),
                    ConexaoBD.P("@descricao", txtDescricao.Text.Trim()));

                Auditoria.Registrar("REGISTRAR_MOVIMENTACAO", "MOVIMENTACAO", (int)novoId,
                    "Movimentação registrada no processo " + cmbProcesso.Text);

                Mensagens.Sucesso("Movimentação registrada com sucesso!");

                LimparCampos();
                CarregarHistorico();
            }
            catch (Exception ex)
            {
                Mensagens.Erro("registrar a movimentação", ex);
            }
        }

        private void txtDescricao_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
