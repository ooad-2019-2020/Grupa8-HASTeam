using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HASRental.Models
{
    public class FakturaRente
    {
        public int Id { get; set; }
        public int? RentaId { get; set; }
        public double CijenaRente { get; set; }
        public double Taksa { get; set; }
        public double Pdv { get; set; }
        public double UkupniIznos { get; set; }
        public double IznosPopusta { get; set; }
        public double NetoIznos { get; set; }
        public string TipPlacanja { get; set; }
        public int Placeno { get; set; }
        [ForeignKey("RentaId")]
        public virtual Renta Renta { get; set; }

    }
}
