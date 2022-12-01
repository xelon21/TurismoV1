using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;
using TurismoBD.Entidades;
using TurismoBD.Controladores;
using TurismoBD.Helpers;

namespace proyecto1
{
    public partial class PagoSueldos : Form
    {
        ComboBoxsTurismo combo = new ComboBoxsTurismo();
        GastoDeptosController gastoController = new GastoDeptosController();
        EmpleadoController emp = new EmpleadoController();
        Validaciones validar = new Validaciones();
        public PagoSueldos()
        {
            InitializeComponent();

            GetPagos();
            CargaEmpleados();
            CargaMedioDePago();
            CargaZonas();
        }

        private async void GetPagos()
        {
            List<PagoSueldo> lst = new List<PagoSueldo>();
            var com = await gastoController.TraePagoSueldos();
            if(com == null)
            {
                MessageBox.Show("No se encontraron registros");
            }
            else
            {
                foreach (var item in com.pagoSueldo)
                {
                    lst.Add(item);

                }
                dgvInformePago.DataSource = lst;
            }
        }
        public async Task CargaMedioDePago()
        {
            List<MedioDePago> lst = new List<MedioDePago>();
            var com = await combo.CargarMediosDePago();
            foreach (var item in com.medioDePago)
            {
                lst.Add(item);
            }
            cmbMedioPago.DataSource = lst;
            cmbMedioPago.DisplayMember = "descripcion";
            cmbMedioPago.ValueMember = "id_mp";
        }

        public async Task CargaZonas()
        {
            List<Zona> lst = new List<Zona>();
            var com = await combo.CargarComboBoxZona();
            foreach (var item in com.Zona)
            {
                lst.Add(item);
            }
            cmbZonaEmpleado.DataSource = lst;
            cmbZonaEmpleado.DisplayMember = "descripcion";
            cmbZonaEmpleado.ValueMember = "id_zona";
        }


        public async Task CargaEmpleados()
        {
            List<Empleado> lst = new List<Empleado>();
            var com = await emp.TraerEmpleados();
            if(com == null)
            {
                foreach (var item in com.empleado)
                {
                    lst.Add(item);
                }
                cmbEmpleado.DataSource = lst;
                cmbEmpleado.DisplayMember = "apellido";
                cmbEmpleado.ValueMember = "id_empleado";
            }
            else
            {
                MessageBox.Show("No se encontraron registros");
            }
        }


        private async void btnIngresarSueldo_Click(object sender, EventArgs e)
        {

            long empleado = long.Parse(cmbEmpleado.SelectedValue.ToString());           
            long medioPago = long.Parse(cmbMedioPago.SelectedValue.ToString());
            long idZona = long.Parse(cmbZonaEmpleado.SelectedValue.ToString());
            int valorPago = validar.ValidaInt32(txtValorPago.Text);
            string descripcion = txtDescripcion.Text;          
            DateTime fechaPago = DateTime.Parse(dtpFechaPago.Value.ToString());
            string anio = fechaPago.Year.ToString();
            string mes = fechaPago.Month.ToString();
            string dia = fechaPago.Day.ToString();
            string fecha = anio + "-" + mes + "-" + dia;
            if (valorPago <= 0)
            {
                MessageBox.Show("El valor no puede ser 0");
            }
            else
            {
                try
                {
                    bool resp = await gastoController.IngresarPagoSueldo(idZona, empleado, medioPago, descripcion, valorPago, fecha);
                    if (!resp)
                    {
                        MessageBox.Show("Se agregó un Sueldo de empleado");
                        GetPagos();
                    }
                    else
                    {
                        MessageBox.Show("Error al agregar");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                    throw;
                }
            }


        }
    }
}
