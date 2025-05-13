using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace especiemandril.models
{
    public class Especie
    {
        public int Id {get; set; }

        public string Nombre_especie {get; set;} = string.Empty;

        public string sub_especie {get; set; } = string.Empty;

        public int cantidad_especie { get; set; }

    }
}