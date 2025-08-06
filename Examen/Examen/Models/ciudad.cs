using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Models
{
    public class ciudad
    {
        public int id { get; set; }
        [Display(Name = "Ciudad")]
        public string nombre_ciudad { get; set; }
        [Display(Name = "Latitud")]
        public decimal latitud { get; set; }
        [Display(Name = "Longitud")]
        public decimal longitud { get; set; }
    }
}
