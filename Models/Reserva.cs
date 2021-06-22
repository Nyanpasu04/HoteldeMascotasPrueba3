using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoteldeMascotas.Models
{
    public class Reserva
    {
        public int ReservaId { get; set; }
        public String TipoReserva { get; set; }
        public String Costo { get; set; }
        public TimeSpan Duracion { get; set; }
    }
}
