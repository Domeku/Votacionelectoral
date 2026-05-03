using Controllers;
using Models;
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
    public partial class Votacion : Form
    {
        private readonly VotacionController _votacionCtrl = new VotacionController();

        private int? _planchaSeleccionadaId = null;
        public Votacion()
        {
            InitializeComponent();
        }   

        private void Votacion_Load(object sender, EventArgs e)
        {
            VerificarAcesso();
            CargarPlanchas();
        }

        private void VerificarAcesso()
        {
            if (Sesion.UsuarioActual == null)
            {
                MessageBox.Show("Sesión inválida.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if (_votacionCtrl.UsuarioYaVoto(Sesion.UsuarioActual.UsuarioID))
            {
                MessageBox.Show(
                    "Ya ejerciste tu voto anteriormente.\nSerás redirigido a los resultados.",
                    "Acceso restringido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                // Abrimos resultados y cerramos este formulario
                new PanelVotaciones().Show();
                this.Close();
            }
        }

        private void CargarPlanchas()
        {
            try
            {
                var planchas = _votacionCtrl.ObtenerPlanchasPorPadron(
                    Sesion.UsuarioActual.PadronId);

                // Mostramos las planchas en el DataGridView.
                // Solo columnas relevantes: Nombre y Eslogan.
                dgvPlanchas.DataSource = planchas;

                if (dgvPlanchas.Columns["PlanchaId"] != null)
                    dgvPlanchas.Columns["PlanchaId"].Visible = false;

                if (dgvPlanchas.Columns["PadronId"] != null)
                    dgvPlanchas.Columns["PadronId"].Visible = false;

                if (dgvPlanchas.Columns["Candidatos"] != null)
                    dgvPlanchas.Columns["Candidatos"].Visible = false;

                if (dgvPlanchas.Columns["TotalVotos"] != null)
                    dgvPlanchas.Columns["TotalVotos"].Visible = false;

                if (dgvPlanchas.Columns["PorcentajeVotos"] != null)
                    dgvPlanchas.Columns["PorcentajeVotos"].Visible = false;

                if (dgvPlanchas.Columns["LogUrl"] != null)
                    dgvPlanchas.Columns["LogUrl"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar planchas: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnVotar_Click(object sender, EventArgs e)
        {
            if (_planchaSeleccionadaId == null)
            {
                MessageBox.Show(
                    "Selecciona una plancha de la lista antes de votar.",
                    "Sin selección",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            EjecutarVoto(_planchaSeleccionadaId);
        }

        private void dgvPlanchas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvPlanchas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPlanchas.SelectedRows.Count == 0) return;

            var planchaSeleccionada =
                (Plancha)dgvPlanchas.SelectedRows[0].DataBoundItem;

            _planchaSeleccionadaId = planchaSeleccionada.PlanchaId;

            // Mostramos el nombre para que el votante sepa qué seleccionó
            // Ajusta lblPlanchaSeleccionada al nombre real de tu Label
            lblPlanchaSeleccionada.Text =
                $"Plancha seleccionada: {planchaSeleccionada.Nombre}";
        }

        private void btnVotoNulo_Click(object sender, EventArgs e)
        {
            EjecutarVoto(null);
        }

        private void EjecutarVoto(int? planchaId)
        {
            // Construimos el mensaje de confirmación según el tipo de voto
            string mensaje = planchaId == null
                ? "¿Confirmas que deseas emitir un VOTO NULO?\n\nEsta acción es IRREVERSIBLE."
                : $"¿Confirmas tu voto por la plancha seleccionada?\n\nEsta acción es IRREVERSIBLE.";

            var respuesta = MessageBox.Show(
                mensaje,
                "Confirmar voto",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (respuesta != DialogResult.Yes) return;

            try
            {
                // El controller aplica TODAS las reglas de negocio:
                // 1. ¿Votación activa?
                // 2. ¿Dentro del horario?
                // 3. ¿Ya votó?
                // 4. ¿Plancha del padrón correcto?
                // Si todo pasa, ejecuta la transacción de dos inserts.
                _votacionCtrl.EmitirVoto(Sesion.UsuarioActual, planchaId);

                MessageBox.Show(
                    "¡Tu voto fue registrado exitosamente!\nGracias por participar.",
                    "Voto registrado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Deshabilitamos los botones — el usuario no debe poder
                // intentar votar de nuevo en esta sesión
                btnVotar.Enabled = false;
                btnVotoNulo.Enabled = false;
                dgvPlanchas.Enabled = false;

                // Mostramos los resultados parciales
                new PanelVotaciones().Show();
                this.Close();
            }
            catch (InvalidOperationException ex)
            {
                // Estas son las excepciones de reglas de negocio que
                // lanzamos intencionalmente en el controller.
                // Son mensajes que el usuario puede entender.
                MessageBox.Show(ex.Message,
                    "Voto no permitido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Errores técnicos inesperados (conexión, SQL, etc.)
                MessageBox.Show(
                    $"Error técnico al registrar el voto: {ex.Message}",
                    "Error del sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}