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
    public partial class FrmVincularAdvogado : Form
    {
        private int idProcesso;
        private string numeroProcesso;
        public FrmVincularAdvogado()
        {
            InitializeComponent();
        }
        public FrmVincularAdvogado(int idProcesso, string numeroProcesso) : this()
        {
            this.idProcesso = idProcesso;
            this.numeroProcesso = numeroProcesso;
        }
        private void CarregarAdvogados()
        {
            try
            {
                ConexaoBD db = new ConexaoBD();

                string sql = @"SELECT id_usuario, nome
                       FROM USUARIO
                       WHERE perfil = 'advogado' AND ativo = TRUE
                       ORDER BY nome";

                DataTable dt = db.ExecutarSelect(sql);

                cmbAdvogado.DataSource = dt;
                cmbAdvogado.DisplayMember = "nome";
                cmbAdvogado.ValueMember = "id_usuario";
                cmbAdvogado.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                Mensagens.Erro("carregar advogados", ex);
            }
        }
        private void CarregarAdvogadosVinculados()
        {
            try
            {
                ConexaoBD db = new ConexaoBD();

                string sql = @"SELECT U.id_usuario, U.nome, U.oab, PA.responsavel_principal
                       FROM PROCESSO_ADVOGADO PA
                       INNER JOIN USUARIO U ON PA.usuario_id = U.id_usuario
                       WHERE PA.processo_id = @id
                       ORDER BY PA.responsavel_principal DESC, U.nome";

                dgvAdvogados.DataSource = db.ExecutarSelectPorId(sql, idProcesso);

                dgvAdvogados.Columns["id_usuario"].Visible = false;
                dgvAdvogados.Columns["nome"].HeaderText = "Advogado";
                dgvAdvogados.Columns["oab"].HeaderText = "OAB";
                dgvAdvogados.Columns["responsavel_principal"].HeaderText = "Principal";

                dgvAdvogados.ClearSelection();
            }
            catch (Exception ex)
            {
                Mensagens.Erro("carregar advogados vinculados", ex);
            }
        }

        private void btnVincular_Click(object sender, EventArgs e)
        {
            if (cmbAdvogado.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um advogado.");
                cmbAdvogado.Focus();
                return;
            }

            try
            {
                ConexaoBD db = new ConexaoBD();

                using (MySqlConnection conn = db.CriarConexao())
                {
                    conn.Open();

                    string sql = @"INSERT INTO PROCESSO_ADVOGADO
                           (processo_id, usuario_id, responsavel_principal)
                           VALUES
                           (@processo, @usuario, @principal)";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@processo", idProcesso);
                    cmd.Parameters.AddWithValue("@usuario", cmbAdvogado.SelectedValue);
                    cmd.Parameters.AddWithValue("@principal", chkPrincipal.Checked);

                    cmd.ExecuteNonQuery();
                }

                Auditoria.Registrar("VINCULAR_ADVOGADO", "PROCESSO", idProcesso,
                    "Advogado " + cmbAdvogado.Text + " vinculado ao processo " + numeroProcesso);
                Historico.Registrar(idProcesso, "Advogado vinculado ao processo: " + cmbAdvogado.Text + ".");

                MessageBox.Show("Advogado vinculado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cmbAdvogado.SelectedIndex = -1;
                chkPrincipal.Checked = false;

                CarregarAdvogadosVinculados();
            }
            catch (Exception ex)
            {
                Mensagens.Erro("vincular advogado", ex);
            }
        }

        private void FrmVincularAdvogado_Load(object sender, EventArgs e)
        {
            lblNumeroProcesso.Text = numeroProcesso;


            CancelButton = btnFechar;


            bool podeVincular = Permissoes.Pode(Acao.VincularAdvogado);
            cmbAdvogado.Enabled = podeVincular;
            chkPrincipal.Enabled = podeVincular;
            btnVincular.Enabled = podeVincular;

            CarregarAdvogados();
            CarregarAdvogadosVinculados();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvAdvogados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
