using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string Matricula { get; set; }
        public string Curso { get; set; }
        public string Seccion { get; set; }
        public byte[] Contrasena { get; set; }
        public int RolId { get; set; }
        public int PadronId { get; set; }

        // Estas NO están en la tabla, pero las cargaremos
        // haciendo JOIN en SQL para no tener que hacer
        // consultas extra cada vez que necesitemos el nombre
        public string RolNombre { get; set; }
        public string PadronNombre { get; set; }

        // Esta tampoco está en la BD como columna.
        // La calcularemos consultando VotosAudit.
        // Es una propiedad "calculada" que usamos en la UI.
        public bool YaVoto { get; set; }
    }
}
