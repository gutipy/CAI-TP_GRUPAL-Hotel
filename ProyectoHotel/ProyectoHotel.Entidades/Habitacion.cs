using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHotel.Entidades
{
    public class Habitacion
    {
        public Habitacion(int id, int idHotel, string categoria, int cantidadPlazas, bool cancelacion, double precio)
        {
            _id = id;
            _idHotel = idHotel;
            _categoria = categoria;
            _cantidadPlazas = cantidadPlazas;
            _cancelacion = cancelacion;
            _precio = precio;
        }

        private int _id;
        private int _idHotel;
        private string _categoria;
        private int _cantidadPlazas;
        private bool _cancelacion;
        private double _precio;
    
        public int Id { get { return _id; } }

        public int IdHotel { get { return _idHotel; } }

        public string Categoria { get { return _categoria; } }

        public int CantidadPlazas { get { return _cantidadPlazas; } }

        public bool Cancelacion { get { return _cancelacion; } }

        public double Precio { get { return _precio; } }

        public override string ToString()
        {
            return "ID (Habitación): " + this._id + "\n" + "ID (Hotel): " + this._idHotel + "\n" + "Categoría: " + this._categoria +
                "\n" + "Cantidad de plazas: " + this._cantidadPlazas + "\n" + "Cancelación: " + this._cancelacion + "\n" + "Precio: "
                + this._precio + "\n";
        }
    }
}
