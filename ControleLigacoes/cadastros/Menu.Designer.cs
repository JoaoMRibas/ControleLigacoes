namespace ControleLigacoes.cadastros
{
    partial class Menu
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
            this.BtCadCliente = new System.Windows.Forms.Button();
            this.BtCadUsuario = new System.Windows.Forms.Button();
            this.BtCadLigacao = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtCadCliente
            // 
            this.BtCadCliente.Location = new System.Drawing.Point(124, 42);
            this.BtCadCliente.Name = "BtCadCliente";
            this.BtCadCliente.Size = new System.Drawing.Size(77, 37);
            this.BtCadCliente.TabIndex = 12;
            this.BtCadCliente.Text = "Cadastro de Clientes";
            this.BtCadCliente.UseVisualStyleBackColor = true;
            this.BtCadCliente.Click += new System.EventHandler(this.BtCadCliente_Click);
            // 
            // BtCadUsuario
            // 
            this.BtCadUsuario.Location = new System.Drawing.Point(12, 42);
            this.BtCadUsuario.Name = "BtCadUsuario";
            this.BtCadUsuario.Size = new System.Drawing.Size(77, 37);
            this.BtCadUsuario.TabIndex = 13;
            this.BtCadUsuario.Text = "Cadastro de Usuários";
            this.BtCadUsuario.UseVisualStyleBackColor = true;
            this.BtCadUsuario.Click += new System.EventHandler(this.BtCadUsuario_Click);
            // 
            // BtCadLigacao
            // 
            this.BtCadLigacao.Location = new System.Drawing.Point(12, 94);
            this.BtCadLigacao.Name = "BtCadLigacao";
            this.BtCadLigacao.Size = new System.Drawing.Size(77, 37);
            this.BtCadLigacao.TabIndex = 14;
            this.BtCadLigacao.Text = "Cadastro de Ligação";
            this.BtCadLigacao.UseVisualStyleBackColor = true;
            this.BtCadLigacao.Click += new System.EventHandler(this.BtCadLigacao_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 156);
            this.Controls.Add(this.BtCadLigacao);
            this.Controls.Add(this.BtCadUsuario);
            this.Controls.Add(this.BtCadCliente);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtCadCliente;
        private System.Windows.Forms.Button BtCadUsuario;
        private System.Windows.Forms.Button BtCadLigacao;
    }
}