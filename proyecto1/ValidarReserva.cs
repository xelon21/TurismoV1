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
    public partial class ValidarReserva : Form
    {
        public string checkin;
        public string checkout;
        public ValidarReserva()
        {
            InitializeComponent();
        }

        private void txtCheckIn_TextChanged(object sender, EventArgs e)
        {

        }

        private void ValidarReserva_Load(object sender, EventArgs e)
        {

        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            Check_In checkIn = new Check_In();
            Check_Out checkOut = new Check_Out();

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
