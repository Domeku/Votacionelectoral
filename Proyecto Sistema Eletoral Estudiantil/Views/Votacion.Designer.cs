namespace Views
{
    partial class Votacion
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnVotar = new System.Windows.Forms.Button();
            this.btnVotoNulo = new System.Windows.Forms.Button();
            this.lblPlanchaSeleccionada = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanchas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPlanchas
            // 
            this.dgvPlanchas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanchas.Location = new System.Drawing.Point(61, 52);
            this.dgvPlanchas.Name = "dgvPlanchas";
            this.dgvPlanchas.RowHeadersWidth = 51;
            this.dgvPlanchas.RowTemplate.Height = 24;
            this.dgvPlanchas.Size = new System.Drawing.Size(494, 268);
            this.dgvPlanchas.TabIndex = 0;
            this.dgvPlanchas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlanchas_CellContentClick);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(239, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(120, 29);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Votacion";
            // 
            // btnVotar
            // 
            this.btnVotar.Location = new System.Drawing.Point(350, 338);
            this.btnVotar.Name = "btnVotar";
            this.btnVotar.Size = new System.Drawing.Size(205, 37);
            this.btnVotar.TabIndex = 3;
            this.btnVotar.Text = "Votar";
            this.btnVotar.UseVisualStyleBackColor = true;
            this.btnVotar.Click += new System.EventHandler(this.btnVotar_Click);
            // 
            // btnVotoNulo
            // 
            this.btnVotoNulo.BackColor = System.Drawing.Color.Red;
            this.btnVotoNulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVotoNulo.ForeColor = System.Drawing.Color.Black;
            this.btnVotoNulo.Location = new System.Drawing.Point(12, 401);
            this.btnVotoNulo.Name = "btnVotoNulo";
            this.btnVotoNulo.Size = new System.Drawing.Size(96, 37);
            this.btnVotoNulo.TabIndex = 4;
            this.btnVotoNulo.Text = "Voto Nulo";
            this.btnVotoNulo.UseVisualStyleBackColor = false;
            this.btnVotoNulo.Click += new System.EventHandler(this.btnVotoNulo_Click);
            // 
            // lblPlanchaSeleccionada
            // 
            this.lblPlanchaSeleccionada.AutoSize = true;
            this.lblPlanchaSeleccionada.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanchaSeleccionada.Location = new System.Drawing.Point(71, 338);
            this.lblPlanchaSeleccionada.Name = "lblPlanchaSeleccionada";
            this.lblPlanchaSeleccionada.Size = new System.Drawing.Size(194, 20);
            this.lblPlanchaSeleccionada.TabIndex = 5;
            this.lblPlanchaSeleccionada.Text = "Plancha Seleccionada";
            // 
            // Votacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 450);
            this.Controls.Add(this.lblPlanchaSeleccionada);
            this.Controls.Add(this.btnVotoNulo);
            this.Controls.Add(this.btnVotar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.dgvPlanchas);
            this.Name = "Votacion";
            this.Text = "Votacion";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanchas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPlanchas;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnVotar;
        private System.Windows.Forms.Button btnVotoNulo;
        private System.Windows.Forms.Label lblPlanchaSeleccionada;
    }
}