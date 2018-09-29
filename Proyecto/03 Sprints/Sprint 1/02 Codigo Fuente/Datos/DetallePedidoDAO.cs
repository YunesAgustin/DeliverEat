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
        public void insertDetallePedido(DetallePedido nuevoDetallePedido)
        {
            string inserts = "INSERT INTO DetallesPedido(descripcionProducto, monto";
            string values = "VALUES ('" + nuevoDetallePedido.descripcionProducto + "', " + nuevoDetallePedido.monto;

            //if (!nuevoDetallePedido.imagenProducto.Equals(null))
            //{
            //    inserts += ", imagenProducto";
            //    values += ", " + nuevoDetallePedido.imagenProducto;
            //}
            inserts += ") ";
            values += ");";

            string query = inserts + values;
            BDHelper.insert(query);
            nuevoDetallePedido.idDetallePedido = getIdentity();
        }

        public int getIdentity()
        {
            string query = "SELECT MAX(idDetallePedido) FROM DetallesPedido;";
            return BDHelper.select(query);
        }
    }
}
