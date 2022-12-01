using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
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
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;

namespace proyecto1
{
    public partial class Check_In : Form
    {
        ReservasController reserva = new ReservasController();
        Reserva reserv = new Reserva();
        ComboBoxsTurismo combo = new ComboBoxsTurismo();
        List<Departamento> lstDepto = new List<Departamento>();
        List<Reserva> lstReserva = new List<Reserva>();
        List<Huesped> lstHuespedes = new List<Huesped>();
        Departamento depto = new Departamento();
        Huesped huesped = new Huesped();
        ValidarReserva vr = new ValidarReserva();
        public static int totalRestante = 0;
        public static string direccion;
        public static string nombre;

        public Check_In()
        {
            InitializeComponent();

           
        }


        //private async void TraeReservas()
        //{
           
        //}

        private async void TraeDepartamentos()
        {            
            var com = await combo.CargarComboDeptos();
            foreach (var item in com.Departamentos)
            {
                lstDepto.Add(item);
            }          
        }

        private async void TraeHuespedes()
        {
            var com = await reserva.TraeHuespedes();
            foreach (var item in com.huesped)
            {
                lstHuespedes.Add(item);
            }
        }
        private async void LlenaDatosCheckIn()
        {

            var com = await reserva.TraerReservas();
            foreach (var item in com.reserva)
            {
                int a = ValidarReserva.idRes;
                int d = ValidarReserva.idReservadepto;
                if (item.id_reserva == a)
                {
                    reserv = item;
                }
            }

                  
            foreach (var item in lstHuespedes)
            {
                if(reserv.id_huesped_id == item.id_huesped)
                {
                    huesped = item;
                    nombre = item.nombre + " " + item.apellido;
                }
            }
            
            lblCheckin.Text = reserv.f_checkin;
            lblCheckout.Text = reserv.f_checkout;
            
            foreach (var item in lstDepto)
            {
                if(reserv.id_depto_id == item.id_depto)
                {
                    depto = item;
                    direccion = item.direccion;
                }
            }

            if(nombre == null || direccion == null)
            {
                TraeDepartamentos();
                TraeHuespedes();
                LlenaDatosCheckIn();
            }

            lblHuesped.Text = nombre;
            lblDepartamento.Text = direccion;
            int total = reserv.valor_total;
            int resto = reserv.valor_reserva;
            totalRestante = (total - resto);
            lblValorRestante.Text = "CLP: $" + (total - resto).ToString();

        }

        private async void CambiaEstadoReserva()
        {
            long idReserva = reserv.id_reserva;
            string checkin = reserv.f_checkin;
            string checkout = reserv.f_checkout;
            long idHuesped = reserv.id_huesped_id;
            int valorReserva = reserv.valor_reserva;
            int valorTotal = reserv.valor_total;
            long idDepto = reserv.id_depto_id;
            long estado = 4;
            bool cambiaEstado = await reserva.CambiarEstadoReserva(idReserva, checkin, checkout, idHuesped, valorReserva, valorTotal, estado, idDepto);
            if (!cambiaEstado)
            {
                MessageBox.Show("Reserva ingresada");
            }
            else
            {
                MessageBox.Show("No se puede ingresar la reserva, contacte con el administrador");
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            CambiaEstadoReserva();
            CrearPDF();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Check_In_Load(object sender, EventArgs e)
        {
            TraeDepartamentos();
            TraeHuespedes();
            LlenaDatosCheckIn();
        }
        public void CrearPDF()
        {
            
            PdfWriter pdfWriter = new PdfWriter("Check-in.pdf");
            PdfDocument pdf = new PdfDocument(pdfWriter);
            Document documento = new Document(pdf, PageSize.LETTER);

            documento.SetMargins(60, 20, 55, 20);

            var parrafo = new Paragraph("---------------------------------------------------------\n" +
                                                   "         INFORMACION RESERVA\n" +
                                                   "---------------------------------------------------------\n" +
                                                   "Huesped:                    "+ huesped.nombre + " "+ huesped.apellido + " \n" +
                                                   "Acompañantes:                               3         \n" +
                                                   "Fecha/Hora Ingredo:      "+ reserv.f_checkin+"\n" +
                                                   "Días/noches:              "+ reserv.f_checkout+"\n" +
                                                   "Departamento:                             "+ depto.direccion +"\n" +
                                                   "Valor Restante:                     CLP: $"+totalRestante.ToString()+"\n" +
                                                   "----------------------------------------------------------------------\n" +
                                                   "----------------------------------------------------------------------\n" +
                                                   "TurismoReal todos los derechos reservados\n" +
                                                   "Mesa de ayuda:                   2 600 600 9001\n" +
                                                   "Correo contacto:   "+ LoginUsuario.user +"\n" +
                                                   "Empleado:                                  "+ LoginUsuario.nombre+"\n" +
                                                   "-------------------------------------------------------------");
            documento.Add(parrafo);
            documento.Close();
            MessageBox.Show("Se guardó el documento");
        }

        private void lblHuesped_Click(object sender, EventArgs e)
        {

        }
    }
}
