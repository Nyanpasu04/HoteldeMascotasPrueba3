using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoteldeMascotas.Models
{
    public class Emails
    {

        [Display(Name = "ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }


        [Display(Name = "Por")]
        public string Por { get; set; }

        [Display(Name = "Para")]
        public string Para { get; set; }

        [Display(Name = "Asunto")]
        public string Asunto { get; set; }

        [Display(Name = "Mensaje")]
        public string Mensaje { get; set; }
    }
}

