using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HASRental.Models
{
    public class Rezervacija
    {
        public int Id { get; set; }
        [Display(Name ="Pocetna Lokacija")]
        public int? PocetnaLokacijaId { get; set; }
        [Display(Name = "Krajnja Lokacija")]
        public int? KrajnjaLokacijaId { get; set; }
        [Display(Name = "Kategorija Vozila")]
        public int? VoziloKategorijaId { get; set; }
        public int? KorisnikId { get; set; }
        [ForeignKey("PocetnaLokacijaId")]
        [Display(Name = "Pocetna Lokacija")]
        public virtual Lokacija PocetnaLokacija { get; set; }
        [ForeignKey("KrajnjaLokacijaId")]
        [Display(Name = "Krajnja Lokacija")]
        public virtual Lokacija KrajnjaLokacija { get; set; }
        [ForeignKey("VoziloKategorijaId")]
        [Display(Name = "Kategorija Vozila")]
        public virtual VoziloKategorija VoziloKategorija { get; set; }
        [ForeignKey("KorisnikId")]
        public virtual Korisnik Korisnik { get; set; }
    }
}
