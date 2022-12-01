using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TurismoBD.Entidades
{ 
    public partial class HuespedResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("huesped")]
        public Huesped[] huesped { get; set; }
    }
    public class EmpleaHuespedes
    {
        public List<Huesped>? huespedes { get; set; }
    }

    public class Huesped
    {     
        [JsonPropertyName("id_huesped")]
        public long id_huesped { get; set; }
        [JsonPropertyName("nombre")]
        public string nombre { get; set; }
        [JsonPropertyName("apellido")]
        public string apellido { get; set; }
        [JsonPropertyName("rut")]
        public string rut { get; set; }
        [JsonPropertyName("direccion")]
        public string direccion { get; set; }
        [JsonPropertyName("telefono")]
        public string telefono { get; set; }
        [JsonPropertyName("id_usuario_id")]
        public long id_usuario_id { get; set; }
    }
}
