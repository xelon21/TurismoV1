using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace proyecto1
{
    public partial class ServicioExtra : Form
    {
        public ServicioExtra()
        {
            InitializeComponent();
        }

        private void btnVolverDepartamento_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Refresh()
        {
            Connection connection = new Connection();
            var dt = new DataTable();
            var cmd = new SqlCommand();
            var cnx = new SqlConnection(connection.Conneccion());
            var dt2 = new DataTable();
            var cmd2 = new SqlCommand();
            var cnx2 = new SqlConnection(connection.Conneccion());
            try
            {
                cnx.Open();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select tarifa as Tarifa, " +
                                  "fecha_pago as Fecha_Pago, " +
                                  "t.descripcion as Tipo_Servicio " +
                                  "from SERVICIO_EXTRA s join TIPO_SERV t " +
                                  "on (s.id_tipo_serv = t.id_tipo) " +
                                  "order by id_servicio desc;";
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dgvServicioExtra.DataSource = dt;
                dgvServicioExtra2.DataSource = dt;
                try
                {

                    cnx2.Open();
                    cmd2.Connection = cnx;
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "select tarifa as Tarifa, " +
                                  "fecha_pago as Fecha_Pago, " +
                                  "t.descripcion as Tipo_Servicio " +
                                  "from SERVICIO_EXTRA s join TIPO_SERV t " +
                                  "on (s.id_tipo_serv = t.id_tipo) " +
                                  "order by id_servicio asc;";
                    var da2 = new SqlDataAdapter(cmd2);
                    da2.Fill(dt2);
                    dgvServicioExtra3.DataSource = dt2;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                    throw;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
                throw;
            }
            finally
            {
                cnx.Close();
                cnx2.Close();
            }

            //CrudInventarioTableAdapters.ARTICULOTableAdapter crudInventarioTA = new CrudInventarioTableAdapters.ARTICULOTableAdapter();

            //CrudInventario.ARTICULODataTable dt = crudInventarioTA.TraerArticulos();
            //dgvInventario.DataSource = dt;
        }

        private void ServicioExtra_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void rdbIngresarDepartamento_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
