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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtIdVoto = new System.Windows.Forms.TextBox();
            this.btnVotar = new System.Windows.Forms.Button();
            this.btnVotoNulo = new System.Windows.Forms.Button();
            this.lblInsertarIDVOTO = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(61, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(494, 268);
            this.dataGridView1.TabIndex = 0;
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
            // txtIdVoto
            // 
            this.txtIdVoto.Location = new System.Drawing.Point(244, 338);
            this.txtIdVoto.Name = "txtIdVoto";
            this.txtIdVoto.Size = new System.Drawing.Size(100, 22);
            this.txtIdVoto.TabIndex = 2;
            // 
            // btnVotar
            // 
            this.btnVotar.Location = new System.Drawing.Point(350, 338);
            this.btnVotar.Name = "btnVotar";
            this.btnVotar.Size = new System.Drawing.Size(205, 37);
            this.btnVotar.TabIndex = 3;
            this.btnVotar.Text = "Votar";
            this.btnVotar.UseVisualStyleBackColor = true;
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
            // 
            // lblInsertarIDVOTO
            // 
            this.lblInsertarIDVOTO.AutoSize = true;
            this.lblInsertarIDVOTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertarIDVOTO.Location = new System.Drawing.Point(57, 338);
            this.lblInsertarIDVOTO.Name = "lblInsertarIDVOTO";
            this.lblInsertarIDVOTO.Size = new System.Drawing.Size(165, 20);
            this.lblInsertarIDVOTO.TabIndex = 5;
            this.lblInsertarIDVOTO.Text = "Insertar Id de Voto";
            // 
            // Votacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 450);
            this.Controls.Add(this.lblInsertarIDVOTO);
            this.Controls.Add(this.btnVotoNulo);
            this.Controls.Add(this.btnVotar);
            this.Controls.Add(this.txtIdVoto);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Votacion";
            this.Text = "Votacion";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtIdVoto;
        private System.Windows.Forms.Button btnVotar;
        private System.Windows.Forms.Button btnVotoNulo;
        private System.Windows.Forms.Label lblInsertarIDVOTO;
    }
}