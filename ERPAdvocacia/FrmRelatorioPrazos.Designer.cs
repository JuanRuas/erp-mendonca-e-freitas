namespace ERPAdvocacia
{
    partial class FrmRelatorioPrazos
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
            lblInicial = new Label();
            dtpInicial = new DateTimePicker();
            lblFinal = new Label();
            dtpFinal = new DateTimePicker();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            lblResponsavel = new Label();
            cmbResponsavel = new ComboBox();
            btnGerar = new Button();
            btnLimpar = new Button();
            btnExportar = new Button();
            lblResumo = new Label();
            dgvPrazos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvPrazos).BeginInit();
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
            lblTitulo.Text = "Relatório de Prazos";
            // 
            // lblInicial
            // 
            lblInicial.AutoSize = true;
            lblInicial.Location = new Point(25, 77);
            lblInicial.Name = "lblInicial";
            lblInicial.Size = new Size(60, 15);
            lblInicial.TabIndex = 1;
            lblInicial.Text = "Vencimento de:";
            // 
            // dtpInicial
            // 
            dtpInicial.CustomFormat = "dd/MM/yyyy";
            dtpInicial.Format = DateTimePickerFormat.Custom;
            dtpInicial.Location = new Point(130, 72);
            dtpInicial.Name = "dtpInicial";
            dtpInicial.ShowCheckBox = true;
            dtpInicial.Size = new Size(150, 23);
            dtpInicial.TabIndex = 2;
            // 
            // lblFinal
            // 
            lblFinal.AutoSize = true;
            lblFinal.Location = new Point(300, 77);
            lblFinal.Name = "lblFinal";
            lblFinal.Size = new Size(60, 15);
            lblFinal.TabIndex = 3;
            lblFinal.Text = "até:";
            // 
            // dtpFinal
            // 
            dtpFinal.CustomFormat = "dd/MM/yyyy";
            dtpFinal.Format = DateTimePickerFormat.Custom;
            dtpFinal.Location = new Point(335, 72);
            dtpFinal.Name = "dtpFinal";
            dtpFinal.ShowCheckBox = true;
            dtpFinal.Size = new Size(150, 23);
            dtpFinal.TabIndex = 4;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(25, 117);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(60, 15);
            lblStatus.TabIndex = 5;
            lblStatus.Text = "Status:";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(130, 112);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(150, 23);
            cmbStatus.TabIndex = 6;
            // 
            // lblResponsavel
            // 
            lblResponsavel.AutoSize = true;
            lblResponsavel.Location = new Point(300, 117);
            lblResponsavel.Name = "lblResponsavel";
            lblResponsavel.Size = new Size(60, 15);
            lblResponsavel.TabIndex = 7;
            lblResponsavel.Text = "Responsável:";
            // 
            // cmbResponsavel
            // 
            cmbResponsavel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbResponsavel.FormattingEnabled = true;
            cmbResponsavel.Location = new Point(390, 112);
            cmbResponsavel.Name = "cmbResponsavel";
            cmbResponsavel.Size = new Size(260, 23);
            cmbResponsavel.TabIndex = 8;
            // 
            // btnGerar
            // 
            btnGerar.Location = new Point(25, 160);
            btnGerar.Name = "btnGerar";
            btnGerar.Size = new Size(130, 40);
            btnGerar.TabIndex = 9;
            btnGerar.Text = "Gerar";
            btnGerar.UseVisualStyleBackColor = true;
            btnGerar.Click += btnGerar_Click;
            // 
            // btnLimpar
            // 
            btnLimpar.Location = new Point(170, 160);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(130, 40);
            btnLimpar.TabIndex = 10;
            btnLimpar.Text = "Limpar filtros";
            btnLimpar.UseVisualStyleBackColor = true;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // btnExportar
            // 
            btnExportar.Location = new Point(315, 160);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(130, 40);
            btnExportar.TabIndex = 11;
            btnExportar.Text = "Exportar CSV";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // lblResumo
            // 
            lblResumo.AutoSize = true;
            lblResumo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblResumo.Location = new Point(25, 217);
            lblResumo.Name = "lblResumo";
            lblResumo.Size = new Size(400, 15);
            lblResumo.TabIndex = 12;
            lblResumo.Text = "";
            // 
            // dgvPrazos
            // 
            dgvPrazos.AllowUserToAddRows = false;
            dgvPrazos.AllowUserToDeleteRows = false;
            dgvPrazos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPrazos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPrazos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrazos.Location = new Point(25, 240);
            dgvPrazos.MultiSelect = false;
            dgvPrazos.Name = "dgvPrazos";
            dgvPrazos.ReadOnly = true;
            dgvPrazos.RowHeadersWidth = 51;
            dgvPrazos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrazos.Size = new Size(850, 375);
            dgvPrazos.TabIndex = 13;
            // 
            // FrmRelatorioPrazos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 640);
            Controls.Add(dgvPrazos);
            Controls.Add(lblResumo);
            Controls.Add(btnExportar);
            Controls.Add(btnLimpar);
            Controls.Add(btnGerar);
            Controls.Add(cmbResponsavel);
            Controls.Add(lblResponsavel);
            Controls.Add(cmbStatus);
            Controls.Add(lblStatus);
            Controls.Add(dtpFinal);
            Controls.Add(lblFinal);
            Controls.Add(dtpInicial);
            Controls.Add(lblInicial);
            Controls.Add(lblTitulo);
            Name = "FrmRelatorioPrazos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Relatório de Prazos";
            Load += FrmRelatorioPrazos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPrazos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblInicial;
        private DateTimePicker dtpInicial;
        private Label lblFinal;
        private DateTimePicker dtpFinal;
        private Label lblStatus;
        private ComboBox cmbStatus;
        private Label lblResponsavel;
        private ComboBox cmbResponsavel;
        private Button btnGerar;
        private Button btnLimpar;
        private Button btnExportar;
        private Label lblResumo;
        private DataGridView dgvPrazos;
    }
}
