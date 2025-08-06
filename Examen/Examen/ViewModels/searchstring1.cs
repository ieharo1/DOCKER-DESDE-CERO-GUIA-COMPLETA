using Examen.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.ViewModels
{
    public class searchstring1
    {
        public SelectList Ciudades { get; set; }
        public List<user> Usuarios { get; set; }
        public List<ciudad> CiudadesVM { get; set; }
        public string searchstring { get; set; }
        public string buscarselect { get; set; }

    }
}
