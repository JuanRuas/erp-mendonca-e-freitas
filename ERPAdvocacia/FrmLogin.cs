using ERPAdvocacia.Data;
using ERPAdvocacia.UI;
using System;
using System.Data;
using System.Windows.Forms;

namespace ERPAdvocacia
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string senha = txtSenha.Text;

            if (email == "")
            {
                Mensagens.Aviso("Informe o e-mail.");
                txtEmail.Focus();
                return;
            }

            if (senha == "")
            {
                Mensagens.Aviso("Informe a senha.");
                txtSenha.Focus();
                return;
            }

            try
            {
                ConexaoBD db = new ConexaoBD();

                string sql = @"SELECT id_usuario, nome, perfil, senha_hash, ativo
                       FROM USUARIO
                       WHERE email = @email";

                DataTable dt = db.ExecutarSelect(sql, ConexaoBD.P("@email", email));

                                                                        
                                                                 
                if (dt.Rows.Count == 0)
                {
                    MostrarErroDeLogin();
                    return;
                }

                DataRow usuario = dt.Rows[0];
                int idUsuario = Convert.ToInt32(usuario["id_usuario"]);

                string hashDigitado = Seguranca.GerarHash(senha);
                string hashGuardado = usuario["senha_hash"].ToString();

                if (!string.Equals(hashDigitado, hashGuardado, StringComparison.OrdinalIgnoreCase))
                {
                    Auditoria.Registrar(idUsuario, "LOGIN_FALHA", "USUARIO", idUsuario, "Senha incorreta");
                    MostrarErroDeLogin();
                    return;
                }

                if (!Convert.ToBoolean(usuario["ativo"]))
                {
                    Auditoria.Registrar(idUsuario, "LOGIN_FALHA", "USUARIO", idUsuario, "Tentativa de login com usuário inativo");
                    MessageBox.Show(
                        "Este usuário está inativo. Procure um advogado do escritório para reativar o acesso.",
                        "Acesso negado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    txtSenha.Clear();
                    txtEmail.Focus();
                    return;
                }

                SessaoUsuario.Iniciar(idUsuario, usuario["nome"].ToString(), usuario["perfil"].ToString());
                Auditoria.Registrar("LOGIN", "USUARIO", idUsuario, "Login realizado");

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Mensagens.Erro("fazer login", ex);
            }
        }

        private void MostrarErroDeLogin()
        {
            MessageBox.Show(
                "E-mail ou senha inválidos.",
                "Acesso negado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtSenha.Clear();
            txtSenha.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
