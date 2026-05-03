using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Models;

namespace Controllers
{
    public class VotacionController
    {
        // Este Controller necesita tres repositorios para hacer su trabajo.
        // Cada uno tiene una responsabilidad específica.
        private readonly UsuarioRepository _usuarioRepo = new UsuarioRepository();
        private readonly VotoRepository _votoRepo = new VotoRepository();
        private readonly PlanchaRepository _planchaRepo = new PlanchaRepository();
        private readonly ConfiguracionRepository _configRepo = new ConfiguracionRepository();

        // ═══════════════════════════════════════════════════════════════
        // REGLA #1: Verificar si la votación está abierta para un padrón
        //
        // Devuelve la configuración activa, o null si no hay votación abierta.
        // ═══════════════════════════════════════════════════════════════
        public ConfiguracionVotacion ObtenerVotacionActiva(int padronID)
        {
            return _configRepo.ObtenerActiva(padronID);
        }

        // ═══════════════════════════════════════════════════════════════
        // MÉTODO CENTRAL: Emitir un voto
        //
        // Este método aplica TODAS las reglas antes de registrar el voto.
        // Si alguna regla falla, lanza una excepción con el mensaje exacto
        // del problema. El formulario captura esa excepción y la muestra.
        //
        // ¿Por qué excepciones y no bool? Porque un bool solo dice
        // "falló", pero no dice POR QUÉ falló. Con excepciones, el mensaje
        // de error llega exacto hasta el formulario sin código extra.
        // ═══════════════════════════════════════════════════════════════
        public void EliminarPlancha(int planchaId)
        {
            _planchaRepo.Eliminar(planchaId);
        }
        public void EmitirVoto(Usuario votante, int? planchaId)
        {
            // ── REGLA 1: ¿Está la votación activa? ───────────────────
            var config = _configRepo.ObtenerActiva(votante.PadronId);

            if (config == null)
                throw new InvalidOperationException(
                    "No hay una votación activa para tu padrón en este momento.");

            // ── REGLA 2: ¿Estamos dentro del horario? ────────────────
            // Comparamos UTC con UTC — nunca mezclamos zonas horarias.
            if (DateTime.UtcNow < config.FechaInicio || DateTime.UtcNow > config.FechaFin)
                throw new InvalidOperationException(
                    "La votación está fuera del horario permitido.");

            // ── REGLA 3: ¿El usuario ya votó? ────────────────────────
            // Consultamos VotosAudit (no Votos) para mantener el secreto.
            // VotosAudit sabe QUIÉN votó, Votos sabe POR QUIÉN.
            bool yaVoto = _usuarioRepo.YaVoto(votante.UsuarioID);

            if (yaVoto)
                throw new InvalidOperationException(
                    "Ya ejerciste tu voto. No puedes votar dos veces.");

            // ── REGLA 4: ¿La plancha pertenece al padrón del votante? ─
            // Solo aplica si no es voto nulo (planchaId != null).
            // Esto evita que alguien vote por una plancha de otro padrón.
            if (planchaId.HasValue)
            {
                var plancha = _planchaRepo.ObtenerPorID(planchaId.Value);

                if (plancha == null)
                    throw new InvalidOperationException(
                        "La plancha seleccionada no existe.");

                // Comparamos el padrón de la plancha con el padrón del votante
                if (plancha.PadronId != votante.PadronId)
                    throw new InvalidOperationException(
                        "No puedes votar por una plancha de otro padrón.");
            }

            // ── TODAS LAS REGLAS PASARON: Registrar el voto ───────────
            // El repositorio hace DOS inserts en una sola transacción:
            // - Votos: guarda PlanchaID + PadronID (anónimo, sin UsuarioID)
            // - VotosAudit: guarda VotoID + UsuarioID (sin PlanchaID)
            // Si cualquiera falla, los dos se revierten automáticamente.
            _votoRepo.RegistrarVoto(planchaId, votante.PadronId, votante.UsuarioID);
        }

        public void ActualizarPlancha(Plancha p)
        {
            if (string.IsNullOrWhiteSpace(p.Nombre))
                throw new ArgumentException("La plancha debe tener un nombre.");

            _planchaRepo.Actualizar(p);
        }

        public void ActualizarPlanchaCompleta(Plancha p, string presidente,
            string vice, string secretario, string tesorero)
        {
            if (string.IsNullOrWhiteSpace(p.Nombre))
                throw new ArgumentException("La plancha debe tener un nombre.");

            var nombres = new[] { presidente, vice, secretario, tesorero };
            var puestos = new[] { "Presidente", "VicePresidente",
                          "Secretario General", "Tesorero" };

            for (int i = 0; i < nombres.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(nombres[i])) continue;

                for (int j = 0; j < nombres.Length; j++)
                {
                    if (i == j) continue;
                    if (nombres[i].Trim().ToLower() == nombres[j].Trim().ToLower())
                        throw new InvalidOperationException(
                            $"{nombres[i]} no puede tener 2 roles en la misma plancha.\n" +
                            $"Aparece como {puestos[i]} y {puestos[j]}.");
                }

                var (existe, plancha, puesto) =
                    _planchaRepo.CandidatoYaExiste(nombres[i].Trim(), p.PlanchaId, puestos[i]);

                if (existe)
                    throw new InvalidOperationException(
                        $"{nombres[i]} ya es {puesto} de la plancha '{plancha}'.\n" +
                        $"Una persona no puede tener 2 roles.");
            }

            // Actualizamos eslogan y nombre de esta plancha
            _planchaRepo.Actualizar(p);

            // Actualizamos candidatos directamente por PlanchaID y Puesto
            // Esto afecta solo esta plancha específica
            _planchaRepo.ActualizarCandidato(presidente.Trim(), "Presidente", p.PlanchaId);
            _planchaRepo.ActualizarCandidato(vice.Trim(), "VicePresidente", p.PlanchaId);
            _planchaRepo.ActualizarCandidato(secretario.Trim(), "Secretario General", p.PlanchaId);
            _planchaRepo.ActualizarCandidato(tesorero.Trim(), "Tesorero", p.PlanchaId);
        }

        public bool UsuarioYaVoto(int usuarioID)
        {
            return _usuarioRepo.YaVoto(usuarioID);
        }

        // ═══════════════════════════════════════════════════════════════
        // LEER: Obtener las planchas disponibles para el votante
        //
        // Solo muestra las planchas del padrón al que pertenece el votante.
        // Un votante del Padrón 1 nunca verá las planchas del Padrón 2.
        // ═══════════════════════════════════════════════════════════════
        public List<Plancha> ObtenerPlanchasPorPadron(int padronId)
        {
            return _planchaRepo.ObtenerPorPadron(padronId);
        }

        // ═══════════════════════════════════════════════════════════════
        // ADMIN: Crear o cerrar configuración de votación
        // ═══════════════════════════════════════════════════════════════
        public void AbrirVotacion(ConfiguracionVotacion config)
        {
            // Validación básica antes de guardar
            if (config.FechaFin <= config.FechaInicio)
                throw new ArgumentException(
                    "La fecha de cierre debe ser posterior a la de inicio.");

            _configRepo.Crear(config);
        }

        public void CerrarVotacion(int configId)
        {
            _configRepo.CerrarVotacion(configId);
        }

        // ═══════════════════════════════════════════════════════════════
        // ADMIN: Registrar una plancha y sus candidatos
        // ═══════════════════════════════════════════════════════════════
        public void RegistrarPlancha(Plancha plancha)
        {
            if (string.IsNullOrWhiteSpace(plancha.Nombre))
                throw new ArgumentException("La plancha debe tener un nombre.");

            // Primero guardamos la plancha y obtenemos su ID generado
            int nuevoId = _planchaRepo.Registrar(plancha);

            // Luego guardamos cada candidato usando ese ID
            foreach (var candidato in plancha.Candidatos)
            {
                candidato.PlanchaID = nuevoId;
                _planchaRepo.AgregarCandidato(candidato);
            }
        }
    }
}
