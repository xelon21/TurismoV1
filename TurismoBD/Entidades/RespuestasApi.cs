using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TurismoBD.Entidades
{
    public class RespuestasApi
    {
        [JsonPropertyName("Texto")]
        public string Texto { get; set; }
        [JsonPropertyName("mensaje_salida")]
        public string MensajeSalida { get; set; }
        [JsonPropertyName("estado")]
        public string Estado { get; set; }
    }
}
