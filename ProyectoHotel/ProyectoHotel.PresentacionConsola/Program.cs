using ProyectoHotel.Entidades;
using ProyectoHotel.Negocio;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHotel.PresentacionConsola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declaración de variables
            bool _consolaActiva = true;
            string _opcionMenuPrincipal = "";

            try
            {
                while (_consolaActiva)
                {
                    //Despliego en pantalla las opciones para que el usuario decida
                    MenuHelper.OpcionesMenuPrincipal();

                    //Se valida que la opcion ingresada no sea vacío y/o distinta de las opciones permitidas
                    ValidacionesInputHelper.FuncionValidacionOpcion(ref _opcionMenuPrincipal);

                    //Estructura condicional para controlar el flujo del programa
                    switch (_opcionMenuPrincipal)
                    {
                        case "1":
                            ListarC(); //Listar clientes del sistema

                            break;

                        case "2":
                            AgregarC(); //Agrego un cliente al sistema

                            break;

                        case "3":
                            //ListarR(); //Listar reservas del sistema

                            break;

                        case "4":
                            //AgregarR(); //Agrego una reserva al sistema

                            break;

                        case "5":
                            //ListarHo(); //Listar hoteles del sistema

                            break;

                        case "6":
                            //AgregarHo(); //Agrego un hotel al sistema

                            break;

                        case "7":
                            ListarHa(); //Listar habitaciones por hotel del sistema

                            break;

                        case "8":
                            AgregarHa(); //Agrego una habitación al sistema

                            break;

                        case "9":
                            //TraerReservasPorC(); //Traigo las reservas realizadas por cliente

                            break;

                        case "10":
                            //TraerHabitacionesPorHo(); //Traigo las habitaciones por hotel

                            break;

                        case "11":
                            //Salir(); //Salir del programa

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        public static void ListarC()
        {
            //Declaración de variables
            ClienteNegocio C = new ClienteNegocio();
            List<Cliente> _listadoClientes = new List<Cliente>();
            string _acumulador = "";

            _listadoClientes = C.GetLista(); //Traigo el listado de clientes de la capa de negocio que a su vez lo trae de la capa de datos

            if (_listadoClientes.Count == 0 || _listadoClientes == null) //Valido si la lista de clientes está vacía, caso afirmativo le informo al usuario y le pido que ingrese otra opción
            {
                Console.WriteLine("La lista de clientes está vacía, por favor ingrese otra opción.");

                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                foreach (Cliente c in _listadoClientes)
                {
                    _acumulador +=
                        Environment.NewLine +
                        c.GetCredencial() +
                        Environment.NewLine
                        ;
                }

                Console.WriteLine("Listado de todos los clientes de la cadena hotelera: " + Environment.NewLine + _acumulador + Environment.NewLine);

                Console.WriteLine("Presione Enter para elegir otra opción");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void AgregarC()
        {
            //Declaración de variables
            //---------------------------------------------------------
            ClienteNegocio C = new ClienteNegocio();
            List<Cliente> _listadoClientes = new List<Cliente>();
            bool _flag;
            int _idCliente;
            string _dniCliente;
            int _dniClienteValidado = 0;
            string _nombreCliente;
            string _apellidoCliente;
            string _direccionCliente;
            string _telefonoCliente;
            long _telefonoClienteValidado = 0;
            string _fechaNacimientoCliente;
            DateTime _fechaNacimientoClienteValidada = DateTime.Now;
            string _fechaAltaCliente;
            DateTime _fechaAltaClienteValidada = DateTime.Now;
            string _mailCliente;
            //---------------------------------------------------------


            _listadoClientes = C.GetLista(); //Traigo la lista de clientes de la capa de negocio

            _idCliente = _listadoClientes.Last().Id + 1; //Le asigno el código de cliente + 1 partiendo del último cliente de la lista

            do
            {
                Console.WriteLine("Ingrese el número de DNI del cliente a agregar");
                _dniCliente = Console.ReadLine();
                _flag = ValidacionesInputHelper.FuncionValidacionDni(_dniCliente, ref _dniClienteValidado, "Número de documento");

            } while (_flag == false);

            do
            {
                Console.WriteLine("Ingrese el nombre del cliente a agregar");
                _nombreCliente = Console.ReadLine();
                _flag = ValidacionesInputHelper.FuncionValidacionCadena(ref _nombreCliente, "Nombre");

            } while (_flag == false);

            do
            {
                Console.WriteLine("Ingrese el apellido del cliente a agregar");
                _apellidoCliente = Console.ReadLine();
                _flag = ValidacionesInputHelper.FuncionValidacionCadena(ref _apellidoCliente, "Apellido");

            } while (_flag == false);

            do
            {
                Console.WriteLine("Ingrese la fecha de nacimiento del cliente a agregar");
                _fechaNacimientoCliente = Console.ReadLine();
                _flag = ValidacionesInputHelper.FuncionValidacionFecha(_fechaNacimientoCliente, ref _fechaNacimientoClienteValidada, "Fecha de nacimiento");

            } while (_flag == false);

            do
            {
                Console.WriteLine("Ingrese la dirección del cliente a agregar");
                _direccionCliente = Console.ReadLine();
                _flag = ValidacionesInputHelper.FuncionValidacionCadena(ref _direccionCliente, "Dirección");

            } while (_flag == false);

            do
            {
                Console.WriteLine("Ingrese el teléfono del cliente a agregar");
                _telefonoCliente = Console.ReadLine();
                _flag = ValidacionesInputHelper.FuncionValidacionTelefono(_telefonoCliente, ref _telefonoClienteValidado, "Teléfono");

            } while (_flag == false);

            do
            {
                Console.WriteLine("Ingrese el mail del cliente a agregar");
                _mailCliente = Console.ReadLine();
                _flag = ValidacionesInputHelper.FuncionValidacionMail(ref _mailCliente, "Mail");

            } while (_flag == false);

            do
            {
                Console.WriteLine("Ingrese la fecha de alta del cliente a agregar");
                _fechaAltaCliente = Console.ReadLine();
                _flag = ValidacionesInputHelper.FuncionValidacionFecha(_fechaAltaCliente, ref _fechaAltaClienteValidada, "Fecha de alta");

            } while (_flag == false);

            Cliente nuevoCliente = new Cliente //Instancio la clase 'Cliente' y le asigno todos los inputs validados que ingresó el usuario
                (
                _dniClienteValidado,
                _nombreCliente,
                _apellidoCliente,
                _direccionCliente,
                _telefonoClienteValidado,
                _mailCliente,
                _fechaNacimientoClienteValidada,
                _idCliente,
                _fechaAltaClienteValidada
                )
                ;

            C.AgregarCliente(nuevoCliente); //Invoco a la función 'AgregarCliente' de la capa de negocio y le indico que agregue el cliente con los datos que puso el usuario

            Console.WriteLine("El cliente fue agregado exitosamente al sistema, presione Enter para elegir otra opción.");

            Console.ReadKey();
            Console.Clear();
        }

        public static void ListarHa()
        {
            //Declaración de variables
            //-------------------------------------------------------------
            HabitacionNegocio Ha = new HabitacionNegocio();
            List<Habitacion> _listadoHabitaciones = new List<Habitacion>();
            string _idHotel;
            int _idHotelValidado = 0;
            bool _flag;
            string _acumulador = "";
            //-------------------------------------------------------------

            do
            {
                Console.WriteLine("Ingrese el ID del hotel para listar las habitaciones:");
                //Agregar código para mostrarle al usuario el listado de IDs de los hoteles actuales
                _idHotel = Console.ReadLine();

                _flag = ValidacionesInputHelper.FuncionValidacionCodigo(_idHotel, ref _idHotelValidado, "ID Hotel");

            } while (_flag == false);

            _listadoHabitaciones = Ha.GetLista(_idHotelValidado.ToString()); //Traigo el listado de habitaciones por hotel de la capa de negocio que a su vez lo trae de la capa de datos

            if (_listadoHabitaciones.Count == 0 || _listadoHabitaciones == null) //Valido si la lista de habitaciones por hotel está vacía, caso afirmativo le informo al usuario y le pido que ingrese otra opción
            {
                Console.WriteLine("El hotel (ID: #" + _idHotelValidado + ") no posee habitaciones, por favor ingrese otra opción.");

                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                foreach (Habitacion ha in _listadoHabitaciones)
                {
                    _acumulador +=
                        Environment.NewLine +
                        ha.GetCredencial() +
                        Environment.NewLine
                        ;
                }

                Console.WriteLine("Listado de todas las habitaciones del hotel (ID: #" + _idHotelValidado + "): " + Environment.NewLine + _acumulador + Environment.NewLine);

                Console.WriteLine("Presione Enter para elegir otra opción");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void AgregarHa()
        {
            //Declaración de variables
            //---------------------------------------------------------
            HabitacionNegocio Ha = new HabitacionNegocio();
            List<Habitacion> _listadoHabitaciones = new List<Habitacion>();
            bool _flag;
            string _idHotel;
            int _idHotelValidado = 0;
            int _idHabitacion;
            string _opcionCategoriaHabitacion = "";
            string _cantidadPlazasHabitacion;
            int _cantidadPlazasHabitacionValidada = 0;
            string _opcionCancelacion = "";
            bool _esCancelable = false;
            string _precioHabitacion;
            double _precioHabitacionValidado = 0;
            //---------------------------------------------------------

            do
            {
                Console.WriteLine("Ingrese el ID del hotel al cual desea agregar una habitación:");
                //Agregar código para mostrarle al usuario el listado de IDs de los hoteles actuales
                _idHotel = Console.ReadLine();

                _flag = ValidacionesInputHelper.FuncionValidacionCodigo(_idHotel, ref _idHotelValidado, "ID Hotel");

            } while (_flag == false);

            _listadoHabitaciones = Ha.GetLista(_idHotelValidado.ToString()); //Traigo la lista de habitaciones por hotel de la capa de negocio

            _idHabitacion = _listadoHabitaciones.Last().Id + 1; //Le asigno el código de habitación + 1 partiendo del último cliente de la lista

            do
            {
                Console.WriteLine("Ingrese el número correspondiente a la categoría de la habitación a agregar");
                MenuHelper.OpcionesCategoriaHabitacion();

                _flag = ValidacionesInputHelper.FuncionValidacionOpcionCategoriaHabitacion(ref _opcionCategoriaHabitacion);

            } while (_flag == false);

            do
            {
                Console.WriteLine("Ingrese la cantidad de plazas de la habitación a agregar");
                _cantidadPlazasHabitacion = Console.ReadLine();

                _flag = ValidacionesInputHelper.FuncionValidacionNumeroNatural(_cantidadPlazasHabitacion, ref _cantidadPlazasHabitacionValidada, "Cantidad de plazas");

            } while (_flag == false);

            do
            {
                Console.WriteLine("Ingrese '1' si la habitación a agregar es cancelable y '2' si no es cancelable");
                _opcionCancelacion = Console.ReadLine();

                _flag = ValidacionesInputHelper.FuncionValidacionOpcionCancelacion(ref _opcionCancelacion, ref _esCancelable);

            } while (_flag == false);

            do
            {
                Console.WriteLine("Ingrese el precio de la habitación a agregar");
                _precioHabitacion = Console.ReadLine();

                _flag = ValidacionesInputHelper.FuncionValidacionPrecio(_precioHabitacion, ref _precioHabitacionValidado, "Precio");

            } while (_flag == false);

            Habitacion nuevaHabitacion = new Habitacion //Instancio la clase 'Habitacion' y le asigno todos los inputs validados que ingresó el usuario
                (
                _idHabitacion,
                _idHotelValidado,
                _opcionCategoriaHabitacion,
                -_cantidadPlazasHabitacionValidada,
                _esCancelable,
                _precioHabitacionValidado
                )
                ;

            Ha.AgregarHabitacion(nuevaHabitacion); //Invoco a la función 'AgregarHabitacion' de la capa de negocio y le indico que agregue la habitación con los datos que puso el usuario

            Console.WriteLine("La habitación fue agregado exitosamente al sistema, presione Enter para elegir otra opción.");

            Console.ReadKey();
            Console.Clear();
        }
    }
}
