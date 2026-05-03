using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Models;
using System.Text;

namespace Controllers
{
    public class AuthController
    {
        // El Controller tiene una instancia del repositorio que necesita.
        // No crea conexiones directamente — le pide al repositorio que lo haga.
        // Esto es la "inyección de dependencia" más simple posible.
        private readonly UsuarioRepository _usuarioRepo = new UsuarioRepository();

        // ═══════════════════════════════════════════════════════════════
        // MÉTODO PRINCIPAL: Intentar iniciar sesión
        //
        // Devuelve el objeto Usuario completo si el login es correcto.
        // Devuelve null si la matrícula no existe o la contraseña es incorrecta.
        // El formulario de Login usará null para saber si debe mostrar un error.
        // ═══════════════════════════════════════════════════════════════
        public Usuario Login(string matricula, string contrasenaIngresada)
        {
            // PASO 1: Buscar si existe alguien con esa matrícula.
            // El repositorio devuelve null si no encuentra ningún usuario.
            var usuario = _usuarioRepo.ObtenerPorMatricula(matricula);

            // Si no existe el usuario, terminamos aquí.
            // No decimos "matrícula incorrecta" ni "contraseña incorrecta"
            // por separado — eso daría información útil a alguien malintencionado.
            if (usuario == null)
                return null;

            // PASO 2: Verificar la contraseña.
            // En la BD tenemos byte[] (VARBINARY). BCrypt necesita un string.
            // Encoding.UTF8.GetString convierte byte[] → string.
            string hashGuardado = Encoding.UTF8.GetString(usuario.Contrasena);

            // BCrypt.Verify compara la contraseña que escribió el usuario
            // contra el hash guardado. Nunca "descifra" — solo compara.
            // Devuelve true si coinciden, false si no.
            bool contrasenaCorrecta = BCrypt.Net.BCrypt.Verify(contrasenaIngresada, hashGuardado);

            if (!contrasenaCorrecta)
                return null;

            // PASO 3: Si todo está bien, devolvemos el usuario completo.
            // El formulario usará usuario.RolNombre para decidir
            // si abre el menú de Admin o el menú de Votante.
            return usuario;
        }

        // ═══════════════════════════════════════════════════════════════
        // MÉTODO AUXILIAR: Registrar un nuevo usuario con contraseña segura
        //
        // Este método lo usará el formulario de Padrón cuando el Admin
        // registre un nuevo votante. El Admin escribe la contraseña inicial
        // y este método la convierte en hash antes de guardarla.
        // ═══════════════════════════════════════════════════════════════
        public void RegistrarUsuario(Usuario u, string contrasenaNueva)
        {
            // BCrypt.HashPassword genera el hash con salt automático.
            // WorkFactor = 12 significa que tarda ~250ms en calcularse.
            // Eso es imperceptible para el usuario, pero hace que un
            // atacante que intente millones de contraseñas tarde años.
            string hash = BCrypt.Net.BCrypt.HashPassword(contrasenaNueva, workFactor: 12);

            // Convertimos el hash (string) a byte[] para guardarlo en VARBINARY
            byte[] hashBytes = Encoding.UTF8.GetBytes(hash);

            // El repositorio recibe el usuario Y los bytes — él no sabe
            // nada de BCrypt, solo guarda lo que le mandamos.
            _usuarioRepo.Registrar(u, hashBytes);
        }
    }
}