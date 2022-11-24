using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TurismoBD.Entidades
{
    public partial class ServiciosExtraResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("servicioExtras")]
        public ServiciosExtra[] servicioExtra { get; set; }
    }
    public class ServiciosExtras
    {
        public List<ServiciosExtra>? servicioExtras { get; set; }
    }
    public class ServiciosExtra
    {
        [JsonPropertyName("id_servicio")]
        public long id_servicio { get; set; }
        [JsonPropertyName("id_tipo_serv")]
        public long id_tipo_serv { get; set; }
        [JsonPropertyName("tarifa")]
        public int tarifa { get; set; }
        [JsonPropertyName("fecha_pago")]
        public string fecha_pago { get; set; }
        
    }
}
