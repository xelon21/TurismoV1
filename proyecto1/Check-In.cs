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

namespace proyecto1
{
    public partial class Check_In : Form
    {
        public Check_In()
        {
            InitializeComponent();            
        }

      

        private void btnImprimir_Click(object sender, EventArgs e)
        {
          CrearPDF();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Check_In_Load(object sender, EventArgs e)
        {

        }
        public void CrearPDF()
        {
            PdfWriter pdfWriter = new PdfWriter("C:\\Check-in.pdf");
            PdfDocument pdf = new PdfDocument(pdfWriter);
            Document documento = new Document(pdf, PageSize.LETTER);

            documento.SetMargins(60, 20, 55, 20);

            var parrafo = new Paragraph("---------------------------------------------------------\n" +
                                                   "         INFORMACION RESERVA\n" +
                                                   "---------------------------------------------------------\n" +
                                                   "Huesped:                     Juan Carlos Catalan\n" +
                                                   "Acompañantes:                               3         \n" +
                                                   "Fecha/Hora Ingredo:       10/04/2022 : 10:00\n" +
                                                   "Días/noches:                    5 Días / 4 Noches\n" +
                                                   "Departamento:                               351\n" +
                                                   "Valor Restante:                     CLP: $175000\n" +
                                                   "----------------------------------------------------------------------\n" +
                                                   "----------------------------------------------------------------------\n" +
                                                   "TurismoReal todos los derechos reservados\n" +
                                                   "Mesa de ayuda:                   2 600 600 9001\n" +
                                                   "Correo contacto:   TurismoReal@turismo.cl\n" +
                                                   "Empleado:                                   Ivan Draco\n" +
                                                   "-------------------------------------------------------------");
            documento.Add(parrafo);
            documento.Close();
            MessageBox.Show("Se guardó el documento");
        }

    }
}
