using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using TurismoBD.Controladores;
using TurismoBD.Entidades;
using TurismoBD.Helpers;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace proyecto1
{
    public partial class MantenedorInventario : Form
    {
        public static int indice;
        public static int cont = 1;
        public static long idArt = 0;
        public static long idInv = 0;
        InventarioController controller = new InventarioController();
        DepartamentoController deptoCOntrol = new DepartamentoController();
        ComboBoxsTurismo combo = new ComboBoxsTurismo();
        Validaciones validar = new Validaciones();


        public MantenedorInventario()
        {
            InitializeComponent();
            rdbIngresarInventario.Checked = true;
            panelMostrarInv.Hide();
            panelModificarInventario.Hide();
            paneldgvModificarInventario.Hide();

            GetArticulos();
            CargaTipoArticulo();
            CargarDeptos();

        }

        public async Task CargaTipoArticulo()
        {
            List<TipoArticulo> lst = new List<TipoArticulo>();
            var com = await combo.CargarCategorias();
            if (com != null)
            {
                foreach (var item in com.tipoArticulo)
                {
                    lst.Add(item);
                }
            }
            cmbTipoArticulo.DataSource = lst;
            cmbTipoArticulo.DisplayMember = "descripcion";
            cmbTipoArticulo.ValueMember = "id_categoria";
            cmbTipoArticuloModificar.DataSource = lst;
            cmbTipoArticuloModificar.DisplayMember = "descripcion";
            cmbTipoArticuloModificar.ValueMember = "id_categoria";
        }

        public async Task CargarDeptos()
        {
            List<Departamento> lst = new List<Departamento>();
            var com = await combo.CargarComboDeptos();
            if (com != null)
            {
                foreach (var item in com.Departamentos)
                {
                    lst.Add(item);
                }
            }
            cmbNumeroDepartamento.DataSource = lst;
            cmbNumeroDepartamento.DisplayMember = "direccion";
            cmbNumeroDepartamento.ValueMember = "id_depto";
            cmbDepartamentoModificar.DataSource = lst;
            cmbDepartamentoModificar.DisplayMember = "direccion";
            cmbDepartamentoModificar.ValueMember = "id_depto";
        }

        private async void GetArticulos()
        {
            List<Articulo> lst = new List<Articulo>();
            var com = await controller.TraerArticulos();
            if (com != null)
            {
                foreach (var item in com.Articulo)
                {
                    lst.Add(item);
                }
            }
            dgvInventario.DataSource = lst;
            dgvInventario2.DataSource = lst;
            dgvInventario3.DataSource = lst;
        }      
        private async void btnIngresarInventario_Click(object sender, EventArgs e)
        {
            List<Articulo> lst = new List<Articulo>();
            List<DetalleInventario> lst2 = new List<DetalleInventario>();
            List<Inventario> lst3 = new List<Inventario>();
          
            bool creadoEnInventario = false;
            string nombre = txtNombreArticulo.Text;
                string descripcion = txtDescripcion.Text;
                int costo = (int)nudCosto.Value;
                int categoria = cmbTipoArticulo.SelectedIndex + 1;
                //int depto = cmbNumeroDepartamento.SelectedIndex + 1;
                DateTime hoy = DateTime.Now;
                string anio = hoy.Year.ToString();
                string mes = hoy.Month.ToString();
                string dia = hoy.Day.ToString();
                string fecha = anio + "-" + mes + "-" + dia;
            try
            {

                bool respArticulo = await controller.IngresarArticulos(nombre, descripcion, costo, fecha, categoria);
                if (!respArticulo)
                {
                    var art = await controller.TraerArticulos();

                    foreach (var item in art.Articulo)
                    {
                        lst.Add(item);                        
                    }
                    cont = 1;
                    foreach (var item2 in lst)
                    {
                        if (cont == lst.Count)
                        {
                            idArt = item2.id_articulo;
                        }
                        else
                        {
                            cont++;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se agregó el Artículo");
                    return;
                }

                long idDepto = long.Parse(cmbNumeroDepartamento.SelectedValue.ToString());

                var detInv = await controller.TraerInventarios();
                if (detInv != null)
                {
                    foreach (var item in detInv.inventario)
                    {
                        lst3.Add(item);                
                    }
                }

                foreach (var item in lst3)
                {
                    if (item.id_depto == idDepto)
                    {
                        bool respDetInv = await controller.IngresarDetalleInventario(idArt, item.id_inventario);
                        if (!respDetInv)
                        {
                            MessageBox.Show("Se a agregado un Artículo");
                            GetArticulos();
                            creadoEnInventario = true;
                            return;
                        }
                        else
                        {

                            MessageBox.Show("No se agregó el Artículo");
                            return;
                        }
                    }
                    else
                    {
                        creadoEnInventario = false;
                    }

                }

                if (!creadoEnInventario)
                {
                    bool respInv = await controller.IngresarInventario(idDepto, fecha);
                    if (!respInv)
                    {
                        var inv = await controller.TraerInventarios();
                        foreach (var item in inv.inventario)
                        {
                            lst3.Add(item);
                        }
                        cont = 0;
                        foreach (var item in lst3)
                        {
                            if (cont == lst.Count)
                            {
                               idInv = item.id_inventario;
                            }
                            else
                            {
                                cont++;
                            }
                        }

                        var detInv2 = await controller.TraerDetallesInventarios();
                        if (detInv2 != null)
                        {
                            foreach (var item in detInv2.detalleInventario)
                            {
                                if (item.id_inventario_id == idInv)
                                {
                                    bool respDetInv = await controller.IngresarDetalleInventario(idArt, idInv);
                                    if (!respDetInv)
                                    {
                                        MessageBox.Show("Se a agregado un Artículo");
                                        GetArticulos();
                                        creadoEnInventario = true;
                                        return;
                                    }
                                    else
                                    {

                                        MessageBox.Show("No se agregó el Artículo");
                                        return;
                                    }
                                }
                                else
                                {
                                    creadoEnInventario = false;
                                }
                            }
                        }
                    }
                }
                

                //bool resp = await controller.IngresarArticulos(nombre, descripcion, costo, fecha, categoria);
                //if (!resp)
                //{
                //    MessageBox.Show("Se a agregado un Artículo");
                //    GetArticulos();
                //}
                //else
                //{
                //    MessageBox.Show("No se agregó el Artículo");
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
                throw;
            }
        }


        private void rdbIngresarInventario_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbIngresarInventario.Checked.Equals(true))
            {  
                panelMostrarInv.Hide();
                panelModificarInventario.Hide();
                paneldgvModificarInventario.Hide();
                dgvInventario.Show();
                panelIngresoInventario.Show();
                GetArticulos();

            }
        }

        private void rdbMostrarInventario_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMostrarInventario.Checked.Equals(true))
            {
                panelIngresoInventario.Hide(); 
                dgvInventario.Hide();
                paneldgvModificarInventario.Hide();
                panelModificarInventario.Hide();
                panelMostrarInv.Show();
                GetArticulos();
            }
        }

        private void rdbModificarEliminarInventario_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbModificarEliminarInventario.Checked.Equals(true))
            {
                dgvInventario.Hide();
                panelMostrarInv.Hide();
                panelIngresoInventario.Hide();            
                panelModificarInventario.Show();
                paneldgvModificarInventario.Show();
                GetArticulos();
            }
        }


        private void btnVolverDepartamentos_Click(object sender, EventArgs e)
        {
            this.Close();
        }            

        private void MantenedorInventario_Load(object sender, EventArgs e)
        {
            GetArticulos();
        }

        private void dgvInventario3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = Int32.Parse(dgvInventario3.CurrentRow.Cells["ID"].Value.ToString());
            DataTable dt = controller.FiltrarInventario(idx);
            DataTable dt2 = controller.FiltrarInventarioModificar(idx);
            try
            {
                //cmbTipoArticuloModificar.DataSource = combo.CargarComboBoxCategoria();
                //cmbTipoArticuloModificar.DisplayMember = "descripcion";
                //cmbTipoArticuloModificar.ValueMember = "id_categoria";

                //cmbDepartamentoModificar.DataSource = combo.CargarComboBoxDepartamento();
                //cmbDepartamentoModificar.DisplayMember = "direccion";
                //cmbDepartamentoModificar.ValueMember = "id_depto";

                var inde = validar.ValidaInt32(dt2.Rows[0][6].ToString());
                var inde2 = validar.ValidaInt32(dt2.Rows[0][5].ToString());

                


                cmbDepartamentoModificar.SelectedValue = inde;
                cmbTipoArticuloModificar.SelectedValue = inde2;
                txtNombreModificar.Text = dt.Rows[0][1].ToString();
                txtDescripcionModificar.Text = dt.Rows[0][2].ToString();
                nudCostoModificar.Value = Int32.Parse(dt.Rows[0][3].ToString());               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
                throw;
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dgvInventario3.CurrentRow.Selected == false)
            {
                MessageBox.Show("Debe seleccionar un Artículo a eliminar");
            }
            else
            {
                MessageBoxButtons botones = MessageBoxButtons.YesNoCancel;
                DialogResult dr = MessageBox.Show("¿Esta seguro que desea elimina el Artículo seleccionado?", "Eliminando Artículo", botones,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        int idx = Int32.Parse(dgvInventario3.CurrentRow.Cells["ID"].Value.ToString());
                        if(idx == 0) {
                            MessageBox.Show("Debe seleccionar un Artículo a eliminar");
                        }
                        else
                        {
                            bool resp = controller.EliminarInventario(idx);
                            if (resp)
                            {
                                MessageBox.Show("Se ha eliminado un Artículo");
                                dgvInventario3.DataSource = controller.Refresh2();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo eliminar el Artículo");
                            }                       
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex);
                        throw;
                    }
               
                }
                else if (dr == DialogResult.Cancel)
                {
                    MessageBox.Show("Operación Cancelada");
                }

            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int idx = Int32.Parse(dgvInventario3.CurrentRow.Cells["ID"].Value.ToString());
                string nombre = txtNombreModificar.Text;
                string descripcion = txtDescripcionModificar.Text;
                int costo = (int)nudCostoModificar.Value;
                int categoria = cmbTipoArticuloModificar.SelectedIndex + 1;
                bool resp = controller.ModificarInventario(idx, nombre, descripcion, costo, categoria);
                if (resp)
                {
                    MessageBox.Show("Se modificó un Artículo");
                    dgvInventario3.DataSource = controller.Refresh2();
                }
                else
                {
                    MessageBox.Show("No se pudo modificar el Artículo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
                throw;
            }


        }

        private void panelModificarInventario_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

#region lo que estaba antes

//public DataTable CargarComboBoxCategoria()
//{
//    Connection connection = new Connection();
//    var dt = new DataTable();
//    var cmd = new SqlCommand();
//    var cnx = new SqlConnection(connection.Conneccion());
//    SqlDataAdapter da = new SqlDataAdapter("Select id_Categoria, descripcion from CATEGORIA;", cnx);
//    da.SelectCommand.CommandType = CommandType.Text;
//    da.Fill(dt);
//    return dt;
//}

//int indiceCategoria = cmbTipoArticulo.SelectedIndex + 1;
//CrudInventarioTableAdapters.ARTICULOTableAdapter ta = new CrudInventarioTableAdapters.ARTICULOTableAdapter();
//ta.SP_INGRESAARTICULOS(0, txtNombreArticulo.Text, txtDescripcion.Text, (int)nudCosto.Value, DateTime.Now, indiceCategoria);
//Refresh();


//Connection connection = new Connection();
//SqlConnection cnx = new SqlConnection(connection.Conneccion());
//try
//{
//    cnx.Open();
//    SqlCommand cmd = new SqlCommand("SP_INGRESAARTICULOS", cnx);
//    cmd.CommandType = CommandType.StoredProcedure;
//    cmd.Parameters.AddWithValue("@Nombre", txtNombreArticulo.Text);
//    cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
//    cmd.Parameters.AddWithValue("@Costo", (int)nudCosto.Value);
//    cmd.Parameters.AddWithValue("@FechaActualizacion", DateTime.Now);
//    cmd.Parameters.AddWithValue("@IdCategoria", cmbTipoArticulo.SelectedIndex + 1);

//    try
//    {
//        cmd.ExecuteNonQuery();
//        MessageBox.Show("Se agrego un Articulo");
//        Refresh();
//    }
//    catch (Exception ex)
//    {
//        MessageBox.Show("Error: " + ex);
//        throw;
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


//private void Refresh()
//{
//    Connection connection = new Connection();
//    var dt = new DataTable();
//    var cmd = new SqlCommand();
//    var cnx = new SqlConnection(connection.Conneccion());
//    var dt2 = new DataTable();
//    var cmd2 = new SqlCommand();
//    var cnx2 = new SqlConnection(connection.Conneccion());
//    try
//    {
//        cnx.Open();
//        cmd.Connection = cnx;
//        cmd.CommandType = CommandType.Text;
//        cmd.CommandText = "SELECT  nombre as Nombre, " +
//                          "descirpcion as Descripcion, " +
//                          "costo_reposicion as Costo, " +
//                          "fehca_actualizacion as Fecha_Actualizacion, " +
//                          "c.descripcion as Tipo_Articulo " +
//                          "FROM dbo.ARTICULO a join dbo.CATEGORIA c " +
//                          "on(a.id_categoria = c.id_categoria) " +
//                          "order by id_articulo desc";
//        var da = new SqlDataAdapter(cmd);
//        da.Fill(dt);
//        dgvInventario.DataSource = dt;
//        dgvInventario2.DataSource = dt;
//        try
//        {

//            cnx2.Open();
//            cmd2.Connection = cnx;
//            cmd2.CommandType = CommandType.Text;
//            cmd2.CommandText = "SELECT  id_articulo as ID, " +
//                              "nombre as Nombre, " +
//                              "descirpcion as Descripcion, " +
//                              "costo_reposicion as Costo, " +
//                              "fehca_actualizacion as Fecha_Actualizacion, " +
//                              "c.descripcion as Tipo_Articulo " +
//                              "FROM dbo.ARTICULO a join dbo.CATEGORIA c " +
//                              "on(a.id_categoria = c.id_categoria) " +
//                              "order by id_articulo asc";
//            var da2 = new SqlDataAdapter(cmd2);
//            da2.Fill(dt2);
//            dgvInventario3.DataSource = dt2;

//        }
//        catch (Exception ex)
//        {
//            MessageBox.Show("Error: " + ex);
//            throw;
//        }

//    }
//    catch (Exception ex)
//    {
//        MessageBox.Show("Error: " + ex);
//        throw;
//    }
//    finally
//    {
//        cnx.Close();
//        cnx2.Close();
//    }

//    //CrudInventarioTableAdapters.ARTICULOTableAdapter crudInventarioTA = new CrudInventarioTableAdapters.ARTICULOTableAdapter();

//    //CrudInventario.ARTICULODataTable dt = crudInventarioTA.TraerArticulos();
//    //dgvInventario.DataSource = dt;
//}


//Connection connection = new Connection();
//SqlConnection cnx = new SqlConnection(connection.Conneccion());
//try
//{
//    cnx.Open();
//    SqlCommand cmd = new SqlCommand("SP_FILTROARTICULOS", cnx);
//    cmd.CommandType = CommandType.StoredProcedure;
//    cmd.Parameters.AddWithValue("@ID", idx);
//    SqlDataAdapter sda = new SqlDataAdapter(cmd);
//    DataTable dt = new DataTable();
//    sda.Fill(dt);

//    if (dt.Rows.Count == 1)
//    {
//        int costo = Int32.Parse(dt.Rows[0][3].ToString());

//        cmbTipoArticuloModificar.DataSource = CargarComboBoxCategoria();
//        cmbTipoArticuloModificar.DisplayMember = "descripcion";
//        cmbTipoArticuloModificar.ValueMember = "id_categoria";
//        cmbTipoArticuloModificar.SelectedValue = dt.Rows[0][5].ToString();
//        txtNombreModificar.Text = dt.Rows[0][1].ToString();
//        txtDescripcionModificar.Text = dt.Rows[0][2].ToString();
//        nudCostoModificar.Value = costo;


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
//try
//{
//    cnx.Open();
//    SqlCommand cmd = new SqlCommand("SP_ELIMINARARTICULO", cnx);
//    cmd.CommandType = CommandType.StoredProcedure;
//    cmd.Parameters.AddWithValue("@ID", idx);

//    try
//    {
//        cmd.ExecuteNonQuery();
//        Refresh();
//    }
//    catch (Exception ex)
//    {
//        MessageBox.Show("Error: " + ex);
//        throw;
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
//MessageBox.Show("Se ha eliminado el articulo seleccionado");



//Connection connection = new Connection();
//SqlConnection cnx = new SqlConnection(connection.Conneccion());
//try
//{
//    cnx.Open();
//    SqlCommand cmd = new SqlCommand("SP_MODIFICARARTICULO", cnx);
//    cmd.CommandType = CommandType.StoredProcedure;
//    cmd.Parameters.AddWithValue("@ID", idx);
//    cmd.Parameters.AddWithValue("@Nombre", txtNombreModificar.Text);
//    cmd.Parameters.AddWithValue("@Descripcion", txtDescripcionModificar.Text);
//    cmd.Parameters.AddWithValue("@Costo", (int)nudCostoModificar.Value);
//    cmd.Parameters.AddWithValue("@FechaActualizacion", DateTime.Now);
//    cmd.Parameters.AddWithValue("@IdCategoria", cmbTipoArticuloModificar.SelectedIndex + 1);

//    try
//    {
//        cmd.ExecuteNonQuery();
//        MessageBox.Show("Se modifico un articulo");
//        Refresh();
//    }
//    catch (Exception ex)
//    {
//        MessageBox.Show("Error: " + ex);
//        throw;
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
#endregion