using System;
using System.Windows;
using System.Windows.Controls;
using Tesoreria.Presentacion;
using Tesoreria.Vista;

namespace Tesoreria.Controlador
{
    public delegate void DelegadoClickPrincipal(Object sender, RoutedEventArgs e);
    public class PrincipalController
    {

        //Controladores
        public ClienteController ctrCliente = null;
        public CajaController ctrCaja = null;


        // Vista Principal del Sistema
        private Principal viewPrincipal; 

        public PrincipalController(Principal p)
        {
            viewPrincipal = p;

            //Iicilizamos eventos de las vistas
            viewPrincipal.itemCliente.Click += new RoutedEventHandler(AbrirVistaCliente);
            viewPrincipal.itemSalir.Click += new RoutedEventHandler(CerrarVistaPrincipal);
            viewPrincipal.itemCaja.Click += new RoutedEventHandler(AbrirVistaCaja);

        }
        
        private void AbrirVistaCliente(object sender, EventArgs e)
        {
            if (ctrCliente == null)
            {
                GestionCliente viewCliente = new GestionCliente();
                ctrCliente = new ClienteController(viewCliente);
            }
            else
                ctrCliente.MostrarVista();
            
        } 

        private void CerrarVistaPrincipal (object sender, EventArgs e)
        {
            viewPrincipal.Close();
        }

        private void AbrirVistaCaja(object sender, EventArgs e)
        {
            if (ctrCaja == null)
            {
                CajaP viewCaja = new CajaP();
                ctrCaja = new CajaController(viewCaja);
            }
            else
                ctrCaja.MostrarVista();
        
        }
        


    }
}
