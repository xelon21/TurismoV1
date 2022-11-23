using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.Http;
using TurismoBD.Entidades;
using System.Text.Json;
using System.Net;

namespace TurismoBD.Controladores
{
    public class ComboBoxsTurismo
    {
        private readonly HttpClient httpClient;
        private readonly string apiUrl;
        private readonly JsonSerializerOptions joptions;

        public ComboBoxsTurismo()
        {
            httpClient = new HttpClient();
            apiUrl = "http://localhost:8000/api/";
            joptions = new JsonSerializerOptions();
        }
      
        public async Task<string> GetHttpZona()
        {
            WebRequest oRequest = WebRequest.Create(apiUrl);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        public async Task<ZonaResponse> CargarComboBoxZona()
        {           
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl+"zonas/");
                var a = 0;
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    if (content != string.Empty)
                    {
                        var solicitudes = JsonSerializer.Deserialize<ZonaResponse>(content, joptions);
                        return solicitudes;
                    }
                }
                else
                {
                    Debug.WriteLine(" Este mensaje algo hace ");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
            }
            return null;
        }

        public async Task<TipoArticuloResponse> CargarCategorias()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl+"categorias/");
                var a = 0;
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    if (content != string.Empty)
                    {
                        var solicitudes = JsonSerializer.Deserialize<TipoArticuloResponse>(content, joptions);
                        return solicitudes;
                    }
                }
                else
                {
                    Debug.WriteLine(" Este mensaje algo hace ");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
            }
            return null;
        }

        public async Task<DepartamentoResponse> CargarComboDeptos()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl + "departamentos/");
                var a = 0;
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    if (content != string.Empty)
                    {
                        var solicitudes = JsonSerializer.Deserialize<DepartamentoResponse>(content, joptions);
                        return solicitudes;
                    }
                }
                else
                {
                    Debug.WriteLine(" Este mensaje algo hace ");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
            }
            return null;
        }

        public async Task<MedioDePagoResponse> CargarMediosDePago()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl + "medioPagos/");
                var a = 0;
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    if (content != string.Empty)
                    {
                        var solicitudes = JsonSerializer.Deserialize<MedioDePagoResponse>(content, joptions);
                        return solicitudes;
                    }
                }
                else
                {
                    Debug.WriteLine(" Este mensaje algo hace ");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
            }
            return null;
        }
        public DataTable CargarComboBoxMedioPago()
        {
            ConeccionBD connection = new ConeccionBD();
            var dt = new DataTable();
            var cmd = new SqlCommand();
            var cnx = new SqlConnection(connection.Conneccion());
            SqlDataAdapter da = new SqlDataAdapter("Select id_mp, descripcion from MEDIO_PAGO;", cnx);
            da.SelectCommand.CommandType = CommandType.Text;
            da.Fill(dt);
            return dt;
        }

        public DataTable CargarComboBoxEmpleado()
        {
            ConeccionBD connection = new ConeccionBD();
            var dt = new DataTable();
            var cmd = new SqlCommand();
            var cnx = new SqlConnection(connection.Conneccion());
            SqlDataAdapter da = new SqlDataAdapter("Select nombre +' '+ apellido as nombre, id_empleado from EMPLEADO;", cnx);
            da.SelectCommand.CommandType = CommandType.Text;
            da.Fill(dt);
            return dt;
        }
    }
}


#region codigo


//public DataTable CargarComboBoxDepartamento()
//{
//    ConeccionBD connection = new ConeccionBD();
//    var dt = new DataTable();
//    var cmd = new SqlCommand();
//    var cnx = new SqlConnection(connection.Conneccion());
//    SqlDataAdapter da = new SqlDataAdapter("Select id_depto, direccion from DEPARTAMENTO;", cnx);
//    da.SelectCommand.CommandType = CommandType.Text;
//    da.Fill(dt);
//    return dt;
//}

//public DataTable CargarComboBoxCategoria()
//{
//    //try
//    //{
//    //    HttpResponseMessage response = await httpClient.GetAsync("http://localhost:8000/api/zonas/");
//    //    if (response.IsSuccessStatusCode)
//    //    {
//    //        string content = await response.Content.ReadAsStringAsync();
//    //        if (content != string.Empty)
//    //        {
//    //            var solicitudes = JsonSerializer.Deserialize<ZonaResponse>(content, joptions);
//    //            return solicitudes;
//    //        }
//    //    }
//    //    else
//    //    {
//    //        Debug.WriteLine(" Este mensaje algo hace ");
//    //    }
//    //}
//    //catch (Exception ex)
//    //{
//    //    Debug.WriteLine($"Exception: {ex.Message}");
//    //}
//    //return null;
//    //object zona = new object(i);
//    ////ConeccionBD connection = new ConeccionBD();
//    //var dt = new DataTable();
//    ////var cmd = new SqlCommand();
//    ////var cnx = new SqlConnection(connection.Conneccion());
//    ////SqlDataAdapter da = new SqlDataAdapter("Select id_Categoria, descripcion from CATEGORIA;", cnx);
//    ////da.SelectCommand.CommandType = CommandType.Text;

//    //da.Fill(dt);
//    //return dt;
//}
#endregion