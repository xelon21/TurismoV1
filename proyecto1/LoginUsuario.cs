using Oracle.ManagedDataAccess.Client;
using proyecto1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TurismoBD.Controladores;
using TurismoBD.Entidades;

namespace proyecto1
{
    public partial class LoginUsuario : Form
    {
        public static long rol;
        UsuarioController controller = new UsuarioController();
        EmpleadoController empController = new EmpleadoController(); 
        public static string user;
        public static string pass;
        public static string nombre;
        public static long idEmpleado;
        public static long idZona;
        public LoginUsuario()
        {
            InitializeComponent();
        }
               
        public async void Login(string usuario, string password)
        {           
                
            try
            {
                var empleados = await empController.TraerEmpleados();

                var usuarios = await controller.TraerUsuarios();

                foreach (var item in usuarios.Usuario)
                {                  
                    if (item.email == usuario)
                    {
                        if (item.contrasena == password)
                        {
                            foreach (var item2 in empleados.empleado)
                            {
                                if(item2.id_usuario_id == item.id_usuario)
                                {
                                    user = item.email;
                                    pass = item.contrasena;
                                    rol = item.id_tipo_usuario_id;
                                    nombre = item.nombre_completo;
                                    idEmpleado = item2.id_empleado;
                                    idZona = item2.id_zona_id;

                                }
                            }
                        }
                    }
                }

                if(user != null && pass != null)
                {
                    MessageBox.Show("¡Bienvenido! " + nombre);
                    MenuTurismoReal menu = new MenuTurismoReal();
                    this.Hide();
                    menu.Show();
                }
                else
                {
                    MessageBox.Show("Credenciales Incorrectas");
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
                throw;
            }            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MenuTurismoReal menu = new MenuTurismoReal();
            //this.Hide();
            //menu.Show();
            Login(txtUsuario.Text, txtPassword.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void LoginUsuario_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

#region codigo

//Connection connection = new Connection();
//SqlConnection cnx = new SqlConnection(connection.Conneccion());
//cnx.Open();
//SqlCommand cmd = new SqlCommand("SP_LOGIN", cnx);
//cmd.CommandType = CommandType.StoredProcedure;
//cmd.Parameters.AddWithValue("@Email", usuario);
//cmd.Parameters.AddWithValue("@Password", password);
//SqlDataAdapter sda = new SqlDataAdapter(cmd);
//DataTable dt = new DataTable();
//sda.Fill(dt);

//if (dt.Rows.Count == 1)
//{
//    rol = Int32.Parse(dt.Rows[0][1].ToString());

//    MenuTurismoReal menu = new MenuTurismoReal();
//    this.Hide();
//    menu.Show();
//}
//else
//{
//    MessageBox.Show("Credenciales Incorrectas");
//    return;
//}
#endregion
#region ORACULO DEL DEMONIO


//OracleConnection con = new OracleConnection();

////using connection string attributes to connect to Oracle Database
//con.ConnectionString = "User Id=SYSTEM;Password=Blackheart5469;Data Source=PRUEBAS";
//con.Open();
//MessageBox.Show("Connected to Oracle" + con.ServerVersion);


//using (OracleConnection conn = new OracleConnection("User ID=system;Password=.Blackheart5469;Data Source=TURISMO"))
//{
//    conn.Open();
//    using (OracleCommand command = new OracleCommand("select to_char(sysdate,'MM-DD-YYYY HH24:MI:SS') from dual", conn))
//    {
//        using (OracleDataReader dr = command.ExecuteReader())
//        {
//            MessageBox.Show(dr.GetValue(0).ToString());
//        }
//    }
//    conn.Close();
//}
#endregion
