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
    public class HabitacionDatos
    {
        public List<Habitacion> Traer(int usuario)
        {
            string json2 = WebHelper.Get("Hotel/Habitaciones/" + usuario.ToString()); // trae un texto en formato json de una web
            List<Habitacion> resultado = MapList(json2);
            return resultado;
        }
        public List<Habitacion> TraerPorHotel(string idHotel)
        {
            string json2 = WebHelper.Get("Hotel/Habitaciones/" + idHotel); // trae un texto en formato json de una web
            List<Habitacion> resultado = MapList(json2);
            return resultado;
        }


        private List<Habitacion> MapList(string json)
        {
            List<Habitacion> lst = JsonConvert.DeserializeObject<List<Habitacion>>(json); // deserializacion
            return lst;
        }

        private Habitacion MapObj(string json)
        {
            Habitacion lst = JsonConvert.DeserializeObject<Habitacion>(json); // deserializacion
            return lst;
        }

        public TransactionResult Insertar(Habitacion habitacion)
        {
            NameValueCollection obj = ReverseMap(habitacion); //serializacion -> json

            string json = WebHelper.Post("Hotel/Habitaciones", obj);

            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);

            return lst;
        }

        public TransactionResult Actualizar(Habitacion habitacion)
        {
            NameValueCollection obj = ReverseMap(habitacion);

            string json = WebHelper.Put("Hotel/Habitaciones", obj);

            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);

            return lst;
        }
        private NameValueCollection ReverseMap(Habitacion habitacion)
        {
            NameValueCollection n = new NameValueCollection();

            n.Add("idHotel", habitacion.IdHotel.ToString());
            n.Add("CantidadPlazas", habitacion.CantidadPlazas.ToString());
            n.Add("Categoria", habitacion.Categoria);
            n.Add("Precio", habitacion.Precio.ToString());
            n.Add("Cancelable", habitacion.Cancelacion.ToString());
            n.Add("Usuario", "888086");
            n.Add("id", habitacion.Id.ToString());

            return n;
        }
    }
}
