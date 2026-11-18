namespace ERPAdvocacia
{
    partial class FrmMovimentacoes
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
            lblDescricao = new Label();
            txtDescricao = new TextBox();
            lblDataHora = new Label();
            txtDataHora = new TextBox();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            btnNovo = new Button();
            btnRegistrar = new Button();
            lblHistorico = new Label();
            dgvMovimentacoes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvMovimentacoes).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F);
            lblTitulo.Location = new Point(29, 24);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(355, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Movimentações do Processo";
            // 
            // lblProcesso
            // 
            lblProcesso.AutoSize = true;
            lblProcesso.Location = new Point(29, 100);
            lblProcesso.Name = "lblProcesso";
            lblProcesso.Size = new Size(70, 20);
            lblProcesso.TabIndex = 1;
            lblProcesso.Text = "Processo:";
            // 
            // cmbProcesso
            // 
            cmbProcesso.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProcesso.FormattingEnabled = true;
            cmbProcesso.Location = new Point(194, 96);
            cmbProcesso.Margin = new Padding(3, 4, 3, 4);
            cmbProcesso.Name = "cmbProcesso";
            cmbProcesso.Size = new Size(639, 28);
            cmbProcesso.TabIndex = 2;
            cmbProcesso.SelectedIndexChanged += cmbProcesso_SelectedIndexChanged;
            // 
            // lblDescricao
            // 
            lblDescricao.AutoSize = true;
            lblDescricao.Location = new Point(29, 153);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(201, 20);
            lblDescricao.TabIndex = 3;
            lblDescricao.Text = "Descrição da movimentação:";
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(29, 184);
            txtDescricao.Margin = new Padding(3, 4, 3, 4);
            txtDescricao.Multiline = true;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.PlaceholderText = "Ex.: Juntada de documentos, audiência realizada, petição protocolada...";
            txtDescricao.ScrollBars = ScrollBars.Vertical;
            txtDescricao.Size = new Size(857, 105);
            txtDescricao.TabIndex = 4;
            txtDescricao.TextChanged += txtDescricao_TextChanged;
            // 
            // lblDataHora
            // 
            lblDataHora.AutoSize = true;
            lblDataHora.Location = new Point(29, 316);
            lblDataHora.Name = "lblDataHora";
            lblDataHora.Size = new Size(80, 20);
            lblDataHora.TabIndex = 5;
            lblDataHora.Text = "Data/hora:";
            // 
            // txtDataHora
            // 
            txtDataHora.Location = new Point(194, 312);
            txtDataHora.Margin = new Padding(3, 4, 3, 4);
            txtDataHora.Name = "txtDataHora";
            txtDataHora.ReadOnly = true;
            txtDataHora.Size = new Size(194, 27);
            txtDataHora.TabIndex = 6;
            txtDataHora.TabStop = false;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(457, 316);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(111, 20);
            lblUsuario.TabIndex = 7;
            lblUsuario.Text = "Registrado por:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(571, 312);
            txtUsuario.Margin = new Padding(3, 4, 3, 4);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.ReadOnly = true;
            txtUsuario.Size = new Size(262, 27);
            txtUsuario.TabIndex = 8;
            txtUsuario.TabStop = false;
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(29, 373);
            btnNovo.Margin = new Padding(3, 4, 3, 4);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(149, 53);
            btnNovo.TabIndex = 9;
            btnNovo.Text = "Novo";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(194, 373);
            btnRegistrar.Margin = new Padding(3, 4, 3, 4);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(149, 53);
            btnRegistrar.TabIndex = 10;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // lblHistorico
            // 
            lblHistorico.AutoSize = true;
            lblHistorico.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblHistorico.Location = new Point(29, 453);
            lblHistorico.Name = "lblHistorico";
            lblHistorico.Size = new Size(76, 20);
            lblHistorico.TabIndex = 11;
            lblHistorico.Text = "Histórico:";
            // 
            // dgvMovimentacoes
            // 
            dgvMovimentacoes.AllowUserToAddRows = false;
            dgvMovimentacoes.AllowUserToDeleteRows = false;
            dgvMovimentacoes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMovimentacoes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvMovimentacoes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMovimentacoes.Location = new Point(29, 487);
            dgvMovimentacoes.Margin = new Padding(3, 4, 3, 4);
            dgvMovimentacoes.MultiSelect = false;
            dgvMovimentacoes.Name = "dgvMovimentacoes";
            dgvMovimentacoes.ReadOnly = true;
            dgvMovimentacoes.RowHeadersWidth = 51;
            dgvMovimentacoes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMovimentacoes.Size = new Size(857, 413);
            dgvMovimentacoes.TabIndex = 12;
            // 
            // FrmMovimentacoes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 933);
            Controls.Add(dgvMovimentacoes);
            Controls.Add(lblHistorico);
            Controls.Add(btnRegistrar);
            Controls.Add(btnNovo);
            Controls.Add(txtUsuario);
            Controls.Add(lblUsuario);
            Controls.Add(txtDataHora);
            Controls.Add(lblDataHora);
            Controls.Add(txtDescricao);
            Controls.Add(lblDescricao);
            Controls.Add(cmbProcesso);
            Controls.Add(lblProcesso);
            Controls.Add(lblTitulo);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmMovimentacoes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Movimentações do Processo";
            Load += FrmMovimentacoes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMovimentacoes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblProcesso;
        private ComboBox cmbProcesso;
        private Label lblDescricao;
        private TextBox txtDescricao;
        private Label lblDataHora;
        private TextBox txtDataHora;
        private Label lblUsuario;
        private TextBox txtUsuario;
        private Button btnNovo;
        private Button btnRegistrar;
        private Label lblHistorico;
        private DataGridView dgvMovimentacoes;
    }
}
