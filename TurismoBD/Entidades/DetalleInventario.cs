using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TurismoBD.Entidades
{
    public partial class DetalleInventarioResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("detalleInventario")]
        public DetalleInventario[] detalleInventario { get; set; }
    }
    public class DetalleInventarios
    {
        public List<DetalleInventario>? detalleInventarios { get; set; }
    }

    public class DetalleInventario
    {       
        [JsonPropertyName("id_det")]
        public long id_det { get; set; }
        [JsonPropertyName("id_articulo_id")]
        public long id_articulo_id { get; set; }
        [JsonPropertyName("id_inventario_id")]
        public long id_inventario_id { get; set; }
    }
}
