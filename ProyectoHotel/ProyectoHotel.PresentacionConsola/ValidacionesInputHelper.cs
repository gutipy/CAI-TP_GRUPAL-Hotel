using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHotel.PresentacionConsola
{
    internal static class ValidacionesInputHelper
    {
        internal static string FuncionValidacionOpcion(ref string opcion)
        {
            //Declaración de variables
            bool flag = false;

            do
            {
                opcion = Console.ReadLine();

                if (string.IsNullOrEmpty(opcion))
                {
                    Console.WriteLine("ERROR! La opción ingresada no puede ser vacío, intente nuevamente.");
                }
                else if (opcion == "1" || opcion == "2" || opcion == "3" || opcion == "4" || opcion == "5" || opcion == "6" || opcion == "7" || opcion == "8" || opcion == "9" || opcion == "10" || opcion == "11")
                {
                    flag = true;
                }
                else
                {
                    Console.WriteLine("ERROR! La opción " + opcion + " no es una opción válida, intente nuevamente.");
                }
            } while (flag == false);

            return opcion;
        }

        internal static bool FuncionValidacionCadena(ref string cadena, string campo)
        {
            //Declaración de variables
            bool flag = false;

            if (string.IsNullOrEmpty(cadena))
            {
                Console.WriteLine("ERROR! El campo " + campo + " no puede ser vacío, intente nuevamente.");
            }
            else if (cadena.Length > 25)
            {
                Console.WriteLine("ERROR! El campo " + campo + " no puede tener más de 25 caractéres, intente nuevamente.");
            }
            else
            {
                flag = true;
            }

            return flag;
        }

        internal static bool FuncionValidacionOpcionCategoriaHabitacion(ref string opcion)
        {
            //Declaración de variables
            bool flag = false;

            do
            {
                opcion = Console.ReadLine();

                if (string.IsNullOrEmpty(opcion))
                {
                    Console.WriteLine("ERROR! La opción ingresada no puede ser vacío, intente nuevamente.");
                }

                else if (opcion == "1" || opcion == "2" || opcion == "3" || opcion == "4" || opcion == "5" || opcion == "6")
                {
                    flag = true;
                }

                else
                {
                    Console.WriteLine("ERROR! La opción " + opcion + " no es una opción válida, intente nuevamente.");
                }
            } while (flag == false);

            return flag;
        }


        internal static bool FuncionValidacionDni(string dni, ref int dniValidado, string campo)
        {
            //Declaración de variables
            bool flag = false;

            if (string.IsNullOrEmpty(dni))
            {
                Console.WriteLine("ERROR! El campo " + campo + " no puede ser vacío, intente nuevamente.");
            }
            else if (!int.TryParse(dni, out dniValidado))
            {
                Console.WriteLine("ERROR! El valor ingresado para el campo " + campo + " debe ser de tipo numérico, intente nuevamente.");
            }

            else if (dniValidado <= 0)
            {
                Console.WriteLine("ERROR! El valor ingresado para el campo " + campo + " no debe ser negativo, intente nuevamente.");
            }

            else if (dniValidado.ToString().Length > 10)
            {
                Console.WriteLine("ERROR! El valor ingresado para el campo " + campo + " no debe poseer más de 10 dígitos, intente nuevamente.");
            }
            else
            {
                flag = true;
            }

            return flag;
        }

        internal static bool FuncionValidacionFecha(string fecha, ref DateTime fechaValidada, string campo)
        {
            //Declaración de variables
            bool flag = false;

            if (string.IsNullOrEmpty(fecha))
            {
                Console.WriteLine("ERROR! El campo " + campo + " no puede ser vacío, intente nuevamente.");
            }

            else if (!DateTime.TryParse(fecha, out fechaValidada))
            {
                Console.WriteLine("El campo " + campo + " debe ser de tipo fecha y tener un formato válido del tipo dd/mm/aaaa, intente nuevamente.");
            }

            else if (fechaValidada > DateTime.Now)
            {
                Console.WriteLine("El campo " + campo + " no puede ser superior al día de hoy, intente nuevamente.");
            }

            else
            {
                flag = true;
            }

            return flag;
        }

        internal static bool FuncionValidacionTelefono(string telefono, ref long telefonoValidado, string campo)
        {
            //Declaración de variables
            bool flag = false;

            if (string.IsNullOrEmpty(telefono))
            {
                Console.WriteLine("ERROR! El campo " + campo + " no puede ser vacío, intente nuevamente.");
            }

            else if (!long.TryParse(telefono, out telefonoValidado))
            {
                Console.WriteLine("El campo " + campo + " debe ser de tipo numérico, intente nuevamente.");
            }

            else if (telefonoValidado.ToString().Length < 8 || telefonoValidado.ToString().Length > 10)
            {
                Console.WriteLine("El campo " + campo + " debe poseer entre 8 y 10 caracteres, intente nuevamente.");
            }

            else
            {
                flag = true;
            }

            return flag;
        }

        internal static bool FuncionValidacionMail(ref string mail, string campo)
        {
            //Declaración de variables
            string trimmedEmail = mail.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                Console.WriteLine("ERROR! El mail ingresado es inválido porqué finaliza con un punto, intente nuevamente."); //Si el mail ingresado termina con '.' da error
            }

            try
            {
                var addr = new System.Net.Mail.MailAddress(mail);

                if (addr.Address == trimmedEmail)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch
            {
                return false;
            }
        }

        internal static bool FuncionValidacionCodigo(string codigo, ref int codigoValidado, string campo)
        {
            //Declaración de variables
            bool flag = false;

            if (string.IsNullOrEmpty(codigo))
            {
                Console.WriteLine("ERROR! El campo " + campo + " no puede ser vacío, intente nuevamente.");
            }

            else if (!int.TryParse(codigo, out codigoValidado))
            {
                Console.WriteLine("ERROR! El valor ingresado para el campo " + campo + " debe ser de tipo numérico, intente nuevamente.");
            }

            else if (codigoValidado <= 0)
            {
                Console.WriteLine("ERROR! El valor ingresado para el campo " + campo + " no debe ser negativo, intente nuevamente.");
            }

            else
            {
                flag = true;
            }

            return flag;
        }

        internal static bool FuncionValidacionNumeroNatural(string numero, ref int numeroValidado, string campo)
        {
            //Declaración de variables
            bool flag = false;

            if (string.IsNullOrEmpty(numero))
            {
                Console.WriteLine("ERROR! El campo " + campo + " no puede ser vacío, intente nuevamente.");
            }

            else if (!int.TryParse(numero, out numeroValidado))
            {
                Console.WriteLine("ERROR! El valor ingresado para el campo " + campo + " debe ser de tipo numérico, intente nuevamente.");
            }

            else if (numeroValidado <= 0)
            {
                Console.WriteLine("ERROR! El valor ingresado para el campo " + campo + " no debe ser negativo, intente nuevamente.");
            }

            else
            {
                flag = true;
            }

            return flag;
        }

        internal static bool FuncionValidacionOpcionCancelacion(ref string opcion, ref bool esCancelable)
        {
            //Declaración de variables
            bool flag = false;

            do
            {
                opcion = Console.ReadLine();

                if (string.IsNullOrEmpty(opcion))
                {
                    Console.WriteLine("ERROR! La opción ingresada no puede ser vacío, intente nuevamente.");
                }

                else if (opcion == "1" || opcion == "2")
                {
                    flag = true;

                    if (opcion == "1")
                    {
                        esCancelable = true;
                    }
                    else if (opcion == "2")
                    {
                        esCancelable = false;
                    }
                }

                else
                {
                    Console.WriteLine("ERROR! La opción " + opcion + " no es una opción válida, intente nuevamente.");
                }

            } while (flag == false);

            return flag;
        }

        internal static bool FuncionValidacionPrecio(string precio, ref double precioValidado, string campo)
        {
            //Declaración de variables
            bool flag = false;

            if (string.IsNullOrEmpty(precio))
            {
                Console.WriteLine("ERROR! El campo " + campo + " no puede ser vacío, intente nuevamente.");
            }

            else if (!double.TryParse(precio, out precioValidado))
            {
                Console.WriteLine("ERROR! El valor ingresado para el campo " + campo + " debe ser de tipo numérico, intente nuevamente.");
            }

            else if (precioValidado <= 0)
            {
                Console.WriteLine("ERROR! El valor ingresado para el campo " + campo + " no debe ser negativo, intente nuevamente.");
            }

            else
            {
                flag = true;
            }

            return flag;
        }

        internal static bool FuncionValidacionOpcionAmenities(ref string opcion, ref bool tieneAmenities)
        {
            //Declaración de variables
            bool flag = false;

            do
            {
                opcion = Console.ReadLine();

                if (string.IsNullOrEmpty(opcion))
                {
                    Console.WriteLine("ERROR! La opción ingresada no puede ser vacío, intente nuevamente.");
                }

                else if (opcion == "1" || opcion == "2")
                {
                    flag = true;

                    if (opcion == "1")
                    {
                        tieneAmenities = true;
                    }
                    else if (opcion == "2")
                    {
                        tieneAmenities = false;
                    }
                }

                else
                {
                    Console.WriteLine("ERROR! La opción " + opcion + " no es una opción válida, intente nuevamente.");
                }

            } while (flag == false);

            return flag;
        }
    }
}
