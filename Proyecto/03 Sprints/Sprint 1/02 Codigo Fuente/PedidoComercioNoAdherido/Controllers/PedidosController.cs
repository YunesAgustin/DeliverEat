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
        public void Post(Pedido pedido)
        {
            //POST api/pedidos
            RegistrarPedido registrarPedido = new RegistrarPedido();
            registrarPedido.RegistrarNuevoPedido(pedido);
        }
    }
}
