namespace ERPAdvocacia
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuPrincipal = new MenuStrip();
            mnuCadastros = new ToolStripMenuItem();
            mnuClientes = new ToolStripMenuItem();
            mnuUsuarios = new ToolStripMenuItem();
            mnuProcessosGrupo = new ToolStripMenuItem();
            mnuProcessos = new ToolStripMenuItem();
            mnuPrazos = new ToolStripMenuItem();
            mnuMovimentacoes = new ToolStripMenuItem();
            mnuFinanceiro = new ToolStripMenuItem();
            mnuHonorarios = new ToolStripMenuItem();
            mnuPagamentos = new ToolStripMenuItem();
            mnuRelatorios = new ToolStripMenuItem();
            mnuRelPrazos = new ToolStripMenuItem();
            mnuRelFinanceiro = new ToolStripMenuItem();
            mnuLogAuditoria = new ToolStripMenuItem();
            mnuSair = new ToolStripMenuItem();
            barraStatus = new StatusStrip();
            lblStatusUsuario = new ToolStripStatusLabel();
            menuPrincipal.SuspendLayout();
            barraStatus.SuspendLayout();
            SuspendLayout();
            //
            // menuPrincipal
            //
            menuPrincipal.ImageScalingSize = new Size(20, 20);
            menuPrincipal.Items.AddRange(new ToolStripItem[] { mnuCadastros, mnuProcessosGrupo, mnuFinanceiro, mnuRelatorios, mnuSair });
            menuPrincipal.Location = new Point(0, 0);
            menuPrincipal.Name = "menuPrincipal";
            menuPrincipal.Size = new Size(1100, 24);
            menuPrincipal.TabIndex = 0;
            menuPrincipal.Text = "menuPrincipal";
            //
            // mnuCadastros
            //
            mnuCadastros.DropDownItems.AddRange(new ToolStripItem[] { mnuClientes, mnuUsuarios });
            mnuCadastros.Name = "mnuCadastros";
            mnuCadastros.Size = new Size(80, 20);
            mnuCadastros.Text = "&Cadastros";
            //
            // mnuClientes
            //
            mnuClientes.Name = "mnuClientes";
            mnuClientes.ShortcutKeys = Keys.Control | Keys.D1;
            mnuClientes.Size = new Size(200, 22);
            mnuClientes.Text = "Clientes";
            mnuClientes.Click += mnuClientes_Click;
            //
            // mnuUsuarios
            //
            mnuUsuarios.Name = "mnuUsuarios";
            mnuUsuarios.ShortcutKeys = Keys.Control | Keys.D2;
            mnuUsuarios.Size = new Size(200, 22);
            mnuUsuarios.Text = "Usuários";
            mnuUsuarios.Click += mnuUsuarios_Click;
            //
            // mnuProcessosGrupo
            //
            mnuProcessosGrupo.DropDownItems.AddRange(new ToolStripItem[] { mnuProcessos, mnuPrazos, mnuMovimentacoes });
            mnuProcessosGrupo.Name = "mnuProcessosGrupo";
            mnuProcessosGrupo.Size = new Size(80, 20);
            mnuProcessosGrupo.Text = "&Processos";
            //
            // mnuProcessos
            //
            mnuProcessos.Name = "mnuProcessos";
            mnuProcessos.ShortcutKeys = Keys.Control | Keys.D3;
            mnuProcessos.Size = new Size(200, 22);
            mnuProcessos.Text = "Processos";
            mnuProcessos.Click += mnuProcessos_Click;
            //
            // mnuPrazos
            //
            mnuPrazos.Name = "mnuPrazos";
            mnuPrazos.ShortcutKeys = Keys.Control | Keys.D4;
            mnuPrazos.Size = new Size(200, 22);
            mnuPrazos.Text = "Prazos";
            mnuPrazos.Click += mnuPrazos_Click;
            //
            // mnuMovimentacoes
            //
            mnuMovimentacoes.Name = "mnuMovimentacoes";
            mnuMovimentacoes.ShortcutKeys = Keys.Control | Keys.D5;
            mnuMovimentacoes.Size = new Size(200, 22);
            mnuMovimentacoes.Text = "Movimentações";
            mnuMovimentacoes.Click += mnuMovimentacoes_Click;
            //
            // mnuFinanceiro
            //
            mnuFinanceiro.DropDownItems.AddRange(new ToolStripItem[] { mnuHonorarios, mnuPagamentos });
            mnuFinanceiro.Name = "mnuFinanceiro";
            mnuFinanceiro.Size = new Size(80, 20);
            mnuFinanceiro.Text = "&Financeiro";
            //
            // mnuHonorarios
            //
            mnuHonorarios.Name = "mnuHonorarios";
            mnuHonorarios.ShortcutKeys = Keys.Control | Keys.D6;
            mnuHonorarios.Size = new Size(200, 22);
            mnuHonorarios.Text = "Honorários";
            mnuHonorarios.Click += mnuHonorarios_Click;
            //
            // mnuPagamentos
            //
            mnuPagamentos.Name = "mnuPagamentos";
            mnuPagamentos.ShortcutKeys = Keys.Control | Keys.D7;
            mnuPagamentos.Size = new Size(200, 22);
            mnuPagamentos.Text = "Pagamentos";
            mnuPagamentos.Click += mnuPagamentos_Click;
            //
            // mnuRelatorios
            //
            mnuRelatorios.DropDownItems.AddRange(new ToolStripItem[] { mnuRelPrazos, mnuRelFinanceiro, mnuLogAuditoria });
            mnuRelatorios.Name = "mnuRelatorios";
            mnuRelatorios.Size = new Size(80, 20);
            mnuRelatorios.Text = "&Relatórios";
            //
            // mnuRelPrazos
            //
            mnuRelPrazos.Name = "mnuRelPrazos";
            mnuRelPrazos.ShortcutKeys = Keys.Control | Keys.D8;
            mnuRelPrazos.Size = new Size(220, 22);
            mnuRelPrazos.Text = "Prazos";
            mnuRelPrazos.Click += mnuRelPrazos_Click;
            //
            // mnuRelFinanceiro
            //
            mnuRelFinanceiro.Name = "mnuRelFinanceiro";
            mnuRelFinanceiro.ShortcutKeys = Keys.Control | Keys.D9;
            mnuRelFinanceiro.Size = new Size(220, 22);
            mnuRelFinanceiro.Text = "Financeiro por processo";
            mnuRelFinanceiro.Click += mnuRelFinanceiro_Click;
            //
            // mnuLogAuditoria
            //
            mnuLogAuditoria.Name = "mnuLogAuditoria";
            mnuLogAuditoria.Size = new Size(220, 22);
            mnuLogAuditoria.Text = "Log de auditoria";
            mnuLogAuditoria.Click += mnuLogAuditoria_Click;
            //
            // mnuSair
            //
            mnuSair.Name = "mnuSair";
            mnuSair.Size = new Size(40, 20);
            mnuSair.Text = "&Sair";
            mnuSair.Click += mnuSair_Click;
            //
            // barraStatus
            //
            barraStatus.ImageScalingSize = new Size(20, 20);
            barraStatus.Items.AddRange(new ToolStripItem[] { lblStatusUsuario });
            barraStatus.Location = new Point(0, 632);
            barraStatus.Name = "barraStatus";
            barraStatus.Size = new Size(1100, 22);
            barraStatus.TabIndex = 1;
            barraStatus.Text = "barraStatus";
            //
            // lblStatusUsuario
            //
            lblStatusUsuario.Name = "lblStatusUsuario";
            lblStatusUsuario.Size = new Size(120, 17);
            lblStatusUsuario.Text = "lblStatusUsuario";
            //
            // FrmPrincipal
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 654);
            Controls.Add(barraStatus);
            Controls.Add(menuPrincipal);
            IsMdiContainer = true;
            MainMenuStrip = menuPrincipal;
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ERP Advocacia - Mendonça & Freitas";
            WindowState = FormWindowState.Maximized;
            FormClosed += FrmPrincipal_FormClosed;
            Load += FrmPrincipal_Load;
            menuPrincipal.ResumeLayout(false);
            menuPrincipal.PerformLayout();
            barraStatus.ResumeLayout(false);
            barraStatus.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuPrincipal;
        private ToolStripMenuItem mnuCadastros;
        private ToolStripMenuItem mnuClientes;
        private ToolStripMenuItem mnuUsuarios;
        private ToolStripMenuItem mnuProcessosGrupo;
        private ToolStripMenuItem mnuProcessos;
        private ToolStripMenuItem mnuPrazos;
        private ToolStripMenuItem mnuMovimentacoes;
        private ToolStripMenuItem mnuFinanceiro;
        private ToolStripMenuItem mnuHonorarios;
        private ToolStripMenuItem mnuPagamentos;
        private ToolStripMenuItem mnuRelatorios;
        private ToolStripMenuItem mnuRelPrazos;
        private ToolStripMenuItem mnuRelFinanceiro;
        private ToolStripMenuItem mnuLogAuditoria;
        private ToolStripMenuItem mnuSair;
        private StatusStrip barraStatus;
        private ToolStripStatusLabel lblStatusUsuario;
    }
}
