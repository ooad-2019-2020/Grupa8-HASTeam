using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HASRental.Models
{
    public class FakturaRente
    {
        
        public int Id { get; set; }
        public int? RentaId { get; set; }
        [Display(Name = "Cijena rente")]
        public double CijenaRente { get; set; }
        public double Taksa { get; set; }
        public double Pdv { get; set; }
        [Display(Name = "Ukupan iznos")]
        public double UkupniIznos { get; set; }
        [Display(Name = "Iznos popusta")]
        public double IznosPopusta { get; set; }
        [Display(Name = "Neto iznos")]
        public double NetoIznos { get; set; }
        [Display(Name = "Tip plaćanja")]
        public string TipPlacanja { get; set; }
        public int Placeno { get; set; }
        [ForeignKey("RentaId")]
        public virtual Renta Renta { get; set; }

        public FakturaRente(int? rentaId, double cijenaRente, double taksa, double pdv, double ukupniIznos, double iznosPopusta, double netoIznos, string tipPlacanja, int placeno)
        {
            RentaId = rentaId;
            CijenaRente = cijenaRente;
            Taksa = taksa;
            Pdv = pdv;
            UkupniIznos = ukupniIznos;
            IznosPopusta = iznosPopusta;
            NetoIznos = netoIznos;
            TipPlacanja = tipPlacanja;
            Placeno = placeno;
        }
    }
}
