using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHotel.Entidades
{
    public abstract class Persona
    {
        public Persona(int Id, string Nombre, string Apellido, string Direccion, long Telefono, string Mail)
        {
            _id = Id;
            _nombre = Nombre;
            _apellido = Apellido;
            _direccion = Direccion;
            _telefono = Telefono;
            _mail = Mail;
        }

        private int _id;
        private string _nombre;
        private string _apellido;
        private string _direccion;
        private long _telefono;
        private string _mail;

        public int Id { get { return _id; } set { value = _id; } }
        public string Nombre { get { return _nombre; } set { value = _nombre; } }
        public string Apellido { get { return _apellido; } set { value = _apellido; } }
        public string Direccion { get { return _direccion; } set { value = _direccion; } }
        public long Telefono { get { return _telefono; } set { value = _telefono; } }
        public string Mail { get { return _mail; } set { value = _mail; } }

        public override string ToString()
        {
            return "ID: " + this._id + "\n" + "Nombre: " + this._nombre + "\n" + "Apellido: " + this._apellido +
                "\n" + "Dirección: " + this._direccion + "\n" + "Teléfono: " + this._telefono + "\n" + "Mail: " + this._mail + "\n";
        }
    }
}
