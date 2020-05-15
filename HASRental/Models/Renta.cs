using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HASRental.Models
{
    public class Renta
    {
        public int Id { get; set; }
        public int? KorisnikId { get; set; }
        public int? VoziloId { get; set; }
        public int? PocetnaLokacijaId { get; set; }
        public int? KrajnjaLokacijaId { get; set; }
        public DateTime DatumRentanja { get; set; }
        public DateTime DatumVracanja { get; set; }
        public string DodatneNaznake { get; set; }
        public int TipRezervoaraId { get; set; }
        [ForeignKey("KorisnikId")]
        public virtual Korisnik Korisnik { get; set; }
        [ForeignKey("VoziloId")]
        public virtual Vozilo Vozilo { get; set; }
        [ForeignKey("PocetnaLokacijaId")]
        public virtual Lokacija PocetnaLokacija { get; set; }
        [ForeignKey("KrajnjaLokacijaId")]
        public virtual Lokacija KrajnjaLokacija { get; set; }
        [ForeignKey("TipRezervoaraId")]
        public virtual TipRezervoara TipRezervoara { get; set; }
    }
}
