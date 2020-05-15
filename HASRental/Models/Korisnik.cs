using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HASRental.Models
{
    public class Korisnik:IdentityUser<int>
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodenja { get; set; }
        public string BrojVozacke { get; set; }
        public DateTime DatumIzdavanjaVozacke { get; set; }
    }
}
