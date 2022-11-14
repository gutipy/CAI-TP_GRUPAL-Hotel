using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHotel.Negocio.Excepciones
{
    public class ClienteExistenteException : Exception
    {
        public ClienteExistenteException(string objeto, int dni) : base("El " + objeto + " con DNI: " + dni + " ya existe, por favor intente nuevamente.")
        {

        }
    }
}
