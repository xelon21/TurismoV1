using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TurismoBD.Entidades
{
    public partial class DetalleServicioReservaResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("detServicios")]
        public DetalleServicioReserva[] detalleServicioReserva { get; set; }
    }
    public class DetalleServicioReservas
    {
        public List<DetalleServicioReserva>? detalleServicioReserva { get; set; }
    }

    public class DetalleServicioReserva
    {
        [JsonPropertyName("id_det_servicio")]
        public long id_det_servicio { get; set; }
        [JsonPropertyName("id_servicio_id")]
        public long id_servicio_id { get; set; }
        [JsonPropertyName("id_reserva_id")]
        public long id_reserva_id { get; set; }

    }
}
