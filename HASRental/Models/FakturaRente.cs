using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
=======
>>>>>>> d03d76121a57b714259ed968a9ff12bff5050e24
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HASRental.Models
{
    public class FakturaRente
    {
<<<<<<< HEAD
        
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
=======
        public int Id { get; set; }
        public int? RentaId { get; set; }
        public double CijenaRente { get; set; }
        public double Taksa { get; set; }
        public double Pdv { get; set; }
        public double UkupniIznos { get; set; }
        public double IznosPopusta { get; set; }
        public double NetoIznos { get; set; }
>>>>>>> d03d76121a57b714259ed968a9ff12bff5050e24
        public string TipPlacanja { get; set; }
        public int Placeno { get; set; }
        [ForeignKey("RentaId")]
        public virtual Renta Renta { get; set; }

<<<<<<< HEAD
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
=======
>>>>>>> d03d76121a57b714259ed968a9ff12bff5050e24
    }
}
