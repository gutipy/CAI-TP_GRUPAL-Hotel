using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHotel.Entidades
{
    public class Hotel
    {
        public Hotel(int id, string nombre, string direccion, int estrellas, bool amenities)
        {
            _id = id;
            _nombre = nombre;
            _direccion = direccion;
            _estrellas = estrellas;
            _amenities = amenities;
        }

        private int _id;
        private string _nombre;
        private string _direccion;
        private int _estrellas;
        private bool _amenities;

        public int Id { get { return _id; } }

        public string Nombre { get { return _nombre; } }

        public string Direccion { get { return _direccion; } }

        public int Estrellas { get { return _estrellas; } }

        public bool Amenities { get { return _amenities; } }

        public override string ToString()
        {
            return "ID: " + this._id + "\n" + "Nombre: " + this._nombre + "\n" + "Dirección: " + this._direccion +
                "\n" + "Estrellas: " + this._estrellas + "\n" + "Amenities: " + this._amenities + "\n";
        }
    }
}
