using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    class PedidoDAO
    {
        public void insertarPedido(Pedido nuevoPedido)
        {
            string inserts = "INSERT INTO Pedidos(idDetallePedido, calleComercio, nroCalleComercio, calleCliente, nroCalleCliente, idPago, idCliente, loAntesPosible";
            string values = "VALUES (" + nuevoPedido.detallePedido.idDetallePedido + ", '" + nuevoPedido.calleComercio + "', " + nuevoPedido.nroCalleComercio + ", '";
            values += nuevoPedido.calleCliente + "', " + nuevoPedido.nroCalleCliente + ", " + nuevoPedido.pago.idPago + ", " + nuevoPedido.idCliente;

            if (nuevoPedido.loAntesPosible)
            {
                values += ", " + Convert.ToString(1);
            }
            else
            {
                values += ", " + Convert.ToString(0);
                //inserts += ", fechaHoraEntrega";
                //values += ", '" + nuevoPedido.fechaHoraEntrega + "'";
            }
            if (nuevoPedido.pisoCliente != null)
            {
                inserts += ", pisoCliente";
                values += ", " + nuevoPedido.pisoCliente;
            }
            if (nuevoPedido.deptoCliente != null)
            {
                inserts += ", deptoCliente";
                values += ", '" + nuevoPedido.deptoCliente + "'";
            }
            inserts += ") ";
            values += ");";

            string query = inserts + values;
            BDHelper.insert(query);
        }
    }
}
