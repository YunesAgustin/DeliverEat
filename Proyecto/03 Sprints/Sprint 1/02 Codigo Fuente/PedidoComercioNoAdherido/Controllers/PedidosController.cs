using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entidades;
using Datos;

namespace PedidoComercioNoAdherido
{
    public class PedidosController : ApiController
    {
        // GET api/pedidos
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/pedidos/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/pedidos
        public void Post(Pedido pedido)
        {
            RegistrarPedido registrarPedido = new RegistrarPedido();
            registrarPedido.nuevoPedido(pedido);
        }

        // PUT api/pedidos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/pedidos/5
        public void Delete(int id)
        {
        }
    }
}
