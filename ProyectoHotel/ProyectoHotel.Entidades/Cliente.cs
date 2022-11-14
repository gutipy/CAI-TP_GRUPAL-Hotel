using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHotel.Entidades
{
    [DataContract]
    public class Cliente : Persona
    {
        //Constructores
        public Cliente(int dni, string nombre, string apellido, string direccion, long telefono, string mail, DateTime fechaNacimiento, int id, DateTime fechaAlta)
            : base (dni, nombre, apellido, direccion, telefono, mail, fechaNacimiento)
        {
            _id = id;
            _fechaAlta = fechaAlta;
            _activo = true;
        }

        //Atributos
        private int _id;
        private DateTime _fechaAlta;
        private bool _activo;

        //Propiedades

        [DataMember(Name = "id")]
        public int Id { get { return _id; } set { value = _id; } }

        [DataMember(Name = "fechaAlta")]
        public DateTime FechaAlta { get { return _fechaAlta; } set { value = _fechaAlta; } }

        [DataMember(Name = "activo")]
        public bool Activo { get { return _activo; } set { value = _activo; } }

        //Funciones-Métodos
        public override string GetCredencial()
        {
            return "Dni: " + this.Dni + "\n" + "Nombre: " + this.Nombre + "\n" + "Apellido: " + this.Apellido + "\n" + "Fecha de Alta: " + this.FechaAlta +
               "\n" + "Id Cliente: " + this.Id + "\n";
        }
    }
}
