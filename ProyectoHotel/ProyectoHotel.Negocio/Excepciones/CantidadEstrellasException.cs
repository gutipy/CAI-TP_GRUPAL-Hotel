using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHotel.Negocio.Excepciones
{
    public class CantidadEstrellasException : Exception
    {
        public CantidadEstrellasException() : base("ERROR! El número de estrellas de un hotel debe estar entre 1 y 5, intente nuevamente.")
        {

        }
    }
}
