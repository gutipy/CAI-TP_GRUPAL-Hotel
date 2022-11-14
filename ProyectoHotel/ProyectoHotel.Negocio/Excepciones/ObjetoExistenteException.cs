using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHotel.Negocio.Excepciones
{
    public class ObjetoExistenteException : Exception
    {
        public ObjetoExistenteException(string objeto, int id) : base("El " + objeto + " con ID: " + id + " ya existe, por favor intente nuevamente.")
        {

        }
    }
}
