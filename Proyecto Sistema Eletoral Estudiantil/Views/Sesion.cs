using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Views
{
    public static class Sesion
    {
        public static Usuario UsuarioActual { get; set; }

        public static void Cerrar()
        {
            UsuarioActual = null;
        }
    }
}
