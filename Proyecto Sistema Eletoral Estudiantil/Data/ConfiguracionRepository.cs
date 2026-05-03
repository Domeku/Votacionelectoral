using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Models;

namespace Data
{
    public class ConfiguracionRepository
    {
        public ConfiguracionVotacion ObtenerActiva(int padronID)
        {
            string sql = @"
                SELECT TOP 1 ConfigID, FechaInicio, FechaFin, VotacionActiva, PadronID
                FROM ConfiguracionVotacion
                WHERE PadronID = @PadronID AND VotacionActiva = 1
                ORDER BY FechaInicio DESC";

            using var conn = Conexion.instancia.ObtenerConexion();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@PadronID", padronID);
            conn.Open();
            using var reader = cmd.ExecuteReader();

            if (!reader.Read()) return null;

            return new ConfiguracionVotacion
            {
                ConfigID = (int)reader["ConfigID"],
                FechaInicio = (System.DateTime)reader["FechaInicio"],
                FechaFin = (System.DateTime)reader["FechaFin"],
                VotacionActiva = (bool)reader["VotacionActiva"],
                PadronID = (int)reader["PadronID"]
            };
        }

        public void Crear(ConfiguracionVotacion config)
        {
            string sql = @"
                INSERT INTO ConfiguracionVotacion 
                    (FechaInicio, FechaFin, VotacionActiva, PadronID)
                VALUES 
                    (@FechaInicio, @FechaFin, @VotacionActiva, @PadronID)";

            using var conn = Conexion.instancia.ObtenerConexion();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@FechaInicio", config.FechaInicio);
            cmd.Parameters.AddWithValue("@FechaFin", config.FechaFin);
            cmd.Parameters.AddWithValue("@VotacionActiva", config.VotacionActiva);
            cmd.Parameters.AddWithValue("@PadronID", config.PadronID);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void CerrarVotacion(int configID)
        {
            string sql = @"
                UPDATE ConfiguracionVotacion 
                SET VotacionActiva = 0 
                WHERE ConfigID = @ConfigID";

            using var conn = Conexion.instancia.ObtenerConexion();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ConfigID", configID);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
