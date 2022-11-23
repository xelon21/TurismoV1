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
using System.Text;
using System.Windows.Forms;
using TurismoBD.Controladores;

namespace proyecto1
{

    public partial class InformeRentabilidad : Form
    {
        InformesController info = new InformesController();
        public InformeRentabilidad()
        {
            InitializeComponent();
            dgvInforme.DataSource = info.Refresh();
            dgvInforme2.DataSource = info.Refresh2();
        }

        private void btnVolverDepartamento_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            var inicio = DateTime.Parse(dtpInicio.Value.ToString());
            var fin = DateTime.Parse(dtpHasta.Value.ToString());            
            try
            {                
                DataTable dt = info.FiltrarIngresos(inicio, fin);
                if(dt.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron registros");
                }
                else
                {
                    dgvInforme.DataSource = dt;
                }

                DataTable dt2 = info.FiltrarEgresos(inicio, fin);
                if (dt2.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron registros");
                }
                else
                {
                    dgvInforme2.DataSource = dt2;
                }

                DataTable dt3 = info.FiltraTotalIngresosEgresos(inicio, fin);
                if (dt3.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron registros");
                }
                else
                {
                    dgvInforme3.DataSource = dt3;
                }
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

            PdfWriter pdfWriter = new PdfWriter("C:\\ReporteRentabilidadTotal.pdf");
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

       
    }
}



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
