using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TurismoBD;
using TurismoBD.Entidades;

namespace TurismoBD.Controladores
{
    public class InventarioController
    {
        private readonly HttpClient httpClient;
        private readonly string apiUrl;
        private readonly JsonSerializerOptions joptions;

        public InventarioController()
        {
            httpClient = new HttpClient();
            apiUrl = "http://localhost:8000/api/";
            joptions = new JsonSerializerOptions();
        }

        public async Task<InventarioResponse> TraerInventarios()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl + "inventarios/");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    if (content != string.Empty)
                    {
                        var solicitudes = JsonSerializer.Deserialize<InventarioResponse>(content, joptions);
                        var dato = content.ToString();
                        return solicitudes;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            return null;
        }

        public async Task<DetalleInventarioResponse> TraerDetallesInventarios()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl + "detalleInventarios/");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    if (content != string.Empty)
                    {
                        var solicitudes = JsonSerializer.Deserialize<DetalleInventarioResponse>(content, joptions);
                        var dato = content.ToString();
                        return solicitudes;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            return null;
        }

        public async Task<ArticuloResponse> TraerArticulos()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl + "articulos/");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    if (content != string.Empty)
                    {
                        var solicitudes = JsonSerializer.Deserialize<ArticuloResponse>(content, joptions);
                        var dato = content.ToString();
                        return solicitudes;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            return null;
        }

        public async Task<bool> IngresarDetalleInventario(long articulo, long inventario)
        {
            DetalleInventario detalleInv = new DetalleInventario()
            {
                id_articulo_id = articulo,
                id_inventario_id = inventario,
            };

            try
            {
                string jsonArticulo = JsonSerializer.Serialize(detalleInv, joptions);
                StringContent content = new StringContent(jsonArticulo, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync(apiUrl + "detalleInventarios/", content);

                var result = response.Content.ReadAsStringAsync().Result;
                var responseAPI = JsonSerializer.Deserialize<RespuestasApi>(result, joptions);

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hubo un error {ex.Message}");
                return false;
            }
        }

        public async Task<bool> IngresarInventario(long idDepto, string fecha)
        {
            Inventario inventario = new Inventario()
            {
                id_depto = idDepto,
                fecha_actualiz = fecha
            };

            try
            {
                string jsonArticulo = JsonSerializer.Serialize(inventario, joptions);
                StringContent content = new StringContent(jsonArticulo, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync(apiUrl + "inventarios/", content);

                var result = response.Content.ReadAsStringAsync().Result;
                var responseAPI = JsonSerializer.Deserialize<RespuestasApi>(result, joptions);

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hubo un error {ex.Message}");
                return false;
            }
        }

        public async Task<bool> IngresarArticulos(string nombre, string descirpcion, int costo, string fecha, int idCategoria)
        {
            Articulo articulo = new Articulo()
            {
                nombre = nombre,
                descripcion = descirpcion,
                costo_reposicion = costo,
                fecha_actualizacion = fecha,
                id_categoria = idCategoria
            };

            try
            {
                string jsonArticulo = JsonSerializer.Serialize(articulo, joptions);
                StringContent content = new StringContent(jsonArticulo, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync(apiUrl + "articulos/", content);

                var result = response.Content.ReadAsStringAsync().Result;
                var responseAPI = JsonSerializer.Deserialize<RespuestasApi>(result, joptions);
                return false;             
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hubo un error {ex.Message}");
                return false;
            }
        }

        public DataTable Refresh2()
        {
            try
            {
                ConeccionBD connection = new ConeccionBD();
                var dt2 = new DataTable();
                var cmd2 = new SqlCommand();
                var cnx2 = new SqlConnection(connection.Conneccion());
                cnx2.Open();
                cmd2.Connection = cnx2;
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "SELECT  id_articulo as ID, " +
                                   "nombre as Nombre, " +
                                   "a.descripcion as Descripcion, " +
                                   "costo_reposicion as Costo, " +
                                   "fecha_actualizacion as Fecha_Actualizacion, " +
                                   "c.descripcion as Tipo_Articulo " +
                                   "FROM dbo.ARTICULO a join dbo.CATEGORIA c " +
                                   "on(a.id_categoria = c.id_categoria) " +
                                   "order by id_articulo asc";
                var da2 = new SqlDataAdapter(cmd2);
                da2.Fill(dt2);
                cnx2.Close();
                return dt2;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public DataTable Refresh()
        {
            ConeccionBD connection = new ConeccionBD();
            var dt = new DataTable();
            var cmd = new SqlCommand();
            var cnx = new SqlConnection(connection.Conneccion());

            try
            {
                cnx.Open();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT id_articulo as ID, " +
                                  "nombre as Nombre, " +
                                  "a.descripcion as Descripcion, " +
                                  "costo_reposicion as Costo, " +
                                  "fecha_actualizacion as Fecha_Actualizacion, " +
                                  "c.descripcion as Tipo_Articulo " +
                                  "FROM dbo.ARTICULO a join dbo.CATEGORIA c " +
                                  "on(a.id_categoria = c.id_categoria) " +
                                  "order by id_articulo desc";
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;

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

        public DataTable FiltrarInventario(int idx)
        {
            ConeccionBD connection = new ConeccionBD();
            SqlConnection cnx = new SqlConnection(connection.Conneccion());
            try
            {
                cnx.Open();
                SqlCommand cmd = new SqlCommand("SP_FILTROARTICULOS", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", idx);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
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

        public DataTable FiltrarInventarioModificar(int idx)
        {
            ConeccionBD connection = new ConeccionBD();
            SqlConnection cnx = new SqlConnection(connection.Conneccion());
            try
            {
                cnx.Open();
                SqlCommand cmd = new SqlCommand("SP_FILTROARTICULOSMODIFICAR", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", idx);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
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

        public bool EliminarInventario(int idx)
        {
            ConeccionBD connection = new ConeccionBD();
            SqlConnection cnx = new SqlConnection(connection.Conneccion());
            try
            {
                cnx.Open();
                SqlCommand cmd = new SqlCommand("SP_ELIMINARARTICULO", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", idx);
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                    Refresh();
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


        public bool ModificarInventario(int idx, string nombre, string descripcion, int costo, int categoria)
        {

            ConeccionBD connection = new ConeccionBD();
            SqlConnection cnx = new SqlConnection(connection.Conneccion());
            try
            {
                cnx.Open();
                SqlCommand cmd = new SqlCommand("SP_MODIFICARARTICULO", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", idx);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                cmd.Parameters.AddWithValue("@Costo", costo);
                cmd.Parameters.AddWithValue("@FechaActualizacion", DateTime.Now);
                cmd.Parameters.AddWithValue("@IdCategoria", categoria);

                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                    Refresh();
                }
                catch (Exception ex)
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

    }
}

#region codigo

//public bool IngresarInventario(string nombreArticulo, string descripcion, int costo, int categoria, int depto)
//{
//    ConeccionBD connection = new ConeccionBD();
//    SqlConnection cnx = new SqlConnection(connection.Conneccion());
//    try
//    {
//        cnx.Open();
//        SqlCommand cmd = new SqlCommand("SP_INGRESAARTICULOS", cnx);
//        cmd.CommandType = CommandType.StoredProcedure;
//        cmd.Parameters.AddWithValue("@Nombre", nombreArticulo);
//        cmd.Parameters.AddWithValue("@Descripcion", descripcion);
//        cmd.Parameters.AddWithValue("@Costo", costo);
//        cmd.Parameters.AddWithValue("@FechaActualizacion", DateTime.Now);
//        cmd.Parameters.AddWithValue("@IdCategoria", categoria);
//        cmd.Parameters.AddWithValue("@IdDepto", depto);
//        try
//        {
//            cmd.ExecuteNonQuery();
//            return true;
//            Refresh();
//        }
//        catch (Exception ex)
//        {
//            return false;
//            throw;
//        }
//    }
//    catch (Exception ex)
//    {
//        return false;
//        throw;
//    }
//    finally
//    {
//        cnx.Close();
//    }
//}
#endregion
