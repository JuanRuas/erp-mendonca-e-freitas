namespace ERPAdvocacia
{
    partial class FrmVincularAdvogado
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
            lblProcesso = new Label();
            lblNumeroProcesso = new Label();
            lblAdvogado = new Label();
            cmbAdvogado = new ComboBox();
            chkPrincipal = new CheckBox();
            btnVincular = new Button();
            btnFechar = new Button();
            dgvAdvogados = new DataGridView();
            lblTitulo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvAdvogados).BeginInit();
            SuspendLayout();
            // 
            // lblProcesso
            // 
            lblProcesso.AutoSize = true;
            lblProcesso.Font = new Font("Segoe UI", 13F);
            lblProcesso.Location = new Point(42, 51);
            lblProcesso.Name = "lblProcesso";
            lblProcesso.Size = new Size(87, 25);
            lblProcesso.TabIndex = 0;
            lblProcesso.Text = "Processo:";
            // 
            // lblNumeroProcesso
            // 
            lblNumeroProcesso.AutoSize = true;
            lblNumeroProcesso.Location = new Point(135, 57);
            lblNumeroProcesso.Name = "lblNumeroProcesso";
            lblNumeroProcesso.Size = new Size(0, 15);
            lblNumeroProcesso.TabIndex = 1;
            // 
            // lblAdvogado
            // 
            lblAdvogado.AutoSize = true;
            lblAdvogado.Font = new Font("Segoe UI", 13F);
            lblAdvogado.Location = new Point(42, 96);
            lblAdvogado.Name = "lblAdvogado";
            lblAdvogado.Size = new Size(101, 25);
            lblAdvogado.TabIndex = 2;
            lblAdvogado.Text = "Advogado:";
            // 
            // cmbAdvogado
            // 
            cmbAdvogado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAdvogado.FormattingEnabled = true;
            cmbAdvogado.Location = new Point(149, 99);
            cmbAdvogado.Name = "cmbAdvogado";
            cmbAdvogado.Size = new Size(411, 23);
            cmbAdvogado.TabIndex = 3;
            // 
            // chkPrincipal
            // 
            chkPrincipal.AutoSize = true;
            chkPrincipal.Font = new Font("Segoe UI", 13F);
            chkPrincipal.Location = new Point(42, 137);
            chkPrincipal.Name = "chkPrincipal";
            chkPrincipal.Size = new Size(201, 29);
            chkPrincipal.TabIndex = 4;
            chkPrincipal.Text = "Responsável principal";
            chkPrincipal.UseVisualStyleBackColor = true;
            // 
            // btnVincular
            // 
            btnVincular.Location = new Point(42, 185);
            btnVincular.Name = "btnVincular";
            btnVincular.Size = new Size(132, 39);
            btnVincular.TabIndex = 5;
            btnVincular.Text = "Vincular";
            btnVincular.UseVisualStyleBackColor = true;
            btnVincular.Click += btnVincular_Click;
            // 
            // btnFechar
            // 
            btnFechar.Location = new Point(481, 480);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(111, 48);
            btnFechar.TabIndex = 6;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = true;
            btnFechar.Click += btnFechar_Click;
            // 
            // dgvAdvogados
            // 
            dgvAdvogados.AllowUserToAddRows = false;
            dgvAdvogados.AllowUserToDeleteRows = false;
            dgvAdvogados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvAdvogados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAdvogados.Location = new Point(42, 230);
            dgvAdvogados.MultiSelect = false;
            dgvAdvogados.Name = "dgvAdvogados";
            dgvAdvogados.ReadOnly = true;
            dgvAdvogados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAdvogados.Size = new Size(550, 225);
            dgvAdvogados.TabIndex = 7;
            dgvAdvogados.CellContentClick += dgvAdvogados_CellContentClick;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F);
            lblTitulo.Location = new Point(181, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(213, 25);
            lblTitulo.TabIndex = 8;
            lblTitulo.Text = "Advogados do Processo";
            // 
            // FrmVincularAdvogado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(644, 540);
            Controls.Add(lblTitulo);
            Controls.Add(dgvAdvogados);
            Controls.Add(btnFechar);
            Controls.Add(btnVincular);
            Controls.Add(chkPrincipal);
            Controls.Add(cmbAdvogado);
            Controls.Add(lblAdvogado);
            Controls.Add(lblNumeroProcesso);
            Controls.Add(lblProcesso);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmVincularAdvogado";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Vincular Advogado";
            Load += FrmVincularAdvogado_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAdvogados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblProcesso;
        private Label lblNumeroProcesso;
        private Label lblAdvogado;
        private ComboBox cmbAdvogado;
        private CheckBox chkPrincipal;
        private Button btnVincular;
        private Button btnFechar;
        private DataGridView dgvAdvogados;
        private Label lblTitulo;
    }
}