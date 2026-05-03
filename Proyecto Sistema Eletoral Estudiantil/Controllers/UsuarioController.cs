using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Models;


namespace Controllers
{
    public class UsuarioController
    {
        private readonly UsuarioRepository _usuarioRepo = new UsuarioRepository();
        private readonly PadronRepository _padronRepo = new PadronRepository();
        private readonly AuthController _authCtrl = new AuthController();

        // Trae todos los usuarios para mostrar en el DataGridView del Padrón
        public List<Usuario> ObtenerTodos()
        {
            return _usuarioRepo.ObtenerTodos();
        }

        // Trae todos los padrones para llenar el ComboBox
        public List<Padron> ObtenerPadrones()
        {
            return _padronRepo.ObtenerTodos();
        }

        // Trae todos los roles para el ComboBox de rol
        public List<Rol> ObtenerRoles()
        {
            return _usuarioRepo.ObtenerRoles();
        }

        // Registra un nuevo usuario.
        // La validación ocurre AQUÍ, no en el formulario.
        public void Registrar(Usuario u, string contrasena)
        {
            if (string.IsNullOrWhiteSpace(u.Nombre))
                throw new System.ArgumentException("El nombre no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(u.Matricula))
                throw new System.ArgumentException("La matrícula no puede estar vacía.");

            if (string.IsNullOrWhiteSpace(contrasena) || contrasena.Length < 6)
                throw new System.ArgumentException(
                    "La contraseña debe tener al menos 6 caracteres.");

            // Delegamos el hash al AuthController —
            // este controller no sabe de BCrypt, esa es responsabilidad de Auth.
            _authCtrl.RegistrarUsuario(u, contrasena);
        }

        // Elimina un usuario por ID
        public void Eliminar(int usuarioId)
        {
            _usuarioRepo.Eliminar(usuarioId);
        }
    }
}
