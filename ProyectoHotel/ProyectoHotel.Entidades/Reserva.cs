using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHotel.Entidades
{
    internal class Reserva
    {
        public Reserva(int id, int idCliente, int idHabitacion, int cantidadHuespedes, DateTime fechaIngreso, DateTime fechaEgreso)
        {
            _id = id;
            _idCliente = idCliente;
            _idHabitacion = idHabitacion;
            _cantidadHuespedes = cantidadHuespedes;
            _fechaIngreso = fechaIngreso;
            _fechaEgreso = fechaEgreso;
        }

        private int _id;
        private int _idCliente;
        private int _idHabitacion;
        private int _cantidadHuespedes;
        private DateTime _fechaIngreso;
        private DateTime _fechaEgreso;


    }
}
