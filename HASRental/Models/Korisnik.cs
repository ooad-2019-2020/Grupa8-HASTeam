using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations;
=======
>>>>>>> d03d76121a57b714259ed968a9ff12bff5050e24
using System.Linq;
using System.Threading.Tasks;

namespace HASRental.Models
{
    public class Korisnik:IdentityUser<int>
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
<<<<<<< HEAD
        [Display(Name = "Datum rođenja")]
        public DateTime DatumRodenja { get; set; }
        [Display(Name = "Broj vozačke")]
        public string BrojVozacke { get; set; }
        [Display(Name = "Datum izdavanja vozačke")]
        public DateTime DatumIzdavanjaVozacke { get; set; }
        public Uloga Uloga { get; set; }
=======
        public DateTime DatumRodenja { get; set; }
        public string BrojVozacke { get; set; }
        public DateTime DatumIzdavanjaVozacke { get; set; }
>>>>>>> d03d76121a57b714259ed968a9ff12bff5050e24
    }
}
