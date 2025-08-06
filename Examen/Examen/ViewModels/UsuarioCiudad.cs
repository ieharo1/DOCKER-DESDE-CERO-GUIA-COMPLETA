using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examen.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Examen.ViewModels
{
    public class UsuarioCiudad
    {
        public SelectList Ciudad { get; set; }

        public user user { get; set; }
        public string auxiliar { get; set; }

        public SelectList MustraCiudadesCreacion { get; set; }
        public string ciudadnombre { get; set; }



    }
}
