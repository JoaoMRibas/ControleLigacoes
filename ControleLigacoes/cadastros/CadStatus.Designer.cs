﻿namespace ControleLigacoes.cadastros
{
    partial class CadStatus
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
            this.OpcaoStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnSalvar = new System.Windows.Forms.Button();
            this.BtUsuario = new System.Windows.Forms.Button();
            this.Usuario = new System.Windows.Forms.TextBox();
            this.Ligacao = new System.Windows.Forms.TextBox();
            this.BtnLigacao = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OpcaoStatus
            // 
            this.OpcaoStatus.FormattingEnabled = true;
            this.OpcaoStatus.Location = new System.Drawing.Point(12, 60);
            this.OpcaoStatus.Name = "OpcaoStatus";
            this.OpcaoStatus.Size = new System.Drawing.Size(121, 21);
            this.OpcaoStatus.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Selecione uma opção de status:";
            // 
            // BtnSalvar
            // 
            this.BtnSalvar.Location = new System.Drawing.Point(12, 139);
            this.BtnSalvar.Name = "BtnSalvar";
            this.BtnSalvar.Size = new System.Drawing.Size(63, 24);
            this.BtnSalvar.TabIndex = 2;
            this.BtnSalvar.Text = "Salvar";
            this.BtnSalvar.UseVisualStyleBackColor = true;
            this.BtnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
            // 
            // BtUsuario
            // 
            this.BtUsuario.Location = new System.Drawing.Point(132, 87);
            this.BtUsuario.Name = "BtUsuario";
            this.BtUsuario.Size = new System.Drawing.Size(30, 21);
            this.BtUsuario.TabIndex = 3;
            this.BtUsuario.Text = "PU";
            this.BtUsuario.UseVisualStyleBackColor = true;
            this.BtUsuario.Click += new System.EventHandler(this.BtUsuario_Click);
            // 
            // Usuario
            // 
            this.Usuario.Location = new System.Drawing.Point(12, 87);
            this.Usuario.Name = "Usuario";
            this.Usuario.Size = new System.Drawing.Size(121, 20);
            this.Usuario.TabIndex = 4;
            // 
            // Ligacao
            // 
            this.Ligacao.Location = new System.Drawing.Point(12, 113);
            this.Ligacao.Name = "Ligacao";
            this.Ligacao.Size = new System.Drawing.Size(121, 20);
            this.Ligacao.TabIndex = 5;
            // 
            // BtnLigacao
            // 
            this.BtnLigacao.Location = new System.Drawing.Point(132, 113);
            this.BtnLigacao.Name = "BtnLigacao";
            this.BtnLigacao.Size = new System.Drawing.Size(30, 20);
            this.BtnLigacao.TabIndex = 6;
            this.BtnLigacao.Text = "PL";
            this.BtnLigacao.UseVisualStyleBackColor = true;
            this.BtnLigacao.Click += new System.EventHandler(this.BtnLigacao_Click);
            // 
            // CadStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 188);
            this.Controls.Add(this.BtnLigacao);
            this.Controls.Add(this.Ligacao);
            this.Controls.Add(this.Usuario);
            this.Controls.Add(this.BtUsuario);
            this.Controls.Add(this.BtnSalvar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OpcaoStatus);
            this.Name = "CadStatus";
            this.Text = "CadStatus";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox OpcaoStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnSalvar;
        private System.Windows.Forms.Button BtUsuario;
        private System.Windows.Forms.TextBox Usuario;
        private System.Windows.Forms.TextBox Ligacao;
        private System.Windows.Forms.Button BtnLigacao;
    }
}