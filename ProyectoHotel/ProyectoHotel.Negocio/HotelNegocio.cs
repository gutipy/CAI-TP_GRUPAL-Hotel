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
    public class HotelNegocio
    {
        //Atributos
        private HotelDatos _hotelDatos;

        //Constructores
        public HotelNegocio()
        {
            _hotelDatos = new HotelDatos();
        }

        //Funciones-Métodos
        public List<Hotel> GetLista() //Función para listar a todos los hoteles por usuario
        {
            //Declaración de variables
            List<Hotel> _totalHoteles = new List<Hotel>();

            _totalHoteles = _hotelDatos.Traer(888086); //Guardo en la lista '_totalHoteles' los datos de todos los hoteles por usuario que me trae la capa de Datos

            return _totalHoteles; //Devuelvo la lista con todos los hoteles por usuario a la capa de presentación
        }

        public void AgregarHotel(Hotel nuevoHotel)
        {
            //Declaración de variables
            List<Hotel> _totalHoteles = new List<Hotel>();

            _totalHoteles = _hotelDatos.Traer(888086); //Guardo en la lista '_totalHoteles' los datos de todos los hoteles por usuario que me trae la capa de Datos

            if (nuevoHotel == null) //Si el objeto que llega por parámetro es nulo se lo comunico al usuario mediante una excepción custom
            {
                throw new ObjetoInvalidoException("Hotel");
            }

            else if (_totalHoteles.Find(reg => reg.Id == nuevoHotel.Id) != null) //Si dentro de la lista de hoteles encuentro alguno que tenga el mismo id que el nuevo hotel se lo comunico al usuario mediante una excepción custom
            {
                throw new ObjetoExistenteException("Hotel", nuevoHotel.Id);
            }

            else if (nuevoHotel.Estrellas < 1 || nuevoHotel.Estrellas > 5) //Regla de negocio que implica que si un hotel posee menos de 1 estrella o más de 5 entonces le muestro una excepcion al user
            {
                throw new CantidadEstrellasException();
            }

            else
            {
                nuevoHotel.Amenities = ValidarAmenities(nuevoHotel.Estrellas, nuevoHotel.Amenities); //Valido que la configuración de las amenities para los nuevos hoteles respete la regla de negocio indicada en la firma del método 'ValidarAmenities'

                TransactionResult transaction = _hotelDatos.Insertar(nuevoHotel); //Agrego el hotel al repositorio de datos

                if (!transaction.IsOk) //Si la transacción no se pudo completar le comunico el error al usuario mediante una excepción
                {
                    throw new Exception(transaction.Error);
                }
            }
        }

        public bool ValidarAmenities(int estrellas, bool amenities) //Regla de negocio que implica que los hoteles de 2 o menos estrellas NO pueden tener amenities y los de 3 o más estrellas DEBEN tener amenities sino le comunico al usuario mediante excepcion custom
        {
            if (estrellas <= 2)
            {
                if (amenities == true)
                {
                    throw new AmenitiesInvalidasException();
                }

                else
                {
                    return false;
                }

            }

            else
            {
                if (amenities == false)
                {
                    throw new AmenitiesInvalidasException();
                }

                else
                {
                    return true;
                }
            }
        }
    }
}
