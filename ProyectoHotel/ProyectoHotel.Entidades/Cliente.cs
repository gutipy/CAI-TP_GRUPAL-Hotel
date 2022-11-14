using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHotel.Entidades
{
    public class Cliente : Persona
    {
        public Cliente(int Id, DateTime FechaAlta, bool Activo, string Nombre, string Apellido, string Direccion, long Telefono, string Mail)
            : base (Nombre, Apellido, Direccion, Telefono, Mail)
        {
            _id = Id;
            _fechaAlta = FechaAlta;
            _activo = Activo;
        }

        private int _id;
        private DateTime _fechaAlta;
        private bool _activo;

        public int Id { get { return _id; } set { value = _id; } }
        public DateTime FechaAlta { get { return _fechaAlta; } set { value = _fechaAlta; } }
        public bool Activo { get { return _activo; } set { value = _activo; } }

        public override string ToString()
        {
            return "ID: " + this._id + "\n" + "Nombre: " + this.Nombre + "\n" + "Apellido: " + this.Apellido + "\n" + "Fecha de Alta: " + this._fechaAlta +
               "\n" + "Activo?: " + this._activo + "\n" + "Dirección: " + this.Direccion + "\n" + "Teléfono: " + this.Telefono + "\n" + "Mail: " + this.Mail + "\n";
        }
    }
}
