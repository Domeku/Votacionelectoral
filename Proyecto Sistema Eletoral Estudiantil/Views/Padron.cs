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
    public partial class Padron : Form
    {
        private readonly UsuarioController _usuarioCtrl = new UsuarioController();
        public Padron()
        {
            InitializeComponent();
        }

        private void Padron_Load(object sender, EventArgs e)
        {
            CargarComboBoxes();
            CargarGrilla();
        }

        private void CargarComboBoxes()
        {
            try
            {
                // DisplayMember = qué propiedad se muestra al usuario
                // ValueMember   = qué propiedad se usa como valor interno (el ID)
                // Así cuando el usuario selecciona "Admin", tú puedes leer
                // el ID correspondiente con cmbRol.SelectedValue

                var roles = _usuarioCtrl.ObtenerRoles();
                cmbRol.DataSource = roles;
                cmbRol.DisplayMember = "Nombre";
                cmbRol.ValueMember = "RolID";

                var padrones = _usuarioCtrl.ObtenerPadrones();
                cmbPadron.DataSource = padrones;
                cmbPadron.DisplayMember = "Nombre";
                cmbPadron.ValueMember = "PadronID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGrilla()
        {
            try
            {
                var usuarios = _usuarioCtrl.ObtenerTodos();

                // DataSource conecta la lista directamente al grid.
                // El DataGridView muestra automáticamente una columna
                // por cada propiedad pública del objeto Usuario.
                dgvUsuarios.DataSource = usuarios;

                // Ocultamos columnas que no necesita ver el admin.
                // Lo hacemos después de asignar DataSource porque antes
                // las columnas no existen todavía.
                if (dgvUsuarios.Columns["Contrasena"] != null)
                    dgvUsuarios.Columns["Contrasena"].Visible = false;

                if (dgvUsuarios.Columns["UsuarioID"] != null)
                    dgvUsuarios.Columns["UsuarioID"].Visible = false;

                if (dgvUsuarios.Columns["RolId"] != null)
                    dgvUsuarios.Columns["RolId"].Visible = false;

                if (dgvUsuarios.Columns["PadronId"] != null)
                    dgvUsuarios.Columns["PadronId"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                var nuevoUsuario = new Usuario
                {
                    Nombre = txtNombre.Text.Trim(),
                    Matricula = txtMatricula.Text.Trim(),
                    Curso = cmbCurso.Text.Trim(),
                    Seccion = cmbSeccion.Text.Trim(),
                    RolId = (int)cmbRol.SelectedValue,
                    PadronId = (int)cmbPadron.SelectedValue
                };

                // Ahora usa lo que escribió el admin en txtContrasena
                string contrasena = txtContrasena.Text.Trim();

                _usuarioCtrl.Registrar(nuevoUsuario, contrasena);

                MessageBox.Show("Usuario registrado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
                CargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificamos que hay una fila seleccionada
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un usuario de la lista primero.",
                    "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Pedimos confirmación — eliminar es irreversible
            var confirmar = MessageBox.Show(
                "¿Estás seguro de que deseas eliminar este usuario?\nEsta acción no se puede deshacer.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmar != DialogResult.Yes) return;

            try
            {
                // Leemos el ID de la fila seleccionada.
                // DataGridViewRow.DataBoundItem devuelve el objeto Usuario
                // que está detrás de esa fila.
                var usuarioSeleccionado = (Usuario)dgvUsuarios.SelectedRows[0].DataBoundItem;
                _usuarioCtrl.Eliminar(usuarioSeleccionado.UsuarioID);

                MessageBox.Show("Usuario eliminado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void bt_Click(object sender, EventArgs e)
        {
            // Por ahora recargamos todos y dejamos el filtro visual al grid.
            // En el futuro puedes hacer un método en el repositorio que filtre en SQL.
            CargarGrilla();
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtMatricula.Clear();
            txtContrasena.Clear(); // <-- agregar esta línea
            if (cmbRol.Items.Count > 0) cmbRol.SelectedIndex = 0;
            if (cmbPadron.Items.Count > 0) cmbPadron.SelectedIndex = 0;
            if (cmbCurso.Items.Count > 0) cmbCurso.SelectedIndex = 0;
            if (cmbSeccion.Items.Count > 0) cmbSeccion.SelectedIndex = 0;
        }

        private void b_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un usuario de la lista primero.",
                    "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Lee directamente el objeto Usuario que está detrás de la fila
                // Si el admin editó una celda en el grid, DataBoundItem ya tiene
                // el valor nuevo porque el grid está enlazado a la lista
                var u = (Usuario)dgvUsuarios.SelectedRows[0].DataBoundItem;
                _usuarioCtrl.Actualizar(u);

                MessageBox.Show("Usuario actualizado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
