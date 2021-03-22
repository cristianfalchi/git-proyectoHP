using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Tesoreria.Clases;
using Tesoreria.Modelo;
using Tesoreria.Modelo.Clases;
using Tesoreria.Modelo.DTO;

namespace Tesoreria.Controlador
{
    class NuevoIngresoController
    {

        NuevoIngreso viewNuevoIngreso; // Vista

        // es el item que se agrega a la lista de items en Caja. 
        ItemModelo itemIngreso;

        List<NuevoIngresoClienteDTO> listaCliente;
        List<NuevoIngresoEmpleadoDTO> listaEmpleado;


        public NuevoIngresoController(NuevoIngreso vista)
        {
            viewNuevoIngreso = vista;
            
            // Definiendo las suscripciones a eventos
           
            viewNuevoIngreso.Loaded += new RoutedEventHandler(Loaded_ClientesLisBox);
            viewNuevoIngreso.rbCliente.Checked += new RoutedEventHandler(Checked_Clientes);
            viewNuevoIngreso.rbEmpresa.Checked += new RoutedEventHandler(Checked_Empleados);
            viewNuevoIngreso.lbPersonas.SelectionChanged += new SelectionChangedEventHandler(SelectionChanged_Persona);
            viewNuevoIngreso.btnGrabar.Click += new RoutedEventHandler(Click_GuardarItem);

            viewNuevoIngreso.ShowDialog();

        }

        private void Click_GuardarItem(object sender, RoutedEventArgs e)
        {
            if (viewNuevoIngreso.txtBlResponsable.Text == "")
                MessageBox.Show("Debe seleccionar un responsable por favor");
        }

        // Busca elemento seleccionado

        private void Persona_Seleccionada(int id)
        { 
            
        
        }

        private void SelectionChanged_Persona(object sender, SelectionChangedEventArgs e) 
        {
            if (viewNuevoIngreso.rbCliente.IsChecked.Value)
            {
                
                foreach (NuevoIngresoClienteDTO objeto in viewNuevoIngreso.lbPersonas.ItemsSource)
                {
                    if (viewNuevoIngreso.lbPersonas.SelectedValue != null && objeto.id == (int)viewNuevoIngreso.lbPersonas.SelectedValue)
                    {
                        viewNuevoIngreso.txtBlResponsable.Text = objeto.nomYAp;
                        viewNuevoIngreso.txtBlResponsable.Background = Brushes.AntiqueWhite;
                    }
                        

                }
            }
            else {

                foreach (NuevoIngresoEmpleadoDTO objeto in viewNuevoIngreso.lbPersonas.ItemsSource)
                {
                    if (viewNuevoIngreso.lbPersonas.SelectedValue != null && objeto.id == (int)viewNuevoIngreso.lbPersonas.SelectedValue)
                    {
                        viewNuevoIngreso.txtBlResponsable.Text = objeto.nomYAp;
                        viewNuevoIngreso.txtBlResponsable.Background = Brushes.AntiqueWhite;

                    }
                        

                }

            }
            


        
        }

        private void Checked_Clientes(object sender, RoutedEventArgs e)
        {
            viewNuevoIngreso.lbPersonas.DisplayMemberPath = "nomYAp";
            viewNuevoIngreso.lbPersonas.SelectedValuePath = "id";
            viewNuevoIngreso.lbPersonas.ItemsSource = listaCliente;


        }
        private void Checked_Empleados(object sender, RoutedEventArgs e)
        {
            viewNuevoIngreso.lbPersonas.DisplayMemberPath = "nomYAp";
            viewNuevoIngreso.lbPersonas.SelectedValuePath = "id";
            viewNuevoIngreso.lbPersonas.ItemsSource = listaEmpleado;

           

        }


        private void Loaded_ClientesLisBox(object sender, RoutedEventArgs e)
        {
            NuevoIngresoDAO nuevoDAO = new NuevoIngresoDAO();

            listaCliente = nuevoDAO.ObtenerClientes();
            listaEmpleado = nuevoDAO.ObtenerEmpleados();

            viewNuevoIngreso.lbPersonas.DisplayMemberPath = "nomYAp";
            viewNuevoIngreso.lbPersonas.SelectedValuePath = "id";
            viewNuevoIngreso.lbPersonas.ItemsSource = listaCliente;
        
        }

        /*private void GrabarItem(Object sender, RoutedEventArgs e)
        {

            if (TieneEfectivo())
            {
                EfectivoModelo efectivo = new EfectivoModelo(Convert.ToInt16(viewNuevoIngreso.txtb1000), Convert.ToInt16(viewNuevoIngreso.txtb500), Convert.ToInt16(viewNuevoIngreso.txtb200), Convert.ToInt16(viewNuevoIngreso.txtb100), Convert.ToInt16(viewNuevoIngreso.txtb50),
                    Convert.ToInt16(viewNuevoIngreso.txtb20), Convert.ToInt16(viewNuevoIngreso.txtb10), Convert.ToInt16(viewNuevoIngreso.txtm10), Convert.ToInt16(viewNuevoIngreso.txtm5), Convert.ToInt16(viewNuevoIngreso.txtm2), Convert.ToInt16(viewNuevoIngreso.txtm1), Convert.ToInt16(viewNuevoIngreso.txtm050),
                    Convert.ToInt16(viewNuevoIngreso.txtm025), Convert.ToInt16(viewNuevoIngreso.txtm010));
                
                itemIngreso.listaEfectivo.Add(efectivo);


            
            }
           
            itemIngreso.hora = new DateTime();
            
        
        }*/

        public bool TieneEfectivo()
        {
            if (viewNuevoIngreso.txtTotalBilletes.Text == "0" && viewNuevoIngreso.txtTotalMonedas.Text == "0")
                return false;            
            
            return true;
        }
    }
}
