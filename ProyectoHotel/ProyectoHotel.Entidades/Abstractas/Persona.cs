using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHotel.Entidades
{
    [DataContract]
    public abstract class Persona
    {
        //Constructores
        public Persona(int dni, string nombre, string apellido, string direccion, long telefono, string mail, DateTime fechaNacimiento)
        {
            _dni = dni;
            _nombre = nombre;
            _apellido = apellido;
            _direccion = direccion;
            _telefono = telefono;
            _mail = mail;
            _fechaNacimiento = fechaNacimiento;
        }

        //Atributos
        private int _dni;
        private string _nombre;
        private string _apellido;
        private string _direccion;
        private long _telefono;
        private string _mail;
        private DateTime _fechaNacimiento;

        //Propiedades

        [DataMember(Name = "dni")]
        public int Dni { get { return _dni; } set { value = _dni; } }

        [DataMember(Name = "nombre")]
        public string Nombre { get { return _nombre; } set { value = _nombre; } }

        [DataMember(Name = "apellido")]
        public string Apellido { get { return _apellido; } set { value = _apellido; } }

        [DataMember(Name = "direccion")]
        public string Direccion { get { return _direccion; } set { value = _direccion; } }

        [DataMember(Name = "telefono")]
        public long Telefono { get { return _telefono; } set { value = _telefono; } }

        [DataMember(Name = "email")]
        public string Mail { get { return _mail; } set { value = _mail; } }

        [DataMember(Name = "fechaNacimiento")]
        public DateTime FechaNacimiento { get { return _fechaNacimiento; } set { value = _fechaNacimiento; } }

        //Funciones-Métodos
        public virtual string GetCredencial()
        {
            return "Dni: " + this.Dni + "\n" + "Nombre: " + this.Nombre + "\n" + "Apellido: " + this.Apellido +
                "\n" + "Dirección: " + this.Direccion + "\n" + "Teléfono: " + this.Telefono + "\n" + "Mail: " + this.Mail + "\n";
        }
    }
}
