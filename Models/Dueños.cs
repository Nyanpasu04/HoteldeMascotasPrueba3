using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoteldeMascotas.Models
{
    public class Dueños
    {
        
        public int DueñosID { get; set; }
        public string NombreDueño { get; set; }
        public string Rut { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public int ReservaID { get; set; }
        ICollection<Mascotas> Mascota { get; set; }
    }
}
