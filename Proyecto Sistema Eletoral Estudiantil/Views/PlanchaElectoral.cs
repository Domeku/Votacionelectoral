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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                // Construimos la plancha con lo que el admin escribió.
                // Los nombres txtNombrePlancha, txtEslogan deben coincidir
                // con los Names de tus TextBox en el designer.
                var plancha = new Plancha
                {
                    Nombre = txtNombrePlancha.Text.Trim(),
                    Eslogan = txtEslogan.Text.Trim(),
                    // PadronId = (int)cmbPadronPlancha.SelectedValue,
                    // Por ahora usamos el padrón del admin en sesión:
                    PadronId = Sesion.UsuarioActual.PadronId
                };

                // Construimos la lista de candidatos con los campos del formulario.
                // Ajusta los nombres de los TextBox según tu designer.
                plancha.Candidatos = new List<Candidato>
                {
                    new Candidato { Nombre = txtPresidente.Text.Trim(),
                                    Puesto = "Presidente" },
                    new Candidato { Nombre = txtVicePresidente.Text.Trim(),
                                    Puesto = "VicePresidente" },
                    new Candidato { Nombre = txtSecretario.Text.Trim(),
                                    Puesto = "Secretario General" },
                    new Candidato { Nombre = txtTesorero.Text.Trim(),
                                    Puesto = "Tesorero" }
                };

                // El controller valida, guarda la plancha, y luego guarda
                // cada candidato con el ID recién creado.
                _votacionCtrl.RegistrarPlancha(plancha);

                MessageBox.Show("Plancha registrada correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
