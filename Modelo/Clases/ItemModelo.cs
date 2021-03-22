using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesoreria.Modelo.Clases
{
    public class ItemModelo
    {
        public DateTime hora { set; get; }
        public string observacion { set; get; }
        public string numRecibo { set; get; }
        public char tipoItem { set; get; }
        public bool tieneEfectivo { set; get; }
        public List<EfectivoModelo> listaEfectivo { set; get; }
        public PersonaModelo responsable { set; get; }
        public List<ChequeModelo> listaCheque { set; get; }
        public List<DepositoModelo> listaDeposito { set; get; }

    }
}
