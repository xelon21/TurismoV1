using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TurismoBD.Entidades
{
    public partial class DetalleServicioResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("detalleServicio")]
        public DetalleServicio[] detalleServicio { get; set; }
    }
    public class DetalleServicios
    {
        public List<DetalleServicio>? detalleServicios { get; set; }
    }

    public class DetalleServicio
    {
        [JsonPropertyName("id_disp_serv")]
        public long id_disp_serv { get; set; }
        [JsonPropertyName("id_servicio_id")]
        public long id_servicio_id { get; set; }
        [JsonPropertyName("id_zona_id")]
        public long id_zona_id { get; set; }

    }
}
