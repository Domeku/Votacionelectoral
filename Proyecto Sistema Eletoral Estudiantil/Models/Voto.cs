using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Voto
    {
        public int VotoId { get; set; }
        public int? PlanchaId { get; set; }
        public int PadronId { get; set; }
        public DateTime FechaVoto { get; set; }

        public bool EsVotoNulo => !PlanchaId.HasValue;
    }
}
