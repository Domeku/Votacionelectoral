using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Data
{
    public class Conexion
    {
        private static readonly Conexion _instancia = new Conexion();
        private readonly string _connectionString = "Server=DAMIAN\\SQLEXPRESS;Database=Votacion;Integrated Security=true;TrustServerCertificate=true;";

        private Conexion() { }

        public static Conexion instancia => _instancia;

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
