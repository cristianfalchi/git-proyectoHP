using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using Tesoreria.Clases;
using Tesoreria.DAO;
using Tesoreria.Presentacion;
using System.Collections.ObjectModel;

namespace Tesoreria.Controlador
{
    public class ClienteController 
    {

        private GestionCliente viewGestionCliente; // Vista
                
        // Todos los clientes en la base de datos
        public ObservableCollection<ClienteModelo> listaClientes; 

        // Constructor e inicializacion de eventos
        public ClienteController(GestionCliente vista)
        {
            //Seteamos la vista
            viewGestionCliente = vista;

            // Obtengo la lista de clientes desde el modelo
            ClienteDAO ClienteDao = new ClienteDAO();
            listaClientes = ClienteDao.ObtenerClientes();

            //Suscripcion a Eventos
            viewGestionCliente.Loaded += new RoutedEventHandler(Loaded_ClientesDataGrid);
            viewGestionCliente.dtgClientes.MouseDoubleClick += new MouseButtonEventHandler(DobleClick_DataGrid);
            viewGestionCliente.KeyDown += new KeyEventHandler(KeyDown_LimpiarDatos);
            viewGestionCliente.txbCodigo.KeyDown += new KeyEventHandler(KeyDown_CompletarDatos);
            viewGestionCliente.txbCodigo.LostFocus += new RoutedEventHandler(LostFocus_Cliente);
            viewGestionCliente.btnAgregar.Click += new RoutedEventHandler(AgregarCliente);
            viewGestionCliente.btnEliminar.Click += new RoutedEventHandler(EliminarCliente);
            viewGestionCliente.btnActualizar.Click += new RoutedEventHandler(ActualizarCliente);
            
            viewGestionCliente.Show();

        }



        //Se ejecuta cuando carga el formulario. Evento Loaded
        private void Loaded_ClientesDataGrid(object sender, RoutedEventArgs e)
        {
            viewGestionCliente.dtgClientes.ItemsSource = listaClientes;
            viewGestionCliente.dtgClientes.Columns[0].Visibility = Visibility.Hidden;
        }

        //Evento que se ejecuta cuando el usuario hace doble click en algun item del DataGrid
        private void DobleClick_DataGrid(object sender, MouseButtonEventArgs e)
        {
            ClienteModelo clienteSel = (ClienteModelo)viewGestionCliente.dtgClientes.SelectedItem;

            viewGestionCliente.txbCodigo.Text = clienteSel.codCliente;
            viewGestionCliente.txbRazonSocial.Text = clienteSel.razonSocial;
            viewGestionCliente.txbApellidoYNombre.Text = clienteSel.apellidoYNombre;
            viewGestionCliente.txbDireccion.Text = clienteSel.direccion;
            viewGestionCliente.txbDni.Text = clienteSel.cuit;
            viewGestionCliente.txbTelefono.Text = clienteSel.telefono;
            viewGestionCliente.chkbHabilitado.IsChecked = clienteSel.habilitado == '1' ? true : false;
            viewGestionCliente.btnActualizar.IsEnabled = true;

        }

        // Evento que se ejecuta cuando se presiona la tecla ESC
        private void KeyDown_LimpiarDatos(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Escape))
                LimpiarView();

        }

        //Evento que al presionar TAB o ENTER en el codigo del cliente se cargan los datos
        private void KeyDown_CompletarDatos(object sender, KeyEventArgs e)
        {
            if (!viewGestionCliente.txbCodigo.Text.Equals(String.Empty) && (e.Key.Equals(Key.Enter) || e.Key.Equals(Key.Tab)))
            {
                if (comprobarExistencia(viewGestionCliente.txbCodigo.Text))
                {
                    BuscarCliente(viewGestionCliente.txbCodigo.Text);
                    viewGestionCliente.btnActualizar.IsEnabled = true;
                }
                else
                {

                    viewGestionCliente.btnActualizar.IsEnabled = false;
                }
            }
            else
                viewGestionCliente.btnActualizar.IsEnabled = false;
        }

        //
        private bool comprobarExistencia(String codigoC)
        {

            foreach (ClienteModelo cl in viewGestionCliente.dtgClientes.ItemsSource)
            {
                if (cl.codCliente == codigoC)
                    return true;

            }
            return false;
        }

        // Limpia los campos cuando se presiona la tecla ESC
        private void LimpiarView()
        {
            viewGestionCliente.txbCodigo.Clear();
            viewGestionCliente.txbRazonSocial.Clear();
            viewGestionCliente.txbApellidoYNombre.Clear();
            viewGestionCliente.txbDireccion.Clear();
            viewGestionCliente.txbTelefono.Clear();
            viewGestionCliente.txbDni.Clear();
            viewGestionCliente.chkbHabilitado.IsChecked = true;
            viewGestionCliente.txbBuscar.Clear();
        }

        // Busca si existe un cliente con codigo codC
        private void BuscarCliente(string codC)
        {
            foreach (ClienteModelo cl in viewGestionCliente.dtgClientes.ItemsSource)
            {
                if (cl.codCliente == codC)
                {
                    viewGestionCliente.txbRazonSocial.Text = cl.razonSocial;
                    viewGestionCliente.txbApellidoYNombre.Text = cl.apellidoYNombre;
                    viewGestionCliente.txbDireccion.Text = cl.direccion;
                    viewGestionCliente.txbDni.Text = cl.cuit;
                    viewGestionCliente.txbTelefono.Text = cl.telefono;
                    viewGestionCliente.chkbHabilitado.IsChecked = cl.habilitado == '1' ? true : false;
                    viewGestionCliente.btnActualizar.IsEnabled = true;
                    break;
                }
            }
        }

        private void LostFocus_Cliente(object sender, RoutedEventArgs e)
        {
            if (!viewGestionCliente.txbCodigo.Text.Equals(String.Empty))
            {
                if (comprobarExistencia(viewGestionCliente.txbCodigo.Text))
                {
                    BuscarCliente(viewGestionCliente.txbCodigo.Text);
                    viewGestionCliente.btnActualizar.IsEnabled = true;
                }
                else
                {
                    viewGestionCliente.btnActualizar.IsEnabled = false;
                }
            }
        }

        
        public void MostrarVista()
        {
            if (viewGestionCliente.IsLoaded)
                viewGestionCliente.Focus();
            else
            {
                if (viewGestionCliente != null)
                {
                    viewGestionCliente.Close();
                    viewGestionCliente = new GestionCliente();
                    viewGestionCliente.dtgClientes.ItemsSource = listaClientes;
                    viewGestionCliente.Show();
                }
            }
        }

        private void AgregarCliente(object sender, RoutedEventArgs e)
        {
            ClienteDAO clDAO = new ClienteDAO();
            ClienteModelo cl = new ClienteModelo();

            cl.codCliente = viewGestionCliente.txbCodigo.Text;
            cl.razonSocial = viewGestionCliente.txbRazonSocial.Text;
            cl.apellidoYNombre = viewGestionCliente.txbApellidoYNombre.Text;
            cl.direccion = viewGestionCliente.txbDireccion.Text;
            cl.telefono = viewGestionCliente.txbTelefono.Text;
            cl.cuit = viewGestionCliente.txbDni.Text;
            cl.habilitado = viewGestionCliente.chkbHabilitado.IsChecked.Value ? '1' : '0';

            listaClientes.Add(cl);
            clDAO.AgregarCliente(cl);
            viewGestionCliente.dtgClientes.ItemsSource = listaClientes;
            LimpiarView();
            
            
        }

        private void EliminarCliente(object sender, RoutedEventArgs e)
        {
            ClienteDAO clDAO = new ClienteDAO();
            ClienteModelo cl = new ClienteModelo();
           

            cl.codCliente = viewGestionCliente.txbCodigo.Text;
            cl.razonSocial = viewGestionCliente.txbRazonSocial.Text;
            cl.apellidoYNombre = viewGestionCliente.txbApellidoYNombre.Text;
            cl.direccion = viewGestionCliente.txbDireccion.Text;
            cl.telefono = viewGestionCliente.txbTelefono.Text;
            cl.cuit = viewGestionCliente.txbDni.Text;
            cl.habilitado = viewGestionCliente.chkbHabilitado.IsChecked.Value ? '1' : '0';

            foreach (ClienteModelo c in listaClientes)
            {
                if (c.codCliente == cl.codCliente)
                {
                    listaClientes.RemoveAt(listaClientes.IndexOf(c));
                    clDAO.EliminarCliente(cl);
                    viewGestionCliente.dtgClientes.ItemsSource = listaClientes;
                    LimpiarView();
                    break;

                }
                   
            }


        }

        private void ActualizarCliente(object sender, RoutedEventArgs e)
        {
            ClienteDAO clDAO = new ClienteDAO();
            ClienteModelo cl = new ClienteModelo();

            cl.codCliente = viewGestionCliente.txbCodigo.Text;
            cl.razonSocial = viewGestionCliente.txbRazonSocial.Text;
            cl.apellidoYNombre = viewGestionCliente.txbApellidoYNombre.Text;
            cl.direccion = viewGestionCliente.txbDireccion.Text;
            cl.telefono = viewGestionCliente.txbTelefono.Text;
            cl.cuit = viewGestionCliente.txbDni.Text;
            cl.habilitado = viewGestionCliente.chkbHabilitado.IsChecked.Value ? '1' : '0';

            foreach (ClienteModelo c in listaClientes)
            {
                if (c.codCliente == cl.codCliente)
                {
                    listaClientes.RemoveAt(listaClientes.IndexOf(c));
                    listaClientes.Add(cl);
                    clDAO.ActualizarCliente(cl);
                    viewGestionCliente.dtgClientes.ItemsSource = listaClientes;
                    LimpiarView();
                    break;

                }

            }

        }
    }
}
