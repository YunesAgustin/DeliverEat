using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class RegistrarPedido
    {
        public void RegistrarNuevoPedido(Pedido nuevoPedido)
        {
            //Inserta el nuevo pedido junto con su detalle e informacion del pago
            PagoDAO pagoDAO = new PagoDAO();
            DetallePedidoDAO detallePedidoDAO = new DetallePedidoDAO();
            PedidoDAO pedidoDAO = new PedidoDAO();

            pagoDAO.InsertarPago(nuevoPedido.pago);
            detallePedidoDAO.InsertarDetallePedido(nuevoPedido.detallePedido);
            pedidoDAO.InsertarPedido(nuevoPedido);
        }
    }
}
