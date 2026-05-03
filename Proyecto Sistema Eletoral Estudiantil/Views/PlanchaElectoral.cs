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
    public partial class PlanchaElectoral : Form
    {
        private readonly VotacionController _votacionCtrl = new VotacionController();
        private readonly UsuarioController _usuarioCtrl = new UsuarioController();

        private Plancha _planchaActual = null; // <-- aquí

        public PlanchaElectoral()
        {
            InitializeComponent();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void PlanchaElectoral_Load(object sender, EventArgs e)
        {
            CargarComboBoxPadron();
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            try
            {
                var planchas = _votacionCtrl.ObtenerPlanchasPorPadron(
                    Sesion.UsuarioActual.PadronId);

                dgvPlanchas.DataSource = planchas;

                // Ocultamos columnas internas
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

        private void CargarComboBoxPadron()
        {
            try
            {
                // Necesitamos saber a qué padrón pertenece la plancha
                var padrones = _usuarioCtrl.ObtenerPadrones();
                // Si tu formulario tiene un ComboBox para el padrón, lo llenas así:
                // cmbPadronPlancha.DataSource = padrones;
                // cmbPadronPlancha.DisplayMember = "Nombre";
                // cmbPadronPlancha.ValueMember = "PadronID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimpiarFormulario()
        {
            txtNombrePlancha.Clear();
            txtEslogan.Clear();
            txtPresidente.Clear();
            txtVicePresidente.Clear();
            txtSecretario.Clear();
            txtTesorero.Clear();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (_planchaActual == null)
            {
                MessageBox.Show("Selecciona una plancha de la lista primero.",
                    "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var planchaEditada = new Plancha
                {
                    PlanchaId = _planchaActual.PlanchaId,
                    Nombre = txtNombrePlancha.Text.Trim(),
                    Eslogan = txtEslogan.Text.Trim(),
                    PadronId = _planchaActual.PadronId
                };

                _votacionCtrl.ActualizarPlanchaCompleta(
                    planchaEditada,
                    txtPresidente.Text.Trim(),
                    txtVicePresidente.Text.Trim(),
                    txtSecretario.Text.Trim(),
                    txtTesorero.Text.Trim());

                MessageBox.Show("Plancha actualizada correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _planchaActual = null;
                LimpiarFormulario();
                CargarGrilla();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al editar: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                var plancha = new Plancha
                {
                    Nombre = txtNombrePlancha.Text.Trim(),
                    Eslogan = txtEslogan.Text.Trim(),
                    PadronId = Sesion.UsuarioActual.PadronId,
                    Candidatos = new List<Candidato>
                    {
                        new Candidato { Nombre = txtPresidente.Text.Trim(),
                                        Puesto = "Presidente" },
                        new Candidato { Nombre = txtVicePresidente.Text.Trim(),
                                        Puesto = "VicePresidente" },
                        new Candidato { Nombre = txtSecretario.Text.Trim(),
                                        Puesto = "Secretario General" },
                        new Candidato { Nombre = txtTesorero.Text.Trim(),
                                        Puesto = "Tesorero" }
                    }
                };

                _votacionCtrl.RegistrarPlancha(plancha);

                MessageBox.Show("Plancha registrada correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
                CargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPlanchas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPlanchas.SelectedRows.Count == 0) return;

            _planchaActual = (Plancha)dgvPlanchas.SelectedRows[0].DataBoundItem;
            if (_planchaActual == null) return;

            txtNombrePlancha.Text = _planchaActual.Nombre;
            txtEslogan.Text = _planchaActual.Eslogan;
            txtId.Text = _planchaActual.PlanchaId.ToString();

            txtPresidente.Clear();
            txtVicePresidente.Clear();
            txtSecretario.Clear();
            txtTesorero.Clear();

            foreach (var c in _planchaActual.Candidatos)
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Selecciona una plancha de la lista primero.",
                    "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmar = MessageBox.Show(
                "¿Estás seguro de que deseas eliminar esta plancha?\nEsta acción no se puede deshacer.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmar != DialogResult.Yes) return;

            try
            {
                int planchaId = int.Parse(txtId.Text);
                _votacionCtrl.EliminarPlancha(planchaId);

                MessageBox.Show("Plancha eliminada correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
                CargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
