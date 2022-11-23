using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TurismoBD.Entidades
{
    public partial class MedioDePagoResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("medioPagos")]
        public MedioDePago[] medioDePago { get; set; }
    }
    public class MedioDePagos
    {
        public List<MedioDePago>? mediosDePagos { get; set; }
    }

    public class MedioDePago
    {
        [JsonPropertyName("id_mp")]
        public long id_mp { get; set; }
        [JsonPropertyName("descripcion")]
        public string descripcion { get; set; }

    }
}
