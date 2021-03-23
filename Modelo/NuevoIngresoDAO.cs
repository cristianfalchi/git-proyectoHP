using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesoreria.Modelo.DTO;
using System.Data.SqlClient;
using Tesoreria.Clases;
using Tesoreria.DAO;

namespace Tesoreria.Modelo
{
    class NuevoIngresoDAO: ConexionDB
    {

        public List<NuevoIngresoEmpleadoDTO> ObtenerEmpleados() 
        {
            String consulta = "SELECT id, concat(nombre, ' ', apellido) AS nomYApe FROM Empleado ";

            using (SqlConnection conexion = new SqlConnection(cadConexion))
            {

                //SqlCommand command = new SqlCommand(consulta, conexion);
                command.Connection.Open();

                SqlDataReader dataReader = command.ExecuteReader();

                List<NuevoIngresoEmpleadoDTO> listaEmpleados = new List<NuevoIngresoEmpleadoDTO>();

                while (dataReader.Read())
                {
                    NuevoIngresoEmpleadoDTO empleadoDto = new NuevoIngresoEmpleadoDTO();

                    empleadoDto.id = (int)dataReader[0];
                    empleadoDto.nomYAp = dataReader[1].ToString();

                    listaEmpleados.Add(empleadoDto);


                }
                return listaEmpleados;
            }

        }

        public List<NuevoIngresoClienteDTO> ObtenerClientes()
        {
            String consulta = "SELECT id, apellidoYNombre FROM Cliente ";

            using (SqlConnection conexion = new SqlConnection(cadConexion))
            {

                SqlCommand command = new SqlCommand(consulta, conexion);
                command.Connection.Open();

                SqlDataReader dataReader = command.ExecuteReader();

                List<NuevoIngresoClienteDTO> listaClientes = new List<NuevoIngresoClienteDTO>();

                while (dataReader.Read())
                {
                    NuevoIngresoClienteDTO clienteDto = new NuevoIngresoClienteDTO();

                    clienteDto.id = (int)dataReader[0];
                    clienteDto.nomYAp = dataReader[1].ToString();

                    listaClientes.Add(clienteDto);


                }
                return listaClientes;
            }
        }
        
        


    }
}
