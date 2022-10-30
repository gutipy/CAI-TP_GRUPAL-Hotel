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
                            //ListarHa(); //Listar habitaciones del sistema

                            break;

                        case "8":
                            //AgregarHa(); //Agrego una habitación al sistema

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
                Console.WriteLine("La agenda está vacía, por favor ingrese otra opción.");

                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                foreach (Cliente c in _listadoClientes)
                {
                    _acumulador +=
                        Environment.NewLine +
                        c.ToString() +
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
                _idCliente,
                _fechaAltaClienteValidada
                )
                ;

            C.AgregarCliente(nuevoCliente); //Invoco a la función 'AgregarCliente' de la capa de negocio y le indico que agregue el cliente con los datos que puso el usuario

            Console.WriteLine("El cliente fue agregado exitosamente al sistema, presione Enter para elegir otra opción.");

            Console.ReadKey();
            Console.Clear();
        }
    }
}
