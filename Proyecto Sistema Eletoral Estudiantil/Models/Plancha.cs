using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Plancha
    {
        public int PlanchaId { get; set; }
        public string Nombre { get; set; }
        public string Eslogan { get; set; }

        public string LogUrl { get; set; }
        public int PadronId { get; set; }

        public List<Candidato> Candidatos { get; set; }
        = new List<Candidato>();

        public int TotalVotos { get; set; }
        public double PorcentajeVotos { get; set; }
    }
}
