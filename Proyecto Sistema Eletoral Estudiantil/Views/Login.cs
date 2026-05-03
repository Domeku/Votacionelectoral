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
            string matricula  = txtMatricula.Text.Trim();
            string contrasena = txtContrasena.Text;

            // Validación visual antes de llamar al controller
            if (string.IsNullOrEmpty(matricula) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Ingresa tu matrícula y contraseña.",
                    "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // El controller busca al usuario Y verifica el hash.
                // Si algo falla, devuelve null — nunca lanza excepción por
                // credenciales incorrectas, solo por problemas de conexión.
                var usuario = _authCtrl.Login(matricula, contrasena);

                if (usuario == null)
                {
                    MessageBox.Show(
                        "Matrícula o contraseña incorrecta.",
                        "Acceso denegado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    // Limpiamos solo la contraseña — la matrícula puede
                    // estar bien y sería molesto que el usuario la reescriba
                    txtContrasena.Clear();
                    txtContrasena.Focus();
                    return;
                }

                // ── Guardamos la sesión global ──
                // Desde este momento CUALQUIER formulario puede leer
                // Sesion.UsuarioActual sin que nadie se lo pase por parámetro
                Sesion.UsuarioActual = usuario;

                // ── Decidimos qué abrir según el rol ──
                if (usuario.RolNombre == "Admin")
                {
                    new MenuPrincipalAdmin().Show();
                }
                else
                {
                    var votacionCtrl = new VotacionController();
                    bool yaVoto = votacionCtrl.UsuarioYaVoto(usuario.UsuarioID);

                    if (yaVoto)
                    {
                        MessageBox.Show(
                            "Ya ejerciste tu voto. Puedes ver los resultados.",
                            "Voto registrado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        new PanelVotaciones().Show();
                    }
                    else
                    {
                        new MenuPrincipalVotante().Show();
                    }
                }

                // Ocultamos el login — no lo cerramos porque es el
                // formulario raíz de Application.Run()
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error de conexión: {ex.Message}",
                    "Error del sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
