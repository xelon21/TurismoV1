using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoBD.Helpers
{
    public class Validaciones
    {
        public int ValidaInt32(string dato)
        {
            if(dato == string.Empty)
            {
                return 0;
            }
            return Int32.Parse(dato);
        }
    }
}
