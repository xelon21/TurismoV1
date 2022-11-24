using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TurismoBD.Entidades
{
    public partial class TipoServicioResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("tipoServicios")]
        public TipoServicio[] tipoServicio { get; set; }
    }
    public class TipoServicios
    {
        public List<TipoServicio>? tipoServicios { get; set; }
    }

    public class TipoServicio
    {
        [JsonPropertyName("id_tipo")]
        public long id_tipo { get; set; }
        [JsonPropertyName("descripcion")]
        public string descripcion { get; set; }

    }
}
