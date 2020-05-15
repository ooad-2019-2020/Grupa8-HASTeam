using System;
using System.Collections.Generic;
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
        public int PostanskiBroj { get; set; }

    }
}
