namespace Views
{
    partial class MenuPrincipalAdmin
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
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnVotar = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnReportesFinales = new System.Windows.Forms.Button();
            this.btnPanelVotaciones = new System.Windows.Forms.Button();
            this.btnConfiguracionPlanchas = new System.Windows.Forms.Button();
            this.btnPadron = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblCurso = new System.Windows.Forms.Label();
            this.lblNombreEstudiante = new System.Windows.Forms.Label();
            this.panelForm = new System.Windows.Forms.Panel();
            this.panelSidebar.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.AliceBlue;
            this.panelSidebar.Controls.Add(this.btnVotar);
            this.panelSidebar.Controls.Add(this.btnCerrarSesion);
            this.panelSidebar.Controls.Add(this.btnReportesFinales);
            this.panelSidebar.Controls.Add(this.btnPanelVotaciones);
            this.panelSidebar.Controls.Add(this.btnConfiguracionPlanchas);
            this.panelSidebar.Controls.Add(this.btnPadron);
            this.panelSidebar.Location = new System.Drawing.Point(-6, 1);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(209, 448);
            this.panelSidebar.TabIndex = 0;
            // 
            // btnVotar
            // 
            this.btnVotar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVotar.Location = new System.Drawing.Point(18, 105);
            this.btnVotar.Name = "btnVotar";
            this.btnVotar.Size = new System.Drawing.Size(184, 41);
            this.btnVotar.TabIndex = 6;
            this.btnVotar.Text = "Votar";
            this.btnVotar.UseVisualStyleBackColor = true;
            this.btnVotar.Click += new System.EventHandler(this.btnVotar_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.Red;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.Location = new System.Drawing.Point(18, 396);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(184, 41);
            this.btnCerrarSesion.TabIndex = 5;
            this.btnCerrarSesion.Text = "Cerrar Sesion";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnReportesFinales
            // 
            this.btnReportesFinales.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportesFinales.Location = new System.Drawing.Point(18, 296);
            this.btnReportesFinales.Name = "btnReportesFinales";
            this.btnReportesFinales.Size = new System.Drawing.Size(184, 41);
            this.btnReportesFinales.TabIndex = 4;
            this.btnReportesFinales.Text = "Reportes Finales";
            this.btnReportesFinales.UseVisualStyleBackColor = true;
            this.btnReportesFinales.Click += new System.EventHandler(this.btnReportesFinales_Click);
            // 
            // btnPanelVotaciones
            // 
            this.btnPanelVotaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPanelVotaciones.Location = new System.Drawing.Point(18, 243);
            this.btnPanelVotaciones.Name = "btnPanelVotaciones";
            this.btnPanelVotaciones.Size = new System.Drawing.Size(184, 41);
            this.btnPanelVotaciones.TabIndex = 2;
            this.btnPanelVotaciones.Text = "Panel de Votaciones";
            this.btnPanelVotaciones.UseVisualStyleBackColor = true;
            this.btnPanelVotaciones.Click += new System.EventHandler(this.btnPanelVotaciones_Click);
            // 
            // btnConfiguracionPlanchas
            // 
            this.btnConfiguracionPlanchas.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfiguracionPlanchas.Location = new System.Drawing.Point(18, 196);
            this.btnConfiguracionPlanchas.Name = "btnConfiguracionPlanchas";
            this.btnConfiguracionPlanchas.Size = new System.Drawing.Size(184, 41);
            this.btnConfiguracionPlanchas.TabIndex = 1;
            this.btnConfiguracionPlanchas.Text = "Configuracion Planchas";
            this.btnConfiguracionPlanchas.UseVisualStyleBackColor = true;
            this.btnConfiguracionPlanchas.Click += new System.EventHandler(this.btnConfiguracionPlanchas_Click);
            // 
            // btnPadron
            // 
            this.btnPadron.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPadron.Location = new System.Drawing.Point(18, 149);
            this.btnPadron.Name = "btnPadron";
            this.btnPadron.Size = new System.Drawing.Size(184, 41);
            this.btnPadron.TabIndex = 0;
            this.btnPadron.Text = "Padron Electoral";
            this.btnPadron.UseVisualStyleBackColor = true;
            this.btnPadron.Click += new System.EventHandler(this.btnPadron_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.lblCurso);
            this.panelHeader.Controls.Add(this.lblNombreEstudiante);
            this.panelHeader.Location = new System.Drawing.Point(0, 1);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(799, 101);
            this.panelHeader.TabIndex = 0;
            // 
            // lblCurso
            // 
            this.lblCurso.AutoSize = true;
            this.lblCurso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurso.Location = new System.Drawing.Point(12, 33);
            this.lblCurso.Name = "lblCurso";
            this.lblCurso.Size = new System.Drawing.Size(151, 25);
            this.lblCurso.TabIndex = 1;
            this.lblCurso.Text = "Aqui va el curso";
            this.lblCurso.Click += new System.EventHandler(this.lblCurso_Click);
            // 
            // lblNombreEstudiante
            // 
            this.lblNombreEstudiante.AutoSize = true;
            this.lblNombreEstudiante.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreEstudiante.Location = new System.Drawing.Point(12, 8);
            this.lblNombreEstudiante.Name = "lblNombreEstudiante";
            this.lblNombreEstudiante.Size = new System.Drawing.Size(329, 25);
            this.lblNombreEstudiante.TabIndex = 0;
            this.lblNombreEstudiante.Text = "Aqui va el nombre del Estudiante";
            this.lblNombreEstudiante.Click += new System.EventHandler(this.lblNombreEstudiante_Click);
            // 
            // panelForm
            // 
            this.panelForm.BackgroundImage = global::Views.Properties.Resources.Banner;
            this.panelForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelForm.Location = new System.Drawing.Point(202, 100);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(597, 349);
            this.panelForm.TabIndex = 1;
            // 
            // MenuPrincipalAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelForm);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelSidebar);
            this.Name = "MenuPrincipalAdmin";
            this.Text = "MenuPrincipalAdmin";
            this.Load += new System.EventHandler(this.MenuPrincipalAdmin_Load);
            this.panelSidebar.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblNombreEstudiante;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnReportesFinales;
        private System.Windows.Forms.Button btnPanelVotaciones;
        private System.Windows.Forms.Button btnConfiguracionPlanchas;
        private System.Windows.Forms.Button btnPadron;
        private System.Windows.Forms.Label lblCurso;
        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.Button btnVotar;
    }
}