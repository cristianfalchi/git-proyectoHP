using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesoreria.Modelo.Clases
{
    // Clase que utiliza el Datagrid
    public class ResponsableModelo
    {
        // Identificacion de la persona o empresa 
        int codigo;
        string responsable;
        string observacion;
        int tipoResponsable;

        string nombreCompleto;

        List<EfectivoModelo> listaEfectivo;
        List<ChequeModelo> listaCheques;
        List<DepositoModelo> listaDepositos;
        double totalGeneral;

        public ResponsableModelo()
        {
            codigo = 0;
            responsable = "";
            
            tipoResponsable = 0;
            listaEfectivo = null;
            listaCheques = null;
            listaDepositos = null;
            totalGeneral = 0.00;
            nombreCompleto = "";
            
        }
    }
}
