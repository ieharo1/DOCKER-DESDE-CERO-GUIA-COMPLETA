using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Models
{
    public class user
    {
        public int id { get; set; }
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name ="C.I/RUC")]
        public string ci_ruc { get; set; }
        [Display(Name = "Ciudad")]
        public int id_ciudad { get; set; }
        [Display(Name = "ARM")]
        public bool arm { get; set; }
        [Display(Name = "UCI")]
        public bool uci { get; set; }
    }
}
