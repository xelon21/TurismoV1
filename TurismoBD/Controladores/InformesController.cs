using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoBD;

namespace TurismoBD.Controladores
{
    public class InformesController
    {
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
                cmd.CommandText = "select id_reserva as ID, " +
                                  "f_checkin as Fecha_Ingreso, " +
                                  "valor_total as Ingresos " +                                  
                                  "from reserva;";
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
            var dt = new DataTable();
            var cmd = new SqlCommand();
            var cnx = new SqlConnection(connection.Conneccion());
            try
            {
                cnx.Open();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select id_mantencion as ID, " +
                                  "fecha_pago as Fecha_Gastos, " +
                                  "concepto as Concepto ," +
                                  "valor_pago as Gastos " +
                                  "from GASTO_DEPTO; ";
                                  
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

        public DataTable mostrarUltimoRegistro()
        {
            ConeccionBD connection = new ConeccionBD();
            SqlConnection cnx = new SqlConnection(connection.Conneccion());
            try
            {
                cnx.Open();
                SqlCommand cmd = new SqlCommand("SP_TRAEULTIMOINGRESADO", cnx);
                cmd.CommandType = CommandType.StoredProcedure;               
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


        public DataTable FiltrarIngresos(DateTime inicio, DateTime fin)
        {
            ConeccionBD connection = new ConeccionBD();
            SqlConnection cnx = new SqlConnection(connection.Conneccion());
            try
            {
                cnx.Open();
                SqlCommand cmd = new SqlCommand("SP_FILTRAINGRESOS", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Inicio", inicio);
                cmd.Parameters.AddWithValue("@Fin", fin);
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
        public DataTable FiltraTotalIngresosEgresos(DateTime inicio, DateTime fin)
        {
            ConeccionBD connection = new ConeccionBD();
            SqlConnection cnx = new SqlConnection(connection.Conneccion());
            try
            {
                cnx.Open();
                SqlCommand cmd = new SqlCommand("SP_FILTRARENTABILIDADTOTAL", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Inicio", inicio);
                cmd.Parameters.AddWithValue("@Fin", fin);
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

     
    }
}

#region codigo
//public DataTable FiltrarEgresos(DateTime inicio, DateTime fin)
//{
//    ConeccionBD connection = new ConeccionBD();
//    SqlConnection cnx = new SqlConnection(connection.Conneccion());
//    try
//    {
//        cnx.Open();
//        SqlCommand cmd = new SqlCommand("SP_FILTRAEGRESOS", cnx);
//        cmd.CommandType = CommandType.StoredProcedure;
//        cmd.Parameters.AddWithValue("@Inicio", inicio);
//        cmd.Parameters.AddWithValue("@Fin", fin);
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
//public bool IngresarGastos(int idDepto, long idEmpleado, string concepto, string descripcion, int idmp, int valorPago, DateTime fechaPago)
//{
//    ConeccionBD connection = new ConeccionBD();
//    SqlConnection cnx = new SqlConnection(connection.Conneccion());
//    try
//    {
//        cnx.Open();
//        SqlCommand cmd = new SqlCommand("SP_INGRESAGASTODEPTO", cnx);
//        cmd.CommandType = CommandType.StoredProcedure;
//        cmd.Parameters.AddWithValue("@Iddepto", idDepto);
//        cmd.Parameters.AddWithValue("@Idempleado", idEmpleado);
//        cmd.Parameters.AddWithValue("@Concepto", concepto);
//        cmd.Parameters.AddWithValue("@Descripcion", descripcion);
//        cmd.Parameters.AddWithValue("@Idmp", idmp);
//        cmd.Parameters.AddWithValue("@ValorPago", valorPago);
//        cmd.Parameters.AddWithValue("@fechaPago", fechaPago);

//        try
//        {
//            cmd.ExecuteNonQuery();
//            return true;
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

//public DataTable TotalIngreso(DateTime inicio, DateTime fin)
//{
//    ConeccionBD connection = new ConeccionBD();
//    SqlConnection cnx = new SqlConnection(connection.Conneccion());
//    try
//    {
//        cnx.Open();
//        SqlCommand cmd = new SqlCommand("SP_FILTRATOTALINGRESOS", cnx);
//        cmd.CommandType = CommandType.StoredProcedure;
//        cmd.Parameters.AddWithValue("@Inicio", inicio);
//        cmd.Parameters.AddWithValue("@Fin", fin);
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

//public DataTable TotalEgreso(DateTime inicio, DateTime fin)
//{

//    ConeccionBD connection = new ConeccionBD();
//    SqlConnection cnx = new SqlConnection(connection.Conneccion());
//    try
//    {
//        cnx.Open();
//        SqlCommand cmd = new SqlCommand("SP_FILTRATOTALEGRESOS", cnx);
//        cmd.CommandType = CommandType.StoredProcedure;
//        cmd.Parameters.AddWithValue("@Inicio", inicio);
//        cmd.Parameters.AddWithValue("@Fin", fin);
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