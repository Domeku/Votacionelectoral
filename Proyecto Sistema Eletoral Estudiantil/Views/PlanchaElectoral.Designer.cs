namespace Views
{
    partial class PlanchaElectoral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlanchaElectoral));
            this.label1 = new System.Windows.Forms.Label();
            this.lblNombrePlancha = new System.Windows.Forms.Label();
            this.lblEslogan = new System.Windows.Forms.Label();
            this.txtNombrePlancha = new System.Windows.Forms.TextBox();
            this.txtEslogan = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPresidente = new System.Windows.Forms.Label();
            this.txtPresidente = new System.Windows.Forms.TextBox();
            this.txtVicePresidente = new System.Windows.Forms.TextBox();
            this.lblVicePresidente = new System.Windows.Forms.Label();
            this.txtSecretario = new System.Windows.Forms.TextBox();
            this.lblSecretarioGeneral = new System.Windows.Forms.Label();
            this.txtTesorero = new System.Windows.Forms.TextBox();
            this.lblTesorero = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.dgvPlanchas = new System.Windows.Forms.DataGridView();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanchas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Plancha Electoral";
            // 
            // lblNombrePlancha
            // 
            this.lblNombrePlancha.AutoSize = true;
            this.lblNombrePlancha.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombrePlancha.Location = new System.Drawing.Point(13, 63);
            this.lblNombrePlancha.Name = "lblNombrePlancha";
            this.lblNombrePlancha.Size = new System.Drawing.Size(147, 20);
            this.lblNombrePlancha.TabIndex = 1;
            this.lblNombrePlancha.Text = "Nombre Plancha";
            // 
            // lblEslogan
            // 
            this.lblEslogan.AutoSize = true;
            this.lblEslogan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEslogan.Location = new System.Drawing.Point(13, 143);
            this.lblEslogan.Name = "lblEslogan";
            this.lblEslogan.Size = new System.Drawing.Size(128, 20);
            this.lblEslogan.TabIndex = 2;
            this.lblEslogan.Text = "Eslogan/Lema";
            // 
            // txtNombrePlancha
            // 
            this.txtNombrePlancha.Location = new System.Drawing.Point(17, 96);
            this.txtNombrePlancha.Multiline = true;
            this.txtNombrePlancha.Name = "txtNombrePlancha";
            this.txtNombrePlancha.Size = new System.Drawing.Size(143, 33);
            this.txtNombrePlancha.TabIndex = 3;
            // 
            // txtEslogan
            // 
            this.txtEslogan.Location = new System.Drawing.Point(17, 177);
            this.txtEslogan.Multiline = true;
            this.txtEslogan.Name = "txtEslogan";
            this.txtEslogan.Size = new System.Drawing.Size(143, 33);
            this.txtEslogan.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(-2, 292);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(7730, 2);
            this.label4.TabIndex = 5;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(277, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 29);
            this.label5.TabIndex = 6;
            this.label5.Text = "Candidatos";
            // 
            // lblPresidente
            // 
            this.lblPresidente.AutoSize = true;
            this.lblPresidente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPresidente.Location = new System.Drawing.Point(249, 63);
            this.lblPresidente.Name = "lblPresidente";
            this.lblPresidente.Size = new System.Drawing.Size(99, 20);
            this.lblPresidente.TabIndex = 7;
            this.lblPresidente.Text = "Presidente";
            // 
            // txtPresidente
            // 
            this.txtPresidente.Location = new System.Drawing.Point(253, 96);
            this.txtPresidente.Multiline = true;
            this.txtPresidente.Name = "txtPresidente";
            this.txtPresidente.Size = new System.Drawing.Size(143, 33);
            this.txtPresidente.TabIndex = 8;
            // 
            // txtVicePresidente
            // 
            this.txtVicePresidente.Location = new System.Drawing.Point(253, 175);
            this.txtVicePresidente.Multiline = true;
            this.txtVicePresidente.Name = "txtVicePresidente";
            this.txtVicePresidente.Size = new System.Drawing.Size(143, 33);
            this.txtVicePresidente.TabIndex = 10;
            this.txtVicePresidente.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // lblVicePresidente
            // 
            this.lblVicePresidente.AutoSize = true;
            this.lblVicePresidente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVicePresidente.Location = new System.Drawing.Point(249, 142);
            this.lblVicePresidente.Name = "lblVicePresidente";
            this.lblVicePresidente.Size = new System.Drawing.Size(136, 20);
            this.lblVicePresidente.TabIndex = 9;
            this.lblVicePresidente.Text = "VicePresidente";
            this.lblVicePresidente.Click += new System.EventHandler(this.label7_Click);
            // 
            // txtSecretario
            // 
            this.txtSecretario.Location = new System.Drawing.Point(444, 96);
            this.txtSecretario.Multiline = true;
            this.txtSecretario.Name = "txtSecretario";
            this.txtSecretario.Size = new System.Drawing.Size(143, 33);
            this.txtSecretario.TabIndex = 12;
            // 
            // lblSecretarioGeneral
            // 
            this.lblSecretarioGeneral.AutoSize = true;
            this.lblSecretarioGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecretarioGeneral.Location = new System.Drawing.Point(440, 63);
            this.lblSecretarioGeneral.Name = "lblSecretarioGeneral";
            this.lblSecretarioGeneral.Size = new System.Drawing.Size(168, 20);
            this.lblSecretarioGeneral.TabIndex = 11;
            this.lblSecretarioGeneral.Text = "Secretario General";
            // 
            // txtTesorero
            // 
            this.txtTesorero.Location = new System.Drawing.Point(254, 253);
            this.txtTesorero.Multiline = true;
            this.txtTesorero.Name = "txtTesorero";
            this.txtTesorero.Size = new System.Drawing.Size(143, 33);
            this.txtTesorero.TabIndex = 14;
            this.txtTesorero.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // lblTesorero
            // 
            this.lblTesorero.AutoSize = true;
            this.lblTesorero.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTesorero.Location = new System.Drawing.Point(250, 220);
            this.lblTesorero.Name = "lblTesorero";
            this.lblTesorero.Size = new System.Drawing.Size(84, 20);
            this.lblTesorero.TabIndex = 13;
            this.lblTesorero.Text = "Tesorero";
            this.lblTesorero.Click += new System.EventHandler(this.label9_Click);
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.InfoText;
            this.textBox7.Location = new System.Drawing.Point(242, -23);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(2, 317);
            this.textBox7.TabIndex = 15;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(48, 312);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(174, 59);
            this.btnAgregar.TabIndex = 17;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(260, 312);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(174, 59);
            this.btnEditar.TabIndex = 18;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // dgvPlanchas
            // 
            this.dgvPlanchas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanchas.Location = new System.Drawing.Point(403, 139);
            this.dgvPlanchas.Name = "dgvPlanchas";
            this.dgvPlanchas.RowHeadersWidth = 51;
            this.dgvPlanchas.RowTemplate.Height = 24;
            this.dgvPlanchas.Size = new System.Drawing.Size(261, 150);
            this.dgvPlanchas.TabIndex = 19;
            this.dgvPlanchas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlanchas_CellContentClick);
            this.dgvPlanchas.SelectionChanged += new System.EventHandler(this.dgvPlanchas_SelectionChanged);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(17, 254);
            this.txtId.Multiline = true;
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(143, 33);
            this.txtId.TabIndex = 21;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(13, 220);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(24, 20);
            this.lblId.TabIndex = 20;
            this.lblId.Text = "Id";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(457, 312);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(174, 59);
            this.btnEliminar.TabIndex = 22;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // PlanchaElectoral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 383);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.dgvPlanchas);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.txtTesorero);
            this.Controls.Add(this.lblTesorero);
            this.Controls.Add(this.txtSecretario);
            this.Controls.Add(this.lblSecretarioGeneral);
            this.Controls.Add(this.txtVicePresidente);
            this.Controls.Add(this.lblVicePresidente);
            this.Controls.Add(this.txtPresidente);
            this.Controls.Add(this.lblPresidente);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEslogan);
            this.Controls.Add(this.txtNombrePlancha);
            this.Controls.Add(this.lblEslogan);
            this.Controls.Add(this.lblNombrePlancha);
            this.Controls.Add(this.label1);
            this.Name = "PlanchaElectoral";
            this.Text = "PlanchaElectoral";
            this.Load += new System.EventHandler(this.PlanchaElectoral_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanchas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNombrePlancha;
        private System.Windows.Forms.Label lblEslogan;
        private System.Windows.Forms.TextBox txtNombrePlancha;
        private System.Windows.Forms.TextBox txtEslogan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPresidente;
        private System.Windows.Forms.TextBox txtPresidente;
        private System.Windows.Forms.TextBox txtVicePresidente;
        private System.Windows.Forms.Label lblVicePresidente;
        private System.Windows.Forms.TextBox txtSecretario;
        private System.Windows.Forms.Label lblSecretarioGeneral;
        private System.Windows.Forms.TextBox txtTesorero;
        private System.Windows.Forms.Label lblTesorero;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.DataGridView dgvPlanchas;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Button btnEliminar;
    }
}