using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TurismoBD.Entidades
{
    public partial class ArticuloResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("articulos")]
        public Articulo[] Articulo { get; set; }
    }

    public class Articulos
    {
        public List<Articulo>? articulos { get; set; }
    }

    public class Articulo
    {

        [JsonPropertyName("id_articulo")]
        public long id_articulo { get; set; }
        [JsonPropertyName("nombre")]
        public string nombre { get; set; }
        [JsonPropertyName("descirpcion")]
        public string descripcion { get; set; }
        [JsonPropertyName("costo_reposicion")]
        public long costo_reposicion { get; set; }
        [JsonPropertyName("fehca_actualizacion")]
        public string fecha_actualizacion { get; set; }
        [JsonPropertyName("id_categoria")]
        public long id_categoria { get; set; }        

    }
}
