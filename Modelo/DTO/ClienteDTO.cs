using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesoreria.DTO
{
    class ClienteDTO
    {
        public int id { get; set; }
        public string codCliente { get; set; }
        public string razonSocial { get; set; }
        public string apellidoYNombre { get; set; }
        public string direccion { get; set; }
        public string cuit { get; set; }
        public string telefono { get; set; }
        public string habilitado { get; set; }

    }
}
