using ERPAdvocacia.Data;
using ERPAdvocacia.UI;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ERPAdvocacia
{
    public partial class FrmUsuarios : Form
    {
        private int idUsuarioSelecionado = 0;
        private bool usuarioSelecionadoAtivo = true;

        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {

            if (!Permissoes.Pode(Acao.GerenciarUsuarios))
            {
                Mensagens.Aviso("Você não tem permissão para gerenciar usuários.");
                Close();
                return;
            }

            cmbPerfil.Items.Add("advogado");
            cmbPerfil.Items.Add("secretario");
            cmbPerfil.Items.Add("estagiario");

            CarregarDados();
            LimparCampos();
        }

        private void LimparCampos()
        {
            idUsuarioSelecionado = 0;
            usuarioSelecionadoAtivo = true;

            txtNome.Clear();
            txtEmail.Clear();
            txtSenha.Clear();
            cmbPerfil.SelectedIndex = -1;
            txtOab.Clear();
            txtOab.Enabled = false;
            txtSituacao.Text = "Ativo";

            dgvUsuarios.ClearSelection();

            btnSalvar.Enabled = true;
            btnAlterar.Enabled = false;
            btnAtivar.Enabled = false;
            btnAtivar.Text = "Desativar";

            txtNome.Focus();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                Mensagens.Aviso("Informe o nome do usuário.");
                txtNome.Focus();
                return false;
            }

            if (!Formato.EmailValido(txtEmail.Text.Trim()))
            {
                Mensagens.Aviso("Informe um e-mail válido (exemplo: nome@escritorio.com).");
                txtEmail.Focus();
                return false;
            }


            bool novo = idUsuarioSelecionado == 0;

            if (novo && txtSenha.Text == "")
            {
                Mensagens.Aviso("Informe a senha do usuário.");
                txtSenha.Focus();
                return false;
            }

            if (txtSenha.Text != "" && txtSenha.Text.Length < 6)
            {
                Mensagens.Aviso("A senha deve ter pelo menos 6 caracteres.");
                txtSenha.Focus();
                return false;
            }

            if (cmbPerfil.SelectedIndex == -1)
            {
                Mensagens.Aviso("Selecione o perfil do usuário.");
                cmbPerfil.Focus();
                return false;
            }

            if (cmbPerfil.Text == "advogado" && string.IsNullOrWhiteSpace(txtOab.Text))
            {
                Mensagens.Aviso("Informe a OAB do advogado.");
                txtOab.Focus();
                return false;
            }

            return true;
        }


        private void cmbPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool advogado = cmbPerfil.Text == "advogado";

            txtOab.Enabled = advogado;

            if (!advogado)
            {
                txtOab.Clear();
            }
        }



        private object OabParaBanco()
        {
            if (string.IsNullOrWhiteSpace(txtOab.Text))
            {
                return DBNull.Value;
            }

            return txtOab.Text.Trim().ToUpper();
        }

        private void CarregarDados()
        {
            try
            {
                ConexaoBD db = new ConexaoBD();


                string sql = @"SELECT id_usuario, nome, email, perfil, oab, ativo,
                       IF(ativo, 'Ativo', 'Inativo') AS situacao
                       FROM USUARIO
                       WHERE nome LIKE @pesquisa
                       OR email LIKE @pesquisa
                       OR perfil LIKE @pesquisa
                       ORDER BY nome";

                dgvUsuarios.DataSource = db.ExecutarSelect(sql, txtPesquisar.Text.Trim());

                GridHelper.Ocultar(dgvUsuarios, "id_usuario", "ativo");
                GridHelper.Titulo(dgvUsuarios, "nome", "Nome");
                GridHelper.Titulo(dgvUsuarios, "email", "E-mail");
                GridHelper.Titulo(dgvUsuarios, "perfil", "Perfil");
                GridHelper.Titulo(dgvUsuarios, "oab", "OAB");
                GridHelper.Titulo(dgvUsuarios, "situacao", "Situação");

                dgvUsuarios.ClearSelection();
            }
            catch (Exception ex)
            {
                Mensagens.Erro("carregar os usuários", ex);
            }
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

                string sql = @"INSERT INTO USUARIO (nome, email, senha_hash, perfil, oab, ativo)
                       VALUES (@nome, @email, @senha, @perfil, @oab, TRUE)";

                long novoId = db.ExecutarComando(sql,
                    ConexaoBD.P("@nome", txtNome.Text.Trim()),
                    ConexaoBD.P("@email", txtEmail.Text.Trim()),
                    ConexaoBD.P("@senha", Seguranca.GerarHash(txtSenha.Text)),
                    ConexaoBD.P("@perfil", cmbPerfil.Text),
                    ConexaoBD.P("@oab", OabParaBanco()));


                Auditoria.Registrar("CADASTRAR", "USUARIO", (int)novoId,
                    "Usuário cadastrado: " + txtEmail.Text.Trim() + " (" + cmbPerfil.Text + ")");

                Mensagens.Sucesso("Usuário cadastrado com sucesso!");

                CarregarDados();
                LimparCampos();
            }
            catch (Exception ex)
            {
                Mensagens.Erro("cadastrar o usuário", ex);
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow linha = dgvUsuarios.Rows[e.RowIndex];

            idUsuarioSelecionado = Convert.ToInt32(linha.Cells["id_usuario"].Value);
            usuarioSelecionadoAtivo = Convert.ToBoolean(linha.Cells["ativo"].Value);

            txtNome.Text = linha.Cells["nome"].Value.ToString();
            txtEmail.Text = linha.Cells["email"].Value.ToString();
            txtSenha.Clear();
            cmbPerfil.SelectedItem = linha.Cells["perfil"].Value.ToString();
            txtOab.Text = linha.Cells["oab"].Value.ToString();
            txtSituacao.Text = usuarioSelecionadoAtivo ? "Ativo" : "Inativo";

            btnSalvar.Enabled = false;
            btnAlterar.Enabled = true;
            btnAtivar.Enabled = true;
            btnAtivar.Text = usuarioSelecionadoAtivo ? "Desativar" : "Reativar";
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (idUsuarioSelecionado == 0 || !ValidarCampos())
            {
                return;
            }


            if (idUsuarioSelecionado == SessaoUsuario.IdUsuario && cmbPerfil.Text != SessaoUsuario.Perfil)
            {
                Mensagens.Aviso("Você não pode alterar o seu próprio perfil. Peça para outro advogado fazer isso.");
                return;
            }

            try
            {
                ConexaoBD db = new ConexaoBD();


                string sql = @"UPDATE USUARIO SET
                       nome = @nome,
                       email = @email,
                       perfil = @perfil,
                       oab = @oab";

                List<MySqlParameter> parametros = new List<MySqlParameter>();
                parametros.Add(ConexaoBD.P("@nome", txtNome.Text.Trim()));
                parametros.Add(ConexaoBD.P("@email", txtEmail.Text.Trim()));
                parametros.Add(ConexaoBD.P("@perfil", cmbPerfil.Text));
                parametros.Add(ConexaoBD.P("@oab", OabParaBanco()));
                parametros.Add(ConexaoBD.P("@id", idUsuarioSelecionado));


                bool trocarSenha = txtSenha.Text != "";

                if (trocarSenha)
                {
                    sql += ", senha_hash = @senha";
                    parametros.Add(ConexaoBD.P("@senha", Seguranca.GerarHash(txtSenha.Text)));
                }

                sql += " WHERE id_usuario = @id";

                db.ExecutarComando(sql, parametros.ToArray());

                Auditoria.Registrar("ALTERAR", "USUARIO", idUsuarioSelecionado,
                    "Usuário alterado: " + txtEmail.Text.Trim() + (trocarSenha ? " (senha redefinida)" : ""));


                if (idUsuarioSelecionado == SessaoUsuario.IdUsuario)
                {
                    SessaoUsuario.Nome = txtNome.Text.Trim();
                }

                Mensagens.Sucesso("Usuário alterado com sucesso!");

                CarregarDados();
                LimparCampos();
            }
            catch (Exception ex)
            {
                Mensagens.Erro("alterar o usuário", ex);
            }
        }


        private void btnAtivar_Click(object sender, EventArgs e)
        {
            if (idUsuarioSelecionado == 0)
            {
                Mensagens.Aviso("Selecione um usuário.");
                return;
            }

            bool desativando = usuarioSelecionadoAtivo;

            if (desativando && idUsuarioSelecionado == SessaoUsuario.IdUsuario)
            {
                Mensagens.Aviso("Você não pode desativar o seu próprio usuário.");
                return;
            }

            string pergunta = desativando
                ? "Deseja realmente desativar este usuário? Ele não conseguirá mais entrar no sistema."
                : "Deseja reativar este usuário?";

            if (!Mensagens.Confirmar(pergunta))
            {
                return;
            }

            try
            {
                ConexaoBD db = new ConexaoBD();

                db.ExecutarComando("UPDATE USUARIO SET ativo = @ativo WHERE id_usuario = @id",
                    ConexaoBD.P("@ativo", !desativando),
                    ConexaoBD.P("@id", idUsuarioSelecionado));

                Auditoria.Registrar(desativando ? "DESATIVAR" : "REATIVAR", "USUARIO", idUsuarioSelecionado,
                    (desativando ? "Usuário desativado: " : "Usuário reativado: ") + txtEmail.Text.Trim());

                Mensagens.Sucesso(desativando ? "Usuário desativado com sucesso!" : "Usuário reativado com sucesso!");

                CarregarDados();
                LimparCampos();
            }
            catch (Exception ex)
            {
                Mensagens.Erro(desativando ? "desativar o usuário" : "reativar o usuário", ex);
            }
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            LimparCampos();
            txtPesquisar.Focus();
            CarregarDados();
        }

        private void lblDicaSenha_Click(object sender, EventArgs e)
        {

        }

        private void txtSituacao_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
