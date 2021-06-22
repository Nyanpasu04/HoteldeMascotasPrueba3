namespace HoteldeMascotas.Models
{
    public class Mascotas
    {
        public int MascotasId { get; set; }
        public string NombreMascota { get; set; }
        public string Raza { get; set; }
        public int Años { get; set; }
        public bool Vacunas { get; set; }
        public int DueñosID { get; set; }
    }
}
