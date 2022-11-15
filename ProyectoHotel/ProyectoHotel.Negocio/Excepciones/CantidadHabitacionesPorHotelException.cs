using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHotel.Negocio.Excepciones
{
    public class CantidadHabitacionesPorHotelException : Exception
    {
        public CantidadHabitacionesPorHotelException() : base("ERROR! No se puede agregar otra habitación porqué se llegó al límite de 100 habitaciones para el presente hotel, intente nuevamente.")
        {

        }
    }
}
