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
        public void InsertarPago(Pago nuevoPago)
        {
            //inserta un pago en la base de datos
            string query = "";

            if (nuevoPago.idTipoPago == 1)
            {
                //Este es en el caso de que sea pago con efectivo
                query += "INSERT INTO Pagos(total, vuelto, idTipoPago) VALUES(" + nuevoPago.total + ", " + nuevoPago.vuelto + ", " + nuevoPago.idTipoPago + ");";
            }

            if (nuevoPago.idTipoPago == 2)
            {
                //Este es en el caso de que sea pago con tarjeta
                query += "INSERT INTO Pagos(domicilioFacturacion, titularTarjeta, idTipoDocumento, documento, ciudad, idPais, telefono, idTipoPago, total) ";
                query += "VALUES('" + nuevoPago.domicilioFacturacion + "', '" + nuevoPago.titularTarjeta + "', " + nuevoPago.idTipoDocumento + ", " + nuevoPago.documento + ", '";
                query += nuevoPago.ciudad + "', " + nuevoPago.idPais + ", '" + nuevoPago.telefono + "', " + nuevoPago.idTipoPago + ", " + nuevoPago.total + ");";
            }

            BDHelper.Insert(query);
            nuevoPago.idPago = ObtenerIdentity();
        }

        public int ObtenerIdentity()
        {
            //Retorna el ID que se le asigno al pago insertado
            string query = "SELECT MAX(idPago) FROM Pagos;";
            return BDHelper.Select(query);
        }
    }
}
