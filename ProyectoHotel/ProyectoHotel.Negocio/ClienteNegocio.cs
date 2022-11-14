using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoHotel.Datos;
using ProyectoHotel.Entidades;
using ProyectoHotel.Negocio.Excepciones;

namespace ProyectoHotel.Negocio
{
    public class ClienteNegocio
    {
        //Atributos
        private ClienteDatos _clienteDatos;

        //Constructores
        public ClienteNegocio()
        {
            _clienteDatos = new ClienteDatos();
        }

        //Funciones-Métodos
        public List<Cliente> GetLista() //Función para listar a todos los clientes existentes del hotel
        {
            //Declaración de variables
            List<Cliente> _totalClientes = new List<Cliente>();

            _totalClientes = _clienteDatos.Traer(888086); //Guardo en la lista '_totalClientes' los datos de todos los clientes que me trae la capa de Acceso a datos

            return _totalClientes; //Devuelvo la lista con todos los clientes a la capa de presentación
        }

        public void AgregarCliente(Cliente nuevoCliente)
        {
            //Declaración de variables
            List<Cliente> _totalClientes = new List<Cliente>();

            _totalClientes = _clienteDatos.Traer(888086); //Traigo la lista total de clientes de la capa de datos y la guardo en la lista '_totalClientes'

            if (nuevoCliente == null) //Si el objeto que llega por parámetro es nulo se lo comunico al usuario mediante una excepción custom
            {
                throw new ObjetoInvalidoException("Cliente");
            }
            else if (_totalClientes.Find(reg => reg.Id == nuevoCliente.Id) != null) //Regla de negocio: Si dentro de la lista de clientes encuentro algún cliente que tenga el mismo id que el nuevo cliente se lo comunico al usuario mediante una excepción custom
            {
                throw new ObjetoExistenteException("Cliente", nuevoCliente.Id);
            }

            else if (_totalClientes.Find(reg => reg.Dni == nuevoCliente.Dni) != null) //Regla de negocio: Si dentro de la lista de clientes encuentro algún cliente que tenga el mismo dni que el nuevo cliente se lo comunico al usuario mediante una excepción custom
            {
                throw new ClienteExistenteException("Cliente", nuevoCliente.Dni);
            }
            else
            {
                TransactionResult transaction = _clienteDatos.Insertar(nuevoCliente); //Agrego el cliente al repositorio de datos

                if (!transaction.IsOk) //Si la transacción no se pudo completar le comunico el error al usuario mediante una excepción
                {
                    throw new Exception(transaction.Error);
                }
            }
        }
    }
}
