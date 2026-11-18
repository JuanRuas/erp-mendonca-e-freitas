namespace ERPAdvocacia
{
    partial class FrmPagamentos
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
            lblContrato = new Label();
            cmbContrato = new ComboBox();
            lblTotalTitulo = new Label();
            lblTotal = new Label();
            lblValor = new Label();
            txtValor = new TextBox();
            lblData = new Label();
            dtpData = new DateTimePicker();
            lblForma = new Label();
            cmbForma = new ComboBox();
            lblObservacao = new Label();
            txtObservacao = new TextBox();
            btnNovo = new Button();
            btnRegistrar = new Button();
            lblLista = new Label();
            dgvPagamentos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvPagamentos).BeginInit();
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
            lblTitulo.Text = "Pagamentos de Honorários";
            // 
            // lblContrato
            // 
            lblContrato.AutoSize = true;
            lblContrato.Location = new Point(25, 75);
            lblContrato.Name = "lblContrato";
            lblContrato.Size = new Size(60, 15);
            lblContrato.TabIndex = 1;
            lblContrato.Text = "Contrato:";
            // 
            // cmbContrato
            // 
            cmbContrato.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbContrato.FormattingEnabled = true;
            cmbContrato.Location = new Point(170, 72);
            cmbContrato.Name = "cmbContrato";
            cmbContrato.Size = new Size(560, 23);
            cmbContrato.TabIndex = 2;
            cmbContrato.SelectedIndexChanged += cmbContrato_SelectedIndexChanged;
            // 
            // lblTotalTitulo
            // 
            lblTotalTitulo.AutoSize = true;
            lblTotalTitulo.Location = new Point(25, 117);
            lblTotalTitulo.Name = "lblTotalTitulo";
            lblTotalTitulo.Size = new Size(60, 15);
            lblTotalTitulo.TabIndex = 3;
            lblTotalTitulo.Text = "Total recebido:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotal.Location = new Point(170, 113);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(200, 23);
            lblTotal.TabIndex = 4;
            lblTotal.Text = "-";
            // 
            // lblValor
            // 
            lblValor.AutoSize = true;
            lblValor.Location = new Point(25, 155);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(60, 15);
            lblValor.TabIndex = 5;
            lblValor.Text = "Valor:";
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
            // lblData
            // 
            lblData.AutoSize = true;
            lblData.Location = new Point(25, 195);
            lblData.Name = "lblData";
            lblData.Size = new Size(60, 15);
            lblData.TabIndex = 7;
            lblData.Text = "Data do pagamento:";
            // 
            // dtpData
            // 
            dtpData.CustomFormat = "dd/MM/yyyy";
            dtpData.Format = DateTimePickerFormat.Custom;
            dtpData.Location = new Point(170, 192);
            dtpData.Name = "dtpData";
            dtpData.Size = new Size(200, 23);
            dtpData.TabIndex = 8;
            // 
            // lblForma
            // 
            lblForma.AutoSize = true;
            lblForma.Location = new Point(25, 235);
            lblForma.Name = "lblForma";
            lblForma.Size = new Size(60, 15);
            lblForma.TabIndex = 9;
            lblForma.Text = "Forma:";
            // 
            // cmbForma
            // 
            cmbForma.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbForma.FormattingEnabled = true;
            cmbForma.Location = new Point(170, 232);
            cmbForma.Name = "cmbForma";
            cmbForma.Size = new Size(200, 23);
            cmbForma.TabIndex = 10;
            // 
            // lblObservacao
            // 
            lblObservacao.AutoSize = true;
            lblObservacao.Location = new Point(25, 275);
            lblObservacao.Name = "lblObservacao";
            lblObservacao.Size = new Size(60, 15);
            lblObservacao.TabIndex = 11;
            lblObservacao.Text = "Observação:";
            // 
            // txtObservacao
            // 
            txtObservacao.Location = new Point(170, 272);
            txtObservacao.MaxLength = 255;
            txtObservacao.Name = "txtObservacao";
            txtObservacao.Size = new Size(560, 23);
            txtObservacao.TabIndex = 12;
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(25, 320);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(130, 40);
            btnNovo.TabIndex = 13;
            btnNovo.Text = "Novo";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(170, 320);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(130, 40);
            btnRegistrar.TabIndex = 14;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // lblLista
            // 
            lblLista.AutoSize = true;
            lblLista.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLista.Location = new Point(25, 378);
            lblLista.Name = "lblLista";
            lblLista.Size = new Size(60, 15);
            lblLista.TabIndex = 15;
            lblLista.Text = "Pagamentos:";
            // 
            // dgvPagamentos
            // 
            dgvPagamentos.AllowUserToAddRows = false;
            dgvPagamentos.AllowUserToDeleteRows = false;
            dgvPagamentos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPagamentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPagamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPagamentos.Location = new Point(25, 403);
            dgvPagamentos.MultiSelect = false;
            dgvPagamentos.Name = "dgvPagamentos";
            dgvPagamentos.ReadOnly = true;
            dgvPagamentos.RowHeadersWidth = 51;
            dgvPagamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPagamentos.Size = new Size(750, 312);
            dgvPagamentos.TabIndex = 16;
            // 
            // FrmPagamentos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 740);
            Controls.Add(dgvPagamentos);
            Controls.Add(lblLista);
            Controls.Add(btnRegistrar);
            Controls.Add(btnNovo);
            Controls.Add(txtObservacao);
            Controls.Add(lblObservacao);
            Controls.Add(cmbForma);
            Controls.Add(lblForma);
            Controls.Add(dtpData);
            Controls.Add(lblData);
            Controls.Add(txtValor);
            Controls.Add(lblValor);
            Controls.Add(lblTotal);
            Controls.Add(lblTotalTitulo);
            Controls.Add(cmbContrato);
            Controls.Add(lblContrato);
            Controls.Add(lblTitulo);
            Name = "FrmPagamentos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pagamentos de Honorários";
            Load += FrmPagamentos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPagamentos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblContrato;
        private ComboBox cmbContrato;
        private Label lblTotalTitulo;
        private Label lblTotal;
        private Label lblValor;
        private TextBox txtValor;
        private Label lblData;
        private DateTimePicker dtpData;
        private Label lblForma;
        private ComboBox cmbForma;
        private Label lblObservacao;
        private TextBox txtObservacao;
        private Button btnNovo;
        private Button btnRegistrar;
        private Label lblLista;
        private DataGridView dgvPagamentos;
    }
}
