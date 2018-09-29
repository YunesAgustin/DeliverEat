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
        public void nuevoPedido(Pedido nPedido)
        {
            PagoDAO pagoDAO = new PagoDAO();
            DetallePedidoDAO detallePedidoDAO = new DetallePedidoDAO();
            PedidoDAO pedidoDAO = new PedidoDAO();
            pagoDAO.insertarPago(nPedido.pago);
            detallePedidoDAO.insertDetallePedido(nPedido.detallePedido);
            pedidoDAO.insertarPedido(nPedido);
        }
    }
}
