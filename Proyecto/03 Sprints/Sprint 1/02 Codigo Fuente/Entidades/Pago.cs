using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pago
    {
        public int idPago { get; set; }
        public int idTipoPago { get; set; }
        public string titularTarjeta { get; set; }
        public int idTipoDocumento { get; set; }
        public int documento { get; set; }
        public string domicilioFacturacion { get; set; }
        public string ciudad { get; set; }
        public int idPais { get; set; }
        public string telefono { get; set; }
        //era int
        public double total { get; set; }
        //era int
        public double vuelto { get; set; }
        public double pagoCon { get; set; }
    }
}
