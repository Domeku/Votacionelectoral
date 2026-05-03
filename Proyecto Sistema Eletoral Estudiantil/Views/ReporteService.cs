using ClosedXML.Excel;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Views
{
    // Esta clase no hereda de Form ni de nada especial.
    // Es una clase de servicio puro — solo tiene métodos que
    // reciben datos y generan archivos. No muestra nada en pantalla.
    public class ReporteService
    {
        // ═══════════════════════════════════════════════════════════════
        // REPORTE 1: Plancha Ganadora
        //
        // Recibe la plancha ganadora (ya calculada por el controller)
        // y genera un archivo de texto bien formateado.
        //
        // ¿Por qué texto y no solo mostrarlo en pantalla?
        // Porque el acta electoral es un documento oficial que debe
        // poder guardarse, imprimirse y entregarse. Un archivo de texto
        // puede abrirse en cualquier computadora sin software especial.
        // ═══════════════════════════════════════════════════════════════
        public void GenerarActaGanador(Plancha ganador, int totalVotos, int totalPadron)
        {
            // StringBuilder es como un "bloc de notas en memoria".
            // Es más eficiente que concatenar strings con + porque
            // no crea un string nuevo en cada operación.
            var sb = new StringBuilder();

            // Construimos el documento línea por línea
            sb.AppendLine("══════════════════════════════════════════════");
            sb.AppendLine("         ACTA OFICIAL DE RESULTADOS           ");
            sb.AppendLine("         SISTEMA ELECTORAL ESTUDIANTIL        ");
            sb.AppendLine("══════════════════════════════════════════════");
            sb.AppendLine($"Fecha de emisión: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            sb.AppendLine("──────────────────────────────────────────────");
            sb.AppendLine();
            sb.AppendLine("PLANCHA GANADORA:");
            sb.AppendLine($"  Nombre:     {ganador.Nombre}");
            sb.AppendLine($"  Eslogan:    {ganador.Eslogan}");
            sb.AppendLine($"  Votos:      {ganador.TotalVotos} votos");
            sb.AppendLine($"  Porcentaje: {ganador.PorcentajeVotos:F2}%");
            sb.AppendLine();
            sb.AppendLine("CANDIDATOS:");

            // Recorremos cada candidato de la plancha ganadora
            foreach (var candidato in ganador.Candidatos)
                sb.AppendLine($"  {candidato.Puesto,-20} {candidato.Nombre}");

            sb.AppendLine();
            sb.AppendLine("──────────────────────────────────────────────");
            sb.AppendLine("ESTADÍSTICAS GENERALES:");
            sb.AppendLine($"  Total del padrón:  {totalPadron} estudiantes");
            sb.AppendLine($"  Votos emitidos:    {totalVotos}");

            double participacion = totalPadron > 0
                ? (double)totalVotos / totalPadron * 100
                : 0;

            sb.AppendLine($"  Participación:     {participacion:F2}%");
            sb.AppendLine();
            sb.AppendLine("══════════════════════════════════════════════");
            sb.AppendLine("         FIN DEL ACTA OFICIAL                 ");
            sb.AppendLine("══════════════════════════════════════════════");

            // Abrimos el diálogo para que el usuario elija dónde guardar.
            // SaveFileDialog es un control de Windows Forms — muestra la
            // ventana estándar de "Guardar como" de Windows.
            GuardarArchivoTexto(sb.ToString(), "Acta_Ganador");
        }

        // ═══════════════════════════════════════════════════════════════
        // REPORTE 2: Lista de Votantes en Excel
        //
        // Genera un archivo .xlsx con todos los votantes y su estado.
        // ¿Por qué Excel aquí y no texto?
        // Porque una lista de personas se lee mucho mejor en tabla,
        // permite ordenar columnas y hacer filtros — funciones naturales
        // de Excel que serían difíciles de replicar en texto plano.
        // ═══════════════════════════════════════════════════════════════
        public void GenerarListaVotantes(List<Usuario> votantes)
        {
            // Workbook = el archivo Excel completo
            // Worksheet = una hoja dentro del archivo
            using var workbook = new XLWorkbook();
            var hoja = workbook.Worksheets.Add("Votantes");

            // ── Encabezados de columna ──
            // Las celdas en Excel se referencian por fila y columna (números)
            // Fila 1, columnas 1 al 6
            hoja.Cell(1, 1).Value = "N°";
            hoja.Cell(1, 2).Value = "Nombre";
            hoja.Cell(1, 3).Value = "Matrícula";
            hoja.Cell(1, 4).Value = "Curso";
            hoja.Cell(1, 5).Value = "Sección";
            hoja.Cell(1, 6).Value = "Estado";

            // Aplicamos estilo a la fila de encabezados:
            // fondo azul marino, texto blanco, negrita
            var encabezado = hoja.Range("A1:F1");
            encabezado.Style.Fill.BackgroundColor =
                XLColor.FromArgb(27, 42, 74);
            encabezado.Style.Font.FontColor = XLColor.White;
            encabezado.Style.Font.Bold = true;

            // ── Datos fila por fila ──
            // Empezamos en la fila 2 (la 1 es el encabezado)
            int fila = 2;
            foreach (var votante in votantes)
            {
                hoja.Cell(fila, 1).Value = fila - 1;             // Número
                hoja.Cell(fila, 2).Value = votante.Nombre;
                hoja.Cell(fila, 3).Value = votante.Matricula;
                hoja.Cell(fila, 4).Value = votante.Curso;
                hoja.Cell(fila, 5).Value = votante.Seccion;
                hoja.Cell(fila, 6).Value = votante.YaVoto ? "✓ Votó" : "Pendiente";

                // Coloreamos la celda de estado según si votó o no
                // Verde claro si votó, rojo claro si no
                hoja.Cell(fila, 6).Style.Fill.BackgroundColor = votante.YaVoto
                    ? XLColor.FromArgb(198, 239, 206)   // verde suave
                    : XLColor.FromArgb(255, 199, 206);  // rojo suave

                fila++;
            }

            // Ajustamos el ancho de todas las columnas al contenido
            hoja.Columns().AdjustToContents();

            GuardarArchivoExcel(workbook, "Lista_Votantes");
        }

        // ═══════════════════════════════════════════════════════════════
        // REPORTE 3: Resultados Generales en Excel
        //
        // Muestra todas las planchas con sus votos y porcentajes,
        // ordenadas de mayor a menor (ranking).
        // ═══════════════════════════════════════════════════════════════
        public void GenerarReporteGeneral(List<Plancha> resultados, int totalVotos,
            int totalPadron)
        {
            using var workbook = new XLWorkbook();
            var hoja = workbook.Worksheets.Add("Resultados");

            // Título en la primera fila (fusionando celdas A1:E1)
            hoja.Cell(1, 1).Value = "REPORTE GENERAL DE VOTACIONES";
            hoja.Range("A1:E1").Merge();
            hoja.Cell(1, 1).Style.Font.Bold = true;
            hoja.Cell(1, 1).Style.Font.FontSize = 14;
            hoja.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            hoja.Cell(2, 1).Value = $"Generado: {DateTime.Now:dd/MM/yyyy HH:mm}";
            hoja.Range("A2:E2").Merge();

            // Encabezados en fila 4 (dejamos fila 3 como espacio)
            hoja.Cell(4, 1).Value = "Posición";
            hoja.Cell(4, 2).Value = "Plancha";
            hoja.Cell(4, 3).Value = "Eslogan";
            hoja.Cell(4, 4).Value = "Votos";
            hoja.Cell(4, 5).Value = "Porcentaje";

            var encabezado = hoja.Range("A4:E4");
            encabezado.Style.Fill.BackgroundColor = XLColor.FromArgb(27, 42, 74);
            encabezado.Style.Font.FontColor = XLColor.White;
            encabezado.Style.Font.Bold = true;

            // Datos — resultados ya vienen ordenados por votos descendente
            int fila = 5;
            int posicion = 1;
            foreach (var plancha in resultados)
            {
                hoja.Cell(fila, 1).Value = posicion;
                hoja.Cell(fila, 2).Value = plancha.Nombre;
                hoja.Cell(fila, 3).Value = plancha.Eslogan;
                hoja.Cell(fila, 4).Value = plancha.TotalVotos;
                hoja.Cell(fila, 5).Value = $"{plancha.PorcentajeVotos:F2}%";

                // La plancha ganadora (posición 1) va en amarillo
                if (posicion == 1)
                    hoja.Row(fila).Style.Fill.BackgroundColor =
                        XLColor.FromArgb(255, 242, 204);

                fila++;
                posicion++;
            }

            // Sección de resumen al final
            fila += 2;
            hoja.Cell(fila, 1).Value = "RESUMEN";
            hoja.Cell(fila, 1).Style.Font.Bold = true;
            fila++;
            hoja.Cell(fila, 1).Value = "Total del padrón:";
            hoja.Cell(fila, 2).Value = totalPadron;
            fila++;
            hoja.Cell(fila, 1).Value = "Votos emitidos:";
            hoja.Cell(fila, 2).Value = totalVotos;
            fila++;
            hoja.Cell(fila, 1).Value = "Participación:";
            hoja.Cell(fila, 2).Value = totalPadron > 0
                ? $"{(double)totalVotos / totalPadron * 100:F2}%"
                : "0%";

            hoja.Columns().AdjustToContents();
            GuardarArchivoExcel(workbook, "Reporte_General");
        }

        // ═══════════════════════════════════════════════════════════════
        // MÉTODOS PRIVADOS DE APOYO
        // Estos métodos manejan la parte técnica de guardar archivos.
        // Están separados para no repetir código en cada reporte.
        // ═══════════════════════════════════════════════════════════════

        private void GuardarArchivoTexto(string contenido, string nombreSugerido)
        {
            // SaveFileDialog muestra la ventana estándar de Windows "Guardar como"
            using var dlg = new SaveFileDialog();
            dlg.Title = "Guardar reporte";
            dlg.FileName = $"{nombreSugerido}_{DateTime.Now:yyyyMMdd_HHmm}.txt";
            dlg.Filter = "Archivo de texto|*.txt";
            dlg.InitialDirectory = Environment.GetFolderPath(
                Environment.SpecialFolder.Desktop);

            // Si el usuario cancela el diálogo, no hacemos nada
            if (dlg.ShowDialog() != DialogResult.OK) return;

            // File.WriteAllText escribe el string completo en el archivo.
            // Encoding.UTF8 asegura que los acentos (á, é, ñ) se guarden bien.
            File.WriteAllText(dlg.FileName, contenido, Encoding.UTF8);

            // Abrimos el archivo automáticamente para que el usuario lo vea
            System.Diagnostics.Process.Start("notepad.exe", dlg.FileName);
        }

        private void GuardarArchivoExcel(XLWorkbook workbook, string nombreSugerido)
        {
            using var dlg = new SaveFileDialog();
            dlg.Title = "Guardar reporte Excel";
            dlg.FileName = $"{nombreSugerido}_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";
            dlg.Filter = "Excel|*.xlsx";
            dlg.InitialDirectory = Environment.GetFolderPath(
                Environment.SpecialFolder.Desktop);

            if (dlg.ShowDialog() != DialogResult.OK) return;

            // workbook.SaveAs guarda el archivo Excel en la ruta elegida
            workbook.SaveAs(dlg.FileName);

            // Abrimos Excel (o el programa predeterminado para .xlsx)
            System.Diagnostics.Process.Start(
                new System.Diagnostics.ProcessStartInfo
                {
                    FileName = dlg.FileName,
                    UseShellExecute = true   // Usa el programa predeterminado de Windows
                });
        }
    }
}