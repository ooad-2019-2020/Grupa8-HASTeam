using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HASRental.Models
{
    public class Korisnik:IdentityUser<int>
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        [Display(Name = "Datum rođenja")]
        public DateTime DatumRodenja { get; set; }
        [Display(Name = "Broj vozačke")]
        public string BrojVozacke { get; set; }
        [Display(Name = "Datum izdavanja vozačke")]
        public DateTime DatumIzdavanjaVozacke { get; set; }
        public Uloga Uloga { get; set; }
    }
}
