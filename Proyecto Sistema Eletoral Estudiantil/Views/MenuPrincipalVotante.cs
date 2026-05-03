using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Views
{
    public partial class MenuPrincipalVotante : Form
    {
        public MenuPrincipalVotante()
        {
            InitializeComponent();
        }

        private void btnVotar_Click(object sender, EventArgs e)
        {
            using var f = new Votacion();
            f.ShowDialog(this);
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            var confirmar = MessageBox.Show(
    "¿Deseas cerrar sesión?", "Cerrar sesión",
    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmar == DialogResult.Yes)
            {
                Sesion.Cerrar();     // Limpiamos la sesión global
                this.Hide();         // Ocultamos el menú

                // Mostramos el Login de nuevo
                var login = new Login();
                login.Show();
            }
        }

        private void btnReportesFinales_Click(object sender, EventArgs e)
        {
            using var f = new Reportes();
            f.ShowDialog(this);
        }

        private void btnPanelVotaciones_Click(object sender, EventArgs e)
        {
            using var f = new PanelVotaciones();
            f.ShowDialog(this);
        }

        private void MenuPrincipalVotante_Load(object sender, EventArgs e)
        {
            if (Sesion.UsuarioActual != null)
            {
                lblNombreEstudiante.Text = Sesion.UsuarioActual.Nombre;
                lblCurso.Text = Sesion.UsuarioActual.Curso + " " +
                                 Sesion.UsuarioActual.Seccion;
            }
        }

        private void btnPlanchas_Click(object sender, EventArgs e)
        {
            using var f = new Planchas();
            f.ShowDialog(this);
        }
    }
}
