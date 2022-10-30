using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHotel.Entidades
{
    internal class Hotel
    {
        public Hotel(int id, string nombre, string direccion, int estrellas, Reserva amenities)
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
        private Reserva _amenities;

        public int Id
        {
            get { return _id; }
        }

        public string Nombre
        {
            get { return _nombre; }
        }

        public string Direccion
        {
            get { return _direccion; }
        }

        public int Estrellas
        {
            get { return _estrellas; }
        }

        public Reserva Amenities
        {
            get { return _amenities; }
        }
    }
}
