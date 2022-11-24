using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TurismoBD.Entidades
{
    public partial class GastosDeptoResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("gastoDeptos")]
        public GastosDepto[] gastosDepto { get; set; }
    }
    public class GastosDeptos
    {
        public List<GastosDepto>? gastosDeptos { get; set; }
    }  
    public class GastosDepto
    {
        [JsonPropertyName("id_gasto")]
        public long id_gasto { get; set; }
        [JsonPropertyName("id_depto_id")]
        public long id_depto_id { get; set; }
        [JsonPropertyName("id_empleado_id")]
        public long id_empleado_id { get; set; }
        [JsonPropertyName("id_medio_pago_id")]
        public long id_medio_pago_id { get; set; }
        [JsonPropertyName("concepto")]
        public string concepto { get; set; }
        [JsonPropertyName("descripcion")]
        public string descripcion { get; set; }
        [JsonPropertyName("valor_pago")]
        public int valor_pago { get; set; }
        [JsonPropertyName("fecha_pago")]
        public string fecha_pago { get; set; }

}
}
