using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Models;

namespace Data
{
    public class VotoRepository
    {
        public void RegistrarVoto(int? planchaID, int padronID, int usuarioID)
        {
            using var conn = Conexion.instancia.ObtenerConexion();
            conn.Open();

            // BeginTransaction inicia el "sobre" que envuelve los dos inserts
            using var transaccion = conn.BeginTransaction();

            try
            {
                // ─── INSERT 1: Voto anónimo ───────────────────────────
                // Este insert NO tiene UsuarioID. No se puede saber
                // quién votó mirando solo esta tabla.
                string sqlVoto = @"
                    INSERT INTO Votos (PlanchaID, PadronID)
                    OUTPUT INSERTED.VotoID
                    VALUES (@PlanchaID, @PadronID)";

                using var cmdVoto = new SqlCommand(sqlVoto, conn, transaccion);

                // Si planchaID es null (voto nulo), guardamos DBNull.Value
                // DBNull.Value es la representación de NULL en SQL desde C#
                cmdVoto.Parameters.AddWithValue("@PlanchaID",
                    planchaID.HasValue ? (object)planchaID.Value : DBNull.Value);
                cmdVoto.Parameters.AddWithValue("@PadronID", padronID);

                // OUTPUT INSERTED.VotoID nos devuelve el ID recién creado
                int nuevoVotoID = (int)cmdVoto.ExecuteScalar();

                // ─── INSERT 2: Auditoría ──────────────────────────────
                // Este insert sí tiene UsuarioID pero NO tiene PlanchaID.
                // Sabemos quién votó, pero no por quién. Voto secreto intacto.
                string sqlAudit = @"
                    INSERT INTO VotosAudit (VotoID, UsuarioID)
                    VALUES (@VotoID, @UsuarioID)";

                using var cmdAudit = new SqlCommand(sqlAudit, conn, transaccion);
                cmdAudit.Parameters.AddWithValue("@VotoID", nuevoVotoID);
                cmdAudit.Parameters.AddWithValue("@UsuarioID", usuarioID);
                cmdAudit.ExecuteNonQuery();

                // Si llegamos aquí sin excepción, confirmamos ambos inserts
                transaccion.Commit();
            }
            catch
            {
                // Si algo salió mal, deshacemos TODO
                transaccion.Rollback();
                // Re-lanzamos la excepción para que el Controller la maneje
                throw;
            }
        }

        // ─────────────────────────────────────────────────────────────
        // LEER: Total de votos emitidos en un padrón
        // ────────────────────────────────────────────────────────────

        public int TotalVotos(int padronID)
        {
            string sql = "SELECT COUNT(*) FROM Votos WHERE PadronID = @PadronID";
            using var conn = Conexion.instancia.ObtenerConexion();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@PadronID", padronID);
            conn.Open();
            return (int)cmd.ExecuteScalar();
        }

        // ─────────────────────────────────────────────────────────────
        // LEER: Total de votos NULOS en un padrón
        // Un voto nulo es aquel donde PlanchaID IS NULL
        // ─────────────────────────────────────────────────────────────
        public int VotosNulos(int padronID)
        {
            string sql = "SELECT COUNT(*) FROM Votos WHERE PadronID = @PadronID AND PlanchaID IS NULL";
            using var conn = Conexion.instancia.ObtenerConexion();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@PadronID", padronID);
            conn.Open();
            return (int)cmd.ExecuteScalar();
        }

        public int TotalVotosPorNombrePlancha(string nombrePlancha)
        {
            string sql = @"
        SELECT COUNT(*) 
        FROM Votos v
        JOIN Planchas p ON p.PlanchaID = v.PlanchaID
        WHERE p.Nombre = @Nombre";

            using var conn = Conexion.instancia.ObtenerConexion();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Nombre", nombrePlancha);
            conn.Open();
            return (int)cmd.ExecuteScalar();
        }

        public int TotalVotosGlobal()
        {
            string sql = "SELECT COUNT(*) FROM Votos";
            using var conn = Conexion.instancia.ObtenerConexion();
            using var cmd = new SqlCommand(sql, conn);
            conn.Open();
            return (int)cmd.ExecuteScalar();
        }

        public int TotalVotosNulosGlobal()
        {
            string sql = "SELECT COUNT(*) FROM Votos WHERE PlanchaID IS NULL";
            using var conn = Conexion.instancia.ObtenerConexion();
            using var cmd = new SqlCommand(sql, conn);
            conn.Open();
            return (int)cmd.ExecuteScalar();
        }
    }
}
