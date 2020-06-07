using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations;
=======
>>>>>>> d03d76121a57b714259ed968a9ff12bff5050e24
using System.Linq;
using System.Threading.Tasks;

namespace HASRental.Models
{
    public class Lokacija
    {
        public int Id { get; set; }
        public string Adresa { get; set; }
        public string Grad { get; set; }
        public string Kanton { get; set; }
        public string Drazava { get; set; }
<<<<<<< HEAD
        [Display(Name = "Poštanski broj")]
=======
>>>>>>> d03d76121a57b714259ed968a9ff12bff5050e24
        public int PostanskiBroj { get; set; }

    }
}
