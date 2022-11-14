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
    public class ReservaNegocio
    {
        //Atributos
        private ReservaDatos _reservaDatos;

        //Constructores
        public ReservaNegocio()
        {
            _reservaDatos = new ReservaDatos();
        }

        //Funciones-Métodos
        public List<Reserva> GetLista() //Función para listar a todas las reservas por número de registro
        {
            //Declaración de variables
            List<Reserva> _totalReservas = new List<Reserva>();

            _totalReservas = _reservaDatos.TraerPorRegistro(888086); //Guardo en la lista '_totalReservas' los datos de todas las reservas por nro de registro que me trae la capa de Acceso a datos

            return _totalReservas; //Devuelvo la lista con todas las reservas por nro de registro a la capa de presentación
        }
        public List<Reserva> GetListaPorCliente(int idCliente) //Función para listar todas las reservas por cliente
        {
            //Declaración de variables
            List<Reserva> _totalReservas = new List<Reserva>();
            List<Reserva> _totalReservasPorCliente = new List<Reserva>();

            _totalReservas = _reservaDatos.TraerPorRegistro(888086); //Guardo en la lista '_totalReservas' los datos de todas las reservas por nro de registro que me trae la capa de Acceso a datos

            foreach (Reserva r in _totalReservas) //Recorro todas las reservas y si coincide el IdCliente del sistema con el IdCliente indicado por el usuario entonces almaceno ese registro en la lista '_totalReservasPorCliente'.
            {
                if (r.IdCliente == idCliente)
                {
                    _totalReservasPorCliente.Add(r);
                }
            }

            return _totalReservasPorCliente; //Devuelvo la lista con todas las reservas por cliente a la capa de presentación
        }
        public void AgregarReserva(Reserva nuevaReserva, string idHotel)
        {
            //Declaración de variables
            HabitacionDatos _habitacionDatos = new HabitacionDatos();
            List<Habitacion> _totalHabitaciones = new List<Habitacion>();
            List<Reserva> _totalReservas = new List<Reserva>();


            _totalReservas = _reservaDatos.TraerPorRegistro(888086); //Guardo en la lista '_totalReservas' los datos de todas las reservas por nro de registro que me trae la capa de Acceso a datos

            _totalHabitaciones = _habitacionDatos.TraerPorHotel(idHotel); //Guardo en la lista '_totalHabitaciones' los datos de todas las habitaciones por hotel (idHotel) que me trae la capa de Acceso a datos

            if (nuevaReserva == null) //Si el objeto que llega por parámetro es nulo se lo comunico al usuario mediante una excepción custom
            {
                throw new HabitacionInvalidaException();
            }

            else if (_totalReservas.Find(reg => reg.Id == nuevaReserva.Id) != null) //Regla de negocio: Si dentro de la lista de reservas encuentro alguna que tenga el mismo id que la nueva reserva se lo comunico al usuario mediante una excepción custom
            {
                throw new ObjetoExistenteException("Reserva", nuevaReserva.Id);
            }

            else
            {
                foreach (Reserva r in _totalReservas)
                {
                    if (r.IdHabitacion == nuevaReserva.IdHabitacion) //Regla de negocio que chequea si la habitacion a cargar en la reserva ya está reservada para la fecha indicada por el usuario, caso afirmativo se lo comunico al user mediante excepcion custom
                    {
                        if (r.FechaIngreso <= nuevaReserva.FechaIngreso && r.FechaEgreso >= nuevaReserva.FechaIngreso)
                        {
                            throw new HabitacionReservadaException(nuevaReserva.IdHabitacion, r.FechaIngreso, r.FechaEgreso);
                        }

                        else if (r.FechaIngreso <= nuevaReserva.FechaEgreso && r.FechaEgreso >= nuevaReserva.FechaIngreso)
                        {
                            throw new HabitacionReservadaException(nuevaReserva.IdHabitacion, r.FechaIngreso, r.FechaEgreso);
                        }
                    }
                }

                foreach (Habitacion h in _totalHabitaciones)
                {
                    if (nuevaReserva.IdHabitacion == h.Id)
                    {
                        if (nuevaReserva.CantidadHuespedes > h.CantidadPlazas) //Regla de negocio para validar que la cantidad de huespedes de la reserva no supere la cantidad de plazas que posee la habitación a reservar
                        {
                            throw new HabitacionSinEspacioException(h.CantidadPlazas);
                        }
                    }
                }

                TransactionResult transaction = _reservaDatos.Insertar(nuevaReserva); //Agrego la reserva al repositorio de datos

                if (!transaction.IsOk) //Si la transacción no se pudo completar le comunico el error al usuario mediante una excepción
                {
                    throw new Exception(transaction.Error);
                }
            }
        }
    }
}
