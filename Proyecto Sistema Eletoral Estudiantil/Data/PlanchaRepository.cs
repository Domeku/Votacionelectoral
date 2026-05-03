using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Models;

namespace Data
{
    public class PlanchaRepository
    {
        public List<Plancha> ObtenerPorPadron(int padronId)
        {
            string sql = @"
            Select p.PlanchaId, p.Nombre, p.Eslogan, p.LogoURL, p.PadronID,
            c.CandidatoID, c.Nombre AS CandidatoNombre, c.Puesto
            From Planchas p
            Left Join Candidatos c ON c.PlanchaID = p.PlanchaID
            Where p.PadronID = @PadronID
            ORDER BY p.PlanchaID";

            var diccionario = new Dictionary <int, Plancha>();

            using var conn = Conexion.instancia.ObtenerConexion();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@PadronID", padronId);
            conn.Open();
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int planchaID = (int)reader["PlanchaID"];

                // ¿Ya procesamos esta plancha antes?
                if (!diccionario.ContainsKey(planchaID))
                {
                    // Primera vez que vemos esta plancha: la creamos
                    diccionario[planchaID] = new Plancha
                    {
                        PlanchaId = planchaID,
                        Nombre = reader["Nombre"].ToString(),
                        Eslogan = reader["Eslogan"]?.ToString(),
                        LogUrl = reader["LogoURL"]?.ToString(),
                        PadronId = (int)reader["PadronID"]
                    };
                }

                // ¿Esta fila tiene candidato? (LEFT JOIN puede traer NULL)
                if (reader["CandidatoID"] != DBNull.Value)
                {
                    diccionario[planchaID].Candidatos.Add(new Candidato
                    {
                        CandidatoID = (int)reader["CandidatoID"],
                        Nombre = reader["CandNombre"].ToString(),
                        Puesto = reader["Puesto"].ToString(),
                        PlanchaID = planchaID
                    });
                }
            }

            // Convertimos el Dictionary a List para devolverla
            return new List<Plancha>(diccionario.Values);
        }

        // ─────────────────────────────────────────────────────────────
        // LEER: Busca una plancha específica por su ID
        // Usado por el Controller para verificar que la plancha
        // pertenece al mismo padrón del votante.
        // ─────────────────────────────────────────────────────────────
        public Plancha ObtenerPorID(int planchaID)
        {
            string sql = "SELECT PlanchaID, Nombre, Eslogan, LogoURL, PadronID FROM Planchas WHERE PlanchaID = @ID";
            using var conn = Conexion.instancia.ObtenerConexion();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ID", planchaID);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;
            return new Plancha
            {
                PlanchaId = (int)reader["PlanchaID"],
                Nombre = reader["Nombre"].ToString(),
                Eslogan = reader["Eslogan"]?.ToString(),
                LogUrl = reader["LogoURL"]?.ToString(),
                PadronId = (int)reader["PadronID"]
            };
        }

        // ─────────────────────────────────────────────────────────────
        // CREAR: Registra una nueva plancha y devuelve su ID generado
        // "OUTPUT INSERTED.PlanchaID" es una instrucción SQL que retorna
        // el ID que SQL Server asignó automáticamente (IDENTITY).
        // Necesitamos ese ID para poder guardar los candidatos después.
        // ─────────────────────────────────────────────────────────────
        public int Registrar(Plancha p)
        {
            string sql = @"
                INSERT INTO Planchas (Nombre, Eslogan, LogoURL, PadronID)
                OUTPUT INSERTED.PlanchaID
                VALUES (@Nombre, @Eslogan, @LogoURL, @PadronID)";

            using var conn = Conexion.instancia.ObtenerConexion();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
            cmd.Parameters.AddWithValue("@Eslogan", (object)p.Eslogan ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@LogoURL", (object)p.LogUrl ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@PadronID", p.PadronId);
            conn.Open();

            // ExecuteScalar porque OUTPUT devuelve exactamente un valor
            return (int)cmd.ExecuteScalar();
        }

        // ─────────────────────────────────────────────────────────────
        // CREAR: Agrega un candidato a una plancha existente
        // ─────────────────────────────────────────────────────────────
        public void AgregarCandidato(Candidato c)
        {
            string sql = @"
                INSERT INTO Candidatos (Nombre, Puesto, PlanchaID)
                VALUES (@Nombre, @Puesto, @PlanchaID)";

            using var conn = Conexion.instancia.ObtenerConexion();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Nombre", c.Nombre);
            cmd.Parameters.AddWithValue("@Puesto", c.Puesto);
            cmd.Parameters.AddWithValue("@PlanchaID", c.PlanchaID);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        // ─────────────────────────────────────────────────────────────
        // LEER: Cuántos votos tiene cada plancha en un padrón
        // Devuelve un diccionario: PlanchaID → cantidad de votos
        // -1 como clave especial representa los votos nulos (PlanchaID NULL)
        // ─────────────────────────────────────────────────────────────
        public Dictionary<int, int> ContarVotosPorPlancha(int padronID)
        {
            string sql = @"
                SELECT PlanchaID, COUNT(*) AS Total
                FROM Votos
                WHERE PadronID = @PadronID
                GROUP BY PlanchaID";

            var resultado = new Dictionary<int, int>();
            using var conn = Conexion.instancia.ObtenerConexion();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@PadronID", padronID);
            conn.Open();
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                // PlanchaID puede ser NULL (voto nulo). Usamos -1 como clave para nulos.
                int clave = reader["PlanchaID"] == DBNull.Value
                    ? -1
                    : (int)reader["PlanchaID"];
                resultado[clave] = (int)reader["Total"];
            }
            return resultado;
        }
    }
}