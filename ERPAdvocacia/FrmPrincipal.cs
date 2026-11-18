using ERPAdvocacia.Data;
using ERPAdvocacia.UI;
using System;
using System.Windows.Forms;

namespace ERPAdvocacia
{
    public partial class FrmPrincipal : Form
    {
                                                                                       
                                                           
        public bool FezLogout { get; private set; } = false;

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            lblStatusUsuario.Text = "Usuário: " + SessaoUsuario.Nome + "   |   Perfil: " + SessaoUsuario.Perfil;
            AplicarPermissoes();
        }

                                                        
                                                                            
        private void AplicarPermissoes()
        {
            Liberar(mnuUsuarios, Permissoes.Pode(Acao.GerenciarUsuarios));

            bool financeiro = Permissoes.Pode(Acao.ConsultarFinanceiro);
            Liberar(mnuFinanceiro, financeiro);
            Liberar(mnuHonorarios, financeiro);
            Liberar(mnuPagamentos, financeiro);
            Liberar(mnuRelFinanceiro, financeiro);

            Liberar(mnuLogAuditoria, Permissoes.Pode(Acao.ConsultarAuditoria));
        }

                                                                                                            
        private void Liberar(ToolStripMenuItem item, bool pode)
        {
            item.Visible = pode;
            item.Enabled = pode;
        }

                                                        
                                                                       
        private void AbrirTela(Type tipoDoForm)
        {
            foreach (Form aberto in MdiChildren)
            {
                if (aberto.GetType() == tipoDoForm)
                {
                    aberto.Activate();
                    return;
                }
            }

            Form tela = (Form)Activator.CreateInstance(tipoDoForm);
            tela.MdiParent = this;
            tela.WindowState = FormWindowState.Maximized;
            tela.Show();
        }

        private void mnuClientes_Click(object sender, EventArgs e) { AbrirTela(typeof(FrmClientes)); }
        private void mnuUsuarios_Click(object sender, EventArgs e) { AbrirTela(typeof(FrmUsuarios)); }
        private void mnuProcessos_Click(object sender, EventArgs e) { AbrirTela(typeof(FrmProcessos)); }
        private void mnuPrazos_Click(object sender, EventArgs e) { AbrirTela(typeof(FrmPrazos)); }
        private void mnuMovimentacoes_Click(object sender, EventArgs e) { AbrirTela(typeof(FrmMovimentacoes)); }
        private void mnuHonorarios_Click(object sender, EventArgs e) { AbrirTela(typeof(FrmHonorarios)); }
        private void mnuPagamentos_Click(object sender, EventArgs e) { AbrirTela(typeof(FrmPagamentos)); }
        private void mnuRelPrazos_Click(object sender, EventArgs e) { AbrirTela(typeof(FrmRelatorioPrazos)); }
        private void mnuRelFinanceiro_Click(object sender, EventArgs e) { AbrirTela(typeof(FrmRelatorioFinanceiro)); }
        private void mnuLogAuditoria_Click(object sender, EventArgs e) { AbrirTela(typeof(FrmLogAuditoria)); }

        private void mnuSair_Click(object sender, EventArgs e)
        {
            if (!Mensagens.Confirmar("Deseja sair do sistema e voltar para a tela de login?"))
            {
                return;
            }

            FezLogout = true;
            Close();
        }

                                                                                              
        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Auditoria.Registrar("LOGOUT", "USUARIO", SessaoUsuario.IdUsuario, "Logout realizado");
            SessaoUsuario.Encerrar();
        }
    }
}
