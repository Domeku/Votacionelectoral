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
    public partial class Reportes : Form
    {
        private readonly EstadisticasController _estadCtrl =
            new EstadisticasController();
        private readonly ReporteService _reporteService = new ReporteService();
        public Reportes()
        {
            InitializeComponent();
        }

        private void btnActaGanador_Click(object sender, EventArgs e)
        {
            try
            {
                var ganador = _estadCtrl.ObtenerGanadorGlobal(); // <-- global

                if (ganador == null)
                {
                    MessageBox.Show("Aún no hay votos registrados.",
                        "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int totalVotos = _estadCtrl.ObtenerTotalVotosGlobal(); // <-- global
                int totalPadron = _estadCtrl.ObtenerTotalPadron(
                    Sesion.UsuarioActual.PadronId);

                _reporteService.GenerarActaGanador(ganador, totalVotos, totalPadron);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnListaVotantes_Click(object sender, EventArgs e)
        {
            try
            {
                int padronId = Sesion.UsuarioActual.PadronId;
                var votantes = _estadCtrl.ObtenerReporteVotantes(padronId);

                if (votantes.Count == 0)
                {
                    MessageBox.Show("No hay estudiantes en el padrón.",
                        "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                _reporteService.GenerarListaVotantes(votantes);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar reporte: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReporteGeneral_Click(object sender, EventArgs e)
        {
            try
            {
                var resultados = _estadCtrl.ObtenerResultadosGlobales(); // <-- global
                int totalVotos = _estadCtrl.ObtenerTotalVotosGlobal();   // <-- global
                int totalPadron = _estadCtrl.ObtenerTotalPadron(
                    Sesion.UsuarioActual.PadronId);

                if (resultados.Count == 0)
                {
                    MessageBox.Show("No hay planchas registradas.",
                        "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                _reporteService.GenerarReporteGeneral(resultados, totalVotos, totalPadron);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
