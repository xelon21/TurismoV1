using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TurismoBD.Entidades
{
    public partial class EmpleadoResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("empleados")]
        public Empleado[] empleado { get; set; }
    }
    public class Empleados
    {
        public List<Empleado>? empleados { get; set; }
    }

    public class Empleado
    {
        [JsonPropertyName("id_empleado")]
        public long id_empleado { get; set; }
        [JsonPropertyName("id_usuario_id")]
        public long id_usuario_id { get; set; }
        [JsonPropertyName("nombre")]
        public string nombre { get; set; }
        [JsonPropertyName("apellido")]
        public string apellido { get; set; }
        [JsonPropertyName("rut")]
        public string rut { get; set; }
        [JsonPropertyName("direccion")]
        public string direccion { get; set; }
        [JsonPropertyName("id_zona_id")]
        public long id_zona_id { get; set; }
        [JsonPropertyName("tipo_empleado")]
        public string tipo_empleado { get; set; }



    }
}
