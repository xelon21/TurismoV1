using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TurismoBD.Entidades
{
    public partial class ReservaResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("reservas")]
        public Reserva[] reserva { get; set; }
    }
    public class Reservas
    {
        public List<Reserva>? reserva { get; set; }
    }

    public class Reserva
    {
        [JsonPropertyName("id_reserva")]
        public long id_reserva { get; set; }
        [JsonPropertyName("f_checkin")]
        public string f_checkin { get; set; }
        [JsonPropertyName("f_checkout")]
        public string f_checkout { get; set; }
        [JsonPropertyName("id_huesped_id")]
        public long id_huesped_id { get; set; }
        [JsonPropertyName("valor_reserva")]
        public int valor_reserva { get; set; }
        [JsonPropertyName("valor_total")]
        public int valor_total { get; set; }
        [JsonPropertyName("id_estado_id")]
        public long id_estado_id { get; set; }
        [JsonPropertyName("id_depto_id")]
        public long id_depto_id { get; set; }
        
    }
}
