using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHotel.Negocio.Excepciones
{
    public class HabitacionSinEspacioException : Exception
    {
        public HabitacionSinEspacioException(int cantidadHuespedes) : base("La habitación seleccionada posee espacio para " + cantidadHuespedes + " huespedes o menos, intente seleccionando otra habitación.")
        {

        }
    }
}
