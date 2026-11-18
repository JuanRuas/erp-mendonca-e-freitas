namespace ERPAdvocacia
{
    partial class FrmUsuarios
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
            lblNome = new Label();
            txtNome = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblSenha = new Label();
            txtSenha = new TextBox();
            lblDicaSenha = new Label();
            lblPerfil = new Label();
            cmbPerfil = new ComboBox();
            lblOab = new Label();
            txtOab = new TextBox();
            lblSituacao = new Label();
            txtSituacao = new TextBox();
            btnNovo = new Button();
            btnSalvar = new Button();
            btnAlterar = new Button();
            btnAtivar = new Button();
            lblPesquisar = new Label();
            txtPesquisar = new TextBox();
            dgvUsuarios = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F);
            lblTitulo.Location = new Point(29, 24);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(269, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Cadastro de Usuários";
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(29, 100);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(53, 20);
            lblNome.TabIndex = 1;
            lblNome.Text = "Nome:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(194, 96);
            txtNome.Margin = new Padding(3, 4, 3, 4);
            txtNome.MaxLength = 150;
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(639, 27);
            txtNome.TabIndex = 2;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(29, 153);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(55, 20);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "E-mail:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(194, 149);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.MaxLength = 150;
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "nome@escritorio.com";
            txtEmail.Size = new Size(639, 27);
            txtEmail.TabIndex = 4;
            // 
            // lblSenha
            // 
            lblSenha.AutoSize = true;
            lblSenha.Location = new Point(29, 207);
            lblSenha.Name = "lblSenha";
            lblSenha.Size = new Size(52, 20);
            lblSenha.TabIndex = 5;
            lblSenha.Text = "Senha:";
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(194, 203);
            txtSenha.Margin = new Padding(3, 4, 3, 4);
            txtSenha.MaxLength = 50;
            txtSenha.Name = "txtSenha";
            txtSenha.Size = new Size(285, 27);
            txtSenha.TabIndex = 6;
            txtSenha.UseSystemPasswordChar = true;
            // 
            // lblDicaSenha
            // 
            lblDicaSenha.AutoSize = true;
            lblDicaSenha.Location = new Point(491, 208);
            lblDicaSenha.Name = "lblDicaSenha";
            lblDicaSenha.Size = new Size(372, 20);
            lblDicaSenha.TabIndex = 7;
            lblDicaSenha.Text = "Ao alterar, deixe em branco para manter a senha atual.";
            lblDicaSenha.Click += lblDicaSenha_Click;
            // 
            // lblPerfil
            // 
            lblPerfil.AutoSize = true;
            lblPerfil.Location = new Point(29, 260);
            lblPerfil.Name = "lblPerfil";
            lblPerfil.Size = new Size(45, 20);
            lblPerfil.TabIndex = 8;
            lblPerfil.Text = "Perfil:";
            // 
            // cmbPerfil
            // 
            cmbPerfil.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPerfil.FormattingEnabled = true;
            cmbPerfil.Location = new Point(194, 256);
            cmbPerfil.Margin = new Padding(3, 4, 3, 4);
            cmbPerfil.Name = "cmbPerfil";
            cmbPerfil.Size = new Size(285, 28);
            cmbPerfil.TabIndex = 9;
            cmbPerfil.SelectedIndexChanged += cmbPerfil_SelectedIndexChanged;
            // 
            // lblOab
            // 
            lblOab.AutoSize = true;
            lblOab.Location = new Point(29, 313);
            lblOab.Name = "lblOab";
            lblOab.Size = new Size(42, 20);
            lblOab.TabIndex = 10;
            lblOab.Text = "OAB:";
            // 
            // txtOab
            // 
            txtOab.Location = new Point(194, 309);
            txtOab.Margin = new Padding(3, 4, 3, 4);
            txtOab.MaxLength = 20;
            txtOab.Name = "txtOab";
            txtOab.PlaceholderText = "MG123456 (só para advogado)";
            txtOab.Size = new Size(285, 27);
            txtOab.TabIndex = 11;
            // 
            // lblSituacao
            // 
            lblSituacao.AutoSize = true;
            lblSituacao.Location = new Point(29, 367);
            lblSituacao.Name = "lblSituacao";
            lblSituacao.Size = new Size(69, 20);
            lblSituacao.TabIndex = 12;
            lblSituacao.Text = "Situação:";
            // 
            // txtSituacao
            // 
            txtSituacao.Location = new Point(194, 363);
            txtSituacao.Margin = new Padding(3, 4, 3, 4);
            txtSituacao.Name = "txtSituacao";
            txtSituacao.ReadOnly = true;
            txtSituacao.Size = new Size(285, 27);
            txtSituacao.TabIndex = 13;
            txtSituacao.TabStop = false;
            txtSituacao.TextChanged += txtSituacao_TextChanged;
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(29, 427);
            btnNovo.Margin = new Padding(3, 4, 3, 4);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(149, 53);
            btnNovo.TabIndex = 14;
            btnNovo.Text = "Novo";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(194, 427);
            btnSalvar.Margin = new Padding(3, 4, 3, 4);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(149, 53);
            btnSalvar.TabIndex = 15;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnAlterar
            // 
            btnAlterar.Location = new Point(360, 427);
            btnAlterar.Margin = new Padding(3, 4, 3, 4);
            btnAlterar.Name = "btnAlterar";
            btnAlterar.Size = new Size(149, 53);
            btnAlterar.TabIndex = 16;
            btnAlterar.Text = "Alterar";
            btnAlterar.UseVisualStyleBackColor = true;
            btnAlterar.Click += btnAlterar_Click;
            // 
            // btnAtivar
            // 
            btnAtivar.Location = new Point(526, 427);
            btnAtivar.Margin = new Padding(3, 4, 3, 4);
            btnAtivar.Name = "btnAtivar";
            btnAtivar.Size = new Size(149, 53);
            btnAtivar.TabIndex = 17;
            btnAtivar.Text = "Desativar";
            btnAtivar.UseVisualStyleBackColor = true;
            btnAtivar.Click += btnAtivar_Click;
            // 
            // lblPesquisar
            // 
            lblPesquisar.AutoSize = true;
            lblPesquisar.Location = new Point(29, 517);
            lblPesquisar.Name = "lblPesquisar";
            lblPesquisar.Size = new Size(73, 20);
            lblPesquisar.TabIndex = 18;
            lblPesquisar.Text = "Pesquisar:";
            // 
            // txtPesquisar
            // 
            txtPesquisar.Location = new Point(194, 513);
            txtPesquisar.Margin = new Padding(3, 4, 3, 4);
            txtPesquisar.Name = "txtPesquisar";
            txtPesquisar.PlaceholderText = "nome, e-mail ou perfil";
            txtPesquisar.Size = new Size(342, 27);
            txtPesquisar.TabIndex = 19;
            txtPesquisar.TextChanged += txtPesquisar_TextChanged;
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(29, 567);
            dgvUsuarios.Margin = new Padding(3, 4, 3, 4);
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersWidth = 51;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new Size(857, 360);
            dgvUsuarios.TabIndex = 20;
            dgvUsuarios.CellClick += dgvUsuarios_CellClick;
            // 
            // FrmUsuarios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 960);
            Controls.Add(dgvUsuarios);
            Controls.Add(txtPesquisar);
            Controls.Add(lblPesquisar);
            Controls.Add(btnAtivar);
            Controls.Add(btnAlterar);
            Controls.Add(btnSalvar);
            Controls.Add(btnNovo);
            Controls.Add(txtSituacao);
            Controls.Add(lblSituacao);
            Controls.Add(txtOab);
            Controls.Add(lblOab);
            Controls.Add(cmbPerfil);
            Controls.Add(lblPerfil);
            Controls.Add(lblDicaSenha);
            Controls.Add(txtSenha);
            Controls.Add(lblSenha);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtNome);
            Controls.Add(lblNome);
            Controls.Add(lblTitulo);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmUsuarios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Usuários";
            Load += FrmUsuarios_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblNome;
        private TextBox txtNome;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblSenha;
        private TextBox txtSenha;
        private Label lblDicaSenha;
        private Label lblPerfil;
        private ComboBox cmbPerfil;
        private Label lblOab;
        private TextBox txtOab;
        private Label lblSituacao;
        private TextBox txtSituacao;
        private Button btnNovo;
        private Button btnSalvar;
        private Button btnAlterar;
        private Button btnAtivar;
        private Label lblPesquisar;
        private TextBox txtPesquisar;
        private DataGridView dgvUsuarios;
    }
}
