namespace ControleLigacoes.cadastros
{
    partial class SenhaUsuarioExistente
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
            this.BtnLimpar = new System.Windows.Forms.Button();
            this.BtnConfirmar = new System.Windows.Forms.Button();
            this.SenAtual = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SenNova = new System.Windows.Forms.TextBox();
            this.ConfSenha = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnLimpar
            // 
            this.BtnLimpar.Location = new System.Drawing.Point(12, 179);
            this.BtnLimpar.Name = "BtnLimpar";
            this.BtnLimpar.Size = new System.Drawing.Size(67, 24);
            this.BtnLimpar.TabIndex = 0;
            this.BtnLimpar.Text = "Limpar";
            this.BtnLimpar.UseVisualStyleBackColor = true;
            // 
            // BtnConfirmar
            // 
            this.BtnConfirmar.Location = new System.Drawing.Point(110, 179);
            this.BtnConfirmar.Name = "BtnConfirmar";
            this.BtnConfirmar.Size = new System.Drawing.Size(71, 24);
            this.BtnConfirmar.TabIndex = 1;
            this.BtnConfirmar.Text = "Confirmar";
            this.BtnConfirmar.UseVisualStyleBackColor = true;
            this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmar_Click);
            // 
            // SenAtual
            // 
            this.SenAtual.Location = new System.Drawing.Point(96, 52);
            this.SenAtual.Name = "SenAtual";
            this.SenAtual.Size = new System.Drawing.Size(85, 20);
            this.SenAtual.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Senha atual:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Senha nova:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Confirmar senha:";
            // 
            // SenNova
            // 
            this.SenNova.Location = new System.Drawing.Point(96, 91);
            this.SenNova.Name = "SenNova";
            this.SenNova.Size = new System.Drawing.Size(88, 20);
            this.SenNova.TabIndex = 6;
            // 
            // ConfSenha
            // 
            this.ConfSenha.Location = new System.Drawing.Point(96, 130);
            this.ConfSenha.Name = "ConfSenha";
            this.ConfSenha.Size = new System.Drawing.Size(88, 20);
            this.ConfSenha.TabIndex = 7;
            // 
            // SenhaUsuarioExistente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 228);
            this.Controls.Add(this.ConfSenha);
            this.Controls.Add(this.SenNova);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SenAtual);
            this.Controls.Add(this.BtnConfirmar);
            this.Controls.Add(this.BtnLimpar);
            this.Name = "SenhaUsuarioExistente";
            this.Text = "SenhaUsuarioExistente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnLimpar;
        private System.Windows.Forms.Button BtnConfirmar;
        public System.Windows.Forms.TextBox SenAtual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox SenNova;
        public System.Windows.Forms.TextBox ConfSenha;
    }
}