namespace ERPAdvocacia
{
    partial class FrmRelatorioFinanceiro
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
            lblCliente = new Label();
            cmbCliente = new ComboBox();
            lblProcesso = new Label();
            cmbProcesso = new ComboBox();
            lblInicial = new Label();
            dtpInicial = new DateTimePicker();
            lblFinal = new Label();
            dtpFinal = new DateTimePicker();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            btnGerar = new Button();
            btnLimpar = new Button();
            btnExportar = new Button();
            lblResumo = new Label();
            lblTotais = new Label();
            dgvFinanceiro = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvFinanceiro).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F);
            lblTitulo.Location = new Point(25, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(300, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Relatório Financeiro por Cliente / Processo";
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(25, 77);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(60, 15);
            lblCliente.TabIndex = 1;
            lblCliente.Text = "Cliente:";
            // 
            // cmbCliente
            // 
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(130, 72);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(300, 23);
            cmbCliente.TabIndex = 2;
            cmbCliente.SelectedIndexChanged += cmbCliente_SelectedIndexChanged;
            // 
            // lblProcesso
            // 
            lblProcesso.AutoSize = true;
            lblProcesso.Location = new Point(460, 77);
            lblProcesso.Name = "lblProcesso";
            lblProcesso.Size = new Size(60, 15);
            lblProcesso.TabIndex = 3;
            lblProcesso.Text = "Processo:";
            // 
            // cmbProcesso
            // 
            cmbProcesso.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProcesso.FormattingEnabled = true;
            cmbProcesso.Location = new Point(530, 72);
            cmbProcesso.Name = "cmbProcesso";
            cmbProcesso.Size = new Size(345, 23);
            cmbProcesso.TabIndex = 4;
            // 
            // lblInicial
            // 
            lblInicial.AutoSize = true;
            lblInicial.Location = new Point(25, 117);
            lblInicial.Name = "lblInicial";
            lblInicial.Size = new Size(60, 15);
            lblInicial.TabIndex = 5;
            lblInicial.Text = "Assinatura de:";
            // 
            // dtpInicial
            // 
            dtpInicial.CustomFormat = "dd/MM/yyyy";
            dtpInicial.Format = DateTimePickerFormat.Custom;
            dtpInicial.Location = new Point(130, 112);
            dtpInicial.Name = "dtpInicial";
            dtpInicial.ShowCheckBox = true;
            dtpInicial.Size = new Size(130, 23);
            dtpInicial.TabIndex = 6;
            // 
            // lblFinal
            // 
            lblFinal.AutoSize = true;
            lblFinal.Location = new Point(280, 117);
            lblFinal.Name = "lblFinal";
            lblFinal.Size = new Size(60, 15);
            lblFinal.TabIndex = 7;
            lblFinal.Text = "até:";
            // 
            // dtpFinal
            // 
            dtpFinal.CustomFormat = "dd/MM/yyyy";
            dtpFinal.Format = DateTimePickerFormat.Custom;
            dtpFinal.Location = new Point(315, 112);
            dtpFinal.Name = "dtpFinal";
            dtpFinal.ShowCheckBox = true;
            dtpFinal.Size = new Size(130, 23);
            dtpFinal.TabIndex = 8;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(475, 117);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(60, 15);
            lblStatus.TabIndex = 9;
            lblStatus.Text = "Status do contrato:";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(590, 112);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(150, 23);
            cmbStatus.TabIndex = 10;
            // 
            // btnGerar
            // 
            btnGerar.Location = new Point(25, 160);
            btnGerar.Name = "btnGerar";
            btnGerar.Size = new Size(130, 40);
            btnGerar.TabIndex = 11;
            btnGerar.Text = "Gerar";
            btnGerar.UseVisualStyleBackColor = true;
            btnGerar.Click += btnGerar_Click;
            // 
            // btnLimpar
            // 
            btnLimpar.Location = new Point(170, 160);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(130, 40);
            btnLimpar.TabIndex = 12;
            btnLimpar.Text = "Limpar filtros";
            btnLimpar.UseVisualStyleBackColor = true;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // btnExportar
            // 
            btnExportar.Location = new Point(315, 160);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(130, 40);
            btnExportar.TabIndex = 13;
            btnExportar.Text = "Exportar CSV";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // lblResumo
            // 
            lblResumo.AutoSize = true;
            lblResumo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblResumo.Location = new Point(25, 212);
            lblResumo.Name = "lblResumo";
            lblResumo.Size = new Size(400, 15);
            lblResumo.TabIndex = 14;
            lblResumo.Text = "";
            // 
            // lblTotais
            // 
            lblTotais.AutoSize = true;
            lblTotais.Location = new Point(25, 234);
            lblTotais.Name = "lblTotais";
            lblTotais.Size = new Size(500, 15);
            lblTotais.TabIndex = 15;
            lblTotais.Text = "";
            // 
            // dgvFinanceiro
            // 
            dgvFinanceiro.AllowUserToAddRows = false;
            dgvFinanceiro.AllowUserToDeleteRows = false;
            dgvFinanceiro.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvFinanceiro.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvFinanceiro.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFinanceiro.Location = new Point(25, 262);
            dgvFinanceiro.MultiSelect = false;
            dgvFinanceiro.Name = "dgvFinanceiro";
            dgvFinanceiro.ReadOnly = true;
            dgvFinanceiro.RowHeadersWidth = 51;
            dgvFinanceiro.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFinanceiro.Size = new Size(850, 375);
            dgvFinanceiro.TabIndex = 16;
            // 
            // FrmRelatorioFinanceiro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 660);
            Controls.Add(dgvFinanceiro);
            Controls.Add(lblTotais);
            Controls.Add(lblResumo);
            Controls.Add(btnExportar);
            Controls.Add(btnLimpar);
            Controls.Add(btnGerar);
            Controls.Add(cmbStatus);
            Controls.Add(lblStatus);
            Controls.Add(dtpFinal);
            Controls.Add(lblFinal);
            Controls.Add(dtpInicial);
            Controls.Add(lblInicial);
            Controls.Add(cmbProcesso);
            Controls.Add(lblProcesso);
            Controls.Add(cmbCliente);
            Controls.Add(lblCliente);
            Controls.Add(lblTitulo);
            Name = "FrmRelatorioFinanceiro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Relatório Financeiro";
            Load += FrmRelatorioFinanceiro_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFinanceiro).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblCliente;
        private ComboBox cmbCliente;
        private Label lblProcesso;
        private ComboBox cmbProcesso;
        private Label lblInicial;
        private DateTimePicker dtpInicial;
        private Label lblFinal;
        private DateTimePicker dtpFinal;
        private Label lblStatus;
        private ComboBox cmbStatus;
        private Button btnGerar;
        private Button btnLimpar;
        private Button btnExportar;
        private Label lblResumo;
        private Label lblTotais;
        private DataGridView dgvFinanceiro;
    }
}
