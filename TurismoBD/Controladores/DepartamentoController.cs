using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;
using TurismoBD.Entidades;
using TurismoBD.ApiHelpers;
using TurismoBD;
using System.Net.Http;

namespace TurismoBD.Controladores
{
    public class DepartamentoController
    {

        private readonly HttpClient httpClient;
        private readonly string apiUrl;
        private readonly JsonSerializerOptions joptions;

        public DepartamentoController()
        {
            httpClient = new HttpClient();
            apiUrl = "http://localhost:8000/api/departamentos/";
            joptions = new JsonSerializerOptions();
        }        
        public async Task<DepartamentoResponse> TraerDepartamentos()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    if (content != string.Empty)
                    {
                        var solicitudes = JsonSerializer.Deserialize<DepartamentoResponse>(content, joptions);
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

        public async Task<bool> IngresarDepartamento(string descripcion, int valoNoche, int zona, int m2, string img, string direccion, int capacidad, int qbanos, int qcamas)
        {
            Departamento depto = new Departamento()
            {
                descripcion = descripcion,
                valor_noche = valoNoche,
                id_zona_id = zona,
                m2 = m2,
                imagen_url = img,
                direccion = direccion,
                capacidad = capacidad,
                q_banos = qbanos,
                q_plazas = qcamas
            };

            try
            {
                string jsonDepto = JsonSerializer.Serialize(depto, joptions);
                StringContent content = new StringContent(jsonDepto, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

                var result = response.Content.ReadAsStringAsync().Result;
                var responseAPI = JsonSerializer.Deserialize<RespuestasApi>(result, joptions);

                //Probando estas respuestar...
                if (responseAPI.MensajeSalida.Contains("Creado Correctamente"))
                {
                    Debug.WriteLine("Articulo eliminado!");
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
   

        public async Task<bool> ActualizarDepartamento(ActualizarDepartamento departamento)
        {
            try
            {
                string jsonDepto = JsonSerializer.Serialize(departamento, joptions);
                StringContent content = new StringContent(jsonDepto, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync($"{apiUrl}SP_ALGUNPROCEDIMIENTO/", content);

                var result = response.Content.ReadAsStringAsync().Result;
                var responseAPI = JsonSerializer.Deserialize<RespuestasApi>(result, joptions);

                //Probando estas respuestar...
                if (responseAPI.MensajeSalida.Contains("MODIFICADO CORRECTAMENTE"))
                {
                    Debug.WriteLine("Producto eliminado!");
                    return true;
                }
                else
                {
                    Debug.WriteLine($"No fue un status 2XX: {response.StatusCode}");
                    return false;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Hubo un error {ex.Message}");
                return false;
            }
        }
        public async Task<DepartamentoFiltradoResponse> TraerDepartamentoID(int id)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"{apiUrl}{id}");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    if (content != string.Empty)
                    {
                        var solicitudes = JsonSerializer.Deserialize<DepartamentoFiltradoResponse>(content, joptions);
                        Departamento datos = new Departamento();
                        var a = solicitudes;
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
        


        public bool ModificarDepartamento(int idx, string descripcion, int valorNoche, int id_zona, int m2, string imgurl, string direccion, int capacidad, int banos, int camas)
        {
            ConeccionBD connection = new ConeccionBD();
            SqlConnection cnx = new SqlConnection(connection.Conneccion());
            try
            {
                cnx.Open();
                SqlCommand cmd = new SqlCommand("SP_MODIFICARDEPARTAMENTOS", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", idx);
                cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                cmd.Parameters.AddWithValue("@ValorNoche", valorNoche);
                cmd.Parameters.AddWithValue("@Id_Zona", id_zona);
                cmd.Parameters.AddWithValue("@M2", m2);
                cmd.Parameters.AddWithValue("@ImgUrl", imgurl);
                cmd.Parameters.AddWithValue("@Direccion", direccion);
                cmd.Parameters.AddWithValue("@Capacidad", capacidad);
                cmd.Parameters.AddWithValue("@Q_Banos", banos);
                cmd.Parameters.AddWithValue("@Q_Camas", camas);

                try
                {
                    cmd.ExecuteNonQuery();
                   // Refresh();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                    throw;
                }

            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
            finally
            {
                cnx.Close();
            }
        }
        public bool EliminarDepartamento(int idx)
        {
            ConeccionBD connection = new ConeccionBD();
            SqlConnection cnx = new SqlConnection(connection.Conneccion());
            try
            {
                cnx.Open();
                SqlCommand cmd = new SqlCommand("SP_ELIMINARDEPARTAMENTO", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", idx);
                try
                {
                    cmd.ExecuteNonQuery();
                   // Refresh();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                    throw;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cnx.Close();
            }

        }
        public async Task<bool> BorrarDepartamento(int in_id)
        {
            try
            {
                string json = JsonSerializer.Serialize<object>(new { in_id }, joptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri($"{apiUrl}sp_delete_producto/"),
                    Content = content
                };
                var response = await httpClient.SendAsync(request);

                var result = response.Content.ReadAsStringAsync().Result;
                var responseAPI = JsonSerializer.Deserialize<RespuestasApi>(result, joptions);
                //ver estas respuestas
                if (responseAPI.MensajeSalida.Contains("ELIMINADO"))
                {
                    Debug.WriteLine("Producto eliminado!");
                    return true;
                }
                else
                {
                    Debug.WriteLine($"No fue un status 2XX: {response.StatusCode}");
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


#region codigo

//public async Task<string> TraeDeptos()
//{

//    //Creamos el listado de Posts a llenar
//    List<Departamento> listado = new List<Departamento>();
//    //Instanciamos un objeto Reply
//    Reply oReply = new Reply();
//    //poblamos el objeto con el método generic Execute
//    oReply = await Consumer.Execute<List<Departamento>>(apiUrl, ApiHelpers.methodHttp.GET, listado);

//    return oReply.Data.ToString();
//}


//public async Task<string> GetHttp()
//{
//    WebRequest oRequest = WebRequest.Create(apiUrl);
//    WebResponse oResponse = oRequest.GetResponse();
//    StreamReader sr = new StreamReader(oResponse.GetResponseStream());
//    return await sr.ReadToEndAsync();
//}       

//ConeccionBD connection = new ConeccionBD();
//SqlConnection cnx = new SqlConnection(connection.Conneccion());
//try
//{
//    cnx.Open();
//    SqlCommand cmd = new SqlCommand("SP_INGRESADEPARTAMENTOS", cnx);
//    cmd.CommandType = CommandType.StoredProcedure;
//    cmd.Parameters.AddWithValue("@Descripcion", descripcion);
//    cmd.Parameters.AddWithValue("@ValorNoche", valoNoche);
//    cmd.Parameters.AddWithValue("@Id_Zona", zona);
//    cmd.Parameters.AddWithValue("@M2", m2);
//    cmd.Parameters.AddWithValue("@ImgUrl", img);
//    cmd.Parameters.AddWithValue("@Direccion", direccion);
//    cmd.Parameters.AddWithValue("@Capacidad", capacidad);
//    cmd.Parameters.AddWithValue("@Q_Banos", qbanos);
//    cmd.Parameters.AddWithValue("@Q_Camas", qcamas);

//    try
//    {
//        cmd.ExecuteNonQuery();
//        Refresh();
//        return true;
//    }
//    catch (Exception ex)
//    {
//        return false;
//        throw;
//    }
//}
//catch (Exception ex)
//{
//    return false;
//    throw;
//}
//finally
//{
//    cnx.Close();
//}

//public async Task<bool> CrearDepartamento(RegistrarDepartamento depto)
//{
//    try
//    {
//        string jsonProducto = JsonSerializer.Serialize<RegistrarDepartamento>(depto, joptions);
//        StringContent content = new StringContent(jsonProducto, Encoding.UTF8, "application/json");

//        HttpResponseMessage response = await httpClient.PostAsync($"{apiUrl}SP_INGRESADEPARTAMENTOS/", content);
//        //probar mensajes 
//        if (response.IsSuccessStatusCode)
//        {
//            Debug.WriteLine("Producto creado!");
//            return true;
//        }
//        else
//        {
//            Debug.WriteLine($"No fue un status 2XX: {response.StatusCode}");
//            return false;
//        }
//    }
//    catch (Exception ex)
//    {

//        Debug.WriteLine($"Hubo un error {ex.Message}");
//    }
//    return false;
//}

//public DataTable Refresh()
//{
//    ConeccionBD connection = new ConeccionBD();
//    var dt = new DataTable();
//    var cmd = new SqlCommand();
//    var cnx = new SqlConnection(connection.Conneccion());

//    try
//    {
//        cnx.Open();
//        cmd.Connection = cnx;
//        cmd.CommandType = CommandType.Text;
//        cmd.CommandText = "select id_depto as ID, " +
//                          "direccion as direccion, " +
//                          "valor_noche as Valor_Noche, " +
//                          "z.descripcion as Zona, " +
//                          "m2 as Metros_cuadrados, " +
//                          "imagen_url as Url_Imagen, " +
//                          "d.descripcion as Descripcion, " +
//                          "capacidad as Capacidad, " +
//                          "q_banos as Cantidad_Baños, " +
//                          "q_camas as Cantidad_Camas " +
//                          "from DEPARTAMENTO d join ZONA z " +
//                          "on (d.id_zona = z.id_zona) " +
//                          "order by id_depto desc;";
//        var da = new SqlDataAdapter(cmd);
//        da.Fill(dt);
//        return dt;


//    }
//    catch (Exception)
//    {

//        throw;
//    }
//    finally
//    {
//        cnx.Close();
//    }
//}

//public DataTable Refresh2()
//{
//    ConeccionBD connection = new ConeccionBD();
//    var dt = new DataTable();
//    var cmd = new SqlCommand();
//    var cnx = new SqlConnection(connection.Conneccion());

//    try
//    {

//        cnx.Open();
//        cmd.Connection = cnx;
//        cmd.CommandType = CommandType.Text;
//        cmd.CommandText = "select Id_depto as ID, " +
//                          "direccion as direccion, " +
//                          "valor_noche as Valor_Noche, " +
//                          "z.descripcion as Zona, " +
//                          "m2 as Metros_cuadrados, " +
//                          "imagen_url as Url_Imagen, " +
//                          "d.descripcion as Descripcion, " +
//                          "capacidad as Capacidad, " +
//                          "q_banos as Cantidad_Baños, " +
//                          "q_camas as Cantidad_Camas " +
//                          "from DEPARTAMENTO d join ZONA z " +
//                          "on (d.id_zona = z.id_zona) " +
//                          "order by id_depto asc;";
//        var da2 = new SqlDataAdapter(cmd);
//        da2.Fill(dt);
//        return dt;

//    }
//    catch (Exception)
//    {
//        throw;
//    }
//    finally
//    {
//        cnx.Close();
//    }
//}


//public DataTable FiltraDepartamentos(int idx)
//{
//    ConeccionBD connection = new ConeccionBD();
//    SqlConnection cnx = new SqlConnection(connection.Conneccion());
//    try
//    {
//        cnx.Open();
//        SqlCommand cmd = new SqlCommand("SP_FILTRODEPARTAMENTO", cnx);
//        cmd.CommandType = CommandType.StoredProcedure;
//        cmd.Parameters.AddWithValue("@ID", idx);
//        SqlDataAdapter sda = new SqlDataAdapter(cmd);
//        DataTable dt = new DataTable();
//        sda.Fill(dt);
//        return dt;
//    }
//    catch (Exception ex)
//    {
//        throw;
//    }
//    finally
//    {
//        cnx.Close();
//    }

//}
#endregion
