using Microsoft.AspNetCore.Mvc.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TurismoBD.Controladores;
using TurismoBD.Entidades;
using TurismoBD.Helpers;

namespace proyecto1
{
    public partial class IngresarMantencionDepartamentos : Form
    {
        GastoDeptosController gastoController = new GastoDeptosController();
        ComboBoxsTurismo combo = new ComboBoxsTurismo();
        Validaciones validar = new Validaciones(); 
        public IngresarMantencionDepartamentos()
        {
            InitializeComponent();

            CargaMedioDePago();
            CargaDeptos();
        }

        private async void getGastos()
        {
            List<GastosDepto> lst = new List<GastosDepto>();
            var com = await gastoController.TraerGastosDeptos();
            if (com != null)
            {
                foreach (var item in com.gastosDepto)
                {
                    if (item.id_empleado_id == LoginUsuario.idEmpleado)
                    {
                        lst.Add(item);
                    }
                }
            }
            dgvInformePago.DataSource = lst;       
        }
        public async Task CargaMedioDePago()
        {
            List<MedioDePago> lst = new List<MedioDePago>();
            var com = await combo.CargarMediosDePago();
            if (com != null)
            {
                foreach (var item in com.medioDePago)
                {
                    lst.Add(item);
                }
            }
            cmbMedioPago.DataSource = lst;
            cmbMedioPago.DisplayMember = "descripcion";
            cmbMedioPago.ValueMember = "id_mp";          
        }

        public async Task CargaDeptos()
        {
            List<Departamento> lst = new List<Departamento>();
            var com = await combo.CargarComboDeptos();
            foreach (var item in com.Departamentos)
            {
                if(item.id_zona_id == LoginUsuario.idZona)
                {
                    lst.Add(item);                  
                }
            }
            cmbDepartamentos.DataSource = lst;
            cmbDepartamentos.DisplayMember = "direccion";
            cmbDepartamentos.ValueMember = "id_depto";
        }


        private void btnVolverDepartamento_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string ConceptoSeleccionado()
        {
            try
            {
                if (rdbLuz.Checked)
                {
                    return "LUZ";
                }else if (rdbAgua.Checked)
                {
                    return "AGUA";
                }else if (rdbGas.Checked)
                {
                    return "GAS";
                }else if (rdbGastosComunes.Checked)
                {
                    return "GASTOS COMUNES";
                }else if (rdbAseo.Checked)
                {
                    return "ASEO";
                }else if (rdbMantencionDepartamento.Checked)
                {
                    return "MANTENCIÓN";
                }
                else
                {                   
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
                throw;
            }
            
        }

        private async void btnIngresar_Click(object sender, EventArgs e)
        {

            long empleado = LoginUsuario.idEmpleado;
            long departamento = long.Parse(cmbDepartamentos.SelectedValue.ToString());
            long medioPago = long.Parse(cmbMedioPago.SelectedValue.ToString());
            int valorPago = validar.ValidaInt32(txtValorPago.Text);
            string descripcion = txtDescripcion.Text;
            string concepto = ConceptoSeleccionado();
            DateTime fechaPago = DateTime.Parse(dtpFechaPago.Value.ToString());
            string anio = fechaPago.Year.ToString();
            string mes = fechaPago.Month.ToString();
            string dia = fechaPago.Day.ToString();
            string fecha = anio + "-" + mes + "-" + dia;
            if (concepto == null)
            {
                MessageBox.Show("Debe seleccionar un Concepto");
            }
            else if(valorPago <= 0)
            {
                MessageBox.Show("El valor no puede ser 0");
            }
            else
            {
                try
                {
                    bool resp = await gastoController.IngresarGastoDepto(departamento, empleado, medioPago, concepto, descripcion, valorPago, fecha);
                    if (!resp)
                    {
                        MessageBox.Show("Se agregó un gasto de Departamento");
                        getGastos();
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
