using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoHotel.Entidades;
using Newtonsoft.Json;
using System.Collections.Specialized;
using ProyectoHotel.Datos;
using System.Diagnostics.Contracts;

namespace ProyectoHotel.Datos
{
    public class ClienteDatos
    {
        public List<Cliente> TraerTodos()
        {
            string json2 = WebHelper.Get("cliente"); // trae un texto en formato json de una web
            List<Cliente> resultado = MapList(json2);
            return resultado;
        }

        public List<Cliente> Traer(int usuario)
        {
            string json2 = WebHelper.Get("cliente/" + usuario.ToString()); // trae un texto en formato json de una web
            List<Cliente> resultado = MapList(json2);
            return resultado;
        }
        public Cliente TraerPorTelefono(string telefono)
        {
            string json2 = WebHelper.Get("cliente/" + telefono + "/telefono"); // trae un texto en formato json de una web
            Cliente resultado = MapObj(json2);
            return resultado;
        }


        private List<Cliente> MapList(string json)
        {
            List<Cliente> lst = JsonConvert.DeserializeObject<List<Cliente>>(json); // deserializacion
            return lst;
        }

        private Cliente MapObj(string json)
        {
            Cliente lst = JsonConvert.DeserializeObject<Cliente>(json); // deserializacion
            return lst;
        }

        public TransactionResult Insertar(Cliente cliente)
        {
            NameValueCollection obj = ReverseMap(cliente); //serializacion -> json

            string json = WebHelper.Post("cliente", obj);

            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);

            return lst;
        }

        public TransactionResult Actualizar(Cliente cliente)
        {
            NameValueCollection obj = ReverseMap(cliente);

            string json = WebHelper.Put("cliente", obj);

            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);

            return lst;
        }
        private NameValueCollection ReverseMap(Cliente cliente)
        {
            NameValueCollection n = new NameValueCollection();

            n.Add("dni", cliente.Dni.ToString());
            n.Add("nombre", cliente.Nombre);
            n.Add("apellido", cliente.Apellido);
            n.Add("direccion", cliente.Direccion);
            n.Add("email", cliente.Mail);
            n.Add("telefono", cliente.Telefono.ToString());
            n.Add("FechaNacimiento", cliente.FechaNacimiento.ToShortDateString());
            n.Add("FechaAlta", cliente.FechaAlta.ToShortDateString());
            n.Add("activo", cliente.Activo.ToString());
            n.Add("usuario", "888086");
            n.Add("host", "");
            n.Add("id", cliente.Id.ToString());

            return n;
        }
    }
}
