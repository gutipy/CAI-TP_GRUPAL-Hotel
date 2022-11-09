using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHotel.PresentacionConsola
{
    internal static class MenuHelper
    {
        internal static void OpcionesMenuPrincipal()
        {
            Console.WriteLine(
                "Bienvenido al programa de gestión de Rich Texan Hotel! Seleccione una opción:" + Environment.NewLine +

                "1 - Listar clientes" + Environment.NewLine +
                "2 - Agregar clientes" + Environment.NewLine +
                "3 - Listar reservas" + Environment.NewLine +
                "4 - Agregar reservas" + Environment.NewLine +
                "5 - Listar hoteles" + Environment.NewLine +
                "6 - Agregar hoteles" + Environment.NewLine +
                "7 - Listar habitaciones" + Environment.NewLine +
                "8 - Agregar habitaciones" + Environment.NewLine +
                "9 - Traer reservas por cliente" + Environment.NewLine +
                "10 - Traer habitaciones por hotel" + Environment.NewLine +
                "11 - Salir" + Environment.NewLine
                )
                ;
        }

        internal static void OpcionesCategoriaHabitacion()
        {
            Console.WriteLine(
                Environment.NewLine +
                "1 - Single" + Environment.NewLine +
                "2 - Double" + Environment.NewLine +
                "3 - Quadruple" + Environment.NewLine +
                "4 - Junior Suite" + Environment.NewLine +
                "5 - Suite" + Environment.NewLine +
                "6 - Grand Suite" + Environment.NewLine
                )
                ;
        }
    }
}
