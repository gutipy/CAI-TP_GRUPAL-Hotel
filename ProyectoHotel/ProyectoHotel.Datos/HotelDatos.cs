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
    public class HotelDatos
    {
        public List<Hotel> TraerTodos()
        {
            string json2 = WebHelper.Get("Hotel/Hoteles"); // trae un texto en formato json de una web
            List<Hotel> resultado = MapList(json2);
            return resultado;
        }

        public List<Hotel> Traer(int usuario)
        {
            string json2 = WebHelper.Get("Hotel/Hoteles/" + usuario.ToString()); // trae un texto en formato json de una web
            List<Hotel> resultado = MapList(json2);
            return resultado;
        }

        private List<Hotel> MapList(string json)
        {
            List<Hotel> lst = JsonConvert.DeserializeObject<List<Hotel>>(json); // deserializacion
            return lst;
        }

        private Hotel MapObj(string json)
        {
            Hotel lst = JsonConvert.DeserializeObject<Hotel>(json); // deserializacion
            return lst;
        }

        public TransactionResult Insertar(Hotel hotel)
        {
            NameValueCollection obj = ReverseMap(hotel); //serializacion -> json

            string json = WebHelper.Post("Hotel/Hoteles", obj);

            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);

            return lst;
        }

        public TransactionResult Actualizar(Hotel hotel)
        {
            NameValueCollection obj = ReverseMap(hotel);

            string json = WebHelper.Put("Hotel/Hoteles", obj);

            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);

            return lst;
        }
        private NameValueCollection ReverseMap(Hotel hotel)
        {
            NameValueCollection n = new NameValueCollection();

            n.Add("Estrellas", hotel.Estrellas.ToString());
            n.Add("Nombre", hotel.Nombre);
            n.Add("Direccion", hotel.Direccion);
            n.Add("Amenities", hotel.Amenities.ToString());
            n.Add("Usuario", "888086");
            n.Add("id", hotel.Id.ToString());

            return n;
        }
    }
}
