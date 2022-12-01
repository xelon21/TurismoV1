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
    public class GastoDeptosController
    {
        private readonly HttpClient httpClient;
        private readonly string apiUrl;
        private readonly JsonSerializerOptions joptions;

        public GastoDeptosController()
        {
            httpClient = new HttpClient();
            apiUrl = "http://localhost:8000/api/";
            joptions = new JsonSerializerOptions();
        }
        public async Task<GastosDeptoResponse> TraerGastosDeptos()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl + "gastoDeptos/");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    if (content != string.Empty)
                    {
                        var solicitudes = JsonSerializer.Deserialize<GastosDeptoResponse>(content, joptions);
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

      public async Task<bool> IngresarGastoDepto(long idDepto, long idEmpleado, long medioPago, string concepto, string descripcion, int valorPago, string fecha)
        {
            GastosDepto gastoDepto = new GastosDepto()
            {
                id_depto_id = idDepto,
                id_empleado_id = idEmpleado,
                id_medio_pago_id = medioPago,
                concepto = concepto,
                descripcion = descripcion,
                valor_pago = valorPago,
                fecha_pago = fecha
            };

            try
            {
                string jsonDepto = JsonSerializer.Serialize(gastoDepto, joptions);
                StringContent content = new StringContent(jsonDepto, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync(apiUrl + "gastoDeptos/", content);

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

        public async Task<PagoSueldoResponse> TraePagoSueldos()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl + "pagoSueldos/");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    if (content != string.Empty)
                    {
                        var solicitudes = JsonSerializer.Deserialize<PagoSueldoResponse>(content, joptions);
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

        public async Task<bool> IngresarPagoSueldo(long idZona, long idEmpleado, long medioPago, string descripcion, int valorPago, string fecha)
        {
            PagoSueldo pagoSueldo = new PagoSueldo()
            {
                id_zona_id = idZona,
                id_empleado_id = idEmpleado,
                id_medio_pago_id = medioPago,      
                descripcion = descripcion,
                valor_pago = valorPago,
                fecha_pago = fecha
            };

            try
            {
                string jsonDepto = JsonSerializer.Serialize(pagoSueldo, joptions);
                StringContent content = new StringContent(jsonDepto, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync(apiUrl + "pagoSueldos/", content);

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
