using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHotel.Entidades
{
    public class Hotel
    {
        //Constructores
        public Hotel(int id, string nombre, string direccion, int estrellas, bool amenities)
        {
            _id = id;
            _nombre = nombre;
            _direccion = direccion;
            _estrellas = estrellas;
            _amenities = amenities;
        }

        //Atributos
        private int _id;
        private string _nombre;
        private string _direccion;
        private int _estrellas;
        private bool _amenities;

        //Propiedades
        public int Id { get { return _id; } set { value = _id; } }

        public string Nombre { get { return _nombre; } set { value = _nombre; } }

        public string Direccion { get { return _direccion; } set { value = _direccion; } }

        public int Estrellas { get { return _estrellas; } set { value = _estrellas; } }

        public bool Amenities { get { return _amenities; } set { value = _amenities; } }

        //Funciones-Métodos
        public string GetCredencial()
        {
            return "ID (Hotel): " + this.Id + "\n" + "Nombre: " + this.Nombre + "\n" + "Dirección: " + this.Direccion +
                "\n" + "Estrellas: " + this.Estrellas + "\n" + "Amenities: " + (this._amenities ? "SÍ" : "NO") + "\n";
        }
    }
}
