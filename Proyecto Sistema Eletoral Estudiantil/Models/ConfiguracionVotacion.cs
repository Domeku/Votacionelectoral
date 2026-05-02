using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ConfiguracionVotacion
    {
        public int ConfigID { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool VotacionActiva { get; set; }
        public int PadronID { get; set; }

        public TimeSpan TiempoRestante
        {
            get
            {
                var restante = FechaFin - DateTime.UtcNow;
                return restante < TimeSpan.Zero
                    ? TimeSpan.Zero
                    : restante; 
            }
        }
    }
}
