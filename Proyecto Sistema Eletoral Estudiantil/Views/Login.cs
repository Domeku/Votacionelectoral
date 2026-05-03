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

namespace Views
{
    public partial class Login : Form
    {

        private readonly AuthController _authCtrl = new AuthController();
        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Recogemos lo que el usuario escribió
            string matricula = txtMatricula.Text.Trim();
            string contrasena = txtContrasena.Text;

            // Validación visual básica — antes de llamar al controller
            if (string.IsNullOrEmpty(matricula) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor ingresa tu matrícula y contraseña.",
                    "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // El controller hace TODO el trabajo: buscar el usuario,
                // verificar el hash, devolver el objeto o null.
                var usuario = _authCtrl.Login(matricula, contrasena);

                if (usuario == null)
                {
                    // No decimos si falló la matrícula o la contraseña —
                    // eso daría información útil a alguien malintencionado.
                    MessageBox.Show("Credenciales incorrectas. Intenta de nuevo.",
                        "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContrasena.Clear();
                    return;
                }

                // Guardamos el usuario en la sesión global.
                // Desde este momento, cualquier formulario puede leer
                // Sesion.UsuarioActual para saber quién está conectado.
                Sesion.UsuarioActual = usuario;

                // Decidimos qué menú abrir según el rol.
                // RolNombre viene del JOIN que hicimos en UsuarioRepository.
                if (usuario.RolNombre == "Admin")
                {
                    var menu = new MenuPrincipalAdmin();
                    menu.Show();
                }
                else
                {
                    // Aquí irá el menú del votante cuando lo crees
                    var votacion = new Votacion();
                    votacion.Show();
                }

                // Ocultamos el login — no lo cerramos porque si se cierra,
                // la aplicación también se cierra (es el formulario principal).
                this.Hide();
            }
            catch (Exception ex)
            {
                // Si hay un error de conexión a SQL u otro problema técnico,
                // lo mostramos aquí. El usuario nunca ve un crash.
                MessageBox.Show($"Error del sistema: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
