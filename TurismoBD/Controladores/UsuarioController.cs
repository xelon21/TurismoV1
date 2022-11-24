using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Diagnostics;
using TurismoBD.Entidades;

namespace TurismoBD.Controladores
{
    public class UsuarioController
    {
        private readonly HttpClient httpClient;
        private readonly string apiUrl;
        private readonly JsonSerializerOptions joptions;

        public UsuarioController()
        {
            httpClient = new HttpClient();
            apiUrl = "http://localhost:8000/api/usuarios/";
            joptions = new JsonSerializerOptions();
        }

        public async Task<UsuarioResponse> TraerUsuarios()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    if (content != string.Empty)
                    {
                        var solicitudes = JsonSerializer.Deserialize<UsuarioResponse>(content, joptions);
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
        public async Task<bool> IngresarUsuario(string email, string contrasena, string nombreCompleto,
                                            string rut, string direccion, string telefono,
                                            string fechaNacimiento, int idTipo)
        {
            Usuario user = new Usuario()
            {
                email = email,
                contrasena = contrasena,
                nombre_completo = nombreCompleto,
                rut = rut,
                direccion = direccion,
                telefono = telefono,
                fecha_nacimiento = fechaNacimiento,
                id_tipo_usuario_id = idTipo

            };

            try
            {
                string jsonUser = JsonSerializer.Serialize(user, joptions);
                StringContent content = new StringContent(jsonUser, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

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
                cmd.CommandText = "select email as Usuario, " +
                                  "nombre_completo as Nombre_Completo, " +
                                  "rut as Rut, " +
                                  "direccion as Direccion, " +
                                  "telefono as Telefono, " +
                                  "fecha_nacimiento as Fecha_Nacimiento, " +
                                  "t.descripcion as Tipo_Usuario " +
                                  "from USUARIO u join TIPO_USUARIO t " +
                                  "on(u.id_tipo_usuario = t.id_tipo) " +
                                  "order by id_usuario desc;";
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
        public DataTable Refresh2()
        {
            ConeccionBD connection = new ConeccionBD();
            var dt2 = new DataTable();
            var cmd2 = new SqlCommand();
            var cnx2 = new SqlConnection(connection.Conneccion());
            try
            {

                cnx2.Open();
                cmd2.Connection = cnx2;
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select id_usuario as ID, " +
                                   "email as Usuario, " +
                                   "nombre_completo as Nombre_Completo, " +
                                   "rut as Rut, " +
                                   "direccion as Direccion, " +
                                   "telefono as Telefono, " +
                                   "fecha_nacimiento as Fecha_Nacimiento, " +
                                   "t.descripcion as Tipo_Usuario " +
                                   "from USUARIO u join TIPO_USUARIO t " +
                                   "on(u.id_tipo_usuario = t.id_tipo) " +
                                   "order by id_usuario asc;";
                var da2 = new SqlDataAdapter(cmd2);
                da2.Fill(dt2);
                return dt2;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool IngresaUsusario(string email, string contrasena, string ConfirmaContrasena, string nombre, string rut, string direccion, string telefono, DateTime fechanacimiento, int tipoUsuario)
        {
            if (ConfirmaContrasena == contrasena)
            {
                ConeccionBD connection = new ConeccionBD();
                SqlConnection cnx = new SqlConnection(connection.Conneccion());
                try
                {
                    cnx.Open();
                    SqlCommand cmd = new SqlCommand("SP_INGRESARUSUARIO", cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Contrasena", contrasena);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Rut", rut);
                    cmd.Parameters.AddWithValue("@Direccion", direccion);
                    cmd.Parameters.AddWithValue("@Telefono", telefono);
                    cmd.Parameters.AddWithValue("@Fecha_Nacimiento", fechanacimiento);
                    cmd.Parameters.AddWithValue("@Id_tipo_Usuario", tipoUsuario);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        Refresh();
                        return true;
                    }
                    catch (Exception )
                    {
                        return false;
                        throw;
                    }
                }
                catch (Exception )
                {
                    return false;
                    throw;
                }
                finally
                {
                    cnx.Close();
                }
            }
            else
            {
                return false;
            }
        }

        public DataTable FiltroUsuarios(int idx)
        {
            ConeccionBD connection = new ConeccionBD();
            SqlConnection cnx = new SqlConnection(connection.Conneccion());
            try
            {
                cnx.Open();
                SqlCommand cmd = new SqlCommand("SP_FILTROUSUARIOS", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", idx);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                return dt;
            }
            catch (Exception )
            {
                throw;
            }
            finally
            {
                cnx.Close();
            }
        }

        public bool ModificarUsuario(int idx, string email, string contrasena, string confirmarContrasena, string nombre, string rut, string direccion, string telefono, DateTime fechanacimiento, int tipoUsuario)
        {
            if (contrasena == confirmarContrasena)
            {
                ConeccionBD connection = new ConeccionBD();
                SqlConnection cnx = new SqlConnection(connection.Conneccion());
                try
                {
                    cnx.Open();
                    SqlCommand cmd = new SqlCommand("SP_MODIFICARUSUARIO", cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", idx);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Contrasena", contrasena);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Rut", rut);
                    cmd.Parameters.AddWithValue("@Direccion", direccion);
                    cmd.Parameters.AddWithValue("@Telefono", telefono);
                    cmd.Parameters.AddWithValue("@Fecha_Nacimiento", fechanacimiento);
                    cmd.Parameters.AddWithValue("@Id_tipo_Usuario", tipoUsuario);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        Refresh2();
                        return true;
                    }
                    catch (Exception )
                    {
                        return false;
                        throw;
                    }

                }
                catch (Exception )
                {
                    return false;
                    throw;
                }
                finally
                {
                    cnx.Close();
                }
            }
            else
            {                
                return false;
            }
        }

        public bool EliminarUsuario(int idx)
        {

            ConeccionBD connection = new ConeccionBD();
            SqlConnection cnx = new SqlConnection(connection.Conneccion());
            try
            {
                cnx.Open();
                SqlCommand cmd = new SqlCommand("SP_ELIMINARUSUARIO", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", idx);

                try
                {
                    cmd.ExecuteNonQuery();
                    Refresh2();
                    return true;
                }
                catch (Exception )
                {
                    return false;
                    throw;
                }
            }
            catch (Exception )
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

