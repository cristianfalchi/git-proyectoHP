using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesoreria.Modelo.Clases;

namespace Tesoreria.Clases
{
    public class ClienteModelo : PersonaModelo
    {
        
        public string codCliente { get; set; }
        public string razonSocial { get; set; }
        public string cuit { get; set; }
               

        public ClienteModelo()
        {
            this.id = 0;
            this.codCliente = "";
            this.razonSocial = "";
            this.apellidoYNombre = "";
            this.direccion = "";
            this.cuit = "";
            this.telefono = "";
            this.habilitado = '0';
        }
        public ClienteModelo(int id, string cod, string raz, string apyn, string dir, string cu, string tel, char hab ) {

            this.id = id;
            this.codCliente = cod;
            this.razonSocial = raz;
            this.apellidoYNombre = apyn;
            this.direccion = dir;
            this.cuit = cu;
            this.telefono = tel;
            this.habilitado = hab;

        }

        public ClienteModelo(string cod, string raz, string apyn, string dir, string cu, string tel, char hab)
        {

            this.codCliente = cod;
            this.razonSocial = raz;
            this.apellidoYNombre = apyn;
            this.direccion = dir;
            this.cuit = cu;
            this.telefono = tel;
            this.habilitado = hab;

        }


    }
}
