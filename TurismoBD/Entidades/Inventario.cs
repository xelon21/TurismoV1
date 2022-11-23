using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TurismoBD.Entidades
{
    public partial class InventarioResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("inventarios")]
        public Inventario[] inventario { get; set; }
    }
    public class Inventarios
    {
        public List<Inventario>? inventarios { get; set; }
    }

    public class Inventario
    {
        [JsonPropertyName("id_inventario")]
        public long id_inventario { get; set; }
        [JsonPropertyName("id_depto")]
        public long id_depto { get; set; }
        [JsonPropertyName("fecha_actualiz")]
        public string fecha_actualiz { get; set; }
    }
}

