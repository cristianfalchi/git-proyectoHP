using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tesoreria.Modelo.Clases;
using Tesoreria.Vista;

namespace Tesoreria.Controlador
{
    public class CajaController
    {
       // private Caja viewCaja;  Vista
        private CajaP viewCajaP;

        private CajaModelo caja;



        public CajaController(CajaP caja)
        {
            //viewCaja = caja;
            viewCajaP = caja;
            this.caja = new CajaModelo();
           
            //Suscripcion a Eventos
            viewCajaP.Loaded += new RoutedEventHandler(Loaded_CajaDataGrid);
            viewCajaP.btnNuevoItem.Click += new RoutedEventHandler(NuevoItem);


            viewCajaP.Show();
        
        }

        public void MostrarVista()
        {
            viewCajaP.Show();
        }

        private void Loaded_CajaDataGrid(object sender, RoutedEventArgs e) 
        {
            
        }

        private void NuevoItem(object sender, RoutedEventArgs e)
        {
            NuevoIngreso viewNuevoingreso = new NuevoIngreso();
            NuevoIngresoController ctrlNuevoIngreso = new NuevoIngresoController(viewNuevoingreso);
            
            

            if (viewNuevoingreso == null)
                MessageBox.Show("instancia vacia");
        
            
        }

    }
}
