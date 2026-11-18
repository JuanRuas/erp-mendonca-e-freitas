namespace ERPAdvocacia
{
    partial class FrmLogAuditoria
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
            lblTitulo = new Label();
            lblUsuario = new Label();
            cmbUsuario = new ComboBox();
            lblAcao = new Label();
            cmbAcao = new ComboBox();
            lblInicial = new Label();
            dtpInicial = new DateTimePicker();
            lblFinal = new Label();
            dtpFinal = new DateTimePicker();
            btnGerar = new Button();
            btnLimpar = new Button();
            btnExportar = new Button();
            lblResumo = new Label();
            dgvAuditoria = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvAuditoria).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F);
            lblTitulo.Location = new Point(29, 24);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(216, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Log de Auditoria";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(29, 103);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(62, 20);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuário:";
            // 
            // cmbUsuario
            // 
            cmbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsuario.FormattingEnabled = true;
            cmbUsuario.Location = new Point(149, 96);
            cmbUsuario.Margin = new Padding(3, 4, 3, 4);
            cmbUsuario.Name = "cmbUsuario";
            cmbUsuario.Size = new Size(285, 28);
            cmbUsuario.TabIndex = 2;
            // 
            // lblAcao
            // 
            lblAcao.AutoSize = true;
            lblAcao.Location = new Point(469, 103);
            lblAcao.Name = "lblAcao";
            lblAcao.Size = new Size(46, 20);
            lblAcao.TabIndex = 3;
            lblAcao.Text = "Ação:";
            // 
            // cmbAcao
            // 
            cmbAcao.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAcao.FormattingEnabled = true;
            cmbAcao.Location = new Point(526, 96);
            cmbAcao.Margin = new Padding(3, 4, 3, 4);
            cmbAcao.Name = "cmbAcao";
            cmbAcao.Size = new Size(251, 28);
            cmbAcao.TabIndex = 4;
            // 
            // lblInicial
            // 
            lblInicial.AutoSize = true;
            lblInicial.Location = new Point(29, 156);
            lblInicial.Name = "lblInicial";
            lblInicial.Size = new Size(84, 20);
            lblInicial.TabIndex = 5;
            lblInicial.Text = "Período de:";
            // 
            // dtpInicial
            // 
            dtpInicial.CustomFormat = "dd/MM/yyyy";
            dtpInicial.Format = DateTimePickerFormat.Custom;
            dtpInicial.Location = new Point(149, 149);
            dtpInicial.Margin = new Padding(3, 4, 3, 4);
            dtpInicial.Name = "dtpInicial";
            dtpInicial.ShowCheckBox = true;
            dtpInicial.Size = new Size(171, 27);
            dtpInicial.TabIndex = 6;
            // 
            // lblFinal
            // 
            lblFinal.AutoSize = true;
            lblFinal.Location = new Point(343, 156);
            lblFinal.Name = "lblFinal";
            lblFinal.Size = new Size(33, 20);
            lblFinal.TabIndex = 7;
            lblFinal.Text = "até:";
            // 
            // dtpFinal
            // 
            dtpFinal.CustomFormat = "dd/MM/yyyy";
            dtpFinal.Format = DateTimePickerFormat.Custom;
            dtpFinal.Location = new Point(383, 149);
            dtpFinal.Margin = new Padding(3, 4, 3, 4);
            dtpFinal.Name = "dtpFinal";
            dtpFinal.ShowCheckBox = true;
            dtpFinal.Size = new Size(171, 27);
            dtpFinal.TabIndex = 8;
            // 
            // btnGerar
            // 
            btnGerar.Location = new Point(29, 213);
            btnGerar.Margin = new Padding(3, 4, 3, 4);
            btnGerar.Name = "btnGerar";
            btnGerar.Size = new Size(149, 53);
            btnGerar.TabIndex = 9;
            btnGerar.Text = "Gerar";
            btnGerar.UseVisualStyleBackColor = true;
            btnGerar.Click += btnGerar_Click;
            // 
            // btnLimpar
            // 
            btnLimpar.Location = new Point(194, 213);
            btnLimpar.Margin = new Padding(3, 4, 3, 4);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(149, 53);
            btnLimpar.TabIndex = 10;
            btnLimpar.Text = "Limpar filtros";
            btnLimpar.UseVisualStyleBackColor = true;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // btnExportar
            // 
            btnExportar.Location = new Point(360, 213);
            btnExportar.Margin = new Padding(3, 4, 3, 4);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(149, 53);
            btnExportar.TabIndex = 11;
            btnExportar.Text = "Exportar CSV";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // lblResumo
            // 
            lblResumo.AutoSize = true;
            lblResumo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblResumo.Location = new Point(29, 289);
            lblResumo.Name = "lblResumo";
            lblResumo.Size = new Size(0, 20);
            lblResumo.TabIndex = 12;
            // 
            // dgvAuditoria
            // 
            dgvAuditoria.AllowUserToAddRows = false;
            dgvAuditoria.AllowUserToDeleteRows = false;
            dgvAuditoria.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAuditoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvAuditoria.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAuditoria.Location = new Point(29, 320);
            dgvAuditoria.Margin = new Padding(3, 4, 3, 4);
            dgvAuditoria.MultiSelect = false;
            dgvAuditoria.Name = "dgvAuditoria";
            dgvAuditoria.ReadOnly = true;
            dgvAuditoria.RowHeadersWidth = 51;
            dgvAuditoria.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAuditoria.Size = new Size(759, 500);
            dgvAuditoria.TabIndex = 13;
            // 
            // FrmLogAuditoria
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(817, 853);
            Controls.Add(dgvAuditoria);
            Controls.Add(lblResumo);
            Controls.Add(btnExportar);
            Controls.Add(btnLimpar);
            Controls.Add(btnGerar);
            Controls.Add(dtpFinal);
            Controls.Add(lblFinal);
            Controls.Add(dtpInicial);
            Controls.Add(lblInicial);
            Controls.Add(cmbAcao);
            Controls.Add(lblAcao);
            Controls.Add(cmbUsuario);
            Controls.Add(lblUsuario);
            Controls.Add(lblTitulo);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmLogAuditoria";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Log de Auditoria";
            Load += FrmLogAuditoria_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAuditoria).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblUsuario;
        private ComboBox cmbUsuario;
        private Label lblAcao;
        private ComboBox cmbAcao;
        private Label lblInicial;
        private DateTimePicker dtpInicial;
        private Label lblFinal;
        private DateTimePicker dtpFinal;
        private Button btnGerar;
        private Button btnLimpar;
        private Button btnExportar;
        private Label lblResumo;
        private DataGridView dgvAuditoria;
    }
}
