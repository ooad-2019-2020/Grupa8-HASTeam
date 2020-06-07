using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HASRental.Models
{
    public class Renta
    {
        public int Id { get; set; }
        public int? KorisnikId { get; set; }
        [Display(Name="Vozilo")]
        public int? VoziloId { get; set; }
        [Display(Name = "Pocetna Lokacija")]
        public int? PocetnaLokacijaId { get; set; }
        [Display(Name = "Krajnja Lokacija")]
        public int? KrajnjaLokacijaId { get; set; }
        [Display(Name = "Datum rentanja")]
        public DateTime DatumRentanja { get; set; }
        [Display(Name = "Datum vraćanja")]
        public DateTime DatumVracanja { get; set; }
        [Display(Name = "Dodatne naznake")]
        public string DodatneNaznake { get; set; }
        [Display(Name = "Tip rezervoara")]
        public int TipRezervoaraId { get; set; }
        [ForeignKey("KorisnikId")]
        public virtual Korisnik Korisnik { get; set; }
        [ForeignKey("VoziloId")]
        [Display(Name = "Vozilo")]
        public virtual Vozilo Vozilo { get; set; }
        [ForeignKey("PocetnaLokacijaId")]
        [Display(Name = "Pocetna Lokacija")]
        public virtual Lokacija PocetnaLokacija { get; set; }
        [ForeignKey("KrajnjaLokacijaId")]
        [Display(Name = "Krajnja Lokacija")]
        public virtual Lokacija KrajnjaLokacija { get; set; }
        [ForeignKey("TipRezervoaraId")]
        [Display(Name = "Tip rezervoara")]
        public virtual TipRezervoara TipRezervoara { get; set; }
    }
}
