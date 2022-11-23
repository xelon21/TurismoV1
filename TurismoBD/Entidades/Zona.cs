using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TurismoBD.Entidades
{
    public partial class ZonaResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("Zona")]
        public Zona[] Zona { get; set; }
    }
    public class Zonas
    {
        public List<Zona>? zona { get; set; }
    }

    public class Zona
    {
        [JsonPropertyName("id_zona")]
        public long id_zona { get; set; }
        [JsonPropertyName("descripcion")]
        public string descripcion { get; set; }
       
    }

}
