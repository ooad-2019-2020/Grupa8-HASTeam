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
    public class Vozilo
    {
        public int Id { get; set; }
<<<<<<< HEAD
        [Display(Name = "Kategorija vozila")]
        public int? VoziloKategorijaId { get; set; }
        [Display(Name = "Proizvođač")]
        public int? ProizvodjacId { get; set; }
        [Display(Name = "Trenutna lokacija")]
        public int? TrenutnaLokacijaId { get; set; }
        public string Model { get; set; }
        [Display(Name = "Godina proizvodnje")]
=======
        public int? VoziloKategorijaId { get; set; }
        public int? ProizvodjacId { get; set; }
        public int? TrenutnaLokacijaId { get; set; }
        public string Model { get; set; }
>>>>>>> d03d76121a57b714259ed968a9ff12bff5050e24
        public DateTime GodinaProizvodnje { get; set; }
        public int Kilometraza { get; set; }
        public string Boja { get; set; }
        [ForeignKey("VoziloKategorijaId")]
<<<<<<< HEAD
        [Display(Name = "Kategorija vozila")]
=======
>>>>>>> d03d76121a57b714259ed968a9ff12bff5050e24
        public virtual VoziloKategorija VoziloKategorija { get; set; }
        [ForeignKey("ProizvodjacId")]
        public virtual Proizvodjac Proizvodjac { get; set; }
        [ForeignKey("TrenutnaLokacijaId")]
<<<<<<< HEAD
        [Display(Name = "Trenutna lokacija")]
=======
>>>>>>> d03d76121a57b714259ed968a9ff12bff5050e24
        public virtual Lokacija TrenutnaLokacija { get; set; }


    }
}
