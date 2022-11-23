using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TurismoBD.Entidades
{
    public partial class UsuarioResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("usuarios")]
        public Usuario[] Usuario { get; set; }
    }
    public class Usuarios
    {
        public List<Usuario>? Usuario { get; set; }
    }

    public class Usuario
    { 
        [JsonPropertyName("id_usuario")]
        public long id_usuario { get; set; }
        [JsonPropertyName("email")]
        public string email { get; set; }
        [JsonPropertyName("contrasena")]
        public string contrasena { get; set; }
        [JsonPropertyName("nombre_completo")]
        public string nombre_completo { get; set; }
        [JsonPropertyName("rut")]
        public string rut { get; set; }
        [JsonPropertyName("direccion")]
        public string direccion { get; set; }
        [JsonPropertyName("telefono")]
        public string telefono { get; set; }
        [JsonPropertyName("fecha_nacimiento")]
        public string fecha_nacimiento { get; set; }
        [JsonPropertyName("id_tipo_usuario_id")]
        public long id_tipo_usuario_id { get; set; }       

    }
}
