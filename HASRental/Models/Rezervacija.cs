using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HASRental.Models
{
    public class Rezervacija
    {
        public int Id { get; set; }
        public int? PocetnaLokacijaId { get; set; }
        public int? KrajnjaLokacijaId { get; set; }
        public int? VoziloKategorijaId { get; set; }
        public int? KorisnikId { get; set; }
        [ForeignKey("PocetnaLokacijaId")]
        public virtual Lokacija PocetnaLokacija { get; set; }
        [ForeignKey("KrajnjaLokacijaId")]
        public virtual Lokacija KrajnjaLokacija { get; set; }
        [ForeignKey("VoziloKategorijaId")]
        public virtual VoziloKategorija VoziloKategorija { get; set; }
        [ForeignKey("KorisnikId")]
        public virtual Korisnik Korisnik { get; set; }
    }
}
