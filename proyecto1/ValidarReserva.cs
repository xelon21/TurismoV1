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

namespace proyecto1
{
    public partial class ValidarReserva : Form
    {
        public string checkin;
        public string checkout;
        ReservasController reserva = new ReservasController();
        List<Reserva> lstReservas = new List<Reserva>();
        public static Reserva reservaValida = new Reserva();
        public static int idRes;
        public static int idReservadepto;
        public ValidarReserva()
        {
            InitializeComponent();

            TraeReservas();
            

        }

        public int idReserva()
        {
            idRes = idReservadepto;
            return idRes;
        }
        private async void TraeReservas()
        {
            var com = await reserva.TraerReservas();
            if(com == null)
            {
                MessageBox.Show("No existen reservas");
            }
            else
            {
                foreach (var item in com.reserva)
                {
                    lstReservas.Add(item);
                }
            }
        }

        private void txtCheckIn_TextChanged(object sender, EventArgs e)
        {

        }

        private void ValidarReserva_Load(object sender, EventArgs e)
        {

        }

        //public Reserva Reserva()
        //{
        //    int idReserva = Convert.ToInt32(txtCheckIn.Text);
        //    foreach (var item in lstReservas)
        //    {
        //        if (item.id_reserva == idReserva)
        //        {
        //           reservaValida = item;
        //        }               
        //    }
        //    return reservaValida;
        //}

        private async void btnValidar_Click(object sender, EventArgs e)
        {
            Check_In checkIn = new Check_In();
            Check_Out checkOut = new Check_Out();
            idReservadepto = Convert.ToInt32(txtCheckIn.Text);
            idRes = Convert.ToInt32(txtCheckIn.Text);
            int idReserva = Convert.ToInt32(txtCheckIn.Text);
            bool noExiste = true;           
            foreach (var item in lstReservas)
            {
                if(item.id_reserva == idReserva)
                {
                    reservaValida = item;
                    
                    noExiste = true;
                    this.Close();
                    checkIn.Show();
                    return;
                }
                noExiste = false;
                
            }

            if (!noExiste)
            {
                MessageBox.Show("Codigo de reserva invalido");
            }

            if(txtCheckIn.Text.Contains("ivan"))
            {
                this.Close();
                checkIn.Show();
            }
            else if (txtCheckIn.Text.Contains("gabo"))
            {
                this.Close();
                checkOut.Show();
            }

            
        }
    }
}
