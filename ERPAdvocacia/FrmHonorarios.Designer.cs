namespace ERPAdvocacia
{
    partial class FrmHonorarios
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
            lblProcesso = new Label();
            cmbProcesso = new ComboBox();
            lblTipo = new Label();
            cmbTipo = new ComboBox();
            lblValor = new Label();
            txtValor = new TextBox();
            lblPercentual = new Label();
            txtPercentual = new TextBox();
            lblFaixa = new Label();
            lblAssinatura = new Label();
            dtpAssinatura = new DateTimePicker();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            btnNovo = new Button();
            btnSalvar = new Button();
            btnAlterar = new Button();
            lblPesquisar = new Label();
            txtPesquisar = new TextBox();
            dgvContratos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvContratos).BeginInit();
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
            lblTitulo.Text = "Contratos de Honorários";
            // 
            // lblProcesso
            // 
            lblProcesso.AutoSize = true;
            lblProcesso.Location = new Point(25, 75);
            lblProcesso.Name = "lblProcesso";
            lblProcesso.Size = new Size(60, 15);
            lblProcesso.TabIndex = 1;
            lblProcesso.Text = "Processo:";
            // 
            // cmbProcesso
            // 
            cmbProcesso.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProcesso.FormattingEnabled = true;
            cmbProcesso.Location = new Point(170, 72);
            cmbProcesso.Name = "cmbProcesso";
            cmbProcesso.Size = new Size(560, 23);
            cmbProcesso.TabIndex = 2;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(25, 115);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(60, 15);
            lblTipo.TabIndex = 3;
            lblTipo.Text = "Tipo:";
            // 
            // cmbTipo
            // 
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Location = new Point(170, 112);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(200, 23);
            cmbTipo.TabIndex = 4;
            cmbTipo.SelectedIndexChanged += cmbTipo_SelectedIndexChanged;
            // 
            // lblValor
            // 
            lblValor.AutoSize = true;
            lblValor.Location = new Point(25, 155);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(60, 15);
            lblValor.TabIndex = 5;
            lblValor.Text = "Valor de referência:";
            // 
            // txtValor
            // 
            txtValor.Location = new Point(170, 152);
            txtValor.MaxLength = 18;
            txtValor.Name = "txtValor";
            txtValor.PlaceholderText = "0,00";
            txtValor.Size = new Size(200, 23);
            txtValor.TabIndex = 6;
            // 
            // lblPercentual
            // 
            lblPercentual.AutoSize = true;
            lblPercentual.Location = new Point(25, 195);
            lblPercentual.Name = "lblPercentual";
            lblPercentual.Size = new Size(60, 15);
            lblPercentual.TabIndex = 7;
            lblPercentual.Text = "% de êxito:";
            // 
            // txtPercentual
            // 
            txtPercentual.Location = new Point(170, 192);
            txtPercentual.MaxLength = 6;
            txtPercentual.Name = "txtPercentual";
            txtPercentual.PlaceholderText = "20 a 30";
            txtPercentual.Size = new Size(100, 23);
            txtPercentual.TabIndex = 8;
            // 
            // lblFaixa
            // 
            lblFaixa.AutoSize = true;
            lblFaixa.Location = new Point(280, 196);
            lblFaixa.Name = "lblFaixa";
            lblFaixa.Size = new Size(300, 15);
            lblFaixa.TabIndex = 9;
            lblFaixa.Text = "Somente para contrato de êxito (entre 20 e 30).";
            // 
            // lblAssinatura
            // 
            lblAssinatura.AutoSize = true;
            lblAssinatura.Location = new Point(25, 235);
            lblAssinatura.Name = "lblAssinatura";
            lblAssinatura.Size = new Size(60, 15);
            lblAssinatura.TabIndex = 10;
            lblAssinatura.Text = "Data de assinatura:";
            // 
            // dtpAssinatura
            // 
            dtpAssinatura.CustomFormat = "dd/MM/yyyy";
            dtpAssinatura.Format = DateTimePickerFormat.Custom;
            dtpAssinatura.Location = new Point(170, 232);
            dtpAssinatura.Name = "dtpAssinatura";
            dtpAssinatura.Size = new Size(200, 23);
            dtpAssinatura.TabIndex = 11;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(25, 275);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(60, 15);
            lblStatus.TabIndex = 12;
            lblStatus.Text = "Status:";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(170, 272);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(200, 23);
            cmbStatus.TabIndex = 13;
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(25, 320);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(130, 40);
            btnNovo.TabIndex = 14;
            btnNovo.Text = "Novo";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(170, 320);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(130, 40);
            btnSalvar.TabIndex = 15;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnAlterar
            // 
            btnAlterar.Location = new Point(315, 320);
            btnAlterar.Name = "btnAlterar";
            btnAlterar.Size = new Size(130, 40);
            btnAlterar.TabIndex = 16;
            btnAlterar.Text = "Alterar";
            btnAlterar.UseVisualStyleBackColor = true;
            btnAlterar.Click += btnAlterar_Click;
            // 
            // lblPesquisar
            // 
            lblPesquisar.AutoSize = true;
            lblPesquisar.Location = new Point(25, 388);
            lblPesquisar.Name = "lblPesquisar";
            lblPesquisar.Size = new Size(60, 15);
            lblPesquisar.TabIndex = 17;
            lblPesquisar.Text = "Pesquisar:";
            // 
            // txtPesquisar
            // 
            txtPesquisar.Location = new Point(170, 385);
            txtPesquisar.Name = "txtPesquisar";
            txtPesquisar.PlaceholderText = "cliente, processo, tipo ou status";
            txtPesquisar.Size = new Size(300, 23);
            txtPesquisar.TabIndex = 18;
            txtPesquisar.TextChanged += txtPesquisar_TextChanged;
            // 
            // dgvContratos
            // 
            dgvContratos.AllowUserToAddRows = false;
            dgvContratos.AllowUserToDeleteRows = false;
            dgvContratos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvContratos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvContratos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvContratos.Location = new Point(25, 425);
            dgvContratos.MultiSelect = false;
            dgvContratos.Name = "dgvContratos";
            dgvContratos.ReadOnly = true;
            dgvContratos.RowHeadersWidth = 51;
            dgvContratos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvContratos.Size = new Size(750, 290);
            dgvContratos.TabIndex = 19;
            dgvContratos.CellClick += dgvContratos_CellClick;
            // 
            // FrmHonorarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 740);
            Controls.Add(dgvContratos);
            Controls.Add(txtPesquisar);
            Controls.Add(lblPesquisar);
            Controls.Add(btnAlterar);
            Controls.Add(btnSalvar);
            Controls.Add(btnNovo);
            Controls.Add(cmbStatus);
            Controls.Add(lblStatus);
            Controls.Add(dtpAssinatura);
            Controls.Add(lblAssinatura);
            Controls.Add(lblFaixa);
            Controls.Add(txtPercentual);
            Controls.Add(lblPercentual);
            Controls.Add(txtValor);
            Controls.Add(lblValor);
            Controls.Add(cmbTipo);
            Controls.Add(lblTipo);
            Controls.Add(cmbProcesso);
            Controls.Add(lblProcesso);
            Controls.Add(lblTitulo);
            Name = "FrmHonorarios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Contratos de Honorários";
            Load += FrmHonorarios_Load;
            ((System.ComponentModel.ISupportInitialize)dgvContratos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblProcesso;
        private ComboBox cmbProcesso;
        private Label lblTipo;
        private ComboBox cmbTipo;
        private Label lblValor;
        private TextBox txtValor;
        private Label lblPercentual;
        private TextBox txtPercentual;
        private Label lblFaixa;
        private Label lblAssinatura;
        private DateTimePicker dtpAssinatura;
        private Label lblStatus;
        private ComboBox cmbStatus;
        private Button btnNovo;
        private Button btnSalvar;
        private Button btnAlterar;
        private Label lblPesquisar;
        private TextBox txtPesquisar;
        private DataGridView dgvContratos;
    }
}
