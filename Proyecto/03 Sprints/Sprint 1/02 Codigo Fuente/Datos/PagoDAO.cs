using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    class PagoDAO
    {
        public void insertarPago(Pago nuevoPago)
        {
            string query = "";

            if (nuevoPago.idTipoPago == 1)
            {
                query += "INSERT INTO Pagos(total, vuelto, idTipoPago) VALUES(" + nuevoPago.total + ", " + nuevoPago.vuelto + ", " + nuevoPago.idTipoPago + ");";
            }
            if (nuevoPago.idTipoPago == 2)
            {   
                query += "INSERT INTO Pagos(domicilioFacturacion, titularTarjeta, idTipoDocumento, documento, ciudad, idPais, telefono, idTipoPago, total) ";
                query += "VALUES('" + nuevoPago.domicilioFacturacion + "', '" + nuevoPago.titularTarjeta + "', " + nuevoPago.idTipoDocumento + ", " + nuevoPago.documento + ", '";
                query += nuevoPago.ciudad + "', " + nuevoPago.idPais + ", '" + nuevoPago.telefono + "', " + nuevoPago.idTipoPago + ", " + nuevoPago.total + ");";
            }

            BDHelper.insert(query);
            nuevoPago.idPago = getIdentity();
        }

        public int getIdentity()
        {
            string query = "SELECT MAX(idPago) FROM Pagos;";
            return BDHelper.select(query);
        }
    }
}
