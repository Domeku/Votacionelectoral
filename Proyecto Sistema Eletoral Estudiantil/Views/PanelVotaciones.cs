using Controllers;
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
    public partial class PanelVotaciones : Form
    {
        private readonly EstadisticasController _estadCtrl = new EstadisticasController();

        private readonly System.Windows.Forms.Timer _timer =
            new System.Windows.Forms.Timer();   
        public PanelVotaciones()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                
        }

        private void PanelVotaciones_Load(object sender, EventArgs e)
        {
            ActualizarPanel();
            IniciarCronometro();

            // Configuramos el timer para actualizar cada 30 segundos
            _timer.Interval = 30000;
            _timer.Tick += (s, args) => ActualizarPanel();
            _timer.Start();
        }

        private void ActualizarPanel()
        {
            try
            {
                int padronId = Sesion.UsuarioActual.PadronId;

                // Actualizamos los 3 KPI labels grandes
                // Ajusta lblTotalVotos, lblVotosNulos al nombre real de tus Labels
                lblTotalVotosRealizados.Text = _estadCtrl.ObtenerTotalVotos(padronId).ToString();
                lblVotosNulos.Text = _estadCtrl.ObtenerVotosNulos(padronId).ToString();

                // El cronómetro viene de la configuración — lo manejamos aparte
                // Actualizamos el DataGridView con resultados por plancha
                var resultados = _estadCtrl.ObtenerResultados(padronId);
                dgvResultados.DataSource = resultados;

                // Ocultamos columnas internas
                OcultarColumnasInternas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar panel: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OcultarColumnasInternas()
        {
            string[] columnaOcultas = {
                "PlanchaId", "PadronId", "Candidatos", "LogUrl"
            };

            foreach (var col in columnaOcultas)
                if (dgvResultados.Columns[col] != null)
                    dgvResultados.Columns[col].Visible = false;
        }

        private void IniciarCronometro()
        {
            try
            {
                var votacionCtrl = new VotacionController();
                var config = votacionCtrl.ObtenerVotacionActiva(
                    Sesion.UsuarioActual.PadronId);

                if (config == null)
                {
                    lblTiempoRestante.Text = "00:00:00";
                    return;
                }

                // Timer separado de 1 segundo para el cronómetro visual
                var timerCrono = new System.Windows.Forms.Timer();
                timerCrono.Interval = 1000;
                timerCrono.Tick += (s, e) =>
                {
                    var restante = config.TiempoRestante;
                    lblTiempoRestante.Text = restante.ToString(@"hh\:mm\:ss");

                    if (restante <= TimeSpan.Zero)
                    {
                        timerCrono.Stop();
                        lblTiempoRestante.Text = "CERRADA";
                    }
                };
                timerCrono.Start();
            }
            catch
            {
                lblTiempoRestante.Text = "00:00:00";
            }
        }

        private void PanelVotaciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            _timer.Stop();
            _timer.Dispose();
        }
    }
}