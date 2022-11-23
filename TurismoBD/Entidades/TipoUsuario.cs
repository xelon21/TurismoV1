using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TurismoBD.Entidades
{
    public partial class TipoUsuarioResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("tipoUsuario")]
        public TipoUsuario[] TipoUsuario { get; set; }
    }
    public class TipoUsuarios
    {
        public List<TipoUsuario>? tipoUsuarios { get; set; }
    }

    public class TipoUsuario
    {
        [JsonPropertyName("id_tipo")]
        public long id_tipo { get; set; }
        [JsonPropertyName("descripcion")]
        public string descripcion { get; set; }

    }

}
