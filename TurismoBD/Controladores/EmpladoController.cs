using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TurismoBD.Entidades;

namespace TurismoBD.Controladores
{
    public class EmpleadoController
    {
        private readonly HttpClient httpClient;
        private readonly string apiUrl;
        private readonly JsonSerializerOptions joptions;

        public EmpleadoController()
        {
            httpClient = new HttpClient();
            apiUrl = "http://localhost:8000/api/empleados/";
            joptions = new JsonSerializerOptions();
        }

        public async Task<EmpleadoResponse> TraerEmpleados()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    if (content != string.Empty)
                    {
                        var solicitudes = JsonSerializer.Deserialize<EmpleadoResponse>(content, joptions);
                        var dato = content.ToString();
                        return solicitudes;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
            }
            return null;
        }
        public async Task<bool> IngresaEmpleados(long idUsuario, string nombre, string apellido,
                                                 string rut, string direccion, long idZona, string tipoEmpleado)
        {
            Empleado empleado = new Empleado()
            {
                id_usuario_id = idUsuario,
                nombre = nombre,
                apellido = apellido,
                rut = rut,
                direccion = direccion,
                id_zona_id = idZona,
                tipo_empleado = tipoEmpleado

            };
            try
            {
                string jsonEmpleado = JsonSerializer.Serialize(empleado, joptions);
                StringContent content = new StringContent(jsonEmpleado, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

                var result = response.Content.ReadAsStringAsync().Result;
                var responseAPI = JsonSerializer.Deserialize<RespuestasApi>(result, joptions);

                //Probando estas respuestar...
                if (responseAPI.MensajeSalida.Contains("Creado Correctamente"))
                {
                    return true;
                }
                else
                {
                    Debug.WriteLine($"No se ingreso : {response.StatusCode}");
                    return false;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Hubo un error {ex.Message}");
                return false;
            }


        }
    }
}