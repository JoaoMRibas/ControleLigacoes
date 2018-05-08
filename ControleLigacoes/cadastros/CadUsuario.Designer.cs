namespace ControleLigacoes.cadastros
{
    partial class CadUsuario
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
            this.Codigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Nome = new System.Windows.Forms.TextBox();
            this.Login = new System.Windows.Forms.TextBox();
            this.Senha = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Tipo = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Codigo
            // 
            this.Codigo.Location = new System.Drawing.Point(49, 23);
            this.Codigo.Name = "Codigo";
            this.Codigo.Size = new System.Drawing.Size(100, 20);
            this.Codigo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Código:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-1, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Login:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-1, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Senha:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Tipo:";
            // 
            // Nome
            // 
            this.Nome.Location = new System.Drawing.Point(49, 60);
            this.Nome.Name = "Nome";
            this.Nome.Size = new System.Drawing.Size(100, 20);
            this.Nome.TabIndex = 6;
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(49, 93);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(100, 20);
            this.Login.TabIndex = 6;
            // 
            // Senha
            // 
            this.Senha.Location = new System.Drawing.Point(49, 133);
            this.Senha.Name = "Senha";
            this.Senha.Size = new System.Drawing.Size(100, 20);
            this.Senha.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 22);
            this.button1.TabIndex = 7;
            this.button1.Text = "Limpar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(88, 226);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 22);
            this.button2.TabIndex = 8;
            this.button2.Text = "Salvar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Tipo
            // 
            this.Tipo.FormattingEnabled = true;
            this.Tipo.Location = new System.Drawing.Point(46, 170);
            this.Tipo.Name = "Tipo";
            this.Tipo.Size = new System.Drawing.Size(103, 21);
            this.Tipo.TabIndex = 9;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(5, 253);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(77, 35);
            this.button3.TabIndex = 10;
            this.button3.Text = "Visualizar Registros";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(88, 254);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(84, 34);
            this.button5.TabIndex = 12;
            this.button5.Text = "Apagar Registro";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // CadUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(180, 302);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Tipo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Senha);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.Nome);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Codigo);
            this.Name = "CadUsuario";
            this.Text = "CadUsuario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Codigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Nome;
        private System.Windows.Forms.TextBox Login;
        private System.Windows.Forms.TextBox Senha;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox Tipo;
        private System.Windows.Forms.ComboBox OpcaoStatus;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
    }
}