using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TurismoBD.Entidades
{
    public partial class PagoSueldoResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("pagoSueldos")]
        public PagoSueldo[] pagoSueldo { get; set; }
    }
    public class PagoSueldos
    {
        public List<PagoSueldo>? pagoSueldos { get; set; }
    }
    public class PagoSueldo
    {
        [JsonPropertyName("id_pago_sueldo")]
        public long id_pago_sueldo { get; set; }
        [JsonPropertyName("id_zona_id")]
        public long id_zona_id { get; set; }
        [JsonPropertyName("id_empleado_id")]
        public long id_empleado_id { get; set; }
        [JsonPropertyName("id_medio_pago_id")]
        public long id_medio_pago_id { get; set; }
        [JsonPropertyName("descripcion")]
        public string descripcion { get; set; }
        [JsonPropertyName("valor_pago")]
        public int valor_pago { get; set; }
        [JsonPropertyName("fecha_pago")]
        public string fecha_pago { get; set; }

    }
}
