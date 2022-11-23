using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TurismoBD.Entidades
{
    public partial class TipoArticuloResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("categorias")]
        public TipoArticulo[] tipoArticulo { get; set; }
    }
    public class TipoArticulos
    {
        public List<TipoArticulo>? tipoArticulos { get; set; }
    }

    public class TipoArticulo
    {
        [JsonPropertyName("id_categoria")]
        public long id_categoria { get; set; }
        [JsonPropertyName("descripcion")]
        public string descripcion { get; set; }

    }
}
