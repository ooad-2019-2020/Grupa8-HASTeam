using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HASRental.ViewModels
{
    public class KreirajUlogu
    {
        [Required]
        [Display(Name="Naziv uloge")]
        public string NazivUloge { get; set; }

    }

  
}
