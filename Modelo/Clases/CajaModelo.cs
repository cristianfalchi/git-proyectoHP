using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesoreria.Modelo.Clases
{
     public class CajaModelo
    {
        public int numCaja { set; get; }
        DateTime fechaCreacion { set; get; }
        DateTime fechaFinalizacion { set; get; }
        double saldoEfectivo { set; get; }
        List<ItemModelo> listaItems { set; get; }

        public CajaModelo()
        {
            numCaja = 0;
            fechaCreacion = DateTime.Now;
            fechaFinalizacion = DateTime.Now;
            saldoEfectivo = 0.00;
            listaItems = null;
        
        }

        public CajaModelo(int idCaja)
        {
            
        }

        public void AgregarItem(ItemModelo item)
        {
            listaItems.Add(item);            
        
        }

    }
}
