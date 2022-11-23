using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoBD
{
    internal class ConeccionBD
    {
        private static string connectionString = "Data Source=.; Initial Catalog= TurismoV2; User Id=sa; Password=.Blackheart5469; ";

        public string Conneccion()
        {
            return connectionString;            
        }
    }
}
