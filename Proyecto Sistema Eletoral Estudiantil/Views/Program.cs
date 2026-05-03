using System;
using System.Windows.Forms;
using Controllers;
using Models;

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

            try
            {
                var ctrl = new AuthController();
                var admin = new Usuario
                {
                    Nombre = "damian",
                    Matricula = "damian26lp",
                    Curso = "6to Informatica",
                    Seccion = "B",
                    RolId = 1,
                    PadronId = 1
                };
                ctrl.RegistrarUsuario(admin, "admin123");
            }
            catch { }
            // Esta línea es la que abre tu formulario de Login
            Application.Run(new Login());
        }
    }
}