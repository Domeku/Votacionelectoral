using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Models;


namespace Controllers
{
    public class EstadisticasController
    {
        private readonly PlanchaRepository _planchaRepo = new PlanchaRepository();
        private readonly VotoRepository _votoRepo = new VotoRepository();
        private readonly UsuarioRepository _usuarioRepo = new UsuarioRepository();

        // ═══════════════════════════════════════════════════════════════
        // ESTADÍSTICAS COMPLETAS de un padrón
        //
        // Devuelve la lista de planchas con sus votos y porcentajes ya
        // calculados. El formulario solo tiene que mostrarlos.
        //
        // ¿Por qué calculamos aquí y no en el formulario?
        // Porque si mañana cambia la fórmula del porcentaje, lo cambias
        // en UN solo lugar — aquí — y todos los formularios que usen
        // este método se actualizan solos.
        // ═══════════════════════════════════════════════════════════════
        public List<Plancha> ObtenerResultados(int padronId)
        {
            // Traemos las planchas con sus candidatos
            var planchas = _planchaRepo.ObtenerPorPadron(padronId);

            // Traemos el conteo de votos por plancha:
            // { PlanchaID → cantidad }, con -1 = votos nulos
            var conteoVotos = _planchaRepo.ContarVotosPorPlancha(padronId);

            // Total de votos emitidos (incluyendo nulos)
            int totalVotos = _votoRepo.TotalVotos(padronId);

            // Asignamos TotalVotos y Porcentaje a cada plancha
            foreach (var plancha in planchas)
            {
                // Si no tiene votos aún, el diccionario devuelve 0
                plancha.TotalVotos = conteoVotos.ContainsKey(plancha.PlanchaId)
                    ? conteoVotos[plancha.PlanchaId]
                    : 0;

                // Calculamos el porcentaje solo si hay votos.
                // Sin este if, tendríamos división por cero si nadie ha votado.
                plancha.PorcentajeVotos = totalVotos > 0
                    ? (double)plancha.TotalVotos / totalVotos * 100
                    : 0;
            }

            // Ordenamos de mayor a menor votos para el ranking
            return planchas.OrderByDescending(p => p.TotalVotos).ToList();
        }

        // ═══════════════════════════════════════════════════════════════
        // KPIs para el Panel de Votaciones (los 3 números grandes)
        // ═══════════════════════════════════════════════════════════════
        public int ObtenerTotalVotos(int padronId)
        {
            return _votoRepo.TotalVotos(padronId);
        }

        public int ObtenerVotosNulos(int padronId)
        {
            return _votoRepo.VotosNulos(padronId);
        }

        public int ObtenerTotalPadron(int padronId)
        {
            // Cuenta cuántos usuarios pertenecen a este padrón
            var todos = _usuarioRepo.ObtenerTodos();
            return todos.Count(u => u.PadronId == padronId);
        }

        // ═══════════════════════════════════════════════════════════════
        // Porcentaje de participación
        // (cuántos del padrón ya votaron, no cuántos votos hubo)
        // ═══════════════════════════════════════════════════════════════
        public double ObtenerPorcentajeParticipacion(int padronId)
        {
            int totalPadron = ObtenerTotalPadron(padronId);
            if (totalPadron == 0) return 0;

            int votosEmitidos = ObtenerTotalVotos(padronId);
            return (double)votosEmitidos / totalPadron * 100;
        }

        // ═══════════════════════════════════════════════════════════════
        // Determina quién ganó (la plancha con más votos)
        // Devuelve null si nadie ha votado aún
        // ═══════════════════════════════════════════════════════════════
        public Plancha ObtenerGanador(int padronId)
        {
            var resultados = ObtenerResultados(padronId);

            // Si no hay resultados o la primera plancha tiene 0 votos,
            // la votación no ha comenzado — no hay ganador aún.
            if (resultados.Count == 0 || resultados[0].TotalVotos == 0)
                return null;

            return resultados[0]; // Ya están ordenados de mayor a menor
        }
    }
}
