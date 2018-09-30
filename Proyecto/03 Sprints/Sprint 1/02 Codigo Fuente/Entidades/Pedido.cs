using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pedido
    {
        public int idCliente { get; set; }
        public DetallePedido detallePedido { get; set; }
        public Pago pago { get; set; }
        public string calleComercio { get; set; }
        public int nroCalleComercio { get; set; }
        public string calleCliente { get; set; }
        public int nroCalleCliente { get; set; }
        public int pisoCliente { get; set; }
        public string deptoCliente { get; set; }
        public bool loAntesPosible { get; set; }
        public DateTime fechaHoraEntrega { get; set; }
        public double total { get; set; }
    }
}
