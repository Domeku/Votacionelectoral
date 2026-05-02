using System;
using System.Windows.Forms;

namespace Views
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Esta línea es la que abre tu formulario de Login
            Application.Run(new Login());
        }
    }
}