namespace Views
{
    partial class Planchas
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
            this.dgvPlanchas = new System.Windows.Forms.DataGridView();
            this.txtTesorero = new System.Windows.Forms.TextBox();
            this.lblTesorero = new System.Windows.Forms.Label();
            this.txtSecretario = new System.Windows.Forms.TextBox();
            this.lblSecretarioGeneral = new System.Windows.Forms.Label();
            this.txtVicePresidente = new System.Windows.Forms.TextBox();
            this.lblVicePresidente = new System.Windows.Forms.Label();
            this.txtPresidente = new System.Windows.Forms.TextBox();
            this.lblPresidente = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanchas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPlanchas
            // 
            this.dgvPlanchas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanchas.Location = new System.Drawing.Point(12, 56);
            this.dgvPlanchas.Name = "dgvPlanchas";
            this.dgvPlanchas.RowHeadersWidth = 51;
            this.dgvPlanchas.RowTemplate.Height = 24;
            this.dgvPlanchas.Size = new System.Drawing.Size(561, 221);
            this.dgvPlanchas.TabIndex = 0;
            this.dgvPlanchas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlanchas_CellContentClick);
            this.dgvPlanchas.SelectionChanged += new System.EventHandler(this.dgvPlanchas_SelectionChanged);
            // 
            // txtTesorero
            // 
            this.txtTesorero.Location = new System.Drawing.Point(365, 386);
            this.txtTesorero.Multiline = true;
            this.txtTesorero.Name = "txtTesorero";
            this.txtTesorero.ReadOnly = true;
            this.txtTesorero.Size = new System.Drawing.Size(143, 33);
            this.txtTesorero.TabIndex = 22;
            // 
            // lblTesorero
            // 
            this.lblTesorero.AutoSize = true;
            this.lblTesorero.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTesorero.Location = new System.Drawing.Point(361, 351);
            this.lblTesorero.Name = "lblTesorero";
            this.lblTesorero.Size = new System.Drawing.Size(84, 20);
            this.lblTesorero.TabIndex = 21;
            this.lblTesorero.Text = "Tesorero";
            // 
            // txtSecretario
            // 
            this.txtSecretario.Location = new System.Drawing.Point(365, 315);
            this.txtSecretario.Multiline = true;
            this.txtSecretario.Name = "txtSecretario";
            this.txtSecretario.ReadOnly = true;
            this.txtSecretario.Size = new System.Drawing.Size(143, 33);
            this.txtSecretario.TabIndex = 20;
            // 
            // lblSecretarioGeneral
            // 
            this.lblSecretarioGeneral.AutoSize = true;
            this.lblSecretarioGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecretarioGeneral.Location = new System.Drawing.Point(361, 292);
            this.lblSecretarioGeneral.Name = "lblSecretarioGeneral";
            this.lblSecretarioGeneral.Size = new System.Drawing.Size(168, 20);
            this.lblSecretarioGeneral.TabIndex = 19;
            this.lblSecretarioGeneral.Text = "Secretario General";
            // 
            // txtVicePresidente
            // 
            this.txtVicePresidente.Location = new System.Drawing.Point(47, 386);
            this.txtVicePresidente.Multiline = true;
            this.txtVicePresidente.Name = "txtVicePresidente";
            this.txtVicePresidente.ReadOnly = true;
            this.txtVicePresidente.Size = new System.Drawing.Size(143, 33);
            this.txtVicePresidente.TabIndex = 18;
            // 
            // lblVicePresidente
            // 
            this.lblVicePresidente.AutoSize = true;
            this.lblVicePresidente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVicePresidente.Location = new System.Drawing.Point(47, 351);
            this.lblVicePresidente.Name = "lblVicePresidente";
            this.lblVicePresidente.Size = new System.Drawing.Size(136, 20);
            this.lblVicePresidente.TabIndex = 17;
            this.lblVicePresidente.Text = "VicePresidente";
            // 
            // txtPresidente
            // 
            this.txtPresidente.Location = new System.Drawing.Point(51, 315);
            this.txtPresidente.Multiline = true;
            this.txtPresidente.Name = "txtPresidente";
            this.txtPresidente.ReadOnly = true;
            this.txtPresidente.Size = new System.Drawing.Size(143, 33);
            this.txtPresidente.TabIndex = 16;
            // 
            // lblPresidente
            // 
            this.lblPresidente.AutoSize = true;
            this.lblPresidente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPresidente.Location = new System.Drawing.Point(47, 292);
            this.lblPresidente.Name = "lblPresidente";
            this.lblPresidente.Size = new System.Drawing.Size(99, 20);
            this.lblPresidente.TabIndex = 15;
            this.lblPresidente.Text = "Presidente";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(216, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(140, 32);
            this.lblTitulo.TabIndex = 23;
            this.lblTitulo.Text = "Planchas";
            // 
            // Planchas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 450);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.txtTesorero);
            this.Controls.Add(this.lblTesorero);
            this.Controls.Add(this.txtSecretario);
            this.Controls.Add(this.lblSecretarioGeneral);
            this.Controls.Add(this.txtVicePresidente);
            this.Controls.Add(this.lblVicePresidente);
            this.Controls.Add(this.txtPresidente);
            this.Controls.Add(this.lblPresidente);
            this.Controls.Add(this.dgvPlanchas);
            this.Name = "Planchas";
            this.Text = "Planchas";
            this.Load += new System.EventHandler(this.Planchas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanchas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPlanchas;
        private System.Windows.Forms.TextBox txtTesorero;
        private System.Windows.Forms.Label lblTesorero;
        private System.Windows.Forms.TextBox txtSecretario;
        private System.Windows.Forms.Label lblSecretarioGeneral;
        private System.Windows.Forms.TextBox txtVicePresidente;
        private System.Windows.Forms.Label lblVicePresidente;
        private System.Windows.Forms.TextBox txtPresidente;
        private System.Windows.Forms.Label lblPresidente;
        private System.Windows.Forms.Label lblTitulo;
    }
}