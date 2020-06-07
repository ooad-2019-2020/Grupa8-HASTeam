using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HASRental.Models
{
    public class VoziloKategorija
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        [Display(Name = "Cijena rente")]
        public double CijenaRente { get; set; }

    }
}
