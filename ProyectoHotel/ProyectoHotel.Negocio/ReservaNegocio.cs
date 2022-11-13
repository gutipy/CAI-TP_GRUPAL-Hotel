using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoHotel.Datos;
using ProyectoHotel.Entidades;

namespace ProyectoHotel.Negocio
{
    public class ReservaNegocio
    {
        //Atributos
        private ReservaDatos _reservaDatos;
        private ClienteDatos _clienteDatos;
        //Constructores
        public ReservaNegocio()
        {
            _reservaDatos = new ReservaDatos();
            _clienteDatos = new ClienteDatos();
        }

        //Funciones-Métodos
        public List<Reserva> GetLista() //Función para listar a todas las reservas
        {
            //Declaración de variables
            List<Reserva> _totalReservas = new List<Reserva>();

            _totalReservas = _reservaDatos.TraerPorCliente(123); //Guardo en la lista '_totalReservas' los datos de todas las reservas que me trae la capa de Acceso a datos

            return _totalReservas; //Devuelvo la lista con todos los clientes a la capa de presentación
        }
        public List<Reserva> GetListaReservasPorCliente(int id) //Función para listar las reservas por ID de cliente
        {
            //Declaración de variables
            List<Reserva> _clienteReservas = new List<Reserva>();

            _clienteReservas = _reservaDatos.TraerPorCliente(id); //Guardo en la lista '_clienteReservas' los datos de todas las reservas que me trae la capa de Acceso a datos

            return _clienteReservas; //Devuelvo la lista con todas las reservas a la capa de presentación
        }
        public void AgregarReserva(Reserva nuevaReserva)
        {
            //Declaración de variables
            List<Reserva> _totalReservas = new List<Reserva>();

            _totalReservas = _reservaDatos.Traer(123); //Traigo la lista total de reservas

            if (nuevaReserva == null) //Si el objeto que llega por parámetro es nulo se lo comunico al usuario mediante una excepción custom
            {
                throw new ObjetoInvalidoException("Reserva");
            }
            else if (_totalReservas.Find(reg => reg.Id == nuevaReserva.Id) != null) //Si dentro de la lista de reservas encuentro algúna reserva que tenga el mismo id que la nuevo reserva se lo comunico al usuario mediante una excepción custom
            {
                throw new ObjetoExistenteException("Reserva", nuevaReserva.Id);
            }
            else if (_totalReservas.Find(reg => reg.IdHabitacion == nuevaReserva.IdHabitacion) != null) //Si ya hay una reserva para esa habitacion
                throw new HabitacionOcupadaException("HabitacionOcupada", nuevaReserva.IdHabitacion);
            }
            else
            {
                TransactionResult transaction = _reservaDatos.Insertar(nuevaReserva); //Agrego la reserva al repositorio de datos

                if (!transaction.IsOk) //Si la transacción no se pudo completar le comunico el error al usuario mediante una excepción
                {
                    throw new Exception(transaction.Error);
                }
            }
        }
    }
}
