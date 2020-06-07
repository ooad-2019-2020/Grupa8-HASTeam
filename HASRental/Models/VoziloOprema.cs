using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations;
=======
>>>>>>> d03d76121a57b714259ed968a9ff12bff5050e24
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HASRental.Models
{
    public class VoziloOprema
    {
        public int Id { get; set; }
        public int? VoziloId { get; set; }
<<<<<<< HEAD
        [Display(Name = "Opis opreme")]
=======
>>>>>>> d03d76121a57b714259ed968a9ff12bff5050e24
        public string OpisOpreme { get; set; }
        [ForeignKey("VoziloId")]
        public virtual Vozilo Vozilo { get; set; }
    }
}
