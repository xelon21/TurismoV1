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
        InformesController info = new InformesController();
        ComboBoxsTurismo combo = new ComboBoxsTurismo();
        Validaciones validar = new Validaciones();
        public IngresarMantencionDepartamentos()
        {
            InitializeComponent();

            CargaMedioDePago();
            CargaDeptos();
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
            cmbMedioPago.ValueMember = "id_zona";          
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

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            long empleado = LoginUsuario.idEmpleado;
            int departamento = validar.ValidaInt32(cmbDepartamentos.SelectedValue.ToString());
            int medioPago = validar.ValidaInt32(cmbMedioPago.SelectedValue.ToString());
            int valorPago = validar.ValidaInt32(txtValorPago.Text);
            string descripcion = txtDescripcion.Text;
            string concepto = ConceptoSeleccionado();
            DateTime fechaPago = DateTime.Parse(dtpFechaPago.Value.ToString());
            if(concepto == null)
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
                    bool resp = info.IngresarGastos(departamento, empleado, concepto, descripcion, medioPago, valorPago, fechaPago);
                    if (resp)
                    {
                        MessageBox.Show("Se agregó un gasto de Departamento");
                        dgvInformePago.DataSource = info.mostrarUltimoRegistro();
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
