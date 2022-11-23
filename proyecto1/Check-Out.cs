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
    public partial class Check_Out : Form
    {
        public Check_Out()
        {
            InitializeComponent();
            panelEstadoDepartamento.Hide();
        }

        private void btnVolverCheckOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chbPresentaDaños_CheckedChanged(object sender, EventArgs e)
        {
            if (chbPresentaDaños.Checked.Equals(false))
            {
                panelEstadoDepartamento.Hide();
            }
            else
            {
                panelEstadoDepartamento.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
