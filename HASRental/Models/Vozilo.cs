using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HASRental.Models
{
    public class Vozilo
    {
        public int Id { get; set; }
        public int? VoziloKategorijaId { get; set; }
        public int? ProizvodjacId { get; set; }
        public int? TrenutnaLokacijaId { get; set; }
        public string Model { get; set; }
        public DateTime GodinaProizvodnje { get; set; }
        public int Kilometraza { get; set; }
        public string Boja { get; set; }
        [ForeignKey("VoziloKategorijaId")]
        public virtual VoziloKategorija VoziloKategorija { get; set; }
        [ForeignKey("ProizvodjacId")]
        public virtual Proizvodjac Proizvodjac { get; set; }
        [ForeignKey("TrenutnaLokacijaId")]
        public virtual Lokacija TrenutnaLokacija { get; set; }


    }
}
