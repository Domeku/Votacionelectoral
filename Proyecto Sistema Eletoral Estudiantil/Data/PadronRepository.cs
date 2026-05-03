using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Microsoft.Data.SqlClient;

namespace Data
{
    public class PadronRepository
    {
        public List<Padron> ObtenerTodos()
        {
            var lista = new List<Padron>();
            string sql = "SELECT PadronID, Nombre FROM Padrones ORDER BY Nombre";

            using var conn = Conexion.instancia.ObtenerConexion();
            using var cmd = new SqlCommand(sql, conn);
            conn.Open();
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
                lista.Add(new Padron
                {
                    PadronID = (int)reader["PadronID"],
                    Nombre = reader["Nombre"].ToString()
                });

            return lista;
        }

        public void Registrar(Padron p)
        {
            string sql = "INSERT INTO Padrones (Nombre) VALUES (@Nombre)";
            using var conn = Conexion.instancia.ObtenerConexion();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}