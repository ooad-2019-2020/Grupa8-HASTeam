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
    public class Rezervacija
    {
        public int Id { get; set; }
<<<<<<< HEAD
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
=======
        public int? PocetnaLokacijaId { get; set; }
        public int? KrajnjaLokacijaId { get; set; }
        public int? VoziloKategorijaId { get; set; }
        public int? KorisnikId { get; set; }
        [ForeignKey("PocetnaLokacijaId")]
        public virtual Lokacija PocetnaLokacija { get; set; }
        [ForeignKey("KrajnjaLokacijaId")]
        public virtual Lokacija KrajnjaLokacija { get; set; }
        [ForeignKey("VoziloKategorijaId")]
>>>>>>> d03d76121a57b714259ed968a9ff12bff5050e24
        public virtual VoziloKategorija VoziloKategorija { get; set; }
        [ForeignKey("KorisnikId")]
        public virtual Korisnik Korisnik { get; set; }
    }
}
