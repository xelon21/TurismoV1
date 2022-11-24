using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;
using TurismoBD.Entidades;
using TurismoBD.Controladores;
using TurismoBD.Helpers;

namespace proyecto1
{
    public partial class ServicioExtra : Form
    {
        DepartamentoController depto = new DepartamentoController();
        ComboBoxsTurismo combo = new ComboBoxsTurismo();   
        ServicioExtraController serv = new ServicioExtraController();
        Validaciones validar = new Validaciones();
        public ServicioExtra()
        {
            InitializeComponent();

            CargaZona();
            GetTipoServicio();
            GetServiciosExtras();
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
        }

        private async void GetTipoServicio()
        {
            List<TipoServicio> lst = new List<TipoServicio>();
            var com = await combo.CargaTipoServicio();
            foreach (var item in com.tipoServicio)
            {
                lst.Add(item);
            }
            cmbTipoServicio.DataSource = lst;
            cmbTipoServicio.DisplayMember = "descripcion";
            cmbTipoServicio.ValueMember = "id_tipo";
        }

        private async void GetServiciosExtras()
        {
            List<ServiciosExtra> lst = new List<ServiciosExtra>();
            var com = await serv.TraeServiciosExtras();
            foreach (var item in com.servicioExtra)
            {
                lst.Add(item);
            }
            dgvServicioExtra.DataSource = lst;
        }

        private void btnVolverDepartamento_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ServicioExtra_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void rdbIngresarDepartamento_CheckedChanged(object sender, EventArgs e)
        {

        }

        private async void btnIngresarDepartamento_Click(object sender, EventArgs e)
        {
            try
            {
                int cont = 1;
                long idzona = validar.ValidaInt32(cmbZona.SelectedValue.ToString());                
                long idTipoServicio = long.Parse(cmbTipoServicio.SelectedValue.ToString());
                int tarifa = validar.ValidaInt32(txtTarifa.Text);
                DateTimeOffset fechaPago = DateTimeOffset.Parse(dtpFechaPago.Value.ToString("yyyy-MM-dd"));
                string anio = fechaPago.Year.ToString();
                string mes = fechaPago.Month.ToString();
                string dia = fechaPago.Day.ToString();
                string fecha = anio + "-" + mes + "-" + dia;

                bool resp = await serv.IngresaServiciosExtra(idTipoServicio, tarifa, fecha);
                if (!resp)
                {
                    long idServicio = 0;
                    var com2 = await serv.TraeDetalleServicio();
                    var com = await serv.TraeServiciosExtras();                
                    foreach (var item in com.servicioExtra)
                    {                                       
                        if(com.servicioExtra.Length == cont)
                        {
                            idServicio = item.id_servicio;
                        }
                        cont++;
                    }

                    bool resp2 = await serv.IngresaDetalleServicio(idServicio, idzona);
                    if (!resp2)
                    {
                        MessageBox.Show("Se ha agregado un servicio!");
                        GetServiciosExtras();
                    }
                    else
                    {
                        MessageBox.Show("No se agregó el servicio");
                    }

                }

            }
            catch (Exception)
            {
                return;
                throw;
            }
        }
    }
}



//foreach (var item2 in com2.detalleServicio)
//{
//    if (item.id_servicio == item2.id_servicio_id)
//    {
//        bool resp2 = await serv.IngresaDetalleServicio(idzona, item.id_servicio);
//        if (!resp2)
//        {
//            MessageBox.Show("Se ha agregado un servicio!");
//        }
//        else
//        {
//            MessageBox.Show("No se agregó el servicio");
//        }
//    }
//}