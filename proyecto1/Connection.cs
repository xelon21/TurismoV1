using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace proyecto1
{
    public class Connection
    {
        private static string connectionString = "Data Source=.; Initial Catalog= Turismo; User Id=sa; Password=.Blackheart5469; ";
            
        public string Conneccion()
        {
            return connectionString;
            //var cmd = new SqlCommand();
            //var cnx = new SqlConnection(connectionString);
            //try
            //{
            //    cnx.Open();
            //    cmd.Connection = cnx;
            //    MessageBox.Show("Se conecto esta shit");
            //    cnx.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("error: "+ex);
            //    throw;
            //}
        }

    }
}
