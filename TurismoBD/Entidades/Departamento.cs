using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TurismoBD.Entidades
{

    public partial class DepartamentoResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("Departamento")]
        public Departamento[] Departamentos { get; set; }
    }

    public partial class DepartamentoFiltradoResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("Departamento")]
        public Departamento[] Departamentos { get; set; }
    }
    public class Departamentos
    {
        public List<Departamento>? departamentos { get; set; }
    }
 
    public class Departamento
    {
        [JsonPropertyName("id_depto")]
        public long id_depto { get; set; }
        [JsonPropertyName("descripcion")]
        public string descripcion { get; set; }
        [JsonPropertyName("valor_noche")]
        public long valor_noche { get; set; }
        [JsonPropertyName("id_zona_id")]
        public long id_zona_id { get; set; }
        [JsonPropertyName("m2")]
        public long m2 { get; set; }
        [JsonPropertyName("imagen_url")]
        public string imagen_url { get; set; }
        [JsonPropertyName("direccion")]
        public string direccion { get; set; }
        [JsonPropertyName("capacidad")]
        public long capacidad { get; set; }
        [JsonPropertyName("q_banos")]
        public long q_banos { get; set; }
        [JsonPropertyName("q_plazas")]
        public long q_plazas { get; set; }

        //public Departamento(long id_depto, string descripcion, long valor_noche, long id_zona_id, long m2, string imagen_url, string direccion, long capacidad, long q_banos, long q_plaza)
        //{
        //    Id_depto = id_depto;
        //    Descripcion = descripcion;
        //    Valor_noche = valor_noche;
        //    Id_zona_id = id_zona_id;
        //    M2 = m2;
        //    Imagen_url = imagen_url;
        //    Direccion = direccion;
        //    Capacidad = capacidad;
        //    Q_banos = q_banos;
        //    Q_plazas = q_plaza;
        //}
    }

  

    public class RegistrarDepartamento
    {
        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; }
        [JsonPropertyName("valor_noche")]
        public long Valor_noche { get; set; }
        [JsonPropertyName("id_zona_id")]
        public long Id_zona_id { get; set; }
        [JsonPropertyName("m2")]
        public long M2 { get; set; }
        [JsonPropertyName("imagen_url")]
        public string Imagen_url { get; set; }
        [JsonPropertyName("direccion")]
        public string Direccion { get; set; }
        [JsonPropertyName("capacidad")]
        public long Capacidad { get; set; }
        [JsonPropertyName("q_banos")]
        public long Q_banos { get; set; }
        [JsonPropertyName("q_plazas")]
        public long Q_plazas { get; set; }

        public RegistrarDepartamento(string descripcion, long valor_noche, long id_zona_id, long m2, string imagen_url, string direccion, long capacidad, long q_banos, long q_plaza)
        {
            Descripcion = descripcion;
            Valor_noche = valor_noche;
            Id_zona_id = id_zona_id;
            M2 = m2;
            Imagen_url = imagen_url;
            Direccion = direccion;
            Capacidad = capacidad;
            Q_banos = q_banos;
            Q_plazas = q_plaza;
        }
    }

    public class ActualizarDepartamento
    {
        [JsonPropertyName("id_depto")]
        public long Id_depto { get; set; }
        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; }
        [JsonPropertyName("valor_noche")]
        public long Valor_noche { get; set; }
        [JsonPropertyName("id_zona_id")]
        public long Id_zona_id { get; set; }
        [JsonPropertyName("m2")]
        public long M2 { get; set; }
        [JsonPropertyName("imagen_url")]
        public string Imagen_url { get; set; }
        [JsonPropertyName("direccion")]
        public string Direccion { get; set; }
        [JsonPropertyName("capacidad")]
        public long Capacidad { get; set; }
        [JsonPropertyName("q_banos")]
        public long Q_banos { get; set; }
        [JsonPropertyName("q_plazas")]
        public long Q_plazas { get; set; }

        public ActualizarDepartamento(long id_depto, string descripcion, long valor_noche, long id_zona_id, long m2, string imagen_url, string direccion, long capacidad, long q_banos, long q_plaza)
        {
            Id_depto = id_depto;
            Descripcion = descripcion;
            Valor_noche = valor_noche;
            Id_zona_id= id_zona_id;
            M2 = m2;
            Imagen_url = imagen_url;
            Direccion = direccion;
            Capacidad = capacidad;
            Q_banos = q_banos;
            Q_plazas = q_plaza;
        }
    }

}
