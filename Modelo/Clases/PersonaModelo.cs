using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesoreria.Modelo.Clases
{
    public abstract class  PersonaModelo
    {

        public int id { get; set; }
        public string apellidoYNombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public char habilitado { get; set; }
    }
}
