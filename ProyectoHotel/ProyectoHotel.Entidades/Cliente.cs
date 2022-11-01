using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHotel.Entidades
{
    internal class Cliente
    {
        public Cliente(int id, DateTime fechaAlta, bool activo)
        {
            _id = id;
            _fechaAlta = fechaAlta;
            _activo = activo;
        }

        private int _id;
        private DateTime _fechaAlta;
        private bool _activo;

        public int Id { get { return _id; } }

        public DateTime FechaAlta { get { return _fechaAlta; } }

        public bool Activo { get { return _activo; } }
    }
}
