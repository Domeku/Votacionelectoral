using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Models;
using System;

namespace Data
{
    public class UsuarioRepository
    {

        public Usuario ObtenerPorMatricula(string matricula)
        {
            string sql = @"
                SELECT u.UsuarioID, u.Nombre, u.Matricula, u.Curso,
                       u.Seccion, u.Contraseña, u.RolID, u.PadronID,
                       r.Nombre AS RolNombre,
                       p.Nombre AS PadronNombre
                FROM Usuarios u
                INNER JOIN Roles r ON r.RolID = u.RolID
                INNER JOIN Padrones p ON p.PadronID = u.PadronID
                WHERE u.Matricula = @Matricula";

            using var conn = Conexion.instancia.ObtenerConexion();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Matricula", matricula);

            conn.Open();
            using var reader = cmd.ExecuteReader();

            if (!reader.Read()) return null;

            return new Usuario
            {
                UsuarioID = (int)reader["UsuarioID"],
                Nombre = reader["Nombre"].ToString(),
                Matricula = reader["Matricula"].ToString(),
                Curso = reader["Curso"].ToString(),
                Seccion = reader["Seccion"].ToString(),
                Contrasena = (byte[])reader["Contraseña"],
                RolId = (int)reader["RolID"],
                RolNombre = reader["RolNombre"].ToString(),
                PadronId = (int)reader["PadronID"],
                PadronNombre = reader["PadronNombre"].ToString()
            };
        }

        public bool YaVoto(int usuarioID)
        {
            string sql = "SELECT COUNT(1) FROM VotosAudit WHERE UsuarioID = @UsuarioID";

            using var conn = Conexion.instancia.ObtenerConexion();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);
            conn.Open();

            int cantidad = (int)cmd.ExecuteScalar();
            return cantidad > 0;
        }

        public void Registrar(Usuario u, byte[] hashContrasena)
        {
            string sql = @"
Insert Into Usuarios (Nombre, Matricula, Curso, Seccion, Contraseña, RolID, PadronID)
VALUES (@Nombre, @Matricula, @Curso, @Seccion, @Contrasena, @RolID, @PadronID)";

            using var conn = Conexion.instancia.ObtenerConexion();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Nombre", u.Nombre);
            cmd.Parameters.AddWithValue("@Matricula", u.Matricula);
            cmd.Parameters.AddWithValue("@Curso", u.Curso);
            cmd.Parameters.AddWithValue("@Seccion", u.Seccion);
            cmd.Parameters.AddWithValue("@Contrasena", hashContrasena);
            cmd.Parameters.AddWithValue("@RolID", u.RolId);
            cmd.Parameters.AddWithValue("@PadronID", u.PadronId);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public List<Usuario> ObtenerTodos()
        {
            string sql = @"
                SELECT u.UsuarioID, u.Nombre, u.Matricula, u.Curso,
                       u.Seccion, u.RolID, u.PadronID,
                       r.Nombre AS RolNombre,
                       p.Nombre AS PadronNombre,
                       CASE WHEN va.UsuarioID IS NOT NULL THEN 1 ELSE 0 END AS YaVoto
                FROM Usuarios u
                INNER JOIN Roles r ON r.RolID = u.RolID
                INNER JOIN Padrones p ON p.PadronID = u.PadronID
                LEFT JOIN VotosAudit va ON va.UsuarioID = u.UsuarioID
                ORDER BY u.Nombre";

            var lista = new List<Usuario>();
            using var conn = Conexion.instancia.ObtenerConexion();
            using var cmd = new SqlCommand(sql, conn);
            conn.Open();
            using var reader = cmd.ExecuteReader();

            while (reader.Read()) // while porque son MUCHAS filas
            {
                lista.Add(new Usuario
                {
                    UsuarioID = (int)reader["UsuarioID"],
                    Nombre = reader["Nombre"].ToString(),
                    Matricula = reader["Matricula"].ToString(),
                    Curso = reader["Curso"].ToString(),
                    Seccion = reader["Seccion"].ToString(),
                    RolId = (int)reader["RolID"],
                    RolNombre = reader["RolNombre"].ToString(),
                    PadronId = (int)reader["PadronID"],
                    PadronNombre = reader["PadronNombre"].ToString(),
                    YaVoto = (int)reader["YaVoto"] == 1
                });
            }
            return lista;
        }

        public void Eliminar(int UsuarioID)
        {
            string sql = "DELETE FROM Usuarios WHERE UsuarioID = @UsuarioID";
            using var conn = Conexion.instancia.ObtenerConexion();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@UsuarioID", UsuarioID);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public List<Rol> ObtenerRoles()
        {
            var Lista = new List<Rol>();
            string sql = "Select RolID, Nombre From Roles";
            using var conn = Conexion.instancia.ObtenerConexion();
            using var cmd = new SqlCommand(sql, conn);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                Lista.Add(new Rol
                    {
                RolID = (int)reader["RolID"],
                    Nombre = reader["Nombre"].ToString()
                     });
            return Lista;
        }
    }
}
