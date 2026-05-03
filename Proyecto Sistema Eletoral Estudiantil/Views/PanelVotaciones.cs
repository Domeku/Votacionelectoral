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

                // Votos de la mesa del usuario actual
                lblTotalVotosRealizados.Text = _estadCtrl.ObtenerTotalVotos(padronId).ToString();
                lblVotosNulos.Text = _estadCtrl.ObtenerVotosNulos(padronId).ToString();

                // Total global sumando todas las mesas
                lblTotalGlobal.Text = _estadCtrl.ObtenerTotalVotosGlobal().ToString();

                // Resultados globales sumando votos de todas las mesas por plancha
                var resultados = _estadCtrl.ObtenerResultadosGlobales();
                dgvResultados.DataSource = resultados;

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
            string[] columnasOcultas = {
        "PlanchaId", "PadronId", "Candidatos",
        "PorcentajeVotos", "LogUrl"
        // TotalVotos ya NO está aquí — lo queremos visible
    };

            foreach (var col in columnasOcultas)
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