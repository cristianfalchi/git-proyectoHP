using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Tesoreria.Clases;
using Tesoreria.Controlador;

namespace Tesoreria.Presentacion
{

    public partial class GestionCliente : Window
    {

        private ClienteController controller = null;
        public GestionCliente()
        {
            InitializeComponent();
        }

        public void Controlador(ClienteController contr)
        {
            controller = contr;
        
        }

               
    /*
    private void btnModificar_Click(object sender, RoutedEventArgs e)
    {

        ClienteDTO nuevoCliente = new ClienteDTO();

        nuevoCliente.codCliente = this.txbCodigo.Text;
        nuevoCliente.razonSocial = this.txbRazonSocial.Text;
        nuevoCliente.apellidoYNombre = this.txbApellidoYNombre.Text;
        nuevoCliente.direccion = this.txbDireccion.Text;
        nuevoCliente.telefono = this.txbTelefono.Text;
        nuevoCliente.cuit = this.txbDni.Text;
        nuevoCliente.habilitado = this.chkbHabilitado.IsChecked.Value ? "1" : "0";

        controladorCliente.modificarCliente(nuevoCliente);

        muestraClientes();

        MessageBox.Show("El cliente se modificó correctamente.", "Gestion de Cliente", MessageBoxButton.OK, MessageBoxImage.Information);


    }

     */
    
   

    




}

      
    
}     

