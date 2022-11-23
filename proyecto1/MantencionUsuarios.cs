using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TurismoBD.Controladores;
using TurismoBD.Entidades;
using TurismoBD.Helpers;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;

namespace proyecto1
{
    public partial class MantencionUsuarios : Form
    {
        UsuarioController controller = new UsuarioController();
        EmpleadoController empController = new EmpleadoController();
        ComboBoxsTurismo combo = new ComboBoxsTurismo();
        Validaciones validar = new Validaciones();
        public static long idUser;
        public static int cont;

        public enum TipoEmpleado
        {
            Recursos_Humanos,
            Recepcionista,
            Contratista,
            Guia_Turista
        }

        public MantencionUsuarios()
        {
            InitializeComponent();

            panelIngresoUsuarios.Show();
            panelIngresoUsuarios2.Show();
            panelMostrarUsuarios.Hide();
            panelModificarUsuarios.Hide();
            panelModificarUsuarios2.Hide();
            rdbIngresarUsuario.Checked = true;

            GetUsuarios();
            CargaZona();

            

        }

        public async Task CargaZona()
        {
            List<Zona> lst = new List<Zona>();
            var com = await combo.CargarComboBoxZona();
            foreach (var item in com.Zona)
            {
                lst.Add(item);
            }
            cmbZona.DataSource = lst;
            cmbZona.DisplayMember = "descripcion";
            cmbZona.ValueMember = "id_zona";
            cmbModificarZona.DataSource = lst;
            cmbModificarZona.DisplayMember = "descripcion";
            cmbModificarZona.ValueMember = "id_zona";
        }

        private async void GetUsuarios()
        {
            List<Usuario> lst = new List<Usuario>();
            var com = await controller.TraerUsuarios();
            foreach (var item in com.Usuario)
            {
                lst.Add(item);
            }
            dgvUsuarios.DataSource = lst;
            dgvUsuarios2.DataSource = lst;
            dgvUsuarios3.DataSource = lst;
        }
        private void MantencionUsuarios_Load(object sender, EventArgs e)
        {
          //  dgvUsuarios.DataSource = GetUsuarios();
        }

        private async void btnIngresarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtNombre.Text == string.Empty || txtApellido.Text == string.Empty)
                {
                    MessageBox.Show("Debe ingresar un nombre y un apellido");
                    return;
                }
                else
                {
                    string email = txtEmail.Text;
                    string contrasena = txtContrasena.Text;
                    string confirmarContrasena = txtConfirmarContrasenaIngresar.Text;
                    string nombreCompleto = txtNombre.Text + " " + txtApellido.Text;
                    string rut = txtRut.Text;
                    string direccion = txtDireccion.Text;
                    string telefono = txtTelefono.Text;
                    DateTimeOffset fechanacimiento = DateTimeOffset.Parse(dtpFechaNacimiento.Value.ToString("yyyy-MM-dd"));
                    string anio = fechanacimiento.Year.ToString();
                    string mes = fechanacimiento.Month.ToString();
                    string dia = fechanacimiento.Day.ToString();
                    string fecha = anio + "-" + mes + "-" + dia;
                    string tipoEmpleado = cmbTipoEmpleado.SelectedItem.ToString();

                    if (confirmarContrasena == contrasena)
                    {
                        //bool respEmpleado = await empController.IngresaEmpleados( )
                        
                        bool resp = await controller.IngresarUsuario(email, contrasena, nombreCompleto, rut, direccion, telefono, fecha, 2);
                        if (!resp)
                        {                            
                            List<Usuario> lst = new List<Usuario>();
                            var com = await controller.TraerUsuarios();
                            foreach (var item in com.Usuario)
                            {                                
                               if(item.nombre_completo == txtNombre.Text + " " + txtApellido.Text)
                               {
                                    idUser = item.id_usuario;
                               }
                            }   
                            bool respEmp = await empController.IngresaEmpleados(idUser, txtNombre.Text, txtApellido.Text, txtRut.Text, txtDireccion.Text, validar.ValidaInt32(cmbZona.SelectedValue.ToString()), tipoEmpleado);
                            MessageBox.Show("se ha ingresado un Usuario");
                            GetUsuarios();
                        }
                        else
                        {
                            MessageBox.Show("No se ha podido agregar el Usuario");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Las contraseñas no coinciden");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void rdbIngresarUsuario_CheckedChanged(object sender, EventArgs e)
        {
            panelIngresoUsuarios.Show();
            panelIngresoUsuarios2.Show();
            panelMostrarUsuarios.Hide();
            panelModificarUsuarios.Hide();
            panelModificarUsuarios2.Hide();
        
            GetUsuarios();
        }
        private void rdbMostrarUsuario_CheckedChanged(object sender, EventArgs e)
        {
            panelIngresoUsuarios.Hide();
            panelIngresoUsuarios2.Hide();
            panelMostrarUsuarios.Show();
            panelModificarUsuarios.Hide();
            panelModificarUsuarios2.Hide();
        
            GetUsuarios();
        }
        private void rdbModificarYEliminarUsuario_CheckedChanged(object sender, EventArgs e)
        {
            panelIngresoUsuarios.Hide();
            panelIngresoUsuarios2.Hide();
            panelMostrarUsuarios.Hide();
            panelModificarUsuarios.Show();
            panelModificarUsuarios2.Show();
            GetUsuarios();
        }
        private void dgvUsuarios3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int idx = Int32.Parse(dgvUsuarios3.CurrentRow.Cells["ID"].Value.ToString());
                DataTable dt = controller.FiltroUsuarios(idx);


                txtEmailModificar.Text = dt.Rows[0][1].ToString();
                txtNombreModificar.Text = dt.Rows[0][3].ToString();
                txtRutModificar.Text = dt.Rows[0][4].ToString();
                txtDireccionModificar.Text = dt.Rows[0][5].ToString();
                txtTelefonoModificar.Text = dt.Rows[0][6].ToString();
                dtpFechaNacimientoModificar.Value = DateTime.Parse(dt.Rows[0][7].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
                throw;
            }
        }

        private void btnModificarDepartamento_Click(object sender, EventArgs e)
        {
            try
            {
                int idx = Int32.Parse(dgvUsuarios3.CurrentRow.Cells["ID"].Value.ToString());
                string email = txtEmailModificar.Text;
                string contraseña = txtContrasenaModificar.Text;
                string confirmarContrasena = txtConfirmarContrasena.Text;
                string nombre = txtNombreModificar.Text;
                string rut = txtRutModificar.Text;
                string direccion = txtDireccionModificar.Text;
                string telefono = txtTelefonoModificar.Text;
                DateTime fechanacimiento = DateTime.Parse(dtpFechaNacimientoModificar.Value.ToString());
                bool resp = controller.ModificarUsuario(idx, email, contraseña, confirmarContrasena, nombre, rut, direccion, telefono, fechanacimiento, 2);
                if (resp)
                {
                    MessageBox.Show("Se ha modificado un Usuario");
                    dgvUsuarios3.DataSource = controller.Refresh2();
                }
                else
                {
                    MessageBox.Show("No se pudo modificiar el Usuario");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
                throw;
            }
        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            MessageBoxButtons botones = MessageBoxButtons.YesNoCancel;
            DialogResult dr = MessageBox.Show("Esta Seguro que desea elimina el usuario seleccionado?", "Eliminando Usuario", botones,
                MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int idx = Int32.Parse(dgvUsuarios3.CurrentRow.Cells["ID"].Value.ToString());
                bool resp = controller.EliminarUsuario(idx);
                if (resp)
                {
                    MessageBox.Show("Se ha eliminado un usuario");
                    dgvUsuarios3.DataSource = controller.Refresh2();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el usuario");
                }

            }
            else if (dr == DialogResult.Cancel)
            {
                MessageBox.Show("Operacion Cancelada");
            }

        }
               
    }
}

#region otro codigo


//Connection connection = new Connection();
//SqlConnection cnx = new SqlConnection(connection.Conneccion());
//try
//{
//    int idx = Int32.Parse(dgvUsuarios3.CurrentRow.Cells["ID"].Value.ToString());
//    cnx.Open();
//    SqlCommand cmd = new SqlCommand("SP_FILTROUSUARIOS", cnx);
//    cmd.CommandType = CommandType.StoredProcedure;
//    cmd.Parameters.AddWithValue("@ID", idx);
//    SqlDataAdapter sda = new SqlDataAdapter(cmd);
//    DataTable dt = new DataTable();
//    sda.Fill(dt);

//    if (dt.Rows.Count == 1)
//    {
//        cmbTipoUsuarioModificar.DataSource = CargarComboBoxTipoUsuario();
//        cmbTipoUsuarioModificar.DisplayMember = "descripcion";
//        cmbTipoUsuarioModificar.ValueMember = "id_tipo";
//        cmbTipoUsuarioModificar.SelectedValue = dt.Rows[0][3].ToString();
//        txtEmailModificar.Text = dt.Rows[0][1].ToString();

//    }
//    else
//    {
//        MessageBox.Show("Error al hacer la operacion");
//        return;
//    }
//} 
//catch (Exception ex)
//{
//    MessageBox.Show("Error: " + ex);
//    throw;
//}
//finally
//{
//    cnx.Close();
//}

//Connection connection = new Connection();
//SqlConnection cnx = new SqlConnection(connection.Conneccion());
//    cnx.Open();
//                    SqlCommand cmd = new SqlCommand("SP_INGRESARUSUARIO", cnx);
//    cmd.CommandType = CommandType.StoredProcedure;
//                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
//                    cmd.Parameters.AddWithValue("@Contrasena", txtContrasena.Text);
//                    cmd.Parameters.AddWithValue("@Id_tipo_Usuario", cmbTipoUsuario.SelectedIndex + 1);

//                    try
//                    {
//                        cmd.ExecuteNonQuery();
//                        MessageBox.Show("Se agrego un Usuario");
//                        dgvUsuarios.DataSource = controller.Refresh();
//                    }
//                    catch (Exception ex)
//{
//    MessageBox.Show("Error: " + ex);
//    throw;
//}
//                }
//                catch (Exception ex)
//{
//    MessageBox.Show("Error: " + ex);
//    throw;
//}
//finally
//{
//    cnx.Close();
//}
#endregion
