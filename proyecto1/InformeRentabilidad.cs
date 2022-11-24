﻿using iText.IO.Font.Constants;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TurismoBD.Controladores;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;
using TurismoBD.Entidades;

namespace proyecto1
{

    public partial class InformeRentabilidad : Form
    {
        InformesController info = new InformesController();
        ComboBoxsTurismo combo = new ComboBoxsTurismo();
        DepartamentoController depto = new DepartamentoController();
        ReservasController reserva = new ReservasController();
        GastoDeptosController gasto = new GastoDeptosController();
        List<Reserva> lstReserva = new List<Reserva>();
        List<GastosDepto> lstGastos = new List<GastosDepto>();
        List<Departamento> lstDepartamentos = new List<Departamento>(); 
        public InformeRentabilidad()
        {
            InitializeComponent();
            dgvInforme.DataSource = info.Refresh();
            dgvInforme2.DataSource = info.Refresh2();
            CargaZona();
            GetDeptos();
            TraeReservas();
            TraeGastos();

        }

        public async Task TraeReservas()
        {            
            var com = await reserva.TraerReservas();
            foreach(var item in com.reserva)
            {
                lstReserva.Add(item);
            }           
        }

        public async Task TraeGastos()
        {
            var com = await gasto.TraerGastosDeptos();
            foreach (var item in com.gastosDepto)
            {
                lstGastos.Add(item);
            }
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


        private async Task GetDeptos()
        {
            List<Departamento> lst = new List<Departamento>();
            var com = await depto.TraerDepartamentos();
            foreach (var item in com.Departamentos)
            {
                lst.Add(item);
                lstDepartamentos.Add(item);
            }
            cmbDepartamento.DataSource = lst;
            cmbDepartamento.DisplayMember = "direccion";
            cmbDepartamento.ValueMember = "id_depto";

        }


        private void btnVolverDepartamento_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnFiltrar_Click(object sender, EventArgs e)
        {    
            DateTime inicio = DateTime.Parse(dtpInicio.Value.ToString("yyyy-MM-dd"));
            DateTime fin = DateTime.Parse(dtpHasta.Value.ToString("yyyy-MM-dd"));  
            List<Reserva> lstReservaFiltrado = new List<Reserva>();
            List<GastosDepto> lstGastosFiltrado = new List<GastosDepto>();
            int sumaGatos = 0;
            int sumaIngresos = 0;
            try
            {
                foreach (var item in lstGastos)
                {
                    DateTime cambio = DateTime.Parse(item.fecha_pago);
                    if(cambio >= inicio && cambio <= fin)
                    {
                        lstGastosFiltrado.Add(item);
                        sumaGatos += item.valor_pago;
                    }
                }

                foreach (var item in lstReserva)
                {
                    DateTime cambio = DateTime.Parse(item.f_checkin);
                    if (cambio >= inicio && cambio <= fin)
                    {
                        lstReservaFiltrado.Add(item);
                        sumaIngresos += item.valor_total;
                    }
                }

                dgvInforme.DataSource = lstReservaFiltrado;
                dgvInforme2.DataSource = lstGastosFiltrado;

                txtGastos.Text = sumaGatos.ToString();
                txtIngresos.Text = sumaIngresos.ToString();
                txtTotalRentable.Text = (sumaIngresos - sumaGatos).ToString();

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CrearPDF();
        }

        public void CrearPDF()
        {
           
            var inicio = DateTime.Parse(dtpInicio.Value.ToString());
            var fin = DateTime.Parse(dtpHasta.Value.ToString());

            PdfWriter pdfWriter = new PdfWriter("C:/ReporteRentabilidadTotal.pdf");
            PdfDocument pdf = new PdfDocument(pdfWriter);
            Document documento = new Document(pdf, PageSize.LETTER);

            documento.SetMargins(60, 20, 55, 20);

            PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            string[] columnas = { "Total Ingresos", "Total Gastos", "Rentabilidad" };

            float[] tamanios = { 4, 4, 4 };

            Table tabla = new Table(UnitValue.CreatePercentArray(tamanios));
            tabla.SetWidth(UnitValue.CreatePercentValue(100)); 

            DataTable dtingreso = info.TotalIngreso(inicio, fin);
            DataTable dtegreso = info.TotalEgreso(inicio, fin);
            DataTable dtrenta = info.FiltraTotalIngresosEgresos(inicio, fin);

            //tabla.AddHeaderCell(new Cell().Add(new Paragraph("RENTABILIDAD TOTAL").SetFont(fontColumnas)));

            foreach (string columna in columnas)
            {
                tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).SetFont(fontColumnas)));
            }

            tabla.AddCell(new Cell().Add(new Paragraph(dtingreso.Rows[0][0].ToString()).SetFont(fontContenido)));
            tabla.AddCell(new Cell().Add(new Paragraph(dtegreso.Rows[0][0].ToString()).SetFont(fontContenido)));
            tabla.AddCell(new Cell().Add(new Paragraph(dtrenta.Rows[0][0].ToString()).SetFont(fontContenido)));     
            
            documento.Add(tabla); 
            documento.Close();
            MessageBox.Show("Se guardó el documento");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Reserva> lstReservaFiltrado = new List<Reserva>();
            List<GastosDepto> lstGastosFiltrado = new List<GastosDepto>();
            int sumaGatos = 0;
            int sumaIngresos = 0;           
            long id = long.Parse(cmbDepartamento.SelectedValue.ToString());
            foreach (var item in lstReserva)
            {
                if(item.id_depto_id == id)
                {                    
                    lstReservaFiltrado.Add(item);
                }
            }
            foreach (var item in lstGastos)
            {
                if(item.id_depto_id == id)
                {
                    lstGastosFiltrado.Add(item);
                }
            }
            dgvInforme.DataSource = lstReservaFiltrado;
            dgvInforme2.DataSource = lstGastosFiltrado;
            foreach (var item in lstGastosFiltrado)
            {
                sumaGatos += item.valor_pago;
            }
            foreach (var item in lstReservaFiltrado)
            {
                sumaIngresos += item.valor_total;
            }

            txtGastos.Text = sumaGatos.ToString();
            txtIngresos.Text = sumaIngresos.ToString();
            txtTotalRentable.Text = (sumaIngresos - sumaGatos).ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Reserva> lstReservaFiltrado = new List<Reserva>();
            List<GastosDepto> lstGastosFiltrado = new List<GastosDepto>();
            List<Departamento> lstDeptos = new List<Departamento>();
            int sumaGatos = 0;
            int sumaIngresos = 0;
            long id = long.Parse(cmbZona.SelectedValue.ToString());           

            foreach (var item in lstDepartamentos)
            {
                if(item.id_zona_id == id)
                {
                    lstDeptos.Add(item);
                }
            }

            foreach (var item in lstDeptos)
            {
                long idDepto = item.id_depto;
                foreach (var item2 in lstReserva)
                {
                    if (item2.id_depto_id == idDepto)
                    {
                        lstReservaFiltrado.Add(item2);
                        sumaIngresos += item2.valor_total;
                    }
                }
                foreach (var item3 in lstGastos)
                {
                    if (item3.id_depto_id == idDepto)
                    {
                        lstGastosFiltrado.Add(item3);
                        sumaGatos += item3.valor_pago;
                    }
                }

            }         
            dgvInforme.DataSource = lstReservaFiltrado;
            dgvInforme2.DataSource = lstGastosFiltrado;
            //foreach (var item in lstGastosFiltrado)
            //{
            //    sumaGatos += item.valor_pago;
            //}
            //foreach (var item in lstReservaFiltrado)
            //{
            //    sumaIngresos += item.valor_total;
            //}

            txtGastos.Text = sumaGatos.ToString();
            txtIngresos.Text = sumaIngresos.ToString();
            txtTotalRentable.Text = (sumaIngresos - sumaGatos).ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}



//DataTable dt = info.FiltrarIngresos(inicio, fin);
//if(dt.Rows.Count == 0)
//{
//    MessageBox.Show("No se encontraron registros");
//}
//else
//{
//    dgvInforme.DataSource = dt;
//}

//DataTable dt2 = info.FiltrarEgresos(inicio, fin);
//if (dt2.Rows.Count == 0)
//{
//    MessageBox.Show("No se encontraron registros");
//}
//else
//{
//    dgvInforme2.DataSource = dt2;
//}

//DataTable dt3 = info.FiltraTotalIngresosEgresos(inicio, fin);
//if (dt3.Rows.Count == 0)
//{
//    MessageBox.Show("No se encontraron registros");
//}
//else
//{

//}


//var parrafo = new Paragraph("---------------------------------------------------------\n" +
//                                       "         INFORMACION RESERVA\n" +
//                                       "---------------------------------------------------------\n" +
//                                       "Huesped:                     Juan Carlos Catalan\n" +
//                                       "Acompañantes:                               3         \n" +
//                                       "Fecha/Hora Ingredo:       10/04/2022 : 10:00\n" +
//                                       "Días/noches:                    5 Días / 4 Noches\n" +
//                                       "Departamento:                               351\n" +
//                                       "Valor Restante:                     CLP: $175000\n" +
//                                       "//////////////////////////////////////////////////////////////////////\n" +
//                                       "//////////////////////////////////////////////////////////////////////\n" +
//                                       "TurismoReal todos los derechos reservados\n" +
//                                       "Mesa de ayuda:                   2 600 600 9001\n" +
//                                       "Correo contacto:   TurismoReal@turismo.cl\n" +
//                                       "Empleado:                                   Ivan Draco\n" +
//                                       "-------------------------------------------------------------");
//documento.Add(parrafo);
//documento.Close();
