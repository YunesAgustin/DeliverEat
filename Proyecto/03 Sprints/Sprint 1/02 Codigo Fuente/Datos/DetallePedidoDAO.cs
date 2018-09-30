using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    class DetallePedidoDAO
    {
        public void InsertarDetallePedido(DetallePedido nuevoDetallePedido)
        {
            //Inserta un detalle de pedido en la base de datos
            string inserts = "INSERT INTO DetallesPedido(descripcionProducto, monto) ";
            string values = "VALUES ('" + nuevoDetallePedido.descripcionProducto + "', " + nuevoDetallePedido.monto + ");";
            string query = inserts + values;

            BDHelper.Insert(query);
            nuevoDetallePedido.idDetallePedido = ObtenerIdentity();
        }

        public int ObtenerIdentity()
        {
            //Retorna el ID que se le asigno al detalle de pedido insertado
            string query = "SELECT MAX(idDetallePedido) FROM DetallesPedido;";
            return BDHelper.Select(query);
        }
    }
}
