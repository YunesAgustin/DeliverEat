using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetallePedido
    {
        public int idDetallePedido { get; set; }
        public string descripcionProducto { get; set; }
        public string imagenProducto { get; set; }
        public double monto { get; set; }
    }
}
