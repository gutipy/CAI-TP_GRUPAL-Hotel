using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ProyectoHotel.Entidades
{
    [DataContract]
    public class Reserva
    {
        //Constructores
        public Reserva(int id, int idCliente, int idHabitacion, int cantidadHuespedes, DateTime fechaIngreso, DateTime fechaEgreso)
        {
            _id = id;
            _idCliente = idCliente;
            _idHabitacion = idHabitacion;
            _cantidadHuespedes = cantidadHuespedes;
            _fechaIngreso = fechaIngreso;
            _fechaEgreso = fechaEgreso;
        }

        //Atributos
        private int _id;
        private int _idCliente;
        private int _idHabitacion;
        private int _cantidadHuespedes;
        private DateTime _fechaIngreso;
        private DateTime _fechaEgreso;

        //Propiedades

        [DataMember(Name = "id")]
        public int Id { get { return _id; } set { value = _id; } }

        [DataMember(Name = "idCliente")]
        public int IdCliente { get { return _idCliente; } set { value = _idCliente; } }

        [DataMember(Name = "idHabitacion")]
        public int IdHabitacion { get { return _idHabitacion; } set { value = _idHabitacion; } }
        
        [DataMember(Name = "cantidadHuespedes")]
        public int CantidadHuespedes { get { return _cantidadHuespedes; } set { value = _cantidadHuespedes; } }

        [DataMember(Name = "fechaIngreso")]
        public DateTime FechaIngreso { get { return _fechaIngreso; } set { value = _fechaIngreso; } }

        [DataMember(Name = "fechaEgreso")]
        public DateTime FechaEgreso { get { return _fechaEgreso; } set { value = _fechaEgreso; } }

        //Funciones-Métodos
        public string GetCredencial()
        {
            return "ID de la reserva: " + this.Id + "\n" + "ID del cliente: " + this.IdCliente + "\n" + "ID de la habitación: " + this.IdHabitacion +
                "\n" + "Cantidad de huéspedes: " + this.CantidadHuespedes + "\n" + "Fecha de ingreso: " + this.FechaIngreso + "\n" + "Fecha de egreso: "
                + this.FechaEgreso + "\n";
        }
    }
}
