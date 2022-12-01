using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
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
            apiUrl = "http://localhost:8000/api/";
            joptions = new JsonSerializerOptions();
        }
        public async Task<ReservaResponse> TraerReservas()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl + "reservas/");
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

        public async Task<HuespedResponse> TraeHuespedes()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl + "huespedes/");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    if (content != string.Empty)
                    {
                        var solicitudes = JsonSerializer.Deserialize<HuespedResponse>(content, joptions);
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


        //static async Task<Reserva> UpdateProductAsync(Reserva product)
        //{
        //    HttpResponseMessage response = await client.PutAsJsonAsync(
        //        $"api/products/{product.Id}", product);
        //    response.EnsureSuccessStatusCode();

        //    // Deserialize the updated product from the response body.
        //    product = await response.Content.ReadAsAsync<Product>();
        //    return product;
        //}
        public async Task<bool> CambiarEstadoReserva(long idReserva, string checkin, string checkout, long idHuesped, int valorReserva, int valorTotal, long idEstado, long idDepto)
        {
            Reserva reserva = new Reserva()
            {
                f_checkin = checkin,
                f_checkout = checkout,
                id_huesped_id = idHuesped,
                valor_reserva = valorReserva,
                valor_total = valorTotal, 
                id_estado_id = idEstado,
                id_depto_id = idDepto
            };

            try
            {
                string jsonArticulo = JsonSerializer.Serialize(reserva, joptions);
                HttpContent content = new StringContent(jsonArticulo, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PutAsync(apiUrl + "reservas/" + idReserva, content);

                var result = response.Content.ReadAsStringAsync().Result;
               // var responseAPI = JsonSerializer.Deserialize<RespuestasApi>(result, joptions);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hubo un error {ex.Message}");
                return false;
            }
        }

        public async Task<DetalleServicioReservaResponse> TraerDetalleServicioReserva()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl + "detServicios/");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    if (content != string.Empty)
                    {
                        var solicitudes = JsonSerializer.Deserialize<DetalleServicioReservaResponse>(content, joptions);
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
