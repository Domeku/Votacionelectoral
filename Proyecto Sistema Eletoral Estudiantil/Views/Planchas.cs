using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers;
using Models;
    

namespace Views
{
    public partial class Planchas : Form
    {
        private readonly VotacionController _votacionCtrl = new VotacionController();
        public Planchas()
        {
            InitializeComponent();
        }

        private void Planchas_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            try
            {
                var planchas = _votacionCtrl.ObtenerPlanchasPorPadron(
                    Sesion.UsuarioActual.PadronId);

                dgvPlanchas.DataSource = planchas;

                // Mostramos solo Nombre y Eslogan — lo demás es interno
                string[] ocultas = { "PlanchaId", "PadronId", "Candidatos",
                                     "TotalVotos", "PorcentajeVotos", "LogUrl" };
                foreach (var col in ocultas)
                    if (dgvPlanchas.Columns[col] != null)
                        dgvPlanchas.Columns[col].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar planchas: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            private void dgvPlanchas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPlanchas.SelectedRows.Count == 0) return;

            var p = (Plancha)dgvPlanchas.SelectedRows[0].DataBoundItem;
            if (p == null) return;

            // Limpiamos primero por si la plancha no tiene todos los puestos
            txtPresidente.Clear();
            txtVicePresidente.Clear();
            txtSecretario.Clear();
            txtTesorero.Clear();

            // Llenamos cada TextBox según el puesto del candidato
            foreach (var c in p.Candidatos)
            {
                switch (c.Puesto)
                {
                    case "Presidente": txtPresidente.Text = c.Nombre; break;
                    case "VicePresidente": txtVicePresidente.Text = c.Nombre; break;
                    case "Secretario General": txtSecretario.Text = c.Nombre; break;
                    case "Tesorero": txtTesorero.Text = c.Nombre; break;
                }
            }
        }

        private void dgvPlanchas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}