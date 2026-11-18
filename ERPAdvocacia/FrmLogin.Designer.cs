namespace ERPAdvocacia
{
    partial class FrmLogin
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
            lblEscritorio = new Label();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblSenha = new Label();
            txtSenha = new TextBox();
            btnEntrar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F);
            lblTitulo.Location = new Point(30, 22);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(170, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "ERP Advocacia";
            // 
            // lblEscritorio
            // 
            lblEscritorio.AutoSize = true;
            lblEscritorio.Location = new Point(32, 64);
            lblEscritorio.Name = "lblEscritorio";
            lblEscritorio.Size = new Size(250, 15);
            lblEscritorio.TabIndex = 1;
            lblEscritorio.Text = "Mendonça & Freitas Advogados Associados";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(30, 105);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(60, 15);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "E-mail:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(30, 126);
            txtEmail.MaxLength = 150;
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "seu.email@escritorio.com";
            txtEmail.Size = new Size(360, 23);
            txtEmail.TabIndex = 3;
            // 
            // lblSenha
            // 
            lblSenha.AutoSize = true;
            lblSenha.Location = new Point(30, 165);
            lblSenha.Name = "lblSenha";
            lblSenha.Size = new Size(60, 15);
            lblSenha.TabIndex = 4;
            lblSenha.Text = "Senha:";
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(30, 186);
            txtSenha.MaxLength = 50;
            txtSenha.Name = "txtSenha";
            txtSenha.Size = new Size(360, 23);
            txtSenha.UseSystemPasswordChar = true;
            txtSenha.TabIndex = 5;
            // 
            // btnEntrar
            // 
            btnEntrar.Location = new Point(30, 235);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(175, 40);
            btnEntrar.TabIndex = 6;
            btnEntrar.Text = "Entrar";
            btnEntrar.UseVisualStyleBackColor = true;
            btnEntrar.Click += btnEntrar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(215, 235);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(175, 40);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AcceptButton = btnEntrar;
            CancelButton = btnCancelar;
            ClientSize = new Size(420, 300);
            Controls.Add(btnCancelar);
            Controls.Add(btnEntrar);
            Controls.Add(txtSenha);
            Controls.Add(lblSenha);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(lblEscritorio);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ERP Advocacia - Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblEscritorio;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblSenha;
        private TextBox txtSenha;
        private Button btnEntrar;
        private Button btnCancelar;
    }
}
