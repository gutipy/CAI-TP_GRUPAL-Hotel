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

                    Console.Clear();

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
                            ListarR(); //Listar reservas del sistema

                            break;

                        case "4":
                            AgregarR(); //Agrego una reserva al sistema

                            break;

                        case "5":
                            ListarHo(); //Listar hoteles del sistema

                            break;

                        case "6":
                            AgregarHo(); //Agrego un hotel al sistema

                            break;

                        case "7":
                            ListarHa(); //Listar habitaciones por hotel del sistema

                            break;

                        case "8":
                            AgregarHa(); //Agrego una habitación al sistema

                            break;

                        case "9":
                            TraerReservasPorC(); //Traigo las reservas realizadas por cliente

                            break;

                        case "10":
                            TraerHabitacionesPorHo(); //Traigo las habitaciones por hotel

                            break;

                        case "11":
                            Salir(); //Salir del programa

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
                foreach (Cliente c in _listadoClientes) //Recorro todos los clientes por numero de registro y los almaceno en el acumulador ya formateados con la función 'GetCredencial' para mostrar los datos más relevantes al user
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
            DateTime _fechaAltaClienteValidada = DateTime.Now;
            string _mailCliente;
            //---------------------------------------------------------


            _listadoClientes = C.GetLista(); //Traigo la lista de clientes de la capa de negocio

            if (_listadoClientes.Count == 0) //Si la lista de clientes por número de registro está vacía le indico que le cargue el ID #01 al cliente
            {
                _idCliente = 1;
            }
            else //Si la lista de clientes no está vacía le indico que asigne el código de cliente + 1 partiendo del último cliente de la lista
            {
                _idCliente = _listadoClientes.Last().Id + 1;
            }

            do //Pido el DNI del cliente al usuario y lo valido
            {
                Console.WriteLine("Ingrese el número de DNI del cliente a agregar");
                _dniCliente = Console.ReadLine();

                _flag = ValidacionesInputHelper.FuncionValidacionDni(_dniCliente, ref _dniClienteValidado, "Número de documento");

            } while (_flag == false);

            do //Pido el nombre del cliente al usuario y lo valido
            {
                Console.WriteLine("Ingrese el nombre del cliente a agregar");
                _nombreCliente = Console.ReadLine();

                _flag = ValidacionesInputHelper.FuncionValidacionCadena(ref _nombreCliente, "Nombre");

            } while (_flag == false);

            do //Pido el apellido del cliente al usuario y lo valido
            {
                Console.WriteLine("Ingrese el apellido del cliente a agregar");
                _apellidoCliente = Console.ReadLine();

                _flag = ValidacionesInputHelper.FuncionValidacionCadena(ref _apellidoCliente, "Apellido");

            } while (_flag == false);

            do //Pido la fecha de nacimiento del cliente al usuario y lo valido
            {
                Console.WriteLine("Ingrese la fecha de nacimiento del cliente a agregar");
                _fechaNacimientoCliente = Console.ReadLine();

                _flag = ValidacionesInputHelper.FuncionValidacionFechaNacimiento(_fechaNacimientoCliente, ref _fechaNacimientoClienteValidada, "Fecha de nacimiento");

            } while (_flag == false);

            do //Pido la dirección del cliente al usuario y lo valido
            {
                Console.WriteLine("Ingrese la dirección del cliente a agregar");
                _direccionCliente = Console.ReadLine();

                _flag = ValidacionesInputHelper.FuncionValidacionCadena(ref _direccionCliente, "Dirección");

            } while (_flag == false);

            do //Pido el teléfono del cliente al usuario y lo valido
            {
                Console.WriteLine("Ingrese el teléfono del cliente a agregar");
                _telefonoCliente = Console.ReadLine();

                _flag = ValidacionesInputHelper.FuncionValidacionTelefono(_telefonoCliente, ref _telefonoClienteValidado, "Teléfono");

            } while (_flag == false);

            do //Pido el email del cliente al usuario y lo valido
            {
                Console.WriteLine("Ingrese el mail del cliente a agregar");
                _mailCliente = Console.ReadLine();

                _flag = ValidacionesInputHelper.FuncionValidacionMail(ref _mailCliente, "Mail");

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
            HotelNegocio Ho = new HotelNegocio();
            List<Hotel> _listadoHoteles = new List<Hotel>();
            string _idHotel;
            int _idHotelValidado = 0;
            bool _flag;
            string _acumulador = "";
            //-------------------------------------------------------------

            do
            {
                _listadoHoteles = Ho.GetLista(); //Traigo la lista de hoteles de la capa de negocio

                foreach (Hotel ho in _listadoHoteles) //Recorro todos los hoteles por numero de registro y los almaceno en el acumulador ya formateados con la función 'GetCredencial' para mostrar los datos más relevantes al user
                {
                    _acumulador +=
                        Environment.NewLine +
                        ho.GetCredencial() +
                        Environment.NewLine
                        ;
                }

                Console.WriteLine(_acumulador + Environment.NewLine);

                Console.WriteLine("Ingrese el ID del hotel para listar las habitaciones:");
                _idHotel = Console.ReadLine();

                _flag = ValidacionesInputHelper.FuncionValidacionCodigo(_idHotel, ref _idHotelValidado, "ID Hotel");

            } while (_flag == false);

            Console.Clear();

            _listadoHabitaciones = Ha.GetLista(_idHotelValidado.ToString()); //Traigo el listado de habitaciones por hotel de la capa de negocio que a su vez lo trae de la capa de datos

            if (_listadoHabitaciones.Count == 0 || _listadoHabitaciones == null) //Valido si la lista de habitaciones por hotel está vacía, caso afirmativo le informo al usuario y le pido que ingrese otra opción
            {
                Console.WriteLine("El hotel (ID: #" + _idHotelValidado + ") no posee habitaciones, por favor ingrese otra opción.");

                Console.ReadKey();
                Console.Clear();
            }

            else
            {
                _acumulador = "";

                foreach (Habitacion ha in _listadoHabitaciones) //Recorro todas las habitaciones por id de hotel y las almaceno en el acumulador ya formateadas con la función 'GetCredencial' para mostrar los datos más relevantes al user
                {
                    _acumulador +=
                        Environment.NewLine +
                        ha.GetCredencial() +
                        Environment.NewLine
                        ;
                }

                Console.Clear();

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
            HotelNegocio Ho = new HotelNegocio();
            List<Hotel> _listadoHoteles = new List<Hotel>();
            bool _flag;
            string _acumulador = "";
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
                _listadoHoteles = Ho.GetLista();

                foreach (Hotel ho in _listadoHoteles)
                {
                    _acumulador +=
                        Environment.NewLine +
                        ho.GetCredencial() +
                        Environment.NewLine
                        ;
                }

                Console.WriteLine(_acumulador + Environment.NewLine);

                Console.WriteLine("Ingrese el ID del hotel al cual desea agregar una habitación:");
                //Agregar código para mostrarle al usuario el listado de IDs de los hoteles actuales
                _idHotel = Console.ReadLine();

                _flag = ValidacionesInputHelper.FuncionValidacionCodigo(_idHotel, ref _idHotelValidado, "ID Hotel");

            } while (_flag == false);

            _listadoHabitaciones = Ha.GetLista(_idHotelValidado.ToString()); //Traigo la lista de habitaciones por hotel de la capa de negocio

            if (_listadoHabitaciones.Count == 0)
            {
                _idHabitacion = 1;
            }
            else
            {
                _idHabitacion = _listadoHabitaciones.Last().Id + 1; //Le asigno el código de habitación + 1 partiendo de la última habitación de la lista
            }

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
                _cantidadPlazasHabitacionValidada,
                _esCancelable,
                _precioHabitacionValidado
                )
                ;

            Ha.AgregarHabitacion(nuevaHabitacion); //Invoco a la función 'AgregarHabitacion' de la capa de negocio y le indico que agregue la habitación con los datos que puso el usuario

            Console.WriteLine("La habitación fue agregado exitosamente al sistema, presione Enter para elegir otra opción.");

            Console.ReadKey();
            Console.Clear();
        }

        public static void ListarHo()
        {
            //Declaración de variables
            //----------------------------------------------
            HotelNegocio Ho = new HotelNegocio();
            List<Hotel> _listadoHoteles = new List<Hotel>();
            string _acumulador = "";
            //----------------------------------------------

            _listadoHoteles = Ho.GetLista(); //Traigo el listado de hoteles de la capa de negocio que a su vez lo trae de la capa de datos

            if (_listadoHoteles.Count == 0 || _listadoHoteles == null) //Valido si la lista de hoteles está vacía, caso afirmativo le informo al usuario y le pido que ingrese otra opción
            {
                Console.WriteLine("La lista de hoteles está vacía, por favor ingrese otra opción.");

                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                foreach (Hotel ho in _listadoHoteles) //Recorro todos los hoteles por numero de registro y los almaceno en el acumulador ya formateados con la función 'GetCredencial' para mostrar los datos más relevantes al user
                {
                    _acumulador +=
                        Environment.NewLine +
                        ho.GetCredencial() +
                        Environment.NewLine
                        ;
                }

                Console.WriteLine("Listado de todos los hoteles del sistema por número de registro 888.086: " + Environment.NewLine + _acumulador + Environment.NewLine);

                Console.WriteLine("Presione Enter para elegir otra opción");

                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void AgregarHo()
        {
            //Declaración de variables
            //---------------------------------------------------
            HotelNegocio Ho = new HotelNegocio();
            List<Hotel> _listadoHoteles = new List<Hotel>();
            bool _flag;
            int _idHotel;
            string _nombreHotel;
            string _direccionHotel;
            string _cantidadEstrellas;
            int _cantidadEstrellasValidada = 0;
            string _opcionAmenities;
            bool _tieneAmenities = false;
            //---------------------------------------------------

            _listadoHoteles = Ho.GetLista(); //Traigo la lista de hoteles de la capa de negocio

            if (_listadoHoteles.Count == 0) //Si la lista de hoteles por número de registro está vacía le indico que le cargue el ID #01 al hotel
            {
                _idHotel = 1;
            }
            else //Si la lista de hoteles no está vacía le indico que asigne el código de hotel + 1 partiendo del último hotel de la lista
            {
                _idHotel = _listadoHoteles.Last().Id + 1;
            }


            do //Pido al usuario el nombre del hotel y lo valido
            {
                Console.WriteLine("Ingrese el nombre del hotel a agregar");
                _nombreHotel = Console.ReadLine();

                _flag = ValidacionesInputHelper.FuncionValidacionCadena(ref _nombreHotel, "Nombre");

            } while (_flag == false);

            do //Pido al usuario la dirección del hotel y lo valido
            {
                Console.WriteLine("Ingrese la dirección del hotel a agregar");
                _direccionHotel = Console.ReadLine();

                _flag = ValidacionesInputHelper.FuncionValidacionCadena(ref _direccionHotel, "Dirección");

            } while (_flag == false);

            do //Pido al usuario la cantidad de estrellas del hotel y lo valido
            {
                Console.WriteLine("Ingrese la cantidad de estrellas (de 1 a 5) del hotel a agregar");
                _cantidadEstrellas = Console.ReadLine();

                _flag = ValidacionesInputHelper.FuncionValidacionNumeroNatural(_cantidadEstrellas, ref _cantidadEstrellasValidada, "Cantidad de estrellas");

            } while (_flag == false);

            do //Pido al usuario las amenities del hotel y lo valido
            {
                Console.WriteLine("Ingrese '1' si el hotel a agregar posee amenities y '2' si no posee amenities (Recuerde que los hoteles con 2 o menos estrellas NO pueden tener amenities y los hoteles con 3 o más estrellas DEBEN tener amenities)");
                _opcionAmenities = Console.ReadLine();

                _flag = ValidacionesInputHelper.FuncionValidacionOpcionAmenities(ref _opcionAmenities, ref _tieneAmenities);

            } while (_flag == false);

            Hotel nuevoHotel = new Hotel //Instancio la clase 'Hotel' y le asigno todos los inputs validados que ingresó el usuario
                (
                _idHotel,
                _nombreHotel,
                _direccionHotel,
                _cantidadEstrellasValidada,
                _tieneAmenities
                )
                ;

            Ho.AgregarHotel(nuevoHotel); //Invoco a la función 'AgregarHotel' de la capa de negocio y le indico que agregue el hotel con los datos que puso el usuario

            Console.WriteLine("El hotel fue agregado exitosamente al sistema, presione Enter para elegir otra opción.");

            Console.ReadKey();
            Console.Clear();
        }

        public static void ListarR()
        {
            //Declaración de variables
            //----------------------------------------------
            ReservaNegocio R = new ReservaNegocio();
            List<Reserva> _listadoReservas = new List<Reserva>();
            string _acumulador = "";
            //----------------------------------------------

            _listadoReservas = R.GetLista(); //Traigo el listado de reservas de la capa de negocio que a su vez lo trae de la capa de datos

            if (_listadoReservas.Count == 0 || _listadoReservas == null) //Valido si la lista de reservas está vacía, caso afirmativo le informo al usuario y le pido que ingrese otra opción
            {
                Console.WriteLine("La lista de reservas está vacía, por favor ingrese otra opción.");

                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                foreach (Reserva r in _listadoReservas) //Recorro todas las reservas por numero de registro y las almaceno en el acumulador ya formateadas con la función 'GetCredencial' para mostrar los datos más relevantes al user
                {
                    _acumulador +=
                        Environment.NewLine +
                        r.GetCredencial() +
                        Environment.NewLine
                        ;
                }

                Console.WriteLine("Listado de todas las reservas del sistema para el número de registro 888.086: " + Environment.NewLine + _acumulador + Environment.NewLine);

                Console.WriteLine("Presione Enter para elegir otra opción");

                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void AgregarR()
        {
            //Declaración de variables
            //---------------------------------------------------
            ReservaNegocio R = new ReservaNegocio();
            List<Reserva> _listadoReservas = new List<Reserva>();
            ClienteNegocio C = new ClienteNegocio();
            List<Cliente> _listadoClientes = new List<Cliente>();
            HotelNegocio Ho = new HotelNegocio();
            List<Hotel> _listadoHoteles = new List<Hotel>();
            HabitacionNegocio Ha = new HabitacionNegocio();
            List<Habitacion> _listadoHabitaciones = new List<Habitacion>();
            string _acumulador = "";
            bool _flag;
            int _idReserva;
            int _idCliente = 0;
            string _dniCliente;
            int _dniClienteValidado = 0;
            string _idHotel;
            int _idHotelValidado = 0;
            string _idHabitacion;
            int _idHabitacionValidado = 0;
            string _cantidadHuespedes;
            int _cantidadHuespedesValidado = 0;
            string _fechaIngreso;
            DateTime _fechaIngresoValidada = DateTime.Now;
            string _fechaEgreso;
            DateTime _fechaEgresoValidada = DateTime.Now;
            //---------------------------------------------------

            _listadoReservas = R.GetLista(); //Traigo la lista de reservas de la capa de negocio

            if (_listadoReservas.Count == 0) //Si la lista de reservas por número de registro está vacía le indico que le cargue el ID #01 a la reserva
            {
                _idReserva = 1;
            }
            else
            {
                _idReserva = _listadoReservas.Last().Id + 1; //Si la lista de reservas no está vacía le indico que asigne el código de reserva + 1 partiendo de la última reserva de la lista
            }

            do //Muestro los clientes en pantalla para que el usuario ingrese el DNI de un cliente (se valida el DNI) para la reserva a agregar
            {
                _listadoClientes = C.GetLista(); //Traigo la lista de clientes de la capa de negocio

                foreach (Cliente c in _listadoClientes) //Recorro todos los clientes por numero de registro y los almaceno en el acumulador ya formateados con la función 'GetCredencial' para mostrar los datos más relevantes al user
                {
                    _acumulador +=
                        Environment.NewLine +
                        c.GetCredencial() +
                        Environment.NewLine
                        ;
                }

                Console.WriteLine(_acumulador + Environment.NewLine);

                Console.WriteLine("Ingrese el DNI del cliente de la reserva a agregar");
                _dniCliente = Console.ReadLine();

                _flag = ValidacionesInputHelper.FuncionValidacionDni(_dniCliente, ref _dniClienteValidado, "DNI");



                foreach (Cliente c in _listadoClientes)
                {
                    if (c.Dni == _dniClienteValidado) //Una vez que validé el DNI se busca matchear el DNI ingresado con el DNI de la lista de clientes para asi poder encontrar el ID de cliente
                    {
                        _idCliente = c.Id; //Asigno el ID del cliente correspondiente al DNI ingresado por el usuario a la variable _idCliente
                    }
                }

                if (_idCliente == 0) //Si el ID de cliente sigue en su valor por defecto quiere decir que el DNI ingresado no corresponde a ningún cliente registrado, por lo cual le aviso al usuario que ingrese un DNI valido o se registre como cliente.
                {
                    Console.WriteLine("El DNI ingresado no corresponde a ningún cliente registrado en el Sistema, intente nuevamente.");

                    _flag = false;
                }
                else
                {
                    _flag = true;
                }

            } while (_flag == false);

            Console.Clear();

            do //Muestro los hoteles en pantalla para que el usuario ingrese el ID de un hotel (se valida el ID) para la reserva a agregar
            {
                _acumulador = "";
                _listadoHoteles = Ho.GetLista(); //Traigo la lista de hoteles de la capa de negocio

                foreach (Hotel ho in _listadoHoteles) //Recorro todos los hoteles y los almaceno en el acumulador ya formateados con la función 'GetCredencial' para mostrar los datos más relevantes al user
                {
                    _acumulador +=
                        Environment.NewLine +
                        ho.GetCredencial() +
                        Environment.NewLine
                        ;
                }

                Console.WriteLine(_acumulador + Environment.NewLine);

                Console.WriteLine("Ingrese el ID del hotel de la reserva a agregar");
                _idHotel = Console.ReadLine();

                _flag = ValidacionesInputHelper.FuncionValidacionCodigo(_idHotel, ref _idHotelValidado, "ID Hotel");

            } while (_flag == false);

            Console.Clear();

            do //Muestro las habitaciones del ID de hotel seleccionado en pantalla para que el usuario ingrese el ID de una habitación (se valida el ID) para la reserva a agregar
            {
                _acumulador = "";
                _listadoHabitaciones = Ha.GetLista(_idHotelValidado.ToString()); //Traigo la lista de habitaciones para el ID de hotel indicado por el usuario

                foreach (Habitacion ha in _listadoHabitaciones) //Recorro todas las habitaciones del hotel indicado y las almaceno en el acumulador ya formateadas con la función 'GetCredencial' para mostrar los datos más relevantes al user
                {
                    _acumulador +=
                        Environment.NewLine +
                        ha.GetCredencial() +
                        Environment.NewLine
                        ;
                }

                Console.WriteLine(_acumulador + Environment.NewLine);

                Console.WriteLine("Ingrese el ID de la habitación de la reserva a agregar");
                _idHabitacion = Console.ReadLine();

                _flag = ValidacionesInputHelper.FuncionValidacionCodigo(_idHabitacion, ref _idHabitacionValidado, "ID Habitación");

            } while (_flag == false);

            do //Pido la cantidad de huéspedes al usuario y lo valido
            {
                Console.WriteLine("Ingrese la cantidad de huéspedes de la reserva a agregar");
                _cantidadHuespedes = Console.ReadLine();

                _flag = ValidacionesInputHelper.FuncionValidacionNumeroNatural(_cantidadHuespedes, ref _cantidadHuespedesValidado, "Cantidad de huéspedes");

            } while (_flag == false);

            Console.Clear();

            do //Pido la fecha de ingreso al usuario y lo valido
            {
                Console.WriteLine("Ingrese la fecha de ingreso de la reserva a agregar (Recuerde que las reservas se realizan como máximo con 1 (un) año de anticipación)");
                _fechaIngreso = Console.ReadLine();

                _flag = ValidacionesInputHelper.FuncionValidacionFecha(_fechaIngreso, ref _fechaIngresoValidada, "Fecha de ingreso");

            } while (_flag == false);

            do //Pido la fecha de egreso al usuario y lo valido
            {
                Console.WriteLine("Ingrese la fecha de egreso de la reserva a agregar (Recuerde que las reservas se realizan como máximo con 1 (un) año de anticipación)");
                _fechaEgreso = Console.ReadLine();

                _flag = ValidacionesInputHelper.FuncionValidacionFecha(_fechaEgreso, ref _fechaEgresoValidada, "Fecha de egreso");

            } while (_flag == false);

            Reserva nuevaReserva = new Reserva //Instancio la clase 'Reserva' y le asigno todos los inputs validados que ingresó el usuario
                (
                _idReserva,
                _idCliente,
                _idHabitacionValidado,
                _cantidadHuespedesValidado,
                _fechaIngresoValidada,
                _fechaEgresoValidada
                )
                ;

            R.AgregarReserva(nuevaReserva, _idHotel); //Invoco a la función 'AgregarReserva' de la capa de negocio y le indico que agregue la reserva con los datos que puso el usuario

            Console.WriteLine("La reserva fue agregada exitosamente al sistema, presione Enter para elegir otra opción.");

            Console.ReadKey();
            Console.Clear();
        }

        public static void TraerReservasPorC()
        {
            //Declaración de variables
            //----------------------------------------------
            ReservaNegocio R = new ReservaNegocio();
            List<Reserva> _listadoReservasPorCliente = new List<Reserva>();
            ClienteNegocio C = new ClienteNegocio();
            List<Cliente> _listadoClientes = new List<Cliente>();
            string _acumulador = "";
            bool _flag;
            string _idCliente;
            int _idClienteValidado = 0;
            //----------------------------------------------

            do //Muestro los clientes en pantalla para que el usuario ingrese el ID de un cliente (se valida el ID) para la reserva a agregar
            {
                _listadoClientes = C.GetLista(); //Traigo la lista de clientes de la capa de negocio

                foreach (Cliente c in _listadoClientes) //Recorro todos los clientes por numero de registro y los almaceno en el acumulador ya formateados con la función 'GetCredencial' para mostrar los datos más relevantes al user
                {
                    _acumulador +=
                        Environment.NewLine +
                        c.GetCredencial() +
                        Environment.NewLine
                        ;
                }

                Console.WriteLine(_acumulador + Environment.NewLine);

                Console.WriteLine("Ingrese el ID del cliente del cuál desea traer las reservas");
                _idCliente = Console.ReadLine();

                _flag = ValidacionesInputHelper.FuncionValidacionCodigo(_idCliente, ref _idClienteValidado, "ID Cliente");

            } while (_flag == false);

            Console.Clear();

            _listadoReservasPorCliente = R.GetListaPorCliente(_idClienteValidado); //Traigo el listado de reservas por cliente de la capa de negocio que a su vez lo trae de la capa de datos

            if (_listadoReservasPorCliente.Count == 0 || _listadoReservasPorCliente == null) //Valido si la lista de reservas para ese cliente está vacía, caso afirmativo le informo al usuario y le pido que ingrese otra opción
            {
                Console.WriteLine("La lista de reservas para el cliente con ID " + _idClienteValidado + " está vacía, por favor ingrese otra opción.");

                Console.ReadKey();
                Console.Clear();
            }

            else
            {
                _acumulador = "";

                foreach (Reserva r in _listadoReservasPorCliente) //Recorro todas las reservas por ID de cliente y las almaceno en el acumulador ya formateadas con la función 'GetCredencial' para mostrar los datos más relevantes al user
                {
                    _acumulador +=
                        Environment.NewLine +
                        r.GetCredencial() +
                        Environment.NewLine
                        ;
                }

                Console.WriteLine("Listado de todas las reservas para el cliente con ID " + _idClienteValidado + ":" + Environment.NewLine + _acumulador + Environment.NewLine);

                Console.WriteLine("Presione Enter para elegir otra opción");

                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void TraerHabitacionesPorHo()
        {
            ListarHa();
        }

        public static void Salir()
        {
            Console.WriteLine("Usted ha salido del gestor del Rich Texan Hotel, presione Enter");
            Console.ReadKey();

            Environment.Exit(0);
        }
    }
}
