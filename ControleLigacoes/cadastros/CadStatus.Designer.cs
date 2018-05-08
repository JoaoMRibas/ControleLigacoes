namespace ControleLigacoes.cadastros
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
            this.SuspendLayout();
            // 
            // OpcaoStatus
            // 
            this.OpcaoStatus.FormattingEnabled = true;
            this.OpcaoStatus.Location = new System.Drawing.Point(6, 59);
            this.OpcaoStatus.Name = "OpcaoStatus";
            this.OpcaoStatus.Size = new System.Drawing.Size(121, 21);
            this.OpcaoStatus.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Selecione uma opção de status:";
            // 
            // CadStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(167, 150);
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
    }
}