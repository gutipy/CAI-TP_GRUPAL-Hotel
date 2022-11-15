using ProyectoHotel.Datos;
using ProyectoHotel.Entidades;
using ProyectoHotel.Negocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHotel.Negocio
{
    public class HabitacionNegocio
    {
        //Atributos
        private HabitacionDatos _habitacionDatos;

        //Constructores
        public HabitacionNegocio()
        {
            _habitacionDatos = new HabitacionDatos();
        }

        //Funciones-Métodos
        public List<Habitacion> GetLista(string idHotel) //Función para listar a todas las habitaciones existentes por hotel
        {
            //Declaración de variables
            List<Habitacion> _totalHabitaciones = new List<Habitacion>();

            _totalHabitaciones = _habitacionDatos.TraerPorHotel(idHotel); //Guardo en la lista '_totalHabitaciones' los datos de todas las habitaciones de un hotel específico que me trae la capa de Acceso a datos

            return _totalHabitaciones; //Devuelvo la lista con todas las habitaciones por hotel a la capa de presentación
        }

        public void AgregarHabitacion(Habitacion nuevaHabitacion)
        {
            //Declaración de variables
            List<Habitacion> _totalHabitaciones = new List<Habitacion>();

            _totalHabitaciones = _habitacionDatos.TraerPorHotel(nuevaHabitacion.IdHotel.ToString()); //Traigo la lista total de habitaciones por hotel de la capa de datos y la guardo en la lista '_totalHabitaciones'

            if (nuevaHabitacion == null) //Si el objeto que llega por parámetro es nulo se lo comunico al usuario mediante una excepción custom
            {
                throw new HabitacionInvalidaException();
            }

            else if (_totalHabitaciones.Find(reg => reg.Id == nuevaHabitacion.Id) != null) //Si dentro de la lista de habitaciones encuentro alguna que tenga el mismo id que la nueva habitación se lo comunico al usuario mediante una excepción custom
            {
                throw new ObjetoExistenteException("Habitación", nuevaHabitacion.Id);
            }

            else if (_totalHabitaciones.Count > 100) //Regla de negocio que implica que si un hotel posee más de 100 habitaciones como maximo entonces le muestro una excepcion al user
            {
                throw new CantidadHabitacionesPorHotelException();
            }
            else
            {
                nuevaHabitacion.Categoria = ValidarCategoria(nuevaHabitacion.Categoria); //Valido y transformo la categoría recibida en número en la que corresponda (1 - Single, 2 - Double, etc.)

                TransactionResult transaction = _habitacionDatos.Insertar(nuevaHabitacion); //Agrego la habitación al repositorio de datos

                if (!transaction.IsOk) //Si la transacción no se pudo completar le comunico el error al usuario mediante una excepción
                {
                    throw new Exception(transaction.Error);
                }
            }
        }

        public string ValidarCategoria(string categoria)
        {
            if (categoria == "1")
            {
                return "Single";
            }

            else if (categoria == "2")
            {
                return "Double";
            }

            else if (categoria == "3")
            {
                return "Quadruple";
            }

            else if (categoria == "4")
            {
                return "Junior Suite";
            }

            else if (categoria == "5")
            {
                return "Suite";
            }

            else
            {
                return "Grand Suite";
            }
        }
    }
}
