using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApplication1.models
{
    public class Habilidades
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public Epotencia potencia {get;set;}
        
        public enum Epotencia{
            Suave = 0,
            Moderado = 1,
            intenso = 2,
            Potenciafuerte = 3,
            Extremo = 4
        };

        //forengein de Mandril
        public int MandrilId {get; set;}
        
        [JsonIgnore] //esto hace que se ignore este dato y no se suba a la base de datos.
        public Mandril? Mandril { get; set;}
    }
}