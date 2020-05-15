using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HASRental.Models
{
    public class DetaljiRezervacije
    {
        public int Id { get; set; }
        public int? RezervacijaId { get; set; }
        public string Opis { get; set; }
        public string MjestoDolaska { get; set; }
        public DateTime OcekivanoVrijemeDolaska { get; set; }
        [ForeignKey("RezervacijaId")]
        public virtual Rezervacija Rezervacija { get; set; } 

    }
}
