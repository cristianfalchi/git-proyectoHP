using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesoreria.DTO;
using Tesoreria.Clases;
using System.Collections.ObjectModel;

namespace Tesoreria.DAO
{
    public class ClienteDAO : ConexionDB
    {

        public ObservableCollection<ClienteModelo> ObtenerClientes()
        {
            // Los cambios se ven reflejados en el momento
            ObservableCollection<ClienteModelo> listaClientes = new ObservableCollection<ClienteModelo>(); 

            string consulta = "select * from Cliente";

            using (SqlConnection connection = new SqlConnection(cadConexion))
            {

                SqlCommand command = new SqlCommand(consulta, connection);

                command.Connection.Open();

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    ClienteModelo cl = new ClienteModelo();

                    cl.id = (int)dataReader[0];
                    cl.codCliente = dataReader[1].ToString();
                    cl.razonSocial = dataReader[2].ToString();
                    cl.apellidoYNombre = dataReader[3].ToString();
                    cl.telefono = dataReader[4].ToString(); 
                    cl.direccion = dataReader[5].ToString();
                    cl.cuit = dataReader[6].ToString();
                    cl.habilitado = dataReader[7].ToString() == "1" ? '1' : '0';

                    listaClientes.Add(cl);
                }


                return listaClientes;
            }
           

        }


        public void AgregarCliente(ClienteModelo cl)
        {
            string consulta = "insert into Cliente (codCliente, razonSocial, apellidoYNombre, telefono, direccion, cuit, habilitado) " +
                                                    "values (@codigo, @razonSocial, @apellidoYNombre, @telefono, @direccion, @cuit, @habilitado)";

            using (SqlConnection connection = new SqlConnection(cadConexion))
            {

                SqlCommand command = new SqlCommand(consulta,connection);

                command.Parameters.AddWithValue("@codigo", cl.codCliente);
                command.Parameters.AddWithValue("@razonSocial", cl.razonSocial);
                command.Parameters.AddWithValue("@apellidoYNombre", cl.apellidoYNombre);
                command.Parameters.AddWithValue("@direccion", cl.direccion);
                command.Parameters.AddWithValue("@telefono", cl.telefono);
                command.Parameters.AddWithValue("@cuit", cl.cuit);
                command.Parameters.AddWithValue("@habilitado", cl.habilitado);

                command.Connection.Open();
                command.ExecuteNonQuery();
                
            }

        }

        public void EliminarCliente(ClienteModelo cl)
        {
            String consulta = "delete from Cliente where codCliente = @codigoC";

            using (SqlConnection connection = new SqlConnection(cadConexion))
            {

                SqlCommand command = new SqlCommand(consulta, connection);
                command.Parameters.AddWithValue("@codigoC", cl.codCliente);
                command.Connection.Open();
                command.ExecuteNonQuery();

            }
        }

        public void ActualizarCliente(ClienteModelo cl)
        {
            String consulta = "update Cliente set razonSocial = @razonSocial, apellidoYNombre = @apellidoYNombre, telefono = @telefono" +
                ", direccion = @direccion, cuit = @cuit, habilitado = @habilitado  where codCliente = @codigoC";

            using (SqlConnection connection = new SqlConnection(cadConexion))
            {

                SqlCommand command = new SqlCommand(consulta, connection);
                command.Parameters.AddWithValue("@codigoC", cl.codCliente);
                command.Parameters.AddWithValue("@razonSocial", cl.razonSocial);
                command.Parameters.AddWithValue("@apellidoYNombre", cl.apellidoYNombre);
                command.Parameters.AddWithValue("@direccion", cl.direccion);
                command.Parameters.AddWithValue("@telefono", cl.telefono);
                command.Parameters.AddWithValue("@cuit", cl.cuit);
                command.Parameters.AddWithValue("@habilitado", cl.habilitado);

                command.Connection.Open();
                command.ExecuteNonQuery();

            }


        }
    }
}
