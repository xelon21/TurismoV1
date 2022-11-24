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
    public class ServicioExtraController
    {
        private readonly HttpClient httpClient;
        private readonly string apiUrl;
        private readonly JsonSerializerOptions joptions;

        public ServicioExtraController()
        {
            httpClient = new HttpClient();
            apiUrl = "http://localhost:8000/api/";
            joptions = new JsonSerializerOptions();
        }
        public async Task<ServiciosExtraResponse> TraeServiciosExtras()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl + "servicioExtras/");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    if (content != string.Empty)
                    {
                        var solicitudes = JsonSerializer.Deserialize<ServiciosExtraResponse>(content, joptions);
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

        public async Task<DetalleServicioResponse> TraeDetalleServicio()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl + "detServ/");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    if (content != string.Empty)
                    {
                        var solicitudes = JsonSerializer.Deserialize<DetalleServicioResponse>(content, joptions);
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

        public async Task<bool> IngresaDetalleServicio(long idServicio, long idzona)
        {
            DetalleServicio detalleServicio = new DetalleServicio()
            {
                id_servicio_id = idServicio,
                id_zona_id = idzona
            };

            try
            {
                string jsonDepto = JsonSerializer.Serialize(detalleServicio, joptions);
                StringContent content = new StringContent(jsonDepto, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync(apiUrl + "detServ/", content);

                var result = response.Content.ReadAsStringAsync().Result;
                var responseAPI = JsonSerializer.Deserialize<RespuestasApi>(result, joptions);
                return false;

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Hubo un error {ex.Message}");
                return false;
            }


        }
        public async Task<bool> IngresaServiciosExtra(long idTipoServicio, int tarifa, string fechaPago)
        {
            ServiciosExtra servicioExtra = new ServiciosExtra()
            {
               id_tipo_serv = idTipoServicio,
               tarifa = tarifa,
               fecha_pago = fechaPago
            };

            try
            {
                string jsonDepto = JsonSerializer.Serialize(servicioExtra, joptions);
                StringContent content = new StringContent(jsonDepto, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync(apiUrl + "servicioExtras/", content);

                var result = response.Content.ReadAsStringAsync().Result;
                var responseAPI = JsonSerializer.Deserialize<RespuestasApi>(result, joptions);
                return false;

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Hubo un error {ex.Message}");
                return false;
            }


        }
    }
}
