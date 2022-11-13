using Newtonsoft.Json;
using ProyectoHotel.Entidades;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHotel.Datos
{
    public class ReservaDatos
    {
        public List<Reserva> TraerTodos()
        {
            string json2 = WebHelper.Get("Hotel/Reservas"); // trae un texto en formato json de una web
            List<Reserva> resultado = MapList(json2);
            return resultado;
        }

        public List<Reserva> TraerPorRegistro(int usuario)
        {
            string json2 = WebHelper.Get("Hotel/Reservas/" + usuario.ToString()); // trae un texto en formato json de una web
            List<Reserva> resultado = MapList(json2);
            return resultado;
        }

        private List<Reserva> MapList(string json)
        {
            List<Reserva> lst = JsonConvert.DeserializeObject<List<Reserva>>(json); // deserializacion
            return lst;
        }

        private Reserva MapObj(string json)
        {
            Reserva lst = JsonConvert.DeserializeObject<Reserva>(json); // deserializacion
            return lst;
        }

        public TransactionResult Insertar(Reserva reserva)
        {
            NameValueCollection obj = ReverseMap(reserva); //serializacion -> json

            string json = WebHelper.Post("Hotel/Reservas", obj);

            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);

            return lst;
        }

        public TransactionResult Actualizar(Reserva reserva)
        {
            NameValueCollection obj = ReverseMap(reserva);

            string json = WebHelper.Put("Hotel/Reservas", obj);

            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);

            return lst;
        }
        private NameValueCollection ReverseMap(Reserva reserva)
        {
            NameValueCollection n = new NameValueCollection();

            n.Add("idHabitacion", reserva.IdHabitacion.ToString());
            n.Add("idCliente", reserva.IdCliente.ToString());
            n.Add("cantidadHuespedes", reserva.CantidadHuespedes.ToString());
            n.Add("FechaIngreso", reserva.FechaIngreso.ToString());
            n.Add("FechaEgreso", reserva.FechaEgreso.ToString());
            n.Add("usuario", "888086");
            n.Add("id", reserva.Id.ToString());

            return n;
        }
    }
}
