using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TurismoBD.Entidades;

namespace TurismoBD.Controladores
{
    public class ReservasController
    {

        private readonly HttpClient httpClient;
        private readonly string apiUrl;
        private readonly JsonSerializerOptions joptions;

        public ReservasController()
        {
            httpClient = new HttpClient();
            apiUrl = "http://localhost:8000/api/reservas/";
            joptions = new JsonSerializerOptions();
        }
        public async Task<ReservaResponse> TraerReservas()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    if (content != string.Empty)
                    {
                        var solicitudes = JsonSerializer.Deserialize<ReservaResponse>(content, joptions);
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

        //public async Task<bool> IngresaReserva(string descripcion, int valoNoche, int zona, int m2, string img, string direccion, int capacidad, int qbanos, int qcamas)
        //{
        //    Departamento depto = new Departamento()
        //    {
        //        descripcion = descripcion,
        //        valor_noche = valoNoche,
        //        id_zona_id = zona,
        //        m2 = m2,
        //        imagen_url = img,
        //        direccion = direccion,
        //        capacidad = capacidad,
        //        q_banos = qbanos,
        //        q_plazas = qcamas
        //    };

        //    try
        //    {
        //        string jsonDepto = JsonSerializer.Serialize(depto, joptions);
        //        StringContent content = new StringContent(jsonDepto, Encoding.UTF8, "application/json");

        //        HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

        //        var result = response.Content.ReadAsStringAsync().Result;
        //        var responseAPI = JsonSerializer.Deserialize<RespuestasApi>(result, joptions);

        //        //Probando estas respuestar...
        //        if (responseAPI.MensajeSalida.Contains("Creado Correctamente"))
        //        {
        //            Debug.WriteLine("Departamento eliminado!");
        //            return true;
        //        }
        //        else
        //        {
        //            Debug.WriteLine($"No se ingreso : {response.StatusCode}");
        //            return false;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine($"Hubo un error {ex.Message}");
        //        return false;
        //    }


        //}
    }
}
