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

                if (string.IsNullOrEmpty(opcion)) //Valido que la opción ingresada no sea vacía
                {
                    Console.WriteLine("ERROR! La opción ingresada no puede ser vacío, intente nuevamente.");
                }

                else if (!int.TryParse(opcion, out int opcionValidada)) //Valido que la opción ingresada sea un número
                {
                    Console.WriteLine("ERROR! La opción ingresada debe ser de tipo numérico, intente nuevamente.");
                }

                else if (opcionValidada >= 1 && opcionValidada <= 11) //Valido que la opción ingresada se encuentre dentro del rango de opciones válidas
                {
                    flag = true;
                }

                else //Valido que cualquier otra cosa que ingrese el usuario que no sea una opción numérica del 1 al 11 sea un error
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

            if (string.IsNullOrEmpty(cadena)) //Valido que la cadena de texto ingresada no sea vacía
            {
                Console.WriteLine("ERROR! El campo " + campo + " no puede ser vacío, intente nuevamente.");
            }
            else if (cadena.Length > 25) //Valido que la cadena de texto ingresada no tenga más de 25 caractéres
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

                if (string.IsNullOrEmpty(opcion)) //Valido que la opción ingresada no sea vacía
                {
                    Console.WriteLine("ERROR! La opción ingresada no puede ser vacío, intente nuevamente.");
                }

                else if (!int.TryParse(opcion, out int opcionValidada)) //Valido que la opción ingresada sea un número
                {
                    Console.WriteLine("ERROR! La opción ingresada debe ser de tipo numérico, intente nuevamente.");
                }

                else if (opcionValidada >= 1 && opcionValidada <= 6) //Valido que la opción ingresada se encuentre dentro del rango de opciones válidas
                {
                    flag = true;
                }

                else //Valido que cualquier otra cosa que ingrese el usuario que no sea una opción numérica del 1 al 6 sea un error
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

            if (string.IsNullOrEmpty(dni)) //Valido que el valor ingresado no sea vacío
            {
                Console.WriteLine("ERROR! El campo " + campo + " no puede ser vacío, intente nuevamente.");
            }
            else if (!int.TryParse(dni, out dniValidado)) //Valido que el valor ingresado sea de tipo numérico
            {
                Console.WriteLine("ERROR! El valor ingresado para el campo " + campo + " debe ser de tipo numérico, intente nuevamente.");
            }

            else if (dniValidado <= 0) //Valido que el valor ingresado no sea negativo o cero
            {
                Console.WriteLine("ERROR! El valor ingresado para el campo " + campo + " no debe ser negativo, intente nuevamente.");
            }

            else if (dniValidado.ToString().Length > 10) //Valido que el valor ingresado no tenga más de 10 dígitos
            {
                Console.WriteLine("ERROR! El valor ingresado para el campo " + campo + " no debe poseer más de 10 dígitos, intente nuevamente.");
            }
            else
            {
                flag = true;
            }

            return flag;
        }

        internal static bool FuncionValidacionFechaNacimiento(string fecha, ref DateTime fechaValidada, string campo)
        {
            //Declaración de variables
            bool flag = false;

            if (string.IsNullOrEmpty(fecha)) //Valido que el valor ingresado no sea vacío
            {
                Console.WriteLine("ERROR! El campo " + campo + " no puede ser vacío, intente nuevamente.");
            }

            else if (!DateTime.TryParse(fecha, out fechaValidada)) //Valido que el valor ingresado sea de tipo fecha (dd/mm/aaaa)
            {
                Console.WriteLine("El campo " + campo + " debe ser de tipo fecha y tener un formato válido del tipo dd/mm/aaaa, intente nuevamente.");
            }

            else if (fechaValidada > DateTime.Now) //Valido que la fecha ingresada no sea superior al día de hoy
            {
                Console.WriteLine("El campo " + campo + " no puede ser superior al día de hoy, intente nuevamente.");
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
            DateTime fechaLimite = DateTime.Now.AddYears(+1); //Establezco una fecha límite para las fechas

            if (string.IsNullOrEmpty(fecha)) //Valido que el valor ingresado no sea vacío
            {
                Console.WriteLine("ERROR! El campo " + campo + " no puede ser vacío, intente nuevamente.");
            }

            else if (!DateTime.TryParse(fecha, out fechaValidada)) //Valido que el valor ingresado sea de tipo fecha (dd/mm/aaaa)
            {
                Console.WriteLine("El campo " + campo + " debe ser de tipo fecha y tener un formato válido del tipo dd/mm/aaaa, intente nuevamente.");
            }

            else if (fechaValidada > fechaLimite) //Valido que la fecha ingresada no supere la fecha límite
            {
                Console.WriteLine("El campo " + campo + " debe ser anterior a la fecha " + fechaLimite + ", intente nuevamente.");
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

            if (string.IsNullOrEmpty(telefono)) //Valido que el valor ingresado no sea vacío
            {
                Console.WriteLine("ERROR! El campo " + campo + " no puede ser vacío, intente nuevamente.");
            }

            else if (!long.TryParse(telefono, out telefonoValidado)) //Valido que el valor ingresado sea de tipo numérico
            {
                Console.WriteLine("El campo " + campo + " debe ser de tipo numérico, intente nuevamente.");
            }

            else if (telefonoValidado.ToString().LongCount() < 8 || telefonoValidado.ToString().LongCount() > 10) //Valido que el número ingresado tenga entre 8 y 10 dígitos
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

            if (trimmedEmail.EndsWith(".")) //Valido si el mail ingresado termina con un punto, en ese caso es inválido y se lo comunico al usuario
            {
                Console.WriteLine("ERROR! El mail ingresado es inválido porqué finaliza con un punto, intente nuevamente.");
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

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        internal static bool FuncionValidacionCodigo(string codigo, ref int codigoValidado, string campo)
        {
            //Declaración de variables
            bool flag = false;

            if (string.IsNullOrEmpty(codigo)) //Valido que el valor ingresado no sea vacío
            {
                Console.WriteLine("ERROR! El campo " + campo + " no puede ser vacío, intente nuevamente.");
            }

            else if (!int.TryParse(codigo, out codigoValidado)) //Valido que el valor ingresado sea de tipo numérico
            {
                Console.WriteLine("ERROR! El valor ingresado para el campo " + campo + " debe ser de tipo numérico, intente nuevamente.");
            }

            else if (codigoValidado <= 0) //Valido que el código ingresado no sea negativo o cero
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

            if (string.IsNullOrEmpty(numero)) //Valido que el valor ingresado no sea vacío
            {
                Console.WriteLine("ERROR! El campo " + campo + " no puede ser vacío, intente nuevamente.");
            }

            else if (!int.TryParse(numero, out numeroValidado)) //Valido que el valor ingresado sea de tipo numérico
            {
                Console.WriteLine("ERROR! El valor ingresado para el campo " + campo + " debe ser de tipo numérico, intente nuevamente.");
            }

            else if (numeroValidado <= 0) //Valido que el número ingresado no sea negativo o cero
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

                if (string.IsNullOrEmpty(opcion)) //Valido que la opción ingresada no sea vacía
                {
                    Console.WriteLine("ERROR! La opción ingresada no puede ser vacío, intente nuevamente.");
                }

                else if (opcion == "1" || opcion == "2") //Valido que la opción ingresada sea una opción válida ("1" o "2")
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

                else //Valido que cualquier otra cosa que no sea una opción válida ("1" o "2") sea un error y avisado al usuario
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

            if (string.IsNullOrEmpty(precio)) //Valido que el valor ingresado no sea vacío
            {
                Console.WriteLine("ERROR! El campo " + campo + " no puede ser vacío, intente nuevamente.");
            }

            else if (!double.TryParse(precio, out precioValidado)) //Valido que el valor ingresado sea de tipo numérico
            {
                Console.WriteLine("ERROR! El valor ingresado para el campo " + campo + " debe ser de tipo numérico, intente nuevamente.");
            }

            else if (precioValidado <= 0) //Valido que el precio ingresado no sea negativo o cero
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

                if (string.IsNullOrEmpty(opcion)) //Valido que la opción ingresada no sea vacía
                {
                    Console.WriteLine("ERROR! La opción ingresada no puede ser vacío, intente nuevamente.");
                }

                else if (opcion == "1" || opcion == "2") //Valido que la opción ingresada sea una opción válida ("1" o "2")
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

                else //Valido que cualquier otra cosa que no sea una opción válida ("1" o "2") sea un error y avisado al usuario
                {
                    Console.WriteLine("ERROR! La opción " + opcion + " no es una opción válida, intente nuevamente.");
                }

            } while (flag == false);

            return flag;
        }
    }
}
