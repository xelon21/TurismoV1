using iText.Layout.Element;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TurismoBD.ApiHelpers;
using TurismoBD.Controladores;
using TurismoBD.Entidades;
using TurismoBD.Helpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.Common;

namespace proyecto1
{
    public partial class MantenedorDepartamento : Form
    {
        private readonly DepartamentoController departamentos = new();
        DepartamentoController depto = new DepartamentoController();
        ComboBoxsTurismo combo = new ComboBoxsTurismo();
        Validaciones validar = new Validaciones();

        public MantenedorDepartamento()
        {
            InitializeComponent();
            panelIngresoDepartamento.Show();
            panelIngresoDepartamento2.Show();
            panelMostrarDepartamento.Hide();
            panelModificarDepartamento.Hide();
            panelModificarDepartamento2.Hide();


            //dgvDepartamentos.Columns.Add("ID", "ID");
            //dgvDepartamentos.Columns.Add("Direccion", "Direccion");
            //dgvDepartamentos.Columns.Add("Valor Noche", "Valor Noche");
            //dgvDepartamentos.Columns.Add("Zona", "Zona");
            //dgvDepartamentos.Columns.Add("Metros Cuadrados", "Metros Cuadrados");
            //dgvDepartamentos.Columns.Add("Url Imagen", "Url Imagen");
            //dgvDepartamentos.Columns.Add("Descripcion", "Descripcion");
            //dgvDepartamentos.Columns.Add("Capacidad", "Capacidad");
            //dgvDepartamentos.Columns.Add("Cantidad Baños", "Cantidad Baños");
            //dgvDepartamentos.Columns.Add("Cantidad Camas", "Cantidad Camas");

            //dgvDepartamentos2.Columns.Add("ID", "ID");
            //dgvDepartamentos2.Columns.Add("Direccion", "Direccion");
            //dgvDepartamentos2.Columns.Add("Valor Noche", "Valor Noche");
            //dgvDepartamentos2.Columns.Add("Zona", "Zona");
            //dgvDepartamentos2.Columns.Add("Metros Cuadrados", "Metros Cuadrados");
            //dgvDepartamentos2.Columns.Add("Url Imagen", "Url Imagen");
            //dgvDepartamentos2.Columns.Add("Descripcion", "Descripcion");
            //dgvDepartamentos2.Columns.Add("Capacidad", "Capacidad");
            //dgvDepartamentos2.Columns.Add("Cantidad Baños", "Cantidad Baños");
            //dgvDepartamentos2.Columns.Add("Cantidad Camas", "Cantidad Camas");

            CargaZona();
            GetDeptos();

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
            cmbZonaMod.DataSource = lst;
            cmbZonaMod.DisplayMember = "descripcion";
            cmbZonaMod.ValueMember = "id_zona";
        }

        private async void GetDeptos()
        {

            //int indiceFila = dgvDepartamentos.Rows.Add();
            //int indiceFila2 = dgvDepartamentos2.Rows.Add();
            //// int indiceFila3 = dgvInventario3.Rows.Add();
            //DataGridViewRow fila = dgvDepartamentos.Rows[indiceFila];
            //DataGridViewRow fila2 = dgvDepartamentos2.Rows[indiceFila2];

            List<Departamento> lst = new List<Departamento>();
            var com = await departamentos.TraerDepartamentos();
           // var com2 = await combo.CargarComboBoxZona();
            if(com == null)
            {
                MessageBox.Show("No se encontraron registros");
            }
            else
            {
                foreach (var item in com.Departamentos)
                {               

                    //fila.Cells["ID"].Value = item.id_depto.ToString();
                    //fila.Cells["Direccion"].Value = item.direccion.ToString();
                    //fila.Cells["Valor Noche"].Value = item.valor_noche.ToString();               
                    //fila.Cells["Metros Cuadrados"].Value = item.m2.ToString();
                    //fila.Cells["Url Imagen"].Value = item.imagen_url.ToString();
                    //fila.Cells["Descripcion"].Value = item.descripcion.ToString();
                    //fila.Cells["Capacidad"].Value = item.capacidad.ToString();
                    //fila.Cells["Cantidad Baños"].Value = item.q_banos.ToString();
                    //fila.Cells["Cantidad Camas"].Value = item.q_plazas.ToString();

                    //fila2.Cells["ID"].Value = item.id_depto.ToString();
                    //fila2.Cells["Direccion"].Value = item.direccion.ToString();
                    //fila2.Cells["Valor Noche"].Value = item.valor_noche.ToString();
                    //fila2.Cells["Metros Cuadrados"].Value = item.m2.ToString();
                    //fila2.Cells["Url Imagen"].Value = item.imagen_url.ToString();
                    //fila2.Cells["Descripcion"].Value = item.descripcion.ToString();
                    //fila2.Cells["Capacidad"].Value = item.capacidad.ToString();
                    //fila2.Cells["Cantidad Baños"].Value = item.q_banos.ToString();
                    //fila2.Cells["Cantidad Camas"].Value = item.q_plazas.ToString();

                    //foreach (var item2 in com2.Zona)
                    //{
                    //    if(item.id_zona_id == item2.id_zona)
                    //    {
                    //        fila.Cells["Zona"].Value = item2.descripcion.ToString();
                    //        fila2.Cells["Zona"].Value = item2.descripcion.ToString();
                    //    }
                    //}
                              
                    lst.Add(item);
                }                       
                dgvDepartamentos.DataSource = lst;
                dgvDepartamentos2.DataSource = lst;
                dgvDepartamentos3.DataSource = lst;
            }
        }


        private void rdbIngresarDepartamento_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbIngresarDepartamento.Checked.Equals(true))
            {
                panelIngresoDepartamento.Show();
                panelIngresoDepartamento2.Show();
                panelMostrarDepartamento.Hide();
                panelModificarDepartamento.Hide();
                panelModificarDepartamento2.Hide();
            }
        }

        private void rdbMostrarDepartamento_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMostrarDepartamento.Checked.Equals(true))
            {
                panelMostrarDepartamento.Show();
                panelIngresoDepartamento.Hide();
                panelIngresoDepartamento2.Hide();
                panelModificarDepartamento.Hide();
                panelModificarDepartamento2.Hide();
            }
        }
        private void rdbModificarYEliminarDepartamento_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbModificarYEliminarDepartamento.Checked.Equals(true))
            {
                panelModificarDepartamento.Show();
                panelModificarDepartamento2.Show();
                panelIngresoDepartamento.Hide();
                panelIngresoDepartamento2.Hide();
                panelMostrarDepartamento.Hide();
            }
        }

        private async void btnIngresarDepartamento_Click(object sender, EventArgs e)
        {
            try
            {
                string descripcion = txtDescripcion.Text;
                int valorNoche = validar.ValidaInt32(txtValor.Text);
                int zona = validar.ValidaInt32(cmbZona.SelectedValue.ToString());
                int m2 = validar.ValidaInt32(txtMetrosCuadrados.Text);
                string img = txtUrlImagen.Text;
                string direccion = txtDireccion.Text;
                int capacidad = validar.ValidaInt32(txtCapacidad.Text);
                int qbanos = validar.ValidaInt32(txtCantidadBaños.Text);
                int qcamas = validar.ValidaInt32(txtCantidadCamas.Text);

                bool resp = await depto.IngresarDepartamento(descripcion, valorNoche, zona, m2, img, direccion, capacidad, qbanos, qcamas);
                if (!resp)
                {
                    MessageBox.Show("Se ha ingresado un departamento");
                    GetDeptos();
                }
                else
                {
                    MessageBox.Show("No se ha podido ingresar el departamento");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnVolverDepartamento_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificarDepartamento_Click(object sender, EventArgs e)
        {
            try
            {
                int idx = Int32.Parse(dgvDepartamentos3.CurrentRow.Cells["id_depto"].Value.ToString());
                string descripcion = txtDescripcionModificar.Text;
                int valorNoche = validar.ValidaInt32(txtValorModificar.Text);
                int zona = validar.ValidaInt32(cmbZona.SelectedValue.ToString());
                int m2 = validar.ValidaInt32(txtMetrosCuadradosModificar.Text);
                string img = txtUrlImg.Text;
                string direccion = txtDireccionModificar.Text;
                int capacidad = validar.ValidaInt32(txtCapacidadModificar.Text);
                int qbanos = validar.ValidaInt32(txtCantidadBanosModificar.Text);
                int qcamas = validar.ValidaInt32(txtCantidadCamasModificar.Text);
                bool resp = depto.ModificarDepartamento(idx, descripcion, valorNoche, zona, m2, img, direccion, capacidad, qbanos, qcamas);
                if (resp)
                {
                    MessageBox.Show("Se modificó un departamento");
                    // dgvDepartamentos3.DataSource = depto.Refresh2();
                }
                else
                {
                    MessageBox.Show("No se pudo modificar el departamento");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
                throw;
            }
        }

        private void btnEliminarDepartamento_Click(object sender, EventArgs e)
        {
            int idx = validar.ValidaInt32(dgvDepartamentos3.CurrentRow.Cells["ID"].Value.ToString());
            MessageBoxButtons botones = MessageBoxButtons.YesNoCancel;
            DialogResult dr = MessageBox.Show("¿Esta seguro que desea elimina el Departamento seleccionado?", "Eliminando Departamento", botones,
                MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                bool resp = depto.EliminarDepartamento(idx);
                if (resp)
                {
                    MessageBox.Show("Se ha eliminado el Departamento seleccionado");
                    // dgvDepartamentos3.DataSource = depto.Refresh2();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el Departamento");
                }

            }
            else if (dr == DialogResult.Cancel)
            {
                MessageBox.Show("Operación Cancelada");
            }
        }

        private void MantenedorDepartamento_Load(object sender, EventArgs e)
        {
            //   dgvDepartamentos.DataSource = depto.Refresh();
            // dgvDepartamentos2.DataSource = depto.Refresh(); 
            //  dgvDepartamentos3.DataSource = depto.Refresh2();
            GetDeptos();
        }

        private async void dgvDepartamentos3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = validar.ValidaInt32(dgvDepartamentos3.CurrentRow.Cells["id_depto"].Value.ToString());            
            var com = await depto.TraerDepartamentoID(idx);
            //DepartamentoFiltradoResponse dep = new DepartamentoFiltradoResponse();
            //foreach (var item in com.Departamentos)
            //{
            //    dep.Departamentos = item;
            //    dep.descripcion = item.descripcion;
            //    dep.valor_noche = item.valor_noche;
            //    dep.m2 = item.m2;
            //    dep.imagen_url = item.imagen_url;
            //    dep.direccion = item.direccion;
            //    dep.capacidad = item.capacidad;
            //    dep.q_banos = item.q_banos;
            //    dep.q_plazas = item.q_plazas;
            //}
            try
            {
                CargaZona();
                foreach (var item in com.Departamentos)
                {
                    txtDescripcionModificar.Text = item.id_depto.ToString();
                    txtValorModificar.Text = item.valor_noche.ToString();
                    cmbZonaMod.SelectedValue = item.id_zona_id;
                    txtMetrosCuadradosModificar.Text = item.m2.ToString();
                    txtUrlImg.Text = item.imagen_url;
                    txtDireccionModificar.Text = item.direccion;
                    txtCapacidadModificar.Text = item.capacidad.ToString();
                    txtCantidadBanosModificar.Text = item.q_banos.ToString();
                    txtCantidadCamasModificar.Text = item.q_plazas.ToString();   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
                throw;
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void panelModificarDepartamento2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}



#region codigos




////Aqui deserealizo el json mediante get y set que se encuentran en la clase DescomponerJson 

//Zona sc = JsonConvert.DeserializeObject<Zona>(combo.CargarComboBoxZona);

////Aqui creo una lista para que integre a todos los centros disponibles 
//List<DescomponerJson> Centro = new List<DescomponerJson>();

//var status = JsonConvert.DeserializeObject<List<Zona>>(lst.ToString());
//MessageBox.Show(status.ToString());
//var list  = status.ToList();
//cmbZona.DataSource = lst;
////aqui es donde trato de llenar el combo box mediante la lista y solo añadir el id y su nombre de cada centro 
//Centro.Add(sc);
//comboCentro.DataSource = Centro;
//comboCentro.ValueField = "id";
//comboCentro.TextField = "Nombres";
//foreach (var item in sc)
//{
//    cmbZona.Items.Add(item);
//}
//cmbZona.DisplayMember = "descipcion";
//cmbZona.ValueMember = "id_zona";

//dgvDepartamentos.DataSource = lst.ToString();
//dgvDepartamentos2.DataSource = lst.ToString();
//dgvDepartamentos3.DataSource = lst.Departamentos.ToString();
//string respuesta = await depto.GetHttp();
//var lst = JsonConvert.DeserializeObject<DepartamentoResponse>(respuesta);
//List<Whip> lst = JsonConvert.DeserializeObject<List<Whip>>(respuesta);


#endregion