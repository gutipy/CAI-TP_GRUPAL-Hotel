using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHotel.Negocio.Excepciones
{
    public class AmenitiesInvalidasException : Exception
    {
        public AmenitiesInvalidasException() : base("ERROR! Un hotel con 2 o menos estrellas NO puede tener amenities y un hotel con 3 o más estrellas DEBE tener amenities, intente nuevamente.")
        {

        }
    }
}
