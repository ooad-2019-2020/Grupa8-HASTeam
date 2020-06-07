using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HASRental.Models
{
    public class Vozilo
    {
        public int Id { get; set; }
        [Display(Name = "Kategorija vozila")]
        public int? VoziloKategorijaId { get; set; }
        [Display(Name = "Proizvođač")]
        public int? ProizvodjacId { get; set; }
        [Display(Name = "Trenutna lokacija")]
        public int? TrenutnaLokacijaId { get; set; }
        public string Model { get; set; }
        [Display(Name = "Godina proizvodnje")]
        public DateTime GodinaProizvodnje { get; set; }
        public int Kilometraza { get; set; }
        public string Boja { get; set; }
        [ForeignKey("VoziloKategorijaId")]
        [Display(Name = "Kategorija vozila")]
        public virtual VoziloKategorija VoziloKategorija { get; set; }
        [ForeignKey("ProizvodjacId")]
        public virtual Proizvodjac Proizvodjac { get; set; }
        [ForeignKey("TrenutnaLokacijaId")]
        [Display(Name = "Trenutna lokacija")]
        public virtual Lokacija TrenutnaLokacija { get; set; }


    }
}
