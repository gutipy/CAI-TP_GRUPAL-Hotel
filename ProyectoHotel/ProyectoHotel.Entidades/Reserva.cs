using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHotel.Entidades
{
    public class Reserva
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

        public int Id { get { return _id; } }

        public int IdCliente { get { return _idCliente; } }

        public int IdHabitacion { get { return _idHabitacion; } }

        public int CantidadHuespedes { get { return _cantidadHuespedes; } }

        public DateTime FechaIngreso { get { return _fechaIngreso; } }

        public DateTime FechaEgreso { get { return _fechaEgreso; } }

        public override string ToString()
        {
            return "ID de la reserva: " + this._id + "\n" + "ID del cliente: " + this._idCliente + "\n" + "ID de la habitación: " + this._idHabitacion +
                "\n" + "Cantidad de huéspedes: " + this._cantidadHuespedes + "\n" + "Fecha de ingreso: " + this._fechaIngreso + "\n" + "Fecha de egreso: "
                + this._fechaEgreso + "\n";
        }
    }
}
