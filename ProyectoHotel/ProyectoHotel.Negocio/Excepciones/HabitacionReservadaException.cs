using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHotel.Negocio.Excepciones
{
    public class HabitacionReservadaException : Exception
    {
        public HabitacionReservadaException(int idHabitacion, DateTime fechaIngreso, DateTime fechaEgreso) : base("La habitación con ID " + idHabitacion + " se encuentra reservada entre la fecha " + fechaIngreso + " y " + fechaEgreso)
        {

        }
    }
}
