namespace ERPAdvocacia
{
    partial class FrmProcessos
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
            lblCliente = new Label();
            cmbCliente = new ComboBox();
            lblNumeroCnj = new Label();
            txtNumeroCnj = new TextBox();
            lblVara = new Label();
            lblComarca = new Label();
            txtVara = new TextBox();
            txtComarca = new TextBox();
            lblDataAbertura = new Label();
            dtpDataAbertura = new DateTimePicker();
            lblValorCausa = new Label();
            txtValorCausa = new TextBox();
            lblStatus = new Label();
            txtStatus = new TextBox();
            btnNovo = new Button();
            btnSalvar = new Button();
            btnAlterar = new Button();
            btnIniciar = new Button();
            lblPesquisar = new Label();
            txtPesquisar = new TextBox();
            dgvProcessos = new DataGridView();
            btnVincularAdvogados = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProcessos).BeginInit();
            SuspendLayout();
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Segoe UI", 15F);
            lblCliente.Location = new Point(29, 20);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(102, 35);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Cliente: ";
            // 
            // cmbCliente
            // 
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(29, 61);
            cmbCliente.Margin = new Padding(3, 4, 3, 4);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(665, 28);
            cmbCliente.TabIndex = 1;
            // 
            // lblNumeroCnj
            // 
            lblNumeroCnj.AutoSize = true;
            lblNumeroCnj.Font = new Font("Segoe UI", 14F);
            lblNumeroCnj.Location = new Point(29, 109);
            lblNumeroCnj.Name = "lblNumeroCnj";
            lblNumeroCnj.Size = new Size(156, 32);
            lblNumeroCnj.TabIndex = 2;
            lblNumeroCnj.Text = "Número CNJ:";
            // 
            // txtNumeroCnj
            // 
            txtNumeroCnj.Location = new Point(191, 116);
            txtNumeroCnj.Margin = new Padding(3, 4, 3, 4);
            txtNumeroCnj.MaxLength = 25;
            txtNumeroCnj.Name = "txtNumeroCnj";
            txtNumeroCnj.Size = new Size(502, 27);
            txtNumeroCnj.TabIndex = 3;
            // 
            // lblVara
            // 
            lblVara.AutoSize = true;
            lblVara.Font = new Font("Segoe UI", 13F);
            lblVara.Location = new Point(29, 175);
            lblVara.Name = "lblVara";
            lblVara.Size = new Size(60, 30);
            lblVara.TabIndex = 4;
            lblVara.Text = "Vara:";
            // 
            // lblComarca
            // 
            lblComarca.AutoSize = true;
            lblComarca.Font = new Font("Segoe UI", 13F);
            lblComarca.Location = new Point(317, 175);
            lblComarca.Name = "lblComarca";
            lblComarca.Size = new Size(104, 30);
            lblComarca.TabIndex = 5;
            lblComarca.Text = "Comarca:";
            // 
            // txtVara
            // 
            txtVara.Location = new Point(29, 220);
            txtVara.Margin = new Padding(3, 4, 3, 4);
            txtVara.MaxLength = 100;
            txtVara.Name = "txtVara";
            txtVara.Size = new Size(279, 27);
            txtVara.TabIndex = 6;
            // 
            // txtComarca
            // 
            txtComarca.Location = new Point(329, 220);
            txtComarca.Margin = new Padding(3, 4, 3, 4);
            txtComarca.MaxLength = 100;
            txtComarca.Name = "txtComarca";
            txtComarca.Size = new Size(364, 27);
            txtComarca.TabIndex = 7;
            // 
            // lblDataAbertura
            // 
            lblDataAbertura.AutoSize = true;
            lblDataAbertura.Font = new Font("Segoe UI", 13F);
            lblDataAbertura.Location = new Point(29, 281);
            lblDataAbertura.Name = "lblDataAbertura";
            lblDataAbertura.Size = new Size(181, 30);
            lblDataAbertura.TabIndex = 8;
            lblDataAbertura.Text = "Data de abertura:";
            // 
            // dtpDataAbertura
            // 
            dtpDataAbertura.Format = DateTimePickerFormat.Short;
            dtpDataAbertura.Location = new Point(29, 337);
            dtpDataAbertura.Margin = new Padding(3, 4, 3, 4);
            dtpDataAbertura.Name = "dtpDataAbertura";
            dtpDataAbertura.Size = new Size(222, 27);
            dtpDataAbertura.TabIndex = 9;
            // 
            // lblValorCausa
            // 
            lblValorCausa.AutoSize = true;
            lblValorCausa.Font = new Font("Segoe UI", 13F);
            lblValorCausa.Location = new Point(317, 281);
            lblValorCausa.Name = "lblValorCausa";
            lblValorCausa.Size = new Size(156, 30);
            lblValorCausa.TabIndex = 10;
            lblValorCausa.Text = "Valor da causa:";
            // 
            // txtValorCausa
            // 
            txtValorCausa.Location = new Point(320, 333);
            txtValorCausa.Margin = new Padding(3, 4, 3, 4);
            txtValorCausa.Name = "txtValorCausa";
            txtValorCausa.Size = new Size(373, 27);
            txtValorCausa.TabIndex = 11;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 13F);
            lblStatus.Location = new Point(35, 388);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(75, 30);
            lblStatus.TabIndex = 12;
            lblStatus.Text = "Status:";
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(115, 392);
            txtStatus.Margin = new Padding(3, 4, 3, 4);
            txtStatus.Name = "txtStatus";
            txtStatus.ReadOnly = true;
            txtStatus.Size = new Size(578, 27);
            txtStatus.TabIndex = 13;
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(35, 448);
            btnNovo.Margin = new Padding(3, 4, 3, 4);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(121, 45);
            btnNovo.TabIndex = 14;
            btnNovo.Text = "Novo";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(163, 451);
            btnSalvar.Margin = new Padding(3, 4, 3, 4);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(118, 45);
            btnSalvar.TabIndex = 15;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnAlterar
            // 
            btnAlterar.Enabled = false;
            btnAlterar.Location = new Point(288, 451);
            btnAlterar.Margin = new Padding(3, 4, 3, 4);
            btnAlterar.Name = "btnAlterar";
            btnAlterar.Size = new Size(113, 45);
            btnAlterar.TabIndex = 16;
            btnAlterar.Text = "Alterar";
            btnAlterar.UseVisualStyleBackColor = true;
            btnAlterar.Click += btnAlterar_Click;
            // 
            // btnIniciar
            // 
            btnIniciar.Enabled = false;
            btnIniciar.Location = new Point(584, 453);
            btnIniciar.Margin = new Padding(3, 4, 3, 4);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(153, 45);
            btnIniciar.TabIndex = 17;
            btnIniciar.Text = "Iniciar processo";
            btnIniciar.UseVisualStyleBackColor = true;
            btnIniciar.Click += btnIniciar_Click;
            // 
            // lblPesquisar
            // 
            lblPesquisar.AutoSize = true;
            lblPesquisar.Font = new Font("Segoe UI", 13F);
            lblPesquisar.Location = new Point(46, 523);
            lblPesquisar.Name = "lblPesquisar";
            lblPesquisar.Size = new Size(108, 30);
            lblPesquisar.TabIndex = 18;
            lblPesquisar.Text = "Pesquisar:";
            // 
            // txtPesquisar
            // 
            txtPesquisar.Location = new Point(177, 528);
            txtPesquisar.Margin = new Padding(3, 4, 3, 4);
            txtPesquisar.Name = "txtPesquisar";
            txtPesquisar.Size = new Size(378, 27);
            txtPesquisar.TabIndex = 19;
            // 
            // dgvProcessos
            // 
            dgvProcessos.AllowUserToAddRows = false;
            dgvProcessos.AllowUserToDeleteRows = false;
            dgvProcessos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProcessos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvProcessos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProcessos.Location = new Point(46, 584);
            dgvProcessos.Margin = new Padding(3, 4, 3, 4);
            dgvProcessos.MultiSelect = false;
            dgvProcessos.Name = "dgvProcessos";
            dgvProcessos.ReadOnly = true;
            dgvProcessos.RowHeadersWidth = 51;
            dgvProcessos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProcessos.Size = new Size(691, 287);
            dgvProcessos.TabIndex = 20;
            dgvProcessos.CellClick += dgvProcessos_CellClick;
            // 
            // btnVincularAdvogados
            // 
            btnVincularAdvogados.Enabled = false;
            btnVincularAdvogados.Location = new Point(419, 453);
            btnVincularAdvogados.Margin = new Padding(3, 4, 3, 4);
            btnVincularAdvogados.Name = "btnVincularAdvogados";
            btnVincularAdvogados.Size = new Size(152, 43);
            btnVincularAdvogados.TabIndex = 21;
            btnVincularAdvogados.Text = "Vincular Advogados";
            btnVincularAdvogados.UseVisualStyleBackColor = true;
            btnVincularAdvogados.Click += btnVincularAdvogados_Click;
            // 
            // FrmProcessos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(795, 912);
            Controls.Add(btnVincularAdvogados);
            Controls.Add(dgvProcessos);
            Controls.Add(txtPesquisar);
            Controls.Add(lblPesquisar);
            Controls.Add(btnIniciar);
            Controls.Add(btnAlterar);
            Controls.Add(btnSalvar);
            Controls.Add(btnNovo);
            Controls.Add(txtStatus);
            Controls.Add(lblStatus);
            Controls.Add(txtValorCausa);
            Controls.Add(lblValorCausa);
            Controls.Add(dtpDataAbertura);
            Controls.Add(lblDataAbertura);
            Controls.Add(txtComarca);
            Controls.Add(txtVara);
            Controls.Add(lblComarca);
            Controls.Add(lblVara);
            Controls.Add(txtNumeroCnj);
            Controls.Add(lblNumeroCnj);
            Controls.Add(cmbCliente);
            Controls.Add(lblCliente);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmProcessos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Processos";
            Load += FrmProcessos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProcessos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCliente;
        private ComboBox cmbCliente;
        private Label lblNumeroCnj;
        private TextBox txtNumeroCnj;
        private Label lblVara;
        private Label lblComarca;
        private TextBox txtVara;
        private TextBox txtComarca;
        private Label lblDataAbertura;
        private DateTimePicker dtpDataAbertura;
        private Label lblValorCausa;
        private TextBox txtValorCausa;
        private Label lblStatus;
        private TextBox txtStatus;
        private Button btnNovo;
        private Button btnSalvar;
        private Button btnAlterar;
        private Button btnIniciar;
        private Label lblPesquisar;
        private TextBox txtPesquisar;
        private DataGridView dgvProcessos;
        private Button btnVincularAdvogados;
    }
}