namespace ERPAdvocacia
{
    partial class FrmPrazos
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
            lblControlePrazos = new Label();
            lblProcessos = new Label();
            cmbProcesso = new ComboBox();
            lblResponsável = new Label();
            cmbResponsavel = new ComboBox();
            lblTitulo = new Label();
            txtTitulo = new TextBox();
            lblDescricao = new Label();
            txtDescricao = new TextBox();
            lblVencimento = new Label();
            dtpVencimento = new DateTimePicker();
            lblStatus = new Label();
            txtStatus = new TextBox();
            btnNovo = new Button();
            btnSalvar = new Button();
            btnAlterar = new Button();
            btnCumprir = new Button();
            lblPesquisar = new Label();
            txtPesquisar = new TextBox();
            dgvPrazos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvPrazos).BeginInit();
            SuspendLayout();
            // 
            // lblControlePrazos
            // 
            lblControlePrazos.AutoSize = true;
            lblControlePrazos.Font = new Font("Segoe UI", 16F);
            lblControlePrazos.Location = new Point(33, 9);
            lblControlePrazos.Name = "lblControlePrazos";
            lblControlePrazos.Size = new Size(241, 37);
            lblControlePrazos.TabIndex = 0;
            lblControlePrazos.Text = "Controle de Prazos";
            // 
            // lblProcessos
            // 
            lblProcessos.AutoSize = true;
            lblProcessos.Font = new Font("Segoe UI", 12F);
            lblProcessos.Location = new Point(33, 53);
            lblProcessos.Name = "lblProcessos";
            lblProcessos.Size = new Size(101, 28);
            lblProcessos.TabIndex = 1;
            lblProcessos.Text = "Processos:";
            // 
            // cmbProcesso
            // 
            cmbProcesso.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProcesso.FormattingEnabled = true;
            cmbProcesso.Location = new Point(162, 53);
            cmbProcesso.Name = "cmbProcesso";
            cmbProcesso.Size = new Size(507, 28);
            cmbProcesso.TabIndex = 2;
            // 
            // lblResponsável
            // 
            lblResponsável.AutoSize = true;
            lblResponsável.Font = new Font("Segoe UI", 12F);
            lblResponsável.Location = new Point(33, 106);
            lblResponsável.Name = "lblResponsável";
            lblResponsável.Size = new Size(123, 28);
            lblResponsável.TabIndex = 3;
            lblResponsável.Text = "Responsável:";
            // 
            // cmbResponsavel
            // 
            cmbResponsavel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbResponsavel.FormattingEnabled = true;
            cmbResponsavel.Location = new Point(162, 106);
            cmbResponsavel.Name = "cmbResponsavel";
            cmbResponsavel.Size = new Size(507, 28);
            cmbResponsavel.TabIndex = 4;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 12F);
            lblTitulo.Location = new Point(33, 171);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(66, 28);
            lblTitulo.TabIndex = 5;
            lblTitulo.Text = "Título:";
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(162, 171);
            txtTitulo.MaxLength = 150;
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(507, 27);
            txtTitulo.TabIndex = 6;
            // 
            // lblDescricao
            // 
            lblDescricao.AutoSize = true;
            lblDescricao.Font = new Font("Segoe UI", 12F);
            lblDescricao.Location = new Point(33, 211);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(100, 28);
            lblDescricao.TabIndex = 7;
            lblDescricao.Text = "Descrição:";
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(33, 242);
            txtDescricao.Multiline = true;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(636, 47);
            txtDescricao.TabIndex = 8;
            // 
            // lblVencimento
            // 
            lblVencimento.AutoSize = true;
            lblVencimento.Font = new Font("Segoe UI", 12F);
            lblVencimento.Location = new Point(33, 309);
            lblVencimento.Name = "lblVencimento";
            lblVencimento.Size = new Size(192, 28);
            lblVencimento.TabIndex = 9;
            lblVencimento.Text = "Data de Vencimento:";
            // 
            // dtpVencimento
            // 
            dtpVencimento.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpVencimento.Format = DateTimePickerFormat.Custom;
            dtpVencimento.Location = new Point(235, 311);
            dtpVencimento.Name = "dtpVencimento";
            dtpVencimento.Size = new Size(202, 27);
            dtpVencimento.TabIndex = 10;
            dtpVencimento.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 12F);
            lblStatus.Location = new Point(39, 372);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(69, 28);
            lblStatus.TabIndex = 11;
            lblStatus.Text = "Status:";
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(235, 376);
            txtStatus.Name = "txtStatus";
            txtStatus.ReadOnly = true;
            txtStatus.Size = new Size(202, 27);
            txtStatus.TabIndex = 12;
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(43, 415);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(133, 44);
            btnNovo.TabIndex = 13;
            btnNovo.Text = "Novo";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(216, 415);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(127, 44);
            btnSalvar.TabIndex = 14;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnAlterar
            // 
            btnAlterar.Location = new Point(382, 415);
            btnAlterar.Name = "btnAlterar";
            btnAlterar.Size = new Size(115, 44);
            btnAlterar.TabIndex = 15;
            btnAlterar.Text = "Alterar";
            btnAlterar.UseVisualStyleBackColor = true;
            btnAlterar.Click += btnAlterar_Click;
            // 
            // btnCumprir
            // 
            btnCumprir.Location = new Point(539, 415);
            btnCumprir.Name = "btnCumprir";
            btnCumprir.Size = new Size(130, 44);
            btnCumprir.TabIndex = 16;
            btnCumprir.Text = "Cumprir Prazo";
            btnCumprir.UseVisualStyleBackColor = true;
            btnCumprir.Click += btnCumprir_Click;
            // 
            // lblPesquisar
            // 
            lblPesquisar.AutoSize = true;
            lblPesquisar.Font = new Font("Segoe UI", 12F);
            lblPesquisar.Location = new Point(46, 490);
            lblPesquisar.Name = "lblPesquisar";
            lblPesquisar.Size = new Size(97, 28);
            lblPesquisar.TabIndex = 17;
            lblPesquisar.Text = "Pesquisar:";
            // 
            // txtPesquisar
            // 
            txtPesquisar.Location = new Point(174, 495);
            txtPesquisar.Name = "txtPesquisar";
            txtPesquisar.Size = new Size(323, 27);
            txtPesquisar.TabIndex = 18;
            // 
            // dgvPrazos
            // 
            dgvPrazos.AllowUserToAddRows = false;
            dgvPrazos.AllowUserToDeleteRows = false;
            dgvPrazos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPrazos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPrazos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrazos.Location = new Point(46, 543);
            dgvPrazos.MultiSelect = false;
            dgvPrazos.Name = "dgvPrazos";
            dgvPrazos.ReadOnly = true;
            dgvPrazos.RowHeadersWidth = 51;
            dgvPrazos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrazos.Size = new Size(623, 198);
            dgvPrazos.TabIndex = 19;
            dgvPrazos.CellClick += dgvPrazos_CellClick;
            // 
            // FrmPrazos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(719, 743);
            Controls.Add(dgvPrazos);
            Controls.Add(txtPesquisar);
            Controls.Add(lblPesquisar);
            Controls.Add(btnCumprir);
            Controls.Add(btnAlterar);
            Controls.Add(btnSalvar);
            Controls.Add(btnNovo);
            Controls.Add(txtStatus);
            Controls.Add(lblStatus);
            Controls.Add(dtpVencimento);
            Controls.Add(lblVencimento);
            Controls.Add(txtDescricao);
            Controls.Add(lblDescricao);
            Controls.Add(txtTitulo);
            Controls.Add(lblTitulo);
            Controls.Add(cmbResponsavel);
            Controls.Add(lblResponsável);
            Controls.Add(cmbProcesso);
            Controls.Add(lblProcessos);
            Controls.Add(lblControlePrazos);
            Name = "FrmPrazos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Controle de Prazos Processuais";
            Load += FrmPrazos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPrazos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblControlePrazos;
        private Label lblProcessos;
        private ComboBox cmbProcesso;
        private Label lblResponsável;
        private ComboBox cmbResponsavel;
        private Label lblTitulo;
        private TextBox txtTitulo;
        private Label lblDescricao;
        private TextBox txtDescricao;
        private Label lblVencimento;
        private DateTimePicker dtpVencimento;
        private Label lblStatus;
        private TextBox txtStatus;
        private Button btnNovo;
        private Button btnSalvar;
        private Button btnAlterar;
        private Button btnCumprir;
        private Label lblPesquisar;
        private TextBox txtPesquisar;
        private DataGridView dgvPrazos;
    }
}