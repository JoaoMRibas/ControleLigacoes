namespace ControleLigacoes.cadastros
{
    partial class CadLigacao
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Codigo = new System.Windows.Forms.TextBox();
            this.DataHora = new System.Windows.Forms.TextBox();
            this.Cliente = new System.Windows.Forms.TextBox();
            this.Usuario = new System.Windows.Forms.TextBox();
            this.Observacoes = new System.Windows.Forms.TextBox();
            this.BtLimpar = new System.Windows.Forms.Button();
            this.BtSalvar = new System.Windows.Forms.Button();
            this.BtPesquisar = new System.Windows.Forms.Button();
            this.BtExcluir = new System.Windows.Forms.Button();
            this.BtCliente = new System.Windows.Forms.Button();
            this.BtUsuario = new System.Windows.Forms.Button();
            this.DtGvStatus = new System.Windows.Forms.DataGridView();
            this.Ligacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataeHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DtGvStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Data e Hora:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cliente:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Usuário:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Observações:";
            // 
            // Codigo
            // 
            this.Codigo.Location = new System.Drawing.Point(83, 27);
            this.Codigo.Name = "Codigo";
            this.Codigo.Size = new System.Drawing.Size(100, 20);
            this.Codigo.TabIndex = 5;
            // 
            // DataHora
            // 
            this.DataHora.Location = new System.Drawing.Point(83, 53);
            this.DataHora.Name = "DataHora";
            this.DataHora.Size = new System.Drawing.Size(100, 20);
            this.DataHora.TabIndex = 6;
            // 
            // Cliente
            // 
            this.Cliente.Location = new System.Drawing.Point(83, 79);
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            this.Cliente.Size = new System.Drawing.Size(100, 20);
            this.Cliente.TabIndex = 7;
            // 
            // Usuario
            // 
            this.Usuario.Location = new System.Drawing.Point(83, 109);
            this.Usuario.Name = "Usuario";
            this.Usuario.ReadOnly = true;
            this.Usuario.Size = new System.Drawing.Size(100, 20);
            this.Usuario.TabIndex = 8;
            // 
            // Observacoes
            // 
            this.Observacoes.Location = new System.Drawing.Point(83, 135);
            this.Observacoes.Name = "Observacoes";
            this.Observacoes.Size = new System.Drawing.Size(100, 20);
            this.Observacoes.TabIndex = 9;
            // 
            // BtLimpar
            // 
            this.BtLimpar.Location = new System.Drawing.Point(12, 173);
            this.BtLimpar.Name = "BtLimpar";
            this.BtLimpar.Size = new System.Drawing.Size(88, 23);
            this.BtLimpar.TabIndex = 10;
            this.BtLimpar.Text = "Limpar";
            this.BtLimpar.UseVisualStyleBackColor = true;
            this.BtLimpar.Click += new System.EventHandler(this.BtLimpar_Click);
            // 
            // BtSalvar
            // 
            this.BtSalvar.Location = new System.Drawing.Point(131, 173);
            this.BtSalvar.Name = "BtSalvar";
            this.BtSalvar.Size = new System.Drawing.Size(88, 23);
            this.BtSalvar.TabIndex = 11;
            this.BtSalvar.Text = "Salvar";
            this.BtSalvar.UseVisualStyleBackColor = true;
            this.BtSalvar.Click += new System.EventHandler(this.BtSalvar_Click);
            // 
            // BtPesquisar
            // 
            this.BtPesquisar.Location = new System.Drawing.Point(12, 215);
            this.BtPesquisar.Name = "BtPesquisar";
            this.BtPesquisar.Size = new System.Drawing.Size(88, 22);
            this.BtPesquisar.TabIndex = 12;
            this.BtPesquisar.Text = "Pesquisar";
            this.BtPesquisar.UseVisualStyleBackColor = true;
            this.BtPesquisar.Click += new System.EventHandler(this.BtPesquisar_Click);
            // 
            // BtExcluir
            // 
            this.BtExcluir.Location = new System.Drawing.Point(131, 215);
            this.BtExcluir.Name = "BtExcluir";
            this.BtExcluir.Size = new System.Drawing.Size(88, 22);
            this.BtExcluir.TabIndex = 13;
            this.BtExcluir.Text = "Excluir ";
            this.BtExcluir.UseVisualStyleBackColor = true;
            this.BtExcluir.Click += new System.EventHandler(this.BtExcluir_Click);
            // 
            // BtCliente
            // 
            this.BtCliente.Location = new System.Drawing.Point(189, 79);
            this.BtCliente.Name = "BtCliente";
            this.BtCliente.Size = new System.Drawing.Size(30, 20);
            this.BtCliente.TabIndex = 14;
            this.BtCliente.Text = "PC";
            this.BtCliente.UseVisualStyleBackColor = true;
            this.BtCliente.Click += new System.EventHandler(this.BtCliente_Click);
            // 
            // BtUsuario
            // 
            this.BtUsuario.Location = new System.Drawing.Point(189, 108);
            this.BtUsuario.Name = "BtUsuario";
            this.BtUsuario.Size = new System.Drawing.Size(30, 20);
            this.BtUsuario.TabIndex = 15;
            this.BtUsuario.Text = "PU";
            this.BtUsuario.UseVisualStyleBackColor = true;
            this.BtUsuario.Click += new System.EventHandler(this.BtUsuario_Click);
            // 
            // DtGvStatus
            // 
            this.DtGvStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtGvStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ligacao,
            this.UsuarioGrid,
            this.DataeHora,
            this.Status});
            this.DtGvStatus.Location = new System.Drawing.Point(246, 12);
            this.DtGvStatus.Name = "DtGvStatus";
            this.DtGvStatus.Size = new System.Drawing.Size(452, 333);
            this.DtGvStatus.TabIndex = 16;
            // 
            // Ligacao
            // 
            this.Ligacao.HeaderText = "Ligação";
            this.Ligacao.Name = "Ligacao";
            // 
            // UsuarioGrid
            // 
            this.UsuarioGrid.HeaderText = "Usuário";
            this.UsuarioGrid.Name = "UsuarioGrid";
            // 
            // DataeHora
            // 
            this.DataeHora.HeaderText = "Data e Hora";
            this.DataeHora.Name = "DataeHora";
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // CadLigacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 357);
            this.Controls.Add(this.DtGvStatus);
            this.Controls.Add(this.BtUsuario);
            this.Controls.Add(this.BtCliente);
            this.Controls.Add(this.BtExcluir);
            this.Controls.Add(this.BtPesquisar);
            this.Controls.Add(this.BtSalvar);
            this.Controls.Add(this.BtLimpar);
            this.Controls.Add(this.Observacoes);
            this.Controls.Add(this.Usuario);
            this.Controls.Add(this.Cliente);
            this.Controls.Add(this.DataHora);
            this.Controls.Add(this.Codigo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CadLigacao";
            this.Text = "CadLigacao";
            ((System.ComponentModel.ISupportInitialize)(this.DtGvStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Codigo;
        private System.Windows.Forms.TextBox DataHora;
        private System.Windows.Forms.TextBox Cliente;
        private System.Windows.Forms.TextBox Usuario;
        private System.Windows.Forms.TextBox Observacoes;
        private System.Windows.Forms.Button BtLimpar;
        private System.Windows.Forms.Button BtSalvar;
        private System.Windows.Forms.Button BtPesquisar;
        private System.Windows.Forms.Button BtExcluir;
        private System.Windows.Forms.Button BtCliente;
        private System.Windows.Forms.Button BtUsuario;
        private System.Windows.Forms.DataGridView DtGvStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ligacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataeHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}