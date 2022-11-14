using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHotel.Entidades
{
    [DataContract]
    public class Habitacion
    {
        //Constructores
        public Habitacion(int id, int idHotel, string categoria, int cantidadPlazas, bool cancelacion, double precio)
        {
            _id = id;
            _idHotel = idHotel;
            _categoria = categoria;
            _cantidadPlazas = cantidadPlazas;
            _cancelacion = cancelacion;
            _precio = precio;
        }

        //Atributos
        private int _id;
        private int _idHotel;
        private string _categoria;
        private int _cantidadPlazas; //Número de personas que pueden pernoctar (pasar la noche) en las camas instaladas permanentemente de esa habitación
        private bool _cancelacion;
        private double _precio;

        //Propiedades

        [DataMember(Name = "id")]
        public int Id { get { return _id; } set { value = _id; } }

        [DataMember(Name = "idHotel")]
        public int IdHotel { get { return _idHotel; } set { value = _idHotel; } }

        public string Categoria { get { return _categoria; } set { value = _categoria; } }

        public int CantidadPlazas { get { return _cantidadPlazas; } set { value = _cantidadPlazas; } }

        public bool Cancelacion { get { return _cancelacion; } set { value = _cancelacion; } }

        public double Precio { get { return _precio; } set { value = _precio; } }

        //Funciones-Métodos
        public string GetCredencial()
        {
            return "ID (Habitación): " + this.Id + "\n" + "ID (Hotel): " + this.IdHotel + "\n" + "Categoría: " + this.Categoria +
                "\n" + "Cantidad de plazas: " + this.CantidadPlazas + "\n" + "Cancelación: " + (this.Cancelacion ? "SÍ" : "NO") + "\n" + "Precio: "
                + this._precio + "\n";
        }
    }
}
