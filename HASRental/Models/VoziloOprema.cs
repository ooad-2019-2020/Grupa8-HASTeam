using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HASRental.Models
{
    public class VoziloOprema
    {
        public int Id { get; set; }
        public int? VoziloId { get; set; }
        [Display(Name = "Opis opreme")]
        public string OpisOpreme { get; set; }
        [ForeignKey("VoziloId")]
        public virtual Vozilo Vozilo { get; set; }
    }
}
