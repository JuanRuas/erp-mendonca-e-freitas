namespace ERPAdvocacia
{
    partial class FrmClientes
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            lblTitulo = new Label();
            lblNome = new Label();
            txtNomeRazaoSocial = new TextBox();
            label1 = new Label();
            txtCpfCnpj = new TextBox();
            lblTelefone = new Label();
            txtTelefone = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblEndereco = new Label();
            txtEndereco = new TextBox();
            btnNovo = new Button();
            btnSalvar = new Button();
            btnAlterar = new Button();
            btnDesativar = new Button();
            lblPesquisar = new Label();
            txtPesquisar = new TextBox();
            dgvClientes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F);
            lblTitulo.Location = new Point(25, 24);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(261, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Cadastro de Clientes";
            lblTitulo.Click += label1_Click;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(33, 108);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(152, 20);
            lblNome.TabIndex = 1;
            lblNome.Text = "Nome / Razão Social:";
            // 
            // txtNomeRazaoSocial
            // 
            txtNomeRazaoSocial.Location = new Point(191, 105);
            txtNomeRazaoSocial.Margin = new Padding(3, 4, 3, 4);
            txtNomeRazaoSocial.MaxLength = 150;
            txtNomeRazaoSocial.Name = "txtNomeRazaoSocial";
            txtNomeRazaoSocial.Size = new Size(507, 27);
            txtNomeRazaoSocial.TabIndex = 2;
            txtNomeRazaoSocial.TextChanged += txtNomeRazaoSocial_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 174);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 3;
            label1.Text = "CPF / CNPJ:";
            // 
            // txtCpfCnpj
            // 
            txtCpfCnpj.Location = new Point(138, 168);
            txtCpfCnpj.Margin = new Padding(3, 4, 3, 4);
            txtCpfCnpj.MaxLength = 18;
            txtCpfCnpj.Name = "txtCpfCnpj";
            txtCpfCnpj.Size = new Size(205, 27);
            txtCpfCnpj.TabIndex = 4;
            // 
            // lblTelefone
            // 
            lblTelefone.AutoSize = true;
            lblTelefone.Location = new Point(358, 170);
            lblTelefone.Name = "lblTelefone";
            lblTelefone.Size = new Size(69, 20);
            lblTelefone.TabIndex = 5;
            lblTelefone.Text = "Telefone:";
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(433, 167);
            txtTelefone.Margin = new Padding(3, 4, 3, 4);
            txtTelefone.MaxLength = 20;
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(254, 27);
            txtTelefone.TabIndex = 6;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F);
            lblEmail.Location = new Point(48, 225);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(62, 23);
            lblEmail.TabIndex = 7;
            lblEmail.Text = "E-mail:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(116, 224);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.MaxLength = 150;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(571, 27);
            txtEmail.TabIndex = 8;
            // 
            // lblEndereco
            // 
            lblEndereco.AutoSize = true;
            lblEndereco.Location = new Point(48, 292);
            lblEndereco.Name = "lblEndereco";
            lblEndereco.Size = new Size(74, 20);
            lblEndereco.TabIndex = 9;
            lblEndereco.Text = "Endereço:";
            // 
            // txtEndereco
            // 
            txtEndereco.Location = new Point(127, 281);
            txtEndereco.Margin = new Padding(3, 4, 3, 4);
            txtEndereco.MaxLength = 255;
            txtEndereco.Name = "txtEndereco";
            txtEndereco.Size = new Size(560, 27);
            txtEndereco.TabIndex = 10;
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(59, 351);
            btnNovo.Margin = new Padding(3, 4, 3, 4);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(125, 48);
            btnNovo.TabIndex = 11;
            btnNovo.Text = "Novo";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(213, 351);
            btnSalvar.Margin = new Padding(3, 4, 3, 4);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(131, 48);
            btnSalvar.TabIndex = 12;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnAlterar
            // 
            btnAlterar.Location = new Point(387, 351);
            btnAlterar.Margin = new Padding(3, 4, 3, 4);
            btnAlterar.Name = "btnAlterar";
            btnAlterar.Size = new Size(125, 48);
            btnAlterar.TabIndex = 13;
            btnAlterar.Text = "Alterar";
            btnAlterar.UseVisualStyleBackColor = true;
            btnAlterar.Click += btnAlterar_Click;
            // 
            // btnDesativar
            // 
            btnDesativar.Location = new Point(561, 351);
            btnDesativar.Margin = new Padding(3, 4, 3, 4);
            btnDesativar.Name = "btnDesativar";
            btnDesativar.Size = new Size(127, 48);
            btnDesativar.TabIndex = 14;
            btnDesativar.Text = "Desativar";
            btnDesativar.UseVisualStyleBackColor = true;
            btnDesativar.Click += btnDesativar_Click;
            // 
            // lblPesquisar
            // 
            lblPesquisar.AutoSize = true;
            lblPesquisar.Location = new Point(64, 419);
            lblPesquisar.Name = "lblPesquisar";
            lblPesquisar.Size = new Size(73, 20);
            lblPesquisar.TabIndex = 15;
            lblPesquisar.Text = "Pesquisar:";
            // 
            // txtPesquisar
            // 
            txtPesquisar.Location = new Point(166, 408);
            txtPesquisar.Margin = new Padding(3, 4, 3, 4);
            txtPesquisar.Name = "txtPesquisar";
            txtPesquisar.Size = new Size(346, 27);
            txtPesquisar.TabIndex = 16;
            txtPesquisar.TextChanged += txtPesquisar_TextChanged;
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgvClientes.DefaultCellStyle = dataGridViewCellStyle5;
            dgvClientes.Location = new Point(48, 487);
            dgvClientes.Margin = new Padding(3, 4, 3, 4);
            dgvClientes.MultiSelect = false;
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvClientes.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvClientes.RowHeadersWidth = 51;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.Size = new Size(650, 296);
            dgvClientes.TabIndex = 17;
            dgvClientes.CellClick += dgvClientes_CellClick;
            // 
            // FrmClientes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(746, 883);
            Controls.Add(dgvClientes);
            Controls.Add(txtPesquisar);
            Controls.Add(lblPesquisar);
            Controls.Add(btnDesativar);
            Controls.Add(btnAlterar);
            Controls.Add(btnSalvar);
            Controls.Add(btnNovo);
            Controls.Add(txtEndereco);
            Controls.Add(lblEndereco);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtTelefone);
            Controls.Add(lblTelefone);
            Controls.Add(txtCpfCnpj);
            Controls.Add(label1);
            Controls.Add(txtNomeRazaoSocial);
            Controls.Add(lblNome);
            Controls.Add(lblTitulo);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmClientes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmClientes";
            Load += FrmClientes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblNome;
        private TextBox txtNomeRazaoSocial;
        private Label label1;
        private TextBox txtCpfCnpj;
        private Label lblTelefone;
        private TextBox txtTelefone;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblEndereco;
        private TextBox txtEndereco;
        private Button btnNovo;
        private Button btnSalvar;
        private Button btnAlterar;
        private Button btnDesativar;
        private Label lblPesquisar;
        private TextBox txtPesquisar;
        private DataGridView dgvClientes;
    }
}